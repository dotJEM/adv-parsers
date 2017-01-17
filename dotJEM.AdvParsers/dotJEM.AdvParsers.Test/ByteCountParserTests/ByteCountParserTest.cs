using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DotJEM.AdvParsers.Test
{
    [TestFixture]
    public class ByteCountParserTest
    {
        private const long KiloBytes = 1024L;
        private const long MegaBytes = 1024L * KiloBytes;
        private const long GigaBytes = 1024L * MegaBytes;
        private const long TeraBytes = 1024L * GigaBytes;

        [TestCase("512b", 512)]
        [TestCase("512byte", 512)]
        [TestCase("512bytes", 512)]
        [TestCase("512 b", 512)]
        [TestCase("512 byte", 512)]
        [TestCase("512 bytes", 512)]

        [TestCase("4kb", 4 * KiloBytes)]
        [TestCase("4kilobyte", 4 * KiloBytes)]
        [TestCase("4kilobytes", 4 * KiloBytes)]
        [TestCase("2 kb", 2 * KiloBytes)]
        [TestCase("3 kilobyte", 3 * KiloBytes)]
        [TestCase("5 kilobytes", 5 * KiloBytes)]

        [TestCase("14mb", 14 * MegaBytes)]
        [TestCase("12megabyte", 12 * MegaBytes)]
        [TestCase("10megabytes", 10 * MegaBytes)]
        [TestCase("4 mb", 4 * MegaBytes)]
        [TestCase("4 megabyte", 4 * MegaBytes)]
        [TestCase("4 megabytes", 4 * MegaBytes)]

        [TestCase("4gb", 4 * GigaBytes)]
        [TestCase("4gigabyte", 4 * GigaBytes)]
        [TestCase("4gigabytes", 4 * GigaBytes)]
        [TestCase("4 gb", 4 * GigaBytes)]
        [TestCase("4 gigabyte", 4 * GigaBytes)]
        [TestCase("4 gigabytes", 4 * GigaBytes)]

        [TestCase("40tb", 40 * TeraBytes)]
        [TestCase("42terabyte", 42 * TeraBytes)]
        [TestCase("44terabytes", 44 * TeraBytes)]
        [TestCase("13 tb", 13 * TeraBytes)]
        [TestCase("14 terabyte", 14 * TeraBytes)]
        [TestCase("15 terabytes", 15 * TeraBytes)]
        public void Parse_SingleValue_ReturnsTotalBytes(string value, long bytes)
        {
            Assert.That(new ByteCountParser().Parse(value), Is.EqualTo(bytes));
        }

        [TestCase("2kb 512b", 2 * KiloBytes + 512)]
        [TestCase("2mb 4kb", 2 * MegaBytes + 4 * KiloBytes)]
        [TestCase("4gb 16mb 32kb 64b", 4 * GigaBytes + 16 * MegaBytes + 32 * KiloBytes + 64)]
        public void Parse_MultiValue_ReturnsTotalBytes(string value, long bytes)
        {
            Assert.That(new ByteCountParser().Parse(value), Is.EqualTo(bytes));
        }

        [TestCase("2048kb", 2 * MegaBytes)]
        [TestCase("2048mb", 2 * GigaBytes)]
        [TestCase("2048gb", 2 * TeraBytes)]

        [TestCase("1mb 2048kb", 3 * MegaBytes)]
        [TestCase("1gb 2048mb", 3 * GigaBytes)]
        [TestCase("1tb 2048gb", 3 * TeraBytes)]
        public void Parse_OverflowingValues_ReturnsTotalBytes(string value, long bytes)
        {
            Assert.That(new ByteCountParser().Parse(value), Is.EqualTo(bytes));
        }
    }


}
