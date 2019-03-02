using System;
using FluentExtensions.FluentConditionals.Internal;

namespace FluentExtensions.FluentConditionals
{
    public static class If
    {
        /// <summary>
        /// Alternative to FluentConditionals#If without the need of static imports.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IFluentConditional _(bool value) => FluentConditionals.If(value);
    }

    public static class FluentConditionals
    {
        public static IFluentConditional If(bool condition) => FluentConditionalFactory.Of(condition);

        public static IFluentIfItConditional<T> If<T>(this T it, Predicate<T> predicate) =>
            FluentConditionalFactory.Of(predicate(it), it);
    }
}