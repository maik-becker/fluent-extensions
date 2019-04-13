using FluentAssertions;
using Xunit;

namespace FluentExtensions.Numbers
{
    public class IsApproximatelyTest
    {
        [Fact]
        public void givenDoublesWithDeviationOfOneTenmillionth_whenIsApproximately_thenTrue()
        {
            4.1.IsApproximately(4.1000001).Should().BeTrue();
        }

        [Fact]
        public void givenEqualDoubles_whenIsApproximately_thenTrue()
        {
            4.1.IsApproximately(4.1).Should().BeTrue();
        }

        [Fact]
        public void givenDoublesOneMillionthAway_whenIsApproximately_thenFalse()
        {
            4.1.IsApproximately(4.100001).Should().BeFalse();
        }

        [Fact]
        public void givenFloatsWithDeviationOfOneMillionth_whenIsApproximately_thenTrue()
        {
            4.1f.IsApproximately(4.100001f).Should().BeTrue();
        }

        [Fact]
        public void givenEqualFloats_whenIsApproximately_thenTrue()
        {
            4.1f.IsApproximately(4.1f).Should().BeTrue();
        }

        [Fact]
        public void givenFloatsOneHunderetthousandthAway_whenIsApproximately_thenFalse()
        {
            4.1f.IsApproximately(4.10001f).Should().BeFalse();
        }
    }
}