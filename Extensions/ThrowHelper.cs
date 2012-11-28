using System;

namespace SolarCalculator.Extensions
{
    /// <summary>
    ///   Borrowed from morelinq to make batch work.
    /// </summary>
    internal static class ThrowHelper
    {
        internal static void ThrowIfNull<T>(this T argument, string name) where T : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        internal static void ThrowIfNegative(this int argument, string name)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(name);
            }
        }

        internal static void ThrowIfNonPositive(this int argument, string name)
        {
            if (argument <= 0)
            {
                throw new ArgumentOutOfRangeException(name);
            }
        }
    }
}