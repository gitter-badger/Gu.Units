﻿namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.AccelerationUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct AccelerationUnit : IUnit
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.MetresPerSecondSquared"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly AccelerationUnit MetresPerSecondSquared = new AccelerationUnit(1.0, "m/s²");

        /// <summary>
        /// The <see cref="T:Gu.Units.MillimetresPerSecondSquared"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AccelerationUnit MillimetresPerSecondSquared = new AccelerationUnit(1E-06, "mm / s^2");

        /// <summary>
        /// The <see cref="T:Gu.Units.CentimetresPerSecondSquared"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AccelerationUnit CentimetresPerSecondSquared = new AccelerationUnit(0.0001, "cm / s^2");

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public AccelerationUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.MetresPerSecondSquared"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Acceleration operator *(double left, AccelerationUnit right)
        {
            return Acceleration.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.MetresPerSecondSquared"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from MetresPerSecondSquared.
        /// </summary>
        /// <param name="value">The value in MetresPerSecondSquared</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), MetresPerSecondSquared.Symbol);
        }
    }
}