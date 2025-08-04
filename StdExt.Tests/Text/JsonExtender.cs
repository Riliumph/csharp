using System.Collections.Generic;
using System.Text.Json;
using StdExt.Text;
using Xunit;

namespace StdExt.Text.Tests
{
    public class JsonExtender
    {
        public class JsonTestData
        {
            public int Id { get; set; } = 0;
            public string Name { get; set; } = "";
        }

        public static TheoryData<
            JsonTestData,
            bool,
            string
        > ToJsonStringTestData()
        {
            return new TheoryData<JsonTestData, bool, string>
            {
                {
                    new JsonTestData { Id = 1, Name = "Test" },
                    false,
                    """{"Id":1,"Name":"Test"}"""
                },
            };
        }

        [Theory]
        [MemberData(nameof(ToJsonStringTestData))]
        public void ToJsonString(
            JsonTestData input,
            bool writeIndent,
            string expectedJson
        )
        {
            var result = input.ToJsonString(writeIndent);
            Assert.Equal(expectedJson, result);
        }
    }
}
