using System.Collections.Generic;
using StdExt.Enumerable;
using Xunit;

namespace StdExt.Tests.Enumerable
{
    public class EnumerableExtenderTests
    {
        [Theory]
        [InlineData(null, true)]
        [MemberData(nameof(GetTestData))]
        public void IsNullOrEmpty_VariousInputs_ReturnsExpected(
            IEnumerable<int> input,
            bool expected
        )
        {
            var result = input.IsNullOrEmpty();
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { new List<int>(), true };
            yield return new object[]
            {
                new List<int> { 1 },
                false,
            };
            yield return new object[] { new int[] { }, true };
            yield return new object[] { new int[] { 42 }, false };
            yield return new object[] { GetLazyEnumerable(), false };
        }

        private static IEnumerable<int> GetLazyEnumerable()
        {
            yield return 99;
        }
    }
}
