using FluentAssertions;
using Xunit;

namespace FluentExtensions.Numbers
{
    public class RoundTest
    {
        [Fact]
        public void givenDouble_thenCeil()
        {
            3.01.Ceil().Should().Be(4);
        }

        [Fact]
        public void givenFloat_thenCeil()
        {
            3.01f.Ceil().Should().Be(4);
        }

        [Fact]
        public void givenDouble_thenFloor()
        {
            3.54.Floor().Should().Be(3);
        }

        [Fact]
        public void givenFloat_thenFloor()
        {
            3.54f.Floor().Should().Be(3);
        }

        [Fact]
        public void givenDouble_thenRound()
        {
            3.5.Round().Should().Be(4);
        }

        [Fact]
        public void givenFloat_thenRound()
        {
            3.5f.Round().Should().Be(4);
        }
    }
}