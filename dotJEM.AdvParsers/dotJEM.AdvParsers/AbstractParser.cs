using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotJEM.AdvParsers
{
    public abstract class AbstractParser<T> : IParser<T>
    {
        /// <summary>
        /// Calls <see cref="TryParse"/>, if successfull the parsed value for <see cref="T"/> is returned, otherwise a FormatException is thrown.
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="ArgumentNullException">input was null</exception>
        /// <exception cref="FormatException">The given input could not be converted to a <see cref="T"/> because the format was invalid.</exception>
        /// <returns></returns>
        public virtual T Parse(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            T output;
            if (TryParse(input, out output))
                return output;

            throw new FormatException("Input string was not in a correct format.");
        }

        public abstract bool TryParse(string input, out T value);
    }
}
