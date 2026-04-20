using BenchmarkDotNet.Attributes;
using System.Text;
using System.Text.RegularExpressions;

namespace Benchmark
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        private string input = "Example text with numbers 123 and symbols !!!";


        [Benchmark]
        public string Generate()
        {   
            StringBuilder text = new StringBuilder(input.Length);        
            
            foreach (var c in input)
            {
                if (char.IsLetterOrDigit(c))
                {
                    text.Append(char.ToLowerInvariant(c));
                }
                else if (char.IsWhiteSpace(c)  || c == '_')
                {
                    if (text.Length > 0 && text[text.Length - 1] != '-')
                        text.Append('-');
                }
            }

            if (text.Length > 0 && text[text.Length - 1] == '-')
                text.Length--;
            return text.ToString();
        }


        [Benchmark]
        public string UsingRegex()
        {
           var  result = Regex.Replace(input, @"[^\p{L}\d\s-_]", "").ToLower().Trim();

            return Regex.Replace(result, @"[\s_-]+", "-");
        }

    }
}
