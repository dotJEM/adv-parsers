namespace DotJEM.AdvParsers
{
    /// <summary>
    /// Provides convenience extensions to <see cref="Int32"/> for defining byte sizes.
    /// <example>
    ///   long twoGigaBytes = 2.GigaBytes();
    /// </example>
    /// </summary>
    public static class ByteCountFactoryExtensions
    {
        /// <summary>
        /// Returns a byte count for the supplied value as Bytes.
        /// </summary>
        /// <remarks>This method is there for completeness, it just returns the value provide as is.</remarks>
        /// <returns>Supplied value as Bytes converted to a byte count.</returns>
        public static long Bytes(this int self) => self;

        /// <summary>
        /// Returns a byte count for the supplied value as Kilo Bytes.
        /// </summary>
        /// <returns>Supplied value as Kilo Bytes converted to a byte count.</returns>
        public static long KiloBytes(this int self) => self * 1024;

        /// <summary>
        /// Returns a byte count for the supplied value as Mega Bytes.
        /// </summary>
        /// <returns>Supplied value as Mega Bytes converted to a byte count.</returns>
        public static long MegaBytes(this int self) => self.KiloBytes() * 1024;

        /// <summary>
        /// Returns a byte count for the supplied value as Giga Bytes.
        /// </summary>
        /// <param name="self"></param>
        /// <returns>Supplied value as Giga Bytes converted to a byte count.</returns>
        public static long GigaBytes(this int self) => self.MegaBytes() * 1024;

        /// <summary>
        /// Returns a byte count for the supplied value as Tera Bytes.
        /// </summary>
        /// <param name="self"></param>
        /// <returns>Supplied value as Tera Bytes converted to a byte count.</returns>
        public static long TeraBytes(this int self) => self.GigaBytes() * 1024;
    }
}