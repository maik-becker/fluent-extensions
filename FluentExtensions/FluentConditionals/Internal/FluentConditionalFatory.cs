using System;

namespace FluentExtensions.FluentConditionals.Internal
{
    internal static class FluentConditionalFactory
    {
        internal static IFluentConditional Of(bool value) => !value ? False() : True();

        internal static IFluentIfItConditional<T> Of<T>(bool condition, T it) => !condition ? False(it) : True(it);

        private static IFluentConditional False() => new FalseFluentConditional();
        private static IFluentConditional True() => new TrueFluentConditional();
        private static IFluentIfItConditional<T> False<T>(T it) => new FalseFluentIfItConditional<T>(it);
        private static IFluentIfItConditional<T> True<T>(T it) => new TrueFluentIfItConditional<T>(it);

        private class FalseFluentConditional : IFluentConditional
        {
            public IFluentIfElse Then(Action thenAction) => FluentIfElseFactory.False();

            public IFluentTernary<T> Then<T>(Func<T> thenSupplier) => FluentTernaryFactory.False<T>();

            public IFluentTernary<T> Then<T>(T thenValue) => FluentTernaryFactory.False<T>();
        }

        private class TrueFluentConditional : IFluentConditional
        {
            public IFluentIfElse Then(Action thenAction)
            {
                thenAction();
                return FluentIfElseFactory.True();
            }

            public IFluentTernary<T> Then<T>(Func<T> thenSupplier) => FluentTernaryFactory.True(thenSupplier);

            public IFluentTernary<T> Then<T>(T thenValue) => FluentTernaryFactory.True(thenValue);
        }

        private class FalseFluentIfItConditional<T> : IFluentIfItConditional<T>
        {
            private readonly T _it;

            internal FalseFluentIfItConditional(T it) => _it = it;

            public IFluentIfItIfElse<T> Then(Action thenAction) => FluentIfElseFactory.False(_it);

            public IFluentIfItIfElse<T> Then(Action<T> thenAction) => FluentIfElseFactory.False(_it);

            public IFluentTernary<TTernary> Then<TTernary>(Func<TTernary> thenSupplier) =>
                FluentTernaryFactory.False<TTernary>();

            public IFluentTernary<TTernary> Then<TTernary>(TTernary thenValue) =>
                FluentTernaryFactory.False<TTernary>();
        }

        private class TrueFluentIfItConditional<T> : IFluentIfItConditional<T>
        {
            private readonly T _it;

            internal TrueFluentIfItConditional(T it) => _it = it;

            public IFluentIfItIfElse<T> Then(Action thenAction)
            {
                thenAction();
                return FluentIfElseFactory.True<T>();
            }

            public IFluentIfItIfElse<T> Then(Action<T> thenAction)
            {
                thenAction(_it);
                return FluentIfElseFactory.True<T>();
            }

            public IFluentTernary<TTernary> Then<TTernary>(Func<TTernary> thenSupplier) =>
                FluentTernaryFactory.True(thenSupplier);

            public IFluentTernary<TTernary> Then<TTernary>(TTernary thenValue) => FluentTernaryFactory.True(thenValue);
        }
    }
}