using System.Net;
using System.Reflection.Metadata;

namespace StdExt.Tests
{
    public class ArrayExtender
    {
        [Theory]
        [MemberData(nameof(IsBullOrEmptyTestData))]
        public void IsNullOrEmptyTest(object[]? input, bool expected)
        {
            var actual = input.IsNullOrEmpty();
            Assert.Equal(expected, actual);
        }

        public static TheoryData<object[]?, bool> IsBullOrEmptyTestData()
        {
            return new TheoryData<object[]?, bool>
            {
                { new object[] { "hoge", "fuga" }, false },
                { new object[] { 1, 2, 3 }, false },
                { null, true },
                { Array.Empty<object>(), true },
            };
        }
    }
}
