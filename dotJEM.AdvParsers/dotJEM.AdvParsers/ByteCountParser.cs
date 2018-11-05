using System;
using System.Text.RegularExpressions;

namespace DotJEM.AdvParsers
{
    /// <summary>
    /// Parser used to convert strings to byte counts, <see cref="TryParse"/> for details on formats supported by this parser.
    /// </summary>
    public class ByteCountParser : AbstractParser<long>
    {
        private static readonly Regex byteCountExpression = new Regex(
            @"((?'t'[0-9]+)\s?(tb|terabyte(s)?))?\s?" +
            @"((?'g'[0-9]+)\s?(gb|gigabyte(s)?))?\s?" +
            @"((?'m'[0-9]+)\s?(mb|megabyte(s)?))?\s?" +
            @"((?'k'[0-9]+)\s?(kb|kilobyte(s)?))?\s?" +
            @"((?'b'[0-9]+)\s?(b|byte(s)?))?\s?",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Attempts to convert a string to <see cref="long"/> value as a number of bytes.
        /// </summary>
        /// <remarks>
        /// The method uses a range of well-known formats to attempt a conversion of a string representing a size in bytes.
        /// <p/>The order of which the values are defined must always be "Terabytes, Gigabytes, Megabytes, Kilobytes, and Bytes" But non of them are required,
        /// that means that a valid format could be '5 gigabytes 512 bytes' as well as '3kb', and spaces are allowed between each value and it's unit definition.
        /// <p/>The following units are known.
        /// <table>
        /// <tr><td>Terabytes</td><td>tb, terabyte, terabytes</td></tr>
        /// <tr><td>Gigabytes</td><td>gb, gigabyte, gigabytes</td></tr>
        /// <tr><td>Megabytes</td><td>mb, megabyte, megabytes</td></tr>
        /// <tr><td>Kilobytes</td><td>kb, kilobyte, kilobytes</td></tr>
        /// <tr><td>Bytes</td><td>b, byte, bytes</td></tr>
        /// </table>
        /// <p/>All Unit definitions ignores any casing.
        /// </remarks>
        /// <param name="input">A string representing a total number of bytes as Terabytes, Gigabytes, Megabytes, Kilobytes and Bytes.</param>
        /// <param name="value">If success, this holds the <see cref="long"/> calculated as the total number of bytes from the given input.</param>
        /// <returns>true if parsing was successful, otherwise false.</returns>
        /// <example>
        /// This piece of code first parses the string "25mb 512kb" to a long and then uses to write an empty file in the "C:\Temp" folder.
        /// <code>
        /// public void WriteSomeFile()
        /// {
        ///   long length = Convert.ToByteCount("25mb 512kb");
        ///   FileHelper.CreateTextFile("C:\temp", new byte[length], true);
        /// }
        /// </code>
        /// </example>
        /// <exception cref="FormatException">The given input could not be converted because the format was invalid.</exception>
        /// <exception cref="ArgumentNullException">Input was null</exception>
        public override bool TryParse(string input, out long value)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            Match match = byteCountExpression.Match(input);
            if (match == null || !match.Success)
                throw new FormatException("Input string was not in a correct format.");

            long teraBytes = match.Groups["t"].ParseGroupAsInt64();
            long gigaBytes = match.Groups["g"].ParseGroupAsInt64();
            long megaBytes = match.Groups["m"].ParseGroupAsInt64(); 
            long kiloBytes = match.Groups["k"].ParseGroupAsInt64(); 
            long bytes = match.Groups["b"].ParseGroupAsInt64(); 
            value = bytes + 1024L * (kiloBytes + 1024L * (megaBytes + 1024L * (gigaBytes + 1024L * teraBytes)));
            return true;
        }
    }
}