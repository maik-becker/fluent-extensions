using System;

namespace Yuri.Li.FluentExtensions.Internal.FluentConditionals
{
    public interface IFluentConditional
    {
        IFluentIfElse Then(Action action);

        IFluentTernary<T> Then<T>(Func<T> supplier);

        IFluentTernary<T> Then<T>(T value);
    }
    
    public interface IFluentIfItConditional<T>: IFluentConditional
    {
        IFluentIfItIfElse<T> Then(Action<T> action);
    }
}