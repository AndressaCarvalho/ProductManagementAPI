using System.Text.RegularExpressions;

namespace ProductManagement.Application.Helpers
{
    public static class ProviderHelper
    {
        public static string RemoveCnpjMask(string cnpj)
        {
            return Regex.Replace(cnpj.Trim(), "[^0-9]", "");
        }
    }
}