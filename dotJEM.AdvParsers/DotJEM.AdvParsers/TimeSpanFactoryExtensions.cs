using System;

namespace DotJEM.AdvParsers
{
    /// <summary>
    /// Provides convenience extensions to <see cref="Int32"/> for defining <see cref="TimeSpan"/>s.
    /// <example>
    ///   long twoHours = 2.Hours();
    /// </example>
    /// </summary>
    public static class TimeSpanFactoryExtensions
    {
        /// <summary>
        /// Returns the <see cref="Int32"/> as a <see cref="TimeSpan"/> in milliseconds.
        /// </summary>
        /// <remarks>
        /// This is the equivalent of calling <see cref="TimeSpan.FromMilliseconds"/>
        /// </remarks>
        public static TimeSpan Milliseconds(this int self) => TimeSpan.FromMilliseconds(self);
        /// <summary>
        /// Returns the <see cref="Int32"/> as a <see cref="TimeSpan"/> in seconds.
        /// </summary>
        /// <remarks>
        /// This is the equivalent of calling <see cref="TimeSpan.FromSeconds"/>
        /// </remarks>
        public static TimeSpan Seconds(this int self) => TimeSpan.FromSeconds(self);
        /// <summary>
        /// Returns the <see cref="Int32"/> as a <see cref="TimeSpan"/> in minutes.
        /// </summary>
        /// <remarks>
        /// This is the equivalent of calling <see cref="TimeSpan.FromMinutes"/>
        /// </remarks>
        public static TimeSpan Minutes(this int self) => TimeSpan.FromMinutes(self);
        /// <summary>
        /// Returns the <see cref="Int32"/> as a <see cref="TimeSpan"/> in hours.
        /// </summary>
        /// <remarks>
        /// This is the equivalent of calling <see cref="TimeSpan.FromHours"/>
        /// </remarks>
        public static TimeSpan Hours(this int self) => TimeSpan.FromHours(self);
        /// <summary>
        /// Returns the <see cref="Int32"/> as a <see cref="TimeSpan"/> in days.
        /// </summary>
        /// <remarks>
        /// This is the equivalent of calling <see cref="TimeSpan.FromDays"/>
        /// </remarks>
        public static TimeSpan Days(this int self) => TimeSpan.FromDays(self);
    }
}