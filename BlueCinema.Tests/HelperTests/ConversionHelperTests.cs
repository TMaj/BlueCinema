using BlueCinema.Helpers;
using System.Collections.Generic;
using Xunit;

namespace BlueCinema.Tests.HelperTests
{
    public class ConversionHelperTests
    {
        [Theory]
        [InlineData("1:2:3:4:5", 1, 2, 3, 4, 5)]
        [InlineData(":1:2:3:4:5", 1, 2, 3, 4, 5)]
        [InlineData("1:2:3:4:5:", 1, 2, 3, 4, 5)]
        public void Parsing_Delimited_String_Should_Return_Proper_Ints_List(string _string, int int1, int int2, int int3, int int4, int int5)
        {
            var expectedList = new List<int> { int1, int2, int3, int4, int5 };


            var returnedList = ConversionHelper.ParseDelimitedStringToInts(':', _string);


            Assert.Equal(expectedList.Count, returnedList.Count);

            for (int i = 0; i < expectedList.Count; i++)
            {
                Assert.Equal(expectedList[i], returnedList[i]);
            }
        }

        [Fact]
        public void Parsing_Delimited_Strings_Should_Return_Proper_Ints_List()
        {
            var string1 = "1:2:3";
            var string2 = "4:5:6";
            var string3 = "7:8:9";
            var string4 = "10:11:12";

            var inputList = new List<string> { string1, string2, string3, string4 };
            var expectedList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };


            var returnedList = ConversionHelper.ParseDelimitedStringsToInts(':', inputList);


            Assert.Equal(expectedList.Count, returnedList.Count);

            for (int i = 0; i < expectedList.Count; i++)
            {
                Assert.Equal(expectedList[i], returnedList[i]);
            }
        }

    }
}
