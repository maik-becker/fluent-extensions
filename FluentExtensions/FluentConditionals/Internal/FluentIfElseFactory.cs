using System;

namespace Yuri.Li.FluentExtensions.Internal.FluentConditionals
{
    internal static class FluentIfElseFactory
    {
        internal static IFluentIfElse False()
        {
            return new FalseFluentIfElse();
        }

        internal static IFluentIfItIfElse<T> False<T>(T it)
        {
            return new FalseFluentIfItElse<T>(it);
        }

        internal static IFluentIfElse True()
        {
            return new TrueFluentIfElse();
        }

        internal static IFluentIfItIfElse<T> True<T>()
        {
            return new TrueFluentIfItElse<T>();
        }

        internal class FalseFluentIfElse : IFluentIfElse
        {
            public void Else(Action action) => action();
        }

        internal class TrueFluentIfElse : IFluentIfElse
        {
            public void Else(Action action)
            {
                // Do nothing
            }
        }


        private class FalseFluentIfItElse<T> : FalseFluentIfElse, IFluentIfItIfElse<T>
        {
            private readonly T _it;

            public FalseFluentIfItElse(T it) => _it = it;

            public void Else(Action<T> action)
            {
                action(_it);
            }
        }

        private class TrueFluentIfItElse<T> : TrueFluentIfElse, IFluentIfItIfElse<T>
        {
            public void Else(Action<T> action)
            {
                // Do nothing
            }
        }
    }
}