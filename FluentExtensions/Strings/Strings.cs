using System;

namespace FluentExtensions.Strings
{
    public static class Strings
    {
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        public static bool IsNullOrWhitespace(this string str) => string.IsNullOrWhiteSpace(str);


        public static bool Contains(this string source, string other,
            StringComparison comparison = StringComparison.CurrentCulture) =>
            source.IndexOf(other, comparison) >= 0;

        public static bool IsContainedBy(this string source, string other,
            StringComparison comparison = StringComparison.CurrentCulture)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            return other.Contains(source, comparison);
        }
    }
}