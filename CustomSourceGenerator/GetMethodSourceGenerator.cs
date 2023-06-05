using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;
using System.Text;

namespace CustomSourceGenerator
{
    public class SymbolData
    {
        public ClassDeclarationSyntax ClassDeclarationSyntax { get; set; }
        public ITypeSymbol ITypeSymbol { get; set; }
    }
    /// <summary>
    /// https://github.com/dotnet/roslyn/blob/main/docs/features/incremental-generators.md
    /// https://github.com/kant2002/SourceGeneratorsKit/blob/main/SourceGeneratorsKit/DerivedClassesReceiver.cs
    /// </summary>
    [Generator(LanguageNames.CSharp)]
    public class GetMethodSourceGenerator : IIncrementalGenerator
    {
        public const string GeneratorName = "GetMethodSourceGenerator";

        private static readonly Dictionary<string, string> RangeComparations = new Dictionary<string, string>()
        {
            //{ "Min", ">" },
            { "MinEqual", ">=" },
            //{ "Max", "<" },
            { "MaxEqual", "<=" },
            //{ "Exact", "==" },
        };

        private static readonly string[] RangeTypes =
        {
            "sbyte?",
            "byte?",
            "uint?",
            "int?",
            "ulong?",
            "long?",
            "float?",
            "double?",
            "decimal?",
            "DateTime?",
        };

        private static readonly string[] ContainsTypes =
        {
            "string?",
        };

        private static readonly string[] ExactTypes =
        {
            "bool?",
        };

        public void Initialize(IncrementalGeneratorInitializationContext initContext)
        {
            //if (!Debugger.IsAttached)
            //{
            //    Debugger.Launch();
            //}

            initContext.RegisterPostInitializationOutput(PostInitializationCallback);

            // Do a simple filter
            var classDeclarations = initContext.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: IsTargetForGenerator,
                    transform: Transform);

            // Generate the source
            initContext.RegisterSourceOutput(classDeclarations, Execute);
        }

        public static bool IsTargetForGenerator(SyntaxNode SyntaxNode, CancellationToken cancellationToken)
        {
            // true if it's what we are looking for, in that case all clases in the specified namespace
            if (SyntaxNode is not ClassDeclarationSyntax classNode)
            {
                return false;
            }

            if (classNode.BaseList is null)
            {
                return false;
            }

            if (!classNode.Modifiers.HasToken("partial"))
            {
                return false;
            }

            if (classNode.Modifiers.HasToken("abstract"))
            {
                return false;
            }

            var baseTypes = classNode.BaseList.Types;

            // Maybe remove?
            if (baseTypes.Count < 1)
            {
                return false;
            }

            for (int i = 0; i < baseTypes.Count; i++)
            {
                var bt = baseTypes[i];

                if (bt.Type is GenericNameSyntax generic)
                {
                    if (generic.TypeArgumentList.Arguments.Count == 2)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static SymbolData Transform(GeneratorSyntaxContext context, CancellationToken cancellationToken)
        {
            var ITypeSymbol = context.SemanticModel.GetDeclaredSymbol(context.Node, cancellationToken) as ITypeSymbol;

            return new SymbolData()
            {
                ClassDeclarationSyntax = (ClassDeclarationSyntax)context.Node,
                ITypeSymbol = ITypeSymbol,
            };
        }

        public static void Execute(SourceProductionContext context, SymbolData symbolData)
        {
            var temp = symbolData.ITypeSymbol;

            while (temp != null)
            {
                if (temp.Name == "ReadController")
                {
                    break;
                }

                temp = temp.BaseType;
            }

            if (temp is not INamedTypeSymbol namedTypeSymbol)
            {
                // Not what we are loking for, skip
                return;
            }

            // Here is what wee were looking for
            var controllerNamespace = symbolData.ITypeSymbol.ContainingNamespace;

            var controllerName = symbolData.ITypeSymbol.Name;

            var modelType = namedTypeSymbol.TypeArguments[1];

            var modelNamespace = modelType.ContainingNamespace;

            var getStringBuilder = new StringBuilder();

            var dtoStringBuilder = new StringBuilder();

            var members = modelType.GetMembers();

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
                        dtoStringBuilder.Append($"\t\tpublic {type} {property.Name} {{ get; set; }}\n");

                        getStringBuilder.Append($@"
        if (item.{property.Name} is not null)
        {{
            dbSet = dbSet.Where(dbItem => dbItem.{property.Name} == item.{property.Name});
        }}
");
                    }
                    if (ContainsTypes.Contains(type))
                    {
                        dtoStringBuilder.Append($"\t\tpublic {type} {property.Name} {{ get; set; }}\n");
                        getStringBuilder.Append($@"
        if (item.{property.Name} is not null)
        {{
            dbSet = dbSet.Where(dbItem => dbItem.{property.Name}.Contains(item.{property.Name}));
        }}
");
                    }
                    else if (RangeTypes.Contains(type))
                    {
                        foreach (var comparation in RangeComparations)
                        {
                            var filterName = property.Name + comparation.Key;

                            dtoStringBuilder.Append($"\t\tpublic {type} {filterName} {{ get; set; }}\n");

                            getStringBuilder.Append($@"
        if (item.{filterName} is not null)
        {{
            dbSet = dbSet.Where(dbItem => dbItem.{property.Name} {comparation.Value} item.{filterName});
        }}
");
                        }
                    }
                }
            }

            var dtoName = $"{modelType.Name}Query";

            var source = $@"// <auto-generated />
namespace {controllerNamespace};
using Microsoft.AspNetCore.Mvc;
using {modelNamespace};
public partial class {controllerName}
{{
    [HttpGet]
    public virtual IEnumerable<{modelType.Name}> Get([FromQuery] {dtoName} item)
    {{
        IQueryable<{modelType.Name}> dbSet = DatabaseContext.Set<{modelType.Name}> ();
        {getStringBuilder}
        return dbSet;
    }}

    public partial class {dtoName}
    {{
{dtoStringBuilder}
    }}
}}
";
            context.AddSource($"{controllerNamespace}{controllerName}{GeneratorName}.g.cs", source);
        }

        public static void PostInitializationCallback(IncrementalGeneratorPostInitializationContext context)
        {
            // Unconditionally generated files
            context.AddSource("SampleText.g.cs", "// <auto-generated />");
        }
    }
}