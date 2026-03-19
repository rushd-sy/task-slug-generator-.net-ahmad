using System.Text.RegularExpressions;

namespace SlugGenerator
{
    public class Class1
    {

    }
    public static class Genrate
    {
        public static string Generate(string text)
        {

            text = text.ToLower();
            text = text.Trim();


            text = Regex.Replace(text, @"[^\p{L}\d\s-_]", "");
            text = Regex.Replace(text, @"\s+", "-");
            text = Regex.Replace(text, @"_+", "-");
            text = Regex.Replace(text, @"-+", "-");

            return text;
        }

    }
}
