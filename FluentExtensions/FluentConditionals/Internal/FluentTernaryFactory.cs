using System;

namespace Yuri.Li.FluentExtensions.Internal.FluentConditionals
{
    internal static class FluentTernaryFactory
    {
        internal static IFluentTernary<T> False<T>() => new FalseFluentTernary<T>();

        internal static IFluentTernary<T> True<T>(T whenTrue) => new TrueValueGivenFluentTernary<T>(whenTrue);

        internal static IFluentTernary<T> True<T>(Func<T> whenTrue) => new TrueSupplierGivenFluentTernary<T>(whenTrue);

        private class FalseFluentTernary<T> : IFluentTernary<T>
        {
            public T Else(Func<T> supplier) => supplier();

            public T Else(T value) => value;
        }

        private class TrueValueGivenFluentTernary<T> : IFluentTernary<T>
        {
            private readonly T _whenTrue;

            public TrueValueGivenFluentTernary(T whenTrue) => _whenTrue = whenTrue;

            public T Else(Func<T> supplier) => _whenTrue;

            public T Else(T value) => _whenTrue;
        }

        private class TrueSupplierGivenFluentTernary<T> : IFluentTernary<T>
        {
            private readonly Func<T> _whenTrue;

            public TrueSupplierGivenFluentTernary(Func<T> whenTrue) => _whenTrue = whenTrue;

            public T Else(Func<T> supplier) => _whenTrue();

            public T Else(T value) => _whenTrue();
        }
    }
}