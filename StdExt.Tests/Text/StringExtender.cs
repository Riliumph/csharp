using System.ComponentModel;
using StdExt.Text;

namespace StdExt.Tests.Text
{
    public class StringExtender
    {
        [Theory]
        [MemberData(nameof(SubstrTestData))]
        public void Substr(string input, int begin, int end, string expexted)
        {
            var result = input.Substr(begin, end);
            Assert.Equal(expexted, result);
        }

        public static TheoryData<string, int, int, string> SubstrTestData()
        {
            return new TheoryData<string, int, int, string>
            {
                { "SubstrTestData", 0, 6, "Substr" },
                { "SubstrTestData", 0, -8, "Substr" },
                { "SubstrTestData", 6, 10, "Test" },
                { "SubstrTestData", 6, -4, "Test" },
                { "SubstrTestData", 10, 14, "Data" },
                { "SubstrTestData", -4, 0, "Data" },
            };
        }
    }
}
