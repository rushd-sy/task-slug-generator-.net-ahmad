using BenchmarkDotNet.Attributes;
using System.Text.RegularExpressions;

namespace Benchmark
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        [Benchmark]
        public string Generate()
        {
            var text = "vghvgkfty#%%#@ cyj";

            if (text is null)
                throw new ArgumentNullException("Text");

            if (text.Length == 0)
                throw new ArgumentException("text is empty");

            text = Regex.Replace(text, @"[^\p{L}\d\s-_]", "").ToLower().Trim();

            if (text.Length == 0)
                throw new ArgumentException("text contain only symbols");

            text = Regex.Replace(text, @"[\s_-]+", "-");

            return text;
        }


        [Benchmark]
        public string UsingRegex()
        {
            return Regex.Replace("vghvgkfty#%%#@ cyj", @"[\s_-]+", "-");
        }

    }
}
