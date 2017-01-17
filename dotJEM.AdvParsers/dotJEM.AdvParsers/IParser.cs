namespace DotJEM.AdvParsers
{
    public interface IParser<T>
    {
        T Parse(string input);
        bool TryParse(string input, out T value);
    }
}