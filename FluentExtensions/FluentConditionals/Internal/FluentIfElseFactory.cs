using System;

namespace FluentExtensions.FluentConditionals.Internal
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
            public void Else(Action elseAction) => elseAction();
        }

        internal class TrueFluentIfElse : IFluentIfElse
        {
            public void Else(Action elseAction)
            {
                // Do nothing
            }
        }


        private class FalseFluentIfItElse<T> : FalseFluentIfElse, IFluentIfItIfElse<T>
        {
            private readonly T _it;

            public FalseFluentIfItElse(T it) => _it = it;

            public void Else(Action<T> elseAction)
            {
                elseAction(_it);
            }
        }

        private class TrueFluentIfItElse<T> : TrueFluentIfElse, IFluentIfItIfElse<T>
        {
            public void Else(Action<T> elseAction)
            {
                // Do nothing
            }
        }
    }
}