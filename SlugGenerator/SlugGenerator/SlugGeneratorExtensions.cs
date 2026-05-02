using System.Text.RegularExpressions;

namespace SlugGenerator
{

    public static class SlugGeneratorExtensions
    {
        public static string ToSlug(this string text , char separator = '-')
        {
            if(text is null)
              throw new ArgumentNullException("Text");

            if(text.Length == 0)
                throw new ArgumentException("text is empty");
       
            text = Regex.Replace(text, @"[^\p{L}\d\s-_]", "").ToLower().Trim();

            if (text.Length == 0)
                throw new ArgumentException("text contain only symbols");

            text = Regex.Replace(text, @"[\s_-]+", separator.ToString());

            return text;
        }
        public static string ToSlugUnique(this string text, char separator = '-')
        {
            text = text.ToSlug(separator);      
            return text + separator + Guid.NewGuid().ToString();
        }

    }
}
