using System;
using System.Linq;
using Moq;
using Xunit;

namespace FluentExtensions.Enumerables
{
    public class ForEachTest
    {
        [Fact]
        public void whenForEach_shouldCallActionForEveryItem()
        {
            var forEachAction = new Mock<Action<int>>();
            var enumerable = Enumerable.Range(0, 3);
            
            enumerable.ForEach(forEachAction.Object);

            forEachAction.Verify(action => action(0), Times.Once);
            forEachAction.Verify(action => action(1), Times.Once);
            forEachAction.Verify(action => action(2), Times.Once);
        }
    }
}