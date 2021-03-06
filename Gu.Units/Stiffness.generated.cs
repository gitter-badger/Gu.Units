﻿namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Stiffness"/>.
    /// </summary>
    [Serializable]
    public partial struct Stiffness : IComparable<Stiffness>, IEquatable<Stiffness>, IFormattable, IXmlSerializable, IQuantity<MassUnit, I1, TimeUnit, INeg2>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.NewtonsPerMetre"/>.
        /// </summary>
        internal readonly double newtonsPerMetre;

        private Stiffness(double newtonsPerMetre)
        {
            this.newtonsPerMetre = newtonsPerMetre;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.NewtonsPerMetre"/>.</param>
        public Stiffness(double value, StiffnessUnit unit)
        {
            this.newtonsPerMetre = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in NewtonsPerMetre
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.newtonsPerMetre;
            }
        }

        /// <summary>
        /// The quantity in newtonsPerMetre".
        /// </summary>
        public double NewtonsPerMetre
        {
            get
            {
                return this.newtonsPerMetre;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Stiffness"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Stiffness"/></param>
        /// <returns></returns>
        public static Stiffness Parse(string s)
        {
            return Parser.Parse<StiffnessUnit, Stiffness>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Stiffness"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Stiffness"/></returns>
        public static Stiffness ReadFrom(XmlReader reader)
        {
            var v = new Stiffness();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Stiffness From(double value, StiffnessUnit unit)
        {
            return new Stiffness(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="newtonsPerMetre">The value in <see cref="T:Gu.Units.NewtonsPerMetre"/></param>
        public static Stiffness FromNewtonsPerMetre(double newtonsPerMetre)
        {
            return new Stiffness(newtonsPerMetre);
        }


        public static Force operator *(Stiffness left, Length right)
        {
            return Force.FromNewtons(left.newtonsPerMetre * right.metres);
        }

        public static Pressure operator /(Stiffness left, Length right)
        {
            return Pressure.FromPascals(left.newtonsPerMetre / right.metres);
        }

        public static Energy operator *(Stiffness left, Area right)
        {
            return Energy.FromJoules(left.newtonsPerMetre * right.squareMetres);
        }

        public static Flexibility operator /(double left, Stiffness right)
        {
            return Flexibility.FromMetresPerNewton(left / right.newtonsPerMetre);
        }

        public static double operator /(Stiffness left, Stiffness right)
        {
            return left.newtonsPerMetre / right.newtonsPerMetre;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Stiffness"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Stiffness"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Stiffness"/>.</param>
        public static bool operator ==(Stiffness left, Stiffness right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Stiffness"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Stiffness"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Stiffness"/>.</param>
        public static bool operator !=(Stiffness left, Stiffness right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Stiffness"/> is less than another specified <see cref="T:Gu.Units.Stiffness"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Stiffness"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Stiffness"/>.</param>
        public static bool operator <(Stiffness left, Stiffness right)
        {
            return left.newtonsPerMetre < right.newtonsPerMetre;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Stiffness"/> is greater than another specified <see cref="T:Gu.Units.Stiffness"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Stiffness"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Stiffness"/>.</param>
        public static bool operator >(Stiffness left, Stiffness right)
        {
            return left.newtonsPerMetre > right.newtonsPerMetre;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Stiffness"/> is less than or equal to another specified <see cref="T:Gu.Units.Stiffness"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Stiffness"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Stiffness"/>.</param>
        public static bool operator <=(Stiffness left, Stiffness right)
        {
            return left.newtonsPerMetre <= right.newtonsPerMetre;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Stiffness"/> is greater than or equal to another specified <see cref="T:Gu.Units.Stiffness"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Stiffness"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Stiffness"/>.</param>
        public static bool operator >=(Stiffness left, Stiffness right)
        {
            return left.newtonsPerMetre >= right.newtonsPerMetre;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Stiffness"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Stiffness"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Stiffness"/> with <paramref name="left"/> and returns the result.</returns>
        public static Stiffness operator *(double left, Stiffness right)
        {
            return new Stiffness(left * right.newtonsPerMetre);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Stiffness"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Stiffness"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Stiffness"/> with <paramref name="right"/> and returns the result.</returns>
        public static Stiffness operator *(Stiffness left, double right)
        {
            return new Stiffness(left.newtonsPerMetre * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Stiffness"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Stiffness"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Stiffness"/> with <paramref name="right"/> and returns the result.</returns>
        public static Stiffness operator /(Stiffness left, double right)
        {
            return new Stiffness(left.newtonsPerMetre / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Stiffness"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Stiffness"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Stiffness"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Stiffness"/>.</param>
        public static Stiffness operator +(Stiffness left, Stiffness right)
        {
            return new Stiffness(left.newtonsPerMetre + right.newtonsPerMetre);
        }

        /// <summary>
        /// Subtracts an Stiffness from another Stiffness and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Stiffness"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Stiffness"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Stiffness"/> (the subtrahend).</param>
        public static Stiffness operator -(Stiffness left, Stiffness right)
        {
            return new Stiffness(left.newtonsPerMetre - right.newtonsPerMetre);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Stiffness"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Stiffness"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="stiffness">An instance of <see cref="T:Gu.Units.Stiffness"/></param>
        public static Stiffness operator -(Stiffness stiffness)
        {
            return new Stiffness(-1 * stiffness.newtonsPerMetre);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Stiffness"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="stiffness"/>.
        /// </returns>
        /// <param name="stiffness">An instance of <see cref="T:Gu.Units.Stiffness"/></param>
        public static Stiffness operator +(Stiffness stiffness)
        {
            return stiffness;
        }

        public override string ToString()
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.CurrentInfo);
        }

        public string ToString(string format)
        {
            return this.ToString(format, (IFormatProvider)NumberFormatInfo.CurrentInfo);
        }

        public string ToString(IFormatProvider provider)
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.GetInstance(provider));
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return this.ToString(format, formatProvider, StiffnessUnit.NewtonsPerMetre);
        }

        public string ToString(string format, IFormatProvider formatProvider, StiffnessUnit unit)
        {
            var quantity = unit.FromSiUnit(this.newtonsPerMetre);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Stiffness"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.Stiffness"/> object.
        /// </summary>
        /// <returns>
        /// A signed number indicating the relative quantitys of this instance and <paramref name="quantity"/>.
        /// 
        ///                     Value
        /// 
        ///                     Description
        /// 
        ///                     A negative integer
        /// 
        ///                     This instance is smaller than <paramref name="quantity"/>.
        /// 
        ///                     Zero
        /// 
        ///                     This instance is equal to <paramref name="quantity"/>.
        /// 
        ///                     A positive integer
        /// 
        ///                     This instance is larger than <paramref name="quantity"/>.
        /// 
        /// </returns>
        /// <param name="quantity">An instance of <see cref="T:MathNet.Spatial.Units.Stiffness"/> object to compare to this instance.</param>
        public int CompareTo(Stiffness quantity)
        {
            return this.newtonsPerMetre.CompareTo(quantity.newtonsPerMetre);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Stiffness"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Stiffness as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Stiffness"/> object to compare with this instance.</param>
        public bool Equals(Stiffness other)
        {
            return this.newtonsPerMetre.Equals(other.newtonsPerMetre);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Stiffness"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Stiffness as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Stiffness"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Stiffness other, double tolerance)
        {
            return Math.Abs(this.newtonsPerMetre - other.newtonsPerMetre) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Stiffness && this.Equals((Stiffness)obj);
        }

        public override int GetHashCode()
        {
            return this.newtonsPerMetre.GetHashCode();
        }

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, 
        /// you should return null (Nothing in Visual Basic) from this method, and instead, 
        /// if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the
        ///  <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> 
        /// method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public void ReadXml(XmlReader reader)
        {
            // Hacking set readonly fields here, can't think of a cleaner workaround
            XmlExt.SetReadonlyField(ref this, "newtonsPerMetre", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.newtonsPerMetre);
        }
    }
}