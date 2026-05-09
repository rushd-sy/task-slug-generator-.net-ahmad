using System.Text.RegularExpressions;

namespace SlugGenerator
{

    public static class SlugGeneratorExtensions
    {
        public static string ToSlug(this string text , char separator = '-')
        {
           return SlugGenerator.Generate(text , separator);
        }
        public static string ToSlugUnique(this string text, char separator = '-')
        {
            return SlugGenerator.GenerateUnique(text , separator);
        }

    }
}
