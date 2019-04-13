using System;

namespace FluentExtensions.Numbers
{
    public static class Numbers
    {
        public static T Clamp<T>(this T value, T minimum, T maximum) where T : IComparable<T>
        {
            if (value.CompareTo(minimum) < 0)
                return minimum;
            if (value.CompareTo(maximum) > 0)
                return maximum;
            return value;
        }

        public static int Abs(this int value)
        {
            return Math.Abs(value);
        }

        public static float Abs(this float value)
        {
            return Math.Abs(value);
        }

        public static double Abs(this double value)
        {
            return Math.Abs(value);
        }

        public static bool IsApproximately(this float value, float other)
        {
            return (value - other).Abs() <= 1E-6;
        }

        public static bool IsApproximately(this double value, double other)
        {
            return (value - other).Abs() <= 1E-6;
        }


        public static int Floor(this float value)
        {
            return (int) value;
        }

        public static int Floor(this double value)
        {
            return (int) value;
        }

        public static int Ceil(this float value)
        {
            return (int) Math.Ceiling(value);
        }

        public static int Ceil(this double value)
        {
            return (int) Math.Ceiling(value);
        }

        public static int Round(this float value)
        {
            return (int) Math.Round(value);
        }

        public static int Round(this double value)
        {
            return (int) Math.Round(value);
        }
    }
}