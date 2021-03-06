﻿
namespace GeneratorBox.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Radians : IAngleUnit
    {
        private const double _conversionFactor = 1;
        internal const string _name = rad;

        public double Conversionfactor
        {
            get
            {
                return _conversionFactor;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public static Angle operator *(double left, Radians right)
        {
            return new Angle(left, right);
        }
    }
}