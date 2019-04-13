using FluentAssertions;
using Xunit;

namespace FluentExtensions.Numbers
{
    public class ClampTest
    {
        [Fact]
        public void givenIntBelowMinimum_whenClamp_thenMinimum()
        {
            8.Clamp(11, 20).Should().Be(11);
        }

        [Fact]
        public void givenFloatBelowMinimum_whenClamp_thenMinimum()
        {
            (-.4).Clamp(.1, 1.0).Should().Be(.1);
        }

        [Fact]
        public void givenAboveMaximum_whenClamp_thenMaximum()
        {
            11.Clamp(0, 10).Should().Be(10);
        }

        [Fact]
        public void givenBetweenMinimumAndMaximum_whenClamp_thenUnchanged()
        {
            6.Clamp(0, 10).Should().Be(6);
        }
    }
}