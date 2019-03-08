using System;
using FluentAssertions;
using Xunit;

namespace FluentExtensions.Strings
{
    public class IsNullOrWhitespaceTest
    {
        [Fact]
        public void givenNull_whenNullOrWhitespace_shouldBeTrue()
        {
            string it = null;
            var isNullOrWhitespace = it.IsNullOrWhitespace();
            isNullOrWhitespace.Should().BeTrue();
        }

        [Fact]
        public void givenEmpty_whenNullOrWhitespace_shouldBeTrue()
        {
            var isNullOrWhitespace = "".IsNullOrWhitespace();
            isNullOrWhitespace.Should().BeTrue();
        }

        [Fact]
        public void givenWhitespace_whenNullOrWhitespace_shouldBeTrue()
        {
            var isNullOrWhitespace = " ".IsNullOrWhitespace();
            isNullOrWhitespace.Should().BeTrue();
        }

        [Fact]
        public void givenLinebreak_whenNullOrWhitespace_shouldBeTrue()
        {
            var isNullOrWhitespace = Environment.NewLine.IsNullOrWhitespace();
            isNullOrWhitespace.Should().BeTrue();
        }

        [Fact]
        public void givenNeitherNullNorEmpty_whenNullOrEmpty_shouldBeFalse()
        {
            var isNullOrEmpty = " notEmpty".IsNullOrEmpty();
            isNullOrEmpty.Should().BeFalse();
        }
    }
}