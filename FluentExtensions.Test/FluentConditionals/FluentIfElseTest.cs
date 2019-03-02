using System;
using Moq;
using Xunit;

namespace FluentExtensions.FluentConditionals
{
    public class FluentIfElseTest
    {
        [Fact]
        public void givenIfTrue_whenIfThen_thenCallAction()
        {
            var thenAction = new Mock<Action>();
            FluentConditionals.If(true).Then(thenAction.Object);

            thenAction.Verify(action => action(), Times.Once);
        }

        [Fact]
        public void givenIfFalse_whenIfThen_thenDontCallAction()
        {
            var thenAction = new Mock<Action>();
            FluentConditionals.If(false).Then(thenAction.Object);
            thenAction.Verify(action => action(), Times.Never);
        }

        [Fact]
        public void givenIfTrue_whenIfThenElse_thenCallOnlyThenAction()
        {
            var thenAction = new Mock<Action>();
            var elseAction = new Mock<Action>();
            FluentConditionals.If(true).Then(thenAction.Object).Else(elseAction.Object);
            thenAction.Verify(action => action(), Times.Once);
            elseAction.Verify(action => action(), Times.Never);
        }

        [Fact]
        public void givenIfFalse_whenIfThenElse_thenCallOnlyElseAction()
        {
            var thenAction = new Mock<Action>();
            var elseAction = new Mock<Action>();
            FluentConditionals.If(false).Then(thenAction.Object).Else(elseAction.Object);
            thenAction.Verify(action => action(), Times.Never);
            elseAction.Verify(action => action(), Times.Once);
        }
    }
}