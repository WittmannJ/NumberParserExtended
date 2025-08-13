using FluentAssertions;
using static StringNormalizer.StringNormalizer;
using static NumberParserExtended.Logic.MatrixHelper;

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

        [Fact]
        public void ConcatenatingTwo2dArraysHorizontallyShouldReturnCorrectResultArray()
        {
            // Arrange
            char[,] array1 = new char[,]
            {
                { 'a', 'b', 'd', 'e' },
                { 'g', 'h', 'j', 'k' }
            };

            char[,] array2 = new char[,]
            {
                { 'c', 'f', 'i', 'l' }
            };

            // Act
            char[,] resultArray = ConcatenateTwo2DCharArraysHorizontally(array1, array2);

            // Assert
            resultArray.GetLength(0).Should().Be(array1.GetLength(0) + array2.GetLength(0));
        }

        [Fact]
        public void ConcatenatingTwo2dArraysVerticallyShouldReturnCorrectResultArray()
        {
            // Arrange
            char[,] array1 = new char[,]
            {
                { 'a', 'b' },
                { 'd', 'e' },
                { 'g', 'h' },
                { 'j', 'k' }
            };

            char[,] array2 = new char[,]
            {
                { 'c' },
                { 'f'},
                { 'i'},
                { 'l' }
            };

            // Act
            char[,] resultArray = ConcatenateTwo2DCharArraysVertically(array1, array2);

            // Assert
            resultArray.GetLength(1).Should().Be(array1.GetLength(1) + array2.GetLength(1));
        }




    }
}