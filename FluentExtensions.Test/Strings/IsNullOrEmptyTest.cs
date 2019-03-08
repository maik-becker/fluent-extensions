using FluentAssertions;
using Xunit;

namespace FluentExtensions.Strings
{
    public class IsNullOrEmptyTest
    {
        [Fact]
        public void givenNull_whenNullOrEmpty_shouldBeTrue()
        {
            string it = null;
            var isNullOrEmpty = it.IsNullOrEmpty();
            isNullOrEmpty.Should().BeTrue();
        }

        [Fact]
        public void givenEmpty_whenNullOrEmpty_shouldBeTrue()
        {
            var isNullOrEmpty = "".IsNullOrEmpty();
            isNullOrEmpty.Should().BeTrue();
        }

        [Fact]
        public void givenNeitherNullNorEmpty_whenNullOrEmpty_shouldBeFalse()
        {
            var isNullOrEmpty = "notEmpty".IsNullOrEmpty();
            isNullOrEmpty.Should().BeFalse();
        }
    }
}