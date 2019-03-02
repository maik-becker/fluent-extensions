using System;

namespace FluentExtensions.FluentConditionals.Internal
{
    public interface IFluentIfElse
    {
        void Else(Action elseAction);
    }


    public interface IFluentIfItIfElse<out T> : IFluentIfElse
    {
        void Else(Action<T> elseAction);       
    }
}