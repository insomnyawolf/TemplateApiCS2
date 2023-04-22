using Microsoft.CodeAnalysis;

namespace CustomSourceGenerator
{
    public static class Extensions
    {
        public static bool HasToken(this SyntaxTokenList tokenList, string tokenValue) 
        {
            for (int i = 0; i < tokenList.Count; i++)
            {
                var item = tokenList[i];
                
                if(item.Text == tokenValue)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
