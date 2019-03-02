using System;

namespace Yuri.Li.FluentExtensions.Internal.FluentConditionals
{
    public interface IFluentIfElse
    {
        void Else(Action action);
    }


    public interface IFluentIfItIfElse<T> : IFluentIfElse
    {
        void Else(Action<T> action);       
    }
}