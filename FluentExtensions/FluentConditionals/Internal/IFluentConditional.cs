using System;

namespace FluentExtensions.FluentConditionals.Internal
{
    public interface IFluentConditional
    {
        IFluentIfElse Then(Action thenAction);

        IFluentTernary<T> Then<T>(Func<T> thenSupplier);

        IFluentTernary<T> Then<T>(T thenValue);
    }
    
    public interface IFluentIfItConditional<T>
    {      
        IFluentIfItIfElse<T> Then(Action thenAction);
        
        IFluentIfItIfElse<T> Then(Action<T> thenAction);
        
        IFluentTernary<T> Then<T>(Func<T> thenSupplier);

        IFluentTernary<T> Then<T>(T thenValue);
    }
}