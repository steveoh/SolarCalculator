namespace SolarCalculator.Extensions
{
    /// <summary>
    /// string extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Replaces string.format witha  more fluent "".with(param) syntax
        /// </summary>
        /// <param name="format">The string to format.</param>
        /// <param name="args">The args.</param>
        /// <returns>A formatted string</returns>
        public static string With(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
    }
}
