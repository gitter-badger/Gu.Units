﻿namespace Gu.Units.Generator
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Xml.Serialization;

    using Annotations;
    using WpfStuff;

    /// <summary>
    /// http://www.periodni.com/international_system_of_units.html
    /// </summary>
    public class SiUnit : UnitBase
    {
        public SiUnit()
            : base(null, null)
        {
        }

        public SiUnit(string name, string symbol)
            : base(name, symbol)
        {
        }

        [XmlIgnore]
        public override string UiName
        {
            get
            {
                return this.Symbol;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", this.UiName, this.Quantity == null ? "null" : this.Quantity.ClassName);
        }
    }
}
