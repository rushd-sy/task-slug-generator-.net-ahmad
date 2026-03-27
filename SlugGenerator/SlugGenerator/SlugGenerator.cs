using System.Text.RegularExpressions;

namespace SlugGenerator
{
    public static class SlugGenerator
    {
        public static string Generate(string text)
        {
            if(text is null)
              throw new ArgumentNullException("Text");

            if(text.Length == 0)
                throw new ArgumentException("text is empty");
       
            text = Regex.Replace(text, @"[^\p{L}\d\s-_]", "").ToLower().Trim();

            if (text.Length == 0)
                throw new ArgumentException("text contain only symbols");

            text = Regex.Replace(text, @"[\s_-]+", "-");

            return text;
        }      
    }
}
