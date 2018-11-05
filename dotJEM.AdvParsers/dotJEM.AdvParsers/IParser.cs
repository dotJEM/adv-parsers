namespace DotJEM.AdvParsers
{
    /// <summary>
    /// Common interface for parsers.
    /// </summary>
    public interface IParser<T>
    {
        /// <summary>
        /// Parses the input and returns the result.
        /// </summary>
        T Parse(string input);
        bool TryParse(string input, out T value);
    }
}