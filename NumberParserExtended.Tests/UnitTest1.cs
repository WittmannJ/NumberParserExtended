using FluentAssertions;
using static StringNormalizer.StringNormalizer;

namespace NumberParserExtended.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void StringWithTwoTabs_should_be_converted_into_correct_number_of_whitespaces()
        {
            // Arrange
            var demoString = "Hello\tmy\tname\tis";

            // Act
            var demoStringWithWhitespaces = ReplaceTabstopsInStringWithWhitespaces(demoString);

            // Assert
            demoStringWithWhitespaces.Should().NotContain("\t");
            

        }
    }
}