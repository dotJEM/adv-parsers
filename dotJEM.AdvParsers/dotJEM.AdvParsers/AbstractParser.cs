using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotJEM.AdvParsers
{
    /// <summary>
    /// An abstract parser class which provides a default implementation for the <see cref="Parse"/> method which uses <see cref="TryParse"/> in any specific
    /// implementations. <see cref="Parse"/> for more details.
    /// </summary>
    /// <typeparam name="T">The concrete type that the parser handles.</typeparam>
    public abstract class AbstractParser<T> : IParser<T>
    {
        /// <summary>
        /// Calls <see cref="TryParse"/>, if successful the parsed value for type &lt;T&gt; is returned, otherwise a FormatException is thrown.
        /// </summary>
        /// <param name="input">The value to parse</param>
        /// <exception cref="ArgumentNullException">input was null</exception>
        /// <exception cref="FormatException">The given input could not be converted to a value of type &lt;T&gt; because the format was invalid.</exception>
        /// <returns></returns>
        public virtual T Parse(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (TryParse(input, out T output))
                return output;

            throw new FormatException("Input string was not in a correct format.");
        }

        /// <summary>
        /// Tries to parse the <see cref="input"/> value.
        /// <para>
        /// If parsing was successful the method assigns the result to <see cref="value"/> and <see langword="true"/> is returned.
        /// </para>
        /// <para>
        /// Otherwise <see cref="value"/> is assigned to it's <see langword="default"/> value and <see langword="false"/> is returned.
        /// </para>
        /// </summary>
        /// <remarks>
        /// Any implementations of <see cref="TryParse"/> must avoid throwing exceptions and instead return false.
        /// </remarks>
        /// <param name="input">The value to parse.</param>
        /// <param name="value">The value that <see cref="input"/> resulted in.</param>
        /// <returns><see langword="true"/> if parsing was successful, otherwise <see langword="false"/></returns>
        public abstract bool TryParse(string input, out T value);
    }
}
