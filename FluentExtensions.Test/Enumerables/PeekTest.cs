using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using Xunit;

namespace FluentExtensions.Enumerables
{
    public class PeekTest
    {
        [Fact]
        public void whenPeek_shouldCallActionForEveryItem()
        {
            var peekAction = new Mock<Action<int>>();
            var enumarable = Enumerable.Range(4, 3);

            // ReSharper disable once UnusedVariable // We need to query the Enumerable for peekAction to be executed.
            var asList = enumarable.Peek(peekAction.Object).ToList();

            peekAction.Verify(action => action(4), Times.Once);
            peekAction.Verify(action => action(5), Times.Once);
            peekAction.Verify(action => action(6), Times.Once);
        }

        [Fact]
        public void whenPeek_shouldReturnAllItems()
        {
            IEnumerable<string> enumerable = new List<string> {"abc", "def", "ghi"};

            var result = enumerable.Peek(it => { });

            result.Should().Contain("abc").And.Contain("def").And.Contain("ghi");
        }
    }
}