using System;
using NUnit.Framework;

namespace DotJEM.AdvParsers.Test.TimeSpanParserTests
{
    [TestFixture]
    public class TimeSpanParserTest_SingleFormats
    {

        [TestCase("500f", 500)]
        [TestCase("500frac", 500)]
        [TestCase("500fraction", 500)]
        [TestCase("500fractions", 500)]
        [TestCase("750 f", 750)]
        [TestCase("750 frac", 750)]
        [TestCase("750 fraction", 750)]
        [TestCase("750 fractions", 750)]
        [TestCase("500ms", 500)]
        [TestCase("500millisecond", 500)]
        [TestCase("500milliseconds", 500)]
        [TestCase("750 ms", 750)]
        [TestCase("750 millisecond", 750)]
        [TestCase("750 milliseconds", 750)]
        public void Parse_ValidMilliseconds_ReturnsTimespan(string value, int ms)
        {
            Assert.That(new TimeSpanParser().Parse(value), Is.EqualTo(TimeSpan.FromMilliseconds(ms)));
        }

        [TestCase("30s", 30)]
        [TestCase("21sec", 21)]
        [TestCase("42second", 42)]
        [TestCase("51seconds", 51)]
        [TestCase("25 s", 25)]
        [TestCase("3 sec", 3)]
        [TestCase("8 second", 8)]
        [TestCase("59 seconds", 59)]
        public void Parse_ValidSeconds_ReturnsTimespan(string value, int seconds)
        {
            Assert.That(new TimeSpanParser().Parse(value), Is.EqualTo(TimeSpan.FromSeconds(seconds)));
        }

        [TestCase("30m", 30)]
        [TestCase("21min", 21)]
        [TestCase("42minute", 42)]
        [TestCase("42minutes", 42)]
        [TestCase("25 m", 25)]
        [TestCase("3 min", 3)]
        [TestCase("8 minute", 8)]
        [TestCase("8 minutes", 8)]
        public void Parse_ValidMinutes_ReturnsTimespan(string value, int minutes)
        {
            Assert.That(new TimeSpanParser().Parse(value), Is.EqualTo(TimeSpan.FromMinutes(minutes)));
        }

        [TestCase("16h", 16)]
        [TestCase("21hour", 21)]
        [TestCase("12hours", 12)]
        [TestCase("3 h", 3)]
        [TestCase("8 hour", 8)]
        [TestCase("9 hours", 9)]
        public void Parse_ValidHours_ReturnsTimespan(string value, int hours)
        {
            Assert.That(new TimeSpanParser().Parse(value), Is.EqualTo(TimeSpan.FromHours(hours)));
        }

        [TestCase("16d", 16)]
        [TestCase("21day", 21)]
        [TestCase("12days", 12)]
        [TestCase("3 d", 3)]
        [TestCase("8 day", 8)]
        [TestCase("9 days", 9)]
        public void Parse_ValidDays_ReturnsTimespan(string value, int days)
        {
            Assert.That(new TimeSpanParser().Parse(value), Is.EqualTo(TimeSpan.FromDays(days)));
        }

    }
}