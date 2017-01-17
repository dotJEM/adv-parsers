using System;
using NUnit.Framework;

namespace DotJEM.AdvParsers.Test.TimeSpanParserTests
{
    [TestFixture]
    public class TimeSpanParserTest_FullFormats
    {

        [TestCase("2d 12h 30m", 2, 12, 30, 0, 0)]
        [TestCase("2 d 12 h 30 m", 2, 12, 30, 0, 0)]
        [TestCase("2D 12H 30M", 2, 12, 30, 0, 0)]
        [TestCase("2days 12hours 30minutes", 2, 12, 30, 0, 0)]
        [TestCase("2d 12h 30m 45s 500f", 2, 12, 30, 45, 500)]
        public void Parse_ValidFormat_ReturnsTimespan(string value, int days, int hours, int minutes, int seconds, int ms)
        {
            Assert.That(new TimeSpanParser().Parse(value), Is.EqualTo(new TimeSpan(days, hours, minutes, seconds, ms)));
        }

    }
}