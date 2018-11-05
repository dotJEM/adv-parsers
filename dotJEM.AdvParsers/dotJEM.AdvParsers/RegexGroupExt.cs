using System;
using System.Text.RegularExpressions;

namespace DotJEM.AdvParsers
{
    /// <summary>
    /// Intended for internal use only.
    /// </summary>
    public static class RegexGroupExt
    {
        /// <summary>
        /// </summary>
        [Obsolete]
        public static int ParseGroup(this Group group)
        {
            return string.IsNullOrEmpty(@group?.Value) ? 0 : int.Parse(@group.Value);
        }

        /// <summary>
        /// Attempts to parse the value of a regex group as an <see cref="Int32"/>.
        /// </summary>
        public static int ParseGroupAsInt32(this Group group)
        {
            return string.IsNullOrEmpty(@group?.Value) ? 0 : int.Parse(@group.Value);
        }

        /// <summary>
        /// Attempts to parse the value of a regex group as an <see cref="Int64"/>.
        /// </summary>
        public static long ParseGroupAsInt64(this Group group)
        {
            return string.IsNullOrEmpty(@group?.Value) ? 0 : long.Parse(@group.Value);
        }
    }
}