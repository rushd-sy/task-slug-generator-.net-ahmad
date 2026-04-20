using System.Text.RegularExpressions;

namespace SlugGenerator.Tests
{
    public class SlugGeneratorTests
    {
        [Fact]
        public void Generate_TextIsNull_ThrowArgumentNullException()
        {
            
            Func<string?, string> func = (e) => SlugGenerator.Generate(null!);

            Assert.Throws<ArgumentNullException>(() => func(null));

        }

        [Fact]
        public void Generate_TextIsEmpty_ThrowArgumentException()
        {
            string text = "";

            Func<string, string> func = (e) => SlugGenerator.Generate(text);

            Assert.Throws<ArgumentException>(() => func(text));

        }

        [Fact]
        public void Generate_ForTextStandardinputs_ReturnSlugText()
        {
            string text = "A__B C";

            var actual = SlugGenerator.Generate(text);

            var expected = "a-b-c";

            Assert.Matches(expected, actual);


        }

        [Fact]
        public void Generate_ForTextsContainOnlySymbols_ThrowArgumentException()
        {
            string text = "@#$$";

            Func<string, string> func = (e) => SlugGenerator.Generate(text);

            Assert.Throws<ArgumentException>(() => func(text));
        }

        [Fact]
        public void Generate_ForTextsArabicInputs_()
        {
            string text = "شقة للبيع";

            var actual = SlugGenerator.Generate(text);

            var expected = "شقة-للبيع";


            Assert.Matches(expected, actual);


        }

        [Fact]
        public void GenerateUnique_ForMultipleCalls_ReturnSlugTextWithUniqueValue()
        {
            string text = "A__B C";
            var call1 = SlugGenerator.GenerateUnique(text);
            var call2 = SlugGenerator.GenerateUnique(text);
                
            Assert.NotEqual(call1, call2);
        }

        [Fact]
        public void GenerateUnique_ForHighFrequencyCalls_ReturnNonDuplicateSlugs()
        {
         
            var results = new HashSet<string>();

            for (int i = 0; i < 1000; i++)
            {
                results.Add(SlugGenerator.GenerateUnique("test"));
            }

            Assert.Equal(1000, results.Count);
            
        }
    }
}
