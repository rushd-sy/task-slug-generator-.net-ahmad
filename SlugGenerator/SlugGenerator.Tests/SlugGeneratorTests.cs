using System.Text.RegularExpressions;

namespace SlugGenerator.Tests
{
    public class SlugGeneratorTests
    {
        [Fact]
        public void Generate_TextIsNull_ThrowArgumentNullException()
        {
            string text = null;

            Func<string, string> func = (e) => SlugGenerator.Generate(text);

            Assert.Throws<ArgumentNullException>(() => func(text));

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
    }
}
