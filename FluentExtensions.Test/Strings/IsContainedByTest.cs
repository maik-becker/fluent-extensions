using System;
using FluentAssertions;
using Xunit;

namespace FluentExtensions.Strings
{
    public class IsContainedByTest
    {
        [Fact]
        public void givenSubstring_whenIsContainedBy_shouldBeTrue()
        {
            string containing = "Hello";
            string substring = "ell";

            var isContainedBy = substring.IsContainedBy(containing);

            isContainedBy.Should().BeTrue();
        }

        [Fact]
        public void givenNotASubstring_whenIsContainedBy_shouldBeFalse()
        {
            string containing = "Hello";
            string notSubstring = "Good bye!";

            var isContainedBy = notSubstring.IsContainedBy(containing);

            isContainedBy.Should().BeFalse();
        }

        [Fact]
        public void givenNull_whenIsContainedBy_shouldThrowArgumentNullException()
        {
            string containing = null;
            string substring = "Something";

            var exception = Record.Exception(() => substring.IsContainedBy(containing));
            exception.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public void givenOnNull_whenIsContainedBy_shouldThrowArgumentNullException()
        {
            string containing = "Hello";
            string substring = null;


            var exception = Record.Exception(() => substring.IsContainedBy(containing));
            exception.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public void givenSubstringAlternatingCase_whenIsContainedBy_thenTrue()
        {
            string containing = "Hello";
            string substring = "ELL";
            var isContainedBy = substring.IsContainedBy(containing, StringComparison.CurrentCultureIgnoreCase);
            isContainedBy.Should().BeTrue();
        }
    }
}