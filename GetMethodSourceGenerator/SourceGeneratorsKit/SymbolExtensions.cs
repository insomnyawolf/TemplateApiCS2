namespace SourceGeneratorsKit
{
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Text;

    public static class SymbolExtensions
    {
        public static bool HasAttribute(this ISymbol symbol, string atrributeName)
        {
            return symbol.GetAttributes()
                .Any(_ => _.AttributeClass?.ToDisplayString() == atrributeName);
        }

        public static AttributeData FindAttribute(this ISymbol symbol, string atrributeName)
        {
            return symbol.GetAttributes()
                .FirstOrDefault(_ => _.AttributeClass?.ToDisplayString() == atrributeName);
        }

        public static bool IsDerivedFromType(this INamedTypeSymbol symbol, string typeName)
        {
            if (symbol.BaseType is null)
            {
                return false;
            }

            var type = symbol.BaseType;

            while (true)
            {
                if (type.Name == typeName)
                {
                    return true;
                }

                if (type.BaseType != null)
                {
                    type = type.BaseType;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsImplements(this INamedTypeSymbol symbol, string typeName)
        {
            return symbol.AllInterfaces.Any(_ => _.ToDisplayString() == typeName);
        }
    }
}
