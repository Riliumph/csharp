using System.Collections.Generic;
using StdExt.Collections;
using Xunit;

namespace StdExt.Tests.Collections
{
    public class EnumerableExtenderTests
    {
        [Theory]
        [MemberData(nameof(IsNullOrEmptyTestData))]
        public void IsNullOrEmpty(IEnumerable<int>? input, bool expected)
        {
            var result = input.IsNullOrEmpty();
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// IsNUllOrEmpty用のテストデータ生成関数
        /// [InlineData]はコンパイル時定数のみ認められる。
        /// [InlineData(new List<int>(), true)]とすると以下のエラーとなるため使用禁止
        /// error CS0182: 属性引数は、定数式、typeof 式、または属性パラメーター型の配列の作成式でなければなりません
        /// </summary>
        /// <returns></returns>
        public static TheoryData<
            IEnumerable<int>?,
            bool
        > IsNullOrEmptyTestData()
        {
            return new TheoryData<IEnumerable<int>?, bool>
            {
                { null, true },
                { new List<int>(), true },
                {
                    new List<int> { 1 },
                    false
                },
                { Array.Empty<int>(), true },
                { new int[] { 42 }, false },
                { Enumerable.Range(1, 1), false },
            };
        }
    }
}
