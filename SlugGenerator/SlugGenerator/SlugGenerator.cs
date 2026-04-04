using System.Text.RegularExpressions;

namespace SlugGenerator
{
    public static class Genrate
    {
        public static string Generate(string text)
        {
            text = Regex.Replace(text, @"[^\p{L}\d\s-_]", "").ToLower().Trim();
            text = Regex.Replace(text, @"[\s_-]+", "-");
          
            return text;
        }

    }
}
