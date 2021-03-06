﻿namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.ResistanceUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct ResistanceUnit : IUnit
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Ohm"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ResistanceUnit Ohm = new ResistanceUnit(1.0, "Ω");
        /// <summary>
        /// The <see cref="T:Gu.Units.Ohm"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ResistanceUnit Ω = Ohm;

        /// <summary>
        /// The <see cref="T:Gu.Units.Microohm"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ResistanceUnit Microohm = new ResistanceUnit(1E-06, "µΩ");
        /// <summary>
        /// The <see cref="T:Gu.Units.Microohm"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ResistanceUnit µΩ = Microohm;

        /// <summary>
        /// The <see cref="T:Gu.Units.Milliohm"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ResistanceUnit Milliohm = new ResistanceUnit(0.001, "mΩ");
        /// <summary>
        /// The <see cref="T:Gu.Units.Milliohm"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ResistanceUnit mΩ = Milliohm;

        /// <summary>
        /// The <see cref="T:Gu.Units.Kiloohm"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ResistanceUnit Kiloohm = new ResistanceUnit(1000, "kΩ");
        /// <summary>
        /// The <see cref="T:Gu.Units.Kiloohm"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ResistanceUnit kΩ = Kiloohm;

        /// <summary>
        /// The <see cref="T:Gu.Units.Megaohm"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ResistanceUnit Megaohm = new ResistanceUnit(1000000, "MΩ");
        /// <summary>
        /// The <see cref="T:Gu.Units.Megaohm"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ResistanceUnit MΩ = Megaohm;

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public ResistanceUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Ohm"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Resistance operator *(double left, ResistanceUnit right)
        {
            return Resistance.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Ohm"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Ohm.
        /// </summary>
        /// <param name="value">The value in Ohm</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Ohm.Symbol);
        }
    }
}