using BlueCinema.Helpers.Extensions;
using Xunit;

namespace BlueCinema.Tests.ExtensionsTests
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData(".dsa.asd.dsf.dfs", "dsa.asd.dsf.dfs", '.')]
        [InlineData("dsa.asd.dsf.dfs.", "dsa.asd.dsf.dfs", '.')]
        [InlineData(".dsa.asd.dsf.dfs.", "dsa.asd.dsf.dfs", '.')]
        public void Normalizing_String_Should_Return_String_Without_Delimiter_At_The_Beggining_And_End(string givenString, string expectedString, char delimiter)
        {
            givenString = givenString.NormalizeString(delimiter);

            Assert.Equal(expectedString, givenString);
        }
    }
}
