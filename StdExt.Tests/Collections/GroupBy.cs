using System.Collections;
using StdExt.Collections;

namespace StdExt.Tests.Collections
{
    public class GroupByTests
    {
        [Fact]
        public void ToDictionary_ShouldGroupValuesByKey()
        {
            // Arrange
            var list = new List<Dictionary<string, int>>
            {
                new Dictionary<string, int> { { "A", 1 }, { "B", 2 } },
                new Dictionary<string, int> { { "A", 3 }, { "C", 4 } },
                new Dictionary<string, int> { { "B", 5 }, { "C", 6 } }
            };

            // Act
            var result = GroupBy.ToDictionary(list);

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal(new List<int> { 1, 3 }, result["A"]);
            Assert.Equal(new List<int> { 2, 5 }, result["B"]);
            Assert.Equal(new List<int> { 4, 6 }, result["C"]);
        }

        [Fact]
        public void ToOrderedDictionary_ShouldGroupValuesByKey()
        {
            // Arrange
            var list = new List<Dictionary<string, int>>
            {
                new Dictionary<string, int> { { "A", 1 }, { "B", 2 } },
                new Dictionary<string, int> { { "A", 3 }, { "C", 4 } },
                new Dictionary<string, int> { { "B", 5 }, { "C", 6 } }
            };

            // Act
            var result = GroupBy.ToOrderedDictionary(list);

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal(new List<int> { 1, 3 }, (List<int>)result["A"]!);
            Assert.Equal(new List<int> { 2, 5 }, (List<int>)result["B"]!);
            Assert.Equal(new List<int> { 4, 6 }, (List<int>)result["C"]!);

            // 順序もチェック
            var keys = new List<string>();
            foreach (DictionaryEntry entry in result)
            {
                keys.Add((string)entry.Key);
            }
            Assert.Equal(new List<string> { "A", "B", "C" }, keys);
        }
    }
}
