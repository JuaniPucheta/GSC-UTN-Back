using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Utils.Tests.Unit
{
    public class StringExtensionsTests
    {
        public class TheMethoid_CountCharOccurrences : StringExtensionsTests
        {
            [Theory]
            [InlineData('a', 1)]
            [InlineData('l', 2)]
            [InlineData('u', 3)]
            [InlineData('$', 0)]
            public void Should_return_count_of_char_occurrences(char @char, int expected)
            {
                // arrange
                const string sentence = "Curso full stack GSC+UTN!";

                // act
                int actual = sentence.CountCharOccurrences(@char);

                // assert
                Assert.Equal(expected, actual);
                actual.Should().Be(expected);
            }
        }

    }
}