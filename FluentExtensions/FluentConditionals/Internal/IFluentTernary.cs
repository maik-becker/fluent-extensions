using System;

namespace Yuri.Li.FluentExtensions.Internal.FluentConditionals
{
    public interface IFluentTernary<T>
    {
        T Else(Func<T> supplier);

        T Else(T value);
    }
}