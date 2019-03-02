using System;

namespace Yuri.Li.FluentExtensions.Internal.FluentConditionals
{
    internal static class FluentConditionalFactory
    {
        internal static IFluentConditional Of(bool value) => !value ? False() : True();

        internal static IFluentIfItConditional<T> Of<T>(bool condition, T it) => False(it);

        private static IFluentConditional False() => new FalseFluentConditional();
        private static IFluentConditional True() => new TrueFluentConditional();
        private static IFluentIfItConditional<T> False<T>(T it) => new FalseFluentIfItConditional<T>(it);
        private static IFluentIfItConditional<T> True<T>(T it) => new TrueFluentIfItConditional<T>(it);

        private class FalseFluentConditional : IFluentConditional
        {
            public IFluentIfElse Then(Action action) => FluentIfElseFactory.False();

            public IFluentTernary<T> Then<T>(Func<T> supplier) => FluentTernaryFactory.False<T>();

            public IFluentTernary<T> Then<T>(T value) => FluentTernaryFactory.False<T>();
        }

        private class TrueFluentConditional : IFluentConditional
        {
            public IFluentIfElse Then(Action action)
            {
                action();
                return FluentIfElseFactory.True();
            }

            public IFluentTernary<T> Then<T>(Func<T> supplier) => FluentTernaryFactory.True(supplier);

            public IFluentTernary<T> Then<T>(T value) => FluentTernaryFactory.True(value);
        }

        private class FalseFluentIfItConditional<T> : FalseFluentConditional, IFluentIfItConditional<T>
        {
            private readonly T _it;

            internal FalseFluentIfItConditional(T it) => _it = it;

            public IFluentIfItIfElse<T> Then(Action<T> action) => FluentIfElseFactory.False(_it);
        }

        private class TrueFluentIfItConditional<T> : TrueFluentConditional, IFluentIfItConditional<T>
        {
            private readonly T _it;

            internal TrueFluentIfItConditional(T it) => _it = it;

            public IFluentIfItIfElse<T> Then(Action<T> action)
            {
                action(_it);
                return FluentIfElseFactory.True<T>();
            }
        }
    }
}