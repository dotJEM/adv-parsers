using System;
using NUnit.Framework;

namespace DotJEM.AdvParsers.Test.TimeSpanParserTests
{
    [TestFixture]
    public class TimeSpanParserTest_TimeSpanParseableFormats
    {
        [TestCase("2:30")]
        [TestCase("2:30:55")]
        public void Parse_TimeSpan_EqualToResult(string value)
        {
            Assert.That(new TimeSpanParser().Parse(value), Is.EqualTo(TimeSpan.Parse(value)));
        }
    }
}