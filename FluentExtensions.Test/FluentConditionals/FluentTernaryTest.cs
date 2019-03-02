using FluentAssertions;
using Xunit;

namespace FluentExtensions.FluentConditionals
{
    public class FluentTernaryTest
    {
        [Fact]
        public void givenTrue_whenThenSupplier_thenGiveThenValue()
        {
            var result = "abc".If(it => true).Then(() => "Yay").Else("Nopes");
            result.Should().Be("Yay");
        }

        [Fact]
        public void givenTrue_whenThenValue_thenGiveThenValue()
        {
            var result = "abc".If(it => true).Then("Yay").Else("Nopes");
            result.Should().Be("Yay");
        }

        [Fact]
        public void givenFalse_whenElseSupplier_thenGiveElseValue()
        {
            var result = "abc".If(it => false).Then("Yay").Else("Nopes");
            result.Should().Be("Nopes");
        }

        [Fact]
        public void givenFalse_whenElseValue_thenGiveElseValue()
        {
            var result = "abc".If(it => false).Then("Yay").Else(() => "Nopes");
            result.Should().Be("Nopes");
        }
    }
}