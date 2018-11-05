using System;
using System.Text.RegularExpressions;

namespace DotJEM.AdvParsers
{
    /// <summary>
    /// Parser used to convert strings to timespans with an extended set of supported formats compared to the build-in formats, <see cref="TryParse"/> for details on formats supported by this parser.
    /// </summary>
    public class TimeSpanParser : AbstractParser<TimeSpan>
    {
        private static readonly Regex timeSpanExpression = new Regex(
            @"((?'d'[0-9]+)\s?d(ay(s)?)?)?\s?" +
            @"((?'h'[0-9]+)\s?h(our(s)?)?)?\s?" +
            @"((?'m'[0-9]+)\s?(m([^\w]|$)|min(ute(s)?)?))?\s?" +
            @"((?'s'[0-9]+)\s?s(ec(ond(s)?)?)?)?\s?" +
            @"((?'f'[0-9]+)\s?(f(rac(tion(s)?)?)?|ms|millisecond(s)?))?\s?",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Attempts to convert a string to a <see cref="TimeSpan"/>.
        /// </summary>
        /// <remarks>
        /// The method first attempts to use the normal <see cref="TimeSpan.Parse"/> method, if that fails it then uses a range of well-known formats
        /// to attempt a conversion of a string representing a <see cref="TimeSpan"/>.
        /// <p/>The order of which the values are defined must always be "Days, Hours, Minutes, Seconds and Fractions" But non of them are required,
        /// that means that a valid format could be '5 days 30 min' as well as '3h', and spaces are allowed between each value and it's unit definition.
        /// <p/>The following units are known.
        /// <table>
        /// <tr><td>Days</td><td>d, day, days</td></tr>
        /// <tr><td>Hours</td><td>h, hour, hours</td></tr>
        /// <tr><td>Minutes</td><td>m, min, minute, minutes</td></tr>
        /// <tr><td>Seconds</td><td>s, sec, second, seconds</td></tr>
        /// <tr><td>Fractions</td><td>f, frac, fraction. fractions, ms, millisecond, milliseconds</td></tr>
        /// </table>
        /// <p/>All Unit definitions ignores any casing.
        /// </remarks>
        /// <param name="input">A string representing a <see cref="TimeSpan"/>.</param>
        /// <param name="value">If success, this holds the parsed <see cref="TimeSpan"/></param>
        /// <returns>true if parsing was successful, otherwise false.</returns>
        /// <example>
        /// This piece of code first parses the string "2m 30s" to a <see cref="TimeSpan"/> and then uses that <see cref="TimeSpan"/> to sleep for 2 minutes and 30 seconds.
        /// <code>
        /// public void SleepForSomeTime()
        /// {
        ///   //Two and a half minute.
        ///   TimeSpan sleep = Convert.ToTimeSpan("2m 30s");
        ///   Thread.Spleep(sleep);
        /// }
        /// </code>
        /// </example>
        public override bool TryParse(string input, out TimeSpan value)
        {
            if (input == null)
            {
                value = TimeSpan.Zero;
                return false;
            }

            if (TimeSpan.TryParse(input, out value))
                return true;

            Match match = timeSpanExpression.Match(input);
            if (!match.Success)
                return false;

            int days = match.Groups["d"].ParseGroupAsInt32();
            int hours = match.Groups["h"].ParseGroupAsInt32();
            int minutes = match.Groups["m"].ParseGroupAsInt32();
            int seconds = match.Groups["s"].ParseGroupAsInt32();
            int milliseconds = match.Groups["f"].ParseGroupAsInt32();
            value = new TimeSpan(days, hours, minutes, seconds, milliseconds);
            return true;
        }

    }
}