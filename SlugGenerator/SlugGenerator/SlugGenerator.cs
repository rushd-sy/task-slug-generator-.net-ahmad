using System.Text.RegularExpressions;

namespace SlugGenerator
{

    public static class SlugGenerator
    {
        public static string Generate(string text, char separator = '-')
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(text);
            text = Regex.Replace(text, @"[^\p{L}\d\s_-]", "").ToLowerInvariant().Trim();
            ArgumentException.ThrowIfNullOrEmpty(text);
            text = Regex.Replace(text, @"[\s_-]+", separator.ToString());

            return text;
        }
        public static string GenerateUnique(string text , char separator = '-')
        {
            var slug = Generate(text, separator);      
            return slug + separator + Guid.NewGuid().ToString("N");
        }
    }
}
