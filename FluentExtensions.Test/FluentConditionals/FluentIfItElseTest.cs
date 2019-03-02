using System;
using Moq;
using Xunit;

namespace FluentExtensions.FluentConditionals
{
    public class FluentIfItElseTest
    {
        [Fact]
        public void givenIfItResultsTrue_whenThen_thenCallAction()
        {
            var thenAction = new Mock<Action>();
            "abc".If(it => true).Then(thenAction.Object);
            thenAction.Verify(action => action(), Times.Once);
        }

        [Fact]
        public void givenIfItResultsFalse_whenThen_thenDontCallAction()
        {
            var thenAction = new Mock<Action>();
            "abc".If(it => false).Then(thenAction.Object);
            thenAction.Verify(action => action(), Times.Never);
        }

        [Fact]
        public void givenIfItResultsTrue_whenThenElse_thenOnlyCallThenAction()
        {
            var thenAction = new Mock<Action>();
            var elseAction = new Mock<Action>();
            "abc".If(it => true).Then(thenAction.Object).Else(elseAction.Object);
            thenAction.Verify(action => action(), Times.Once);
            elseAction.Verify(action => action(), Times.Never);
        }

        [Fact]
        public void givenIfItResultsFalse_whenThenElse_thenOnlyCallElseAction()
        {
            var thenAction = new Mock<Action>();
            var elseAction = new Mock<Action>();
            "abc".If(it => false).Then(thenAction.Object).Else(elseAction.Object);
            thenAction.Verify(action => action(), Times.Never);
            elseAction.Verify(action => action(), Times.Once);
        }

        [Fact]
        public void givenIfItResultsTrue_whenThen_thenCallThenActionWithIt()
        {
            var thenAction = new Mock<Action<String>>();
            "hEllo".If(it => true).Then(thenAction.Object);
            thenAction.Verify(action => action("hEllo"), Times.Once);
        }

        [Fact]
        public void givenIfItResultsFalse_whenThenElse_thenCallElseActionWithIt()
        {
            var elseAction = new Mock<Action<String>>();
            "hI".If(it => false).Then(() => { }).Else(elseAction.Object);
            elseAction.Verify(action => action("hI"), Times.Once);
        }
    }
}