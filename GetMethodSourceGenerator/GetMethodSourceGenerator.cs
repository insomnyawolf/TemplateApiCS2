using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using SourceGeneratorsKit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GetMethodSourceGenerator
{
    /// <summary>
    /// https://github.com/kant2002/SourceGeneratorsKit/blob/main/SourceGeneratorsKit/DerivedClassesReceiver.cs
    /// </summary>
    public class DerivedClassesReceiver : SyntaxReceiver
    {
        private string baseTypeName;
        public DerivedClassesReceiver(string baseTypeName) => this.baseTypeName = baseTypeName;

        public override bool CollectClassSymbol { get; } = true;

        protected override bool ShouldCollectClassSymbol(INamedTypeSymbol classSymbol)
            => classSymbol.IsDerivedFromType(this.baseTypeName);
    }

    [Generator]
    public class GetMethodSourceGenerator : ISourceGenerator
    {
        public const string TypeName = "CrudController";

        private static readonly string[] RangeSufix =
        {
            "Min",
            "Max",
        };

        private static readonly string[] RangeTypes =
        {
            "sbyte",
            "sbyte?",
            "byte",
            "byte?",
            "uint",
            "uint?",
            "int",
            "int?",
            "ulong",
            "ulong?",
            "long",
            "long?",
            "float",
            "float?",
            "double",
            "double?",
            "decimal",
            "decimal?",
            "DateTime",
            "DateTime?",
        };

        private static readonly string[] OtherFilterTypes =
        {
            "string",
            "string?",
            "bool",
            "bool?",
        };

        private static readonly string[] ContainsTypes =
        {
            "string",
        };

        private static readonly string[] ExactTypes =
        {
            "bool",
        };


        SyntaxReceiver syntaxReceiver = new DerivedClassesReceiver(TypeName);

        public void Initialize(GeneratorInitializationContext context)
        {
#if DEBUG
            if (!Debugger.IsAttached)
            {
                Debugger.Launch();
            }
#endif 
            Debug.WriteLine("Initalize code generator");

            context.RegisterForSyntaxNotifications(() => syntaxReceiver);
        }

        public void Execute(GeneratorExecutionContext context)
        {
            // Retrieve the populated receiver
            if (!(context.SyntaxContextReceiver is SyntaxReceiver receiver))
            {
                return;
            }

            foreach (INamedTypeSymbol classSymbol in this.syntaxReceiver.Classes)
            {
                var baseType = classSymbol.BaseType;

                while (true)
                {
                    if (baseType.Name == TypeName)
                    {
                        break;
                    }

                    baseType = baseType.BaseType;
                }

                var baseTypeForCustomQueryObject = baseType.TypeArguments[1];
                // process your class here.
                //classSymbol.ContainingNamespace.ContainingType
                var members = baseTypeForCustomQueryObject.GetMembers();

                var getStringBuilder = new StringBuilder();

                var dtoStringBuilder = new StringBuilder();

                foreach (var member in members)
                {
                    if (member is IPropertySymbol property)
                    {
                        var type = property.Type.ToString();

                        if (!type.EndsWith("?"))
                        {
                            type += "?";
                        }

                        if (ExactTypes.Contains(type))
                        {
                            dtoStringBuilder.Append($"public {type} {property.Name} {{ get; set; }}\n");

                            getStringBuilder.Append($@"
if (item.{property.Name} is not null)
{{
    dbSet = dbSet.Where(dbItem => dbItem.{property.Name} == item.{property.Name});
}}
");
                        }
                        if (ContainsTypes.Contains(type))
                        {
                            dtoStringBuilder.Append($"public {type} {property.Name} {{ get; set; }}\n");
                            getStringBuilder.Append($@"
if (item.{property.Name} is not null)
{{
    dbSet = dbSet.Where(dbItem => dbItem.{property.Name}.Contains(item.{property.Name}));
}}
");
                        }
                        else if (RangeTypes.Contains(type))
                        {
                            foreach (var suffix in RangeSufix)
                            {
                                var filterName = property.Name + suffix;

                                dtoStringBuilder.Append($"public {type} {filterName} {{ get; set; }}\n");

                                var check = suffix == RangeSufix[0] ? ">=" : "<=";

                                getStringBuilder.Append($@"
if (item.{filterName} is not null)
{{
    dbSet = dbSet.Where(dbItem => dbItem.{property.Name} {check} item.{filterName});
}}
");
                            }
                        }
                        else
                        {

                        }
                    }
                }

                var filterClassName = baseTypeForCustomQueryObject.Name + "Filter";

                var dtoSource = AddElement("public class", filterClassName, dtoStringBuilder.ToString());

                var sourceRaw = dtoSource + GenerateGetMethod(getStringBuilder.ToString(), filterClassName, baseTypeForCustomQueryObject.Name);
                                    
                var usings = $"using {baseTypeForCustomQueryObject.ContainingNamespace};\n";

                usings += "using Microsoft.AspNetCore.Mvc;\n";

                var sourceBp = usings + NamespaceBoilerplate(classSymbol, sourceRaw);

                context.AddSource($"{classSymbol.ContainingNamespace}.{classSymbol.Name}.generated.cs", sourceBp);
            }
        }

        public string GenerateGetMethod(string content, string filterType, string returnType)
        {
            return $@"
[HttpGet]
public IEnumerable<{returnType}> Get([FromQuery] {filterType} item)
{{
    IQueryable<{returnType}> dbSet = DatabaseContext.Set<{returnType}> ();
    {content}
    return dbSet;
}}
";
        }

        public string NamespaceBoilerplate(ISymbol symbol, string content)
        {
            while (symbol.Name != "")
            {
                string what;
                switch (symbol.Kind)
                {
                    case SymbolKind.NamedType:
                        what = "partial class";
                        break;
                    case SymbolKind.Namespace:
                        what = "namespace";
                        break;
                    default:
                        throw new NotImplementedException(symbol.Kind.ToString());
                }

                content = AddElement(what, symbol.Name, content);
                symbol = symbol.ContainingSymbol;
            }

            return content;

        }

        public string AddElement(string type, string name, string content)
        {
            return $@"{type} {name}
{{
{content}
}}";
        }
    }
}
