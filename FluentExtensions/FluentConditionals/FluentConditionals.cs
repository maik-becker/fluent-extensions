using System;
using Yuri.Li.FluentExtensions.Internal.FluentConditionals;

namespace Yuri.Li.FluentExtensions.FluentConditionals
{
    public static class If
    {
        public static IFluentConditional _(bool value)
        {
            return FluentConditionals.If(value);
        }
    }
}

namespace Yuri.Li.FluentExtensions.FluentConditionals
{
    public static class FluentConditionals
    {
        public static IFluentConditional If(bool condition)
        {
            return FluentConditionalFactory.Of(condition);
        }

        public static IFluentConditional If<T>(this T it, Predicate<T> predicate)
        {
            return If(predicate(it));
        }
    }
}