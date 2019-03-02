using System;

namespace FluentExtensions.FluentConditionals.Internal
{
    public interface IFluentTernary<T>
    {
        T Else(Func<T> elseSupplier);

        T Else(T elseValue);
    }
}