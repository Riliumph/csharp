using System.Collections.Generic;
using StdExt.Collections;
using Xunit;

namespace StdExt.Tests.Collections
{
    public class EnumerableExtenderTests
    {
        [Theory]
        [InlineData(null, true)]
        [MemberData(nameof(IsNullOrEmpty_TestData))]
        public void IsNullOrEmpty(IEnumerable<int> input, bool expected)
        {
            var result = input.IsNullOrEmpty();
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> IsNullOrEmpty_TestData()
        {
            yield return new object[] { new List<int>(), true };
            yield return new object[]
            {
                new List<int> { 1 },
                false,
            };
            yield return new object[] { new int[] { }, true };
            yield return new object[] { new int[] { 42 }, false };
            yield return new object[] { Enumerable.Range(1, 1), false };
        }
    }
}
