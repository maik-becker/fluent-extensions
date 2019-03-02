using System;

namespace FluentExtensions.FluentConditionals.Internal
{
    internal static class FluentTernaryFactory
    {
        internal static IFluentTernary<T> False<T>() => new FalseFluentTernary<T>();

        internal static IFluentTernary<T> True<T>(T whenTrue) => new TrueValueGivenFluentTernary<T>(whenTrue);

        internal static IFluentTernary<T> True<T>(Func<T> whenTrue) => new TrueSupplierGivenFluentTernary<T>(whenTrue);

        private class FalseFluentTernary<T> : IFluentTernary<T>
        {
            public T Else(Func<T> elseSupplier) => elseSupplier();

            public T Else(T elseValue) => elseValue;
        }

        private class TrueValueGivenFluentTernary<T> : IFluentTernary<T>
        {
            private readonly T _whenTrue;

            public TrueValueGivenFluentTernary(T whenTrue) => _whenTrue = whenTrue;

            public T Else(Func<T> elseSupplier) => _whenTrue;

            public T Else(T elseValue) => _whenTrue;
        }

        private class TrueSupplierGivenFluentTernary<T> : IFluentTernary<T>
        {
            private readonly Func<T> _whenTrue;

            public TrueSupplierGivenFluentTernary(Func<T> whenTrue) => _whenTrue = whenTrue;

            public T Else(Func<T> elseSupplier) => _whenTrue();

            public T Else(T elseValue) => _whenTrue();
        }
    }
}