using FluentAssertions;
using Xunit;

namespace FluentExtensions.Numbers
{
    public class AbsTest
    {
        [Fact]
        public void givenNegativeDouble_whenAbs_thenPositive()
        {
            (-3.4).Abs().Should().Be(3.4);
        }

        [Fact]
        public void givenPositiveDouble_whenAbs_thenPositive()
        {
            3.4.Abs().Should().Be(3.4);
        }
    }
}