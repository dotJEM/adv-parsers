using System;
using NUnit.Framework;

namespace DotJEM.AdvParsers.Test.TimeSpanParserTests
{
    [TestFixture]
    public class TimeSpanParserTest_Overflows
    {
        [TestCase("2000f", "0.00:00:02.0000")]
        [TestCase("5000ms", "0.00:00:05.0000")]

        [TestCase("300s", "0.00:05:00.0000")]
        [TestCase("300m", "0.05:00:00.0000")]
        [TestCase("125h", "5.05:00:00.0000")]
        public void Parse_SingleValueOverflow_ReturnsTimespan(string value, string expected)
        {
            Assert.That(new TimeSpanParser().Parse(value), Is.EqualTo(TimeSpan.Parse(expected)));
        }

        [TestCase("2d 12h 120m", "2.14:00:00.0000")]
        [TestCase("2d 36h 120m", "3.14:00:00.0000")]
        public void Parse_MultiValueOverflow_ReturnsTimespan(string value, string expected)
        {
            Assert.That(new TimeSpanParser().Parse(value), Is.EqualTo(TimeSpan.Parse(expected)));
        }



    }
}