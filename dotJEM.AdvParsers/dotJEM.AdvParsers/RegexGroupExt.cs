using System.Text.RegularExpressions;

namespace DotJEM.AdvParsers
{
    public static class RegexGroupExt
    {
        public static int ParseGroup(this Group group)
        {
            return string.IsNullOrEmpty(@group?.Value) ? 0 : int.Parse(@group.Value);
        }
    }
}