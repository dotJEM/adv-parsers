using System;

namespace DotJEM.AdvParsers
{
    /// <summary>
    /// Static parser class providing quick access to the different parser implementations contained in this package.
    /// </summary>
    public static class AdvParser
    {
        private static readonly IParser<TimeSpan> timespanParser = new TimeSpanParser();
        private static readonly IParser<long> bytecountParser = new ByteCountParser();

        /// <summary>
        /// <see cref="TimeSpanParser.TryParse"/>
        /// </summary>
        public static TimeSpan ParseTimeSpan(string input) => timespanParser.Parse(input);

        /// <summary>
        /// <see cref="TimeSpanParser.TryParse"/>
        /// </summary>
        public static bool TryParseTimeSpan(string input, out TimeSpan value) => timespanParser.TryParse(input, out value);

        /// <summary>
        /// <see cref="ByteCountParser.TryParse"/>
        /// </summary>
        public static long ParseByteCount(string input) => bytecountParser.Parse(input);

        /// <summary>
        /// <see cref="ByteCountParser.TryParse"/>
        /// </summary>
        public static bool TryParseByteCount(string input, out long value) => bytecountParser.TryParse(input, out value);
    }
}