﻿namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;
    using Annotations;

    public class UnitAndPower : INotifyPropertyChanged
    {
        private IUnit _unit;
        private string _unitName;
        private int _power;
        private IUnit _parent;
        private UnitAndPower()
        {
        }

        public UnitAndPower(IUnit unit)
        {
            _unit = unit;
            _power = 1;
        }

        public UnitAndPower(IUnit unit, int power)
        {
            if (power == 0)
            {
                throw new ArgumentException("power == 0", "power");
            }
            _unit = unit;
            _power = power;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static readonly IEqualityComparer<UnitAndPower> Comparer = new UnitNamePowerEqualityComparer();

        [XmlIgnore]
        public IUnit Unit
        {
            get
            {
                return _unit ?? (_unit = Parent.Settings.AllUnits.Single(x => x.ClassName == _unitName));
            }
            set
            {
                if (Equals(value, _unit))
                {
                    return;
                }
                _unit = value;
                OnPropertyChanged();
                OnPropertyChanged("UnitName");
            }
        }

        public string UnitName
        {
            get
            {
                if (Unit != null)
                {
                    return this.Unit.ClassName;
                }
                return _unitName;
            }
            set
            {
                _unitName = value;
            }
        }

        public int Power
        {
            get { return _power; }
            set
            {
                if (value == _power)
                {
                    return;
                }
                _power = value;
                OnPropertyChanged();
            }
        }

        [XmlIgnore]
        public IUnit Parent
        {
            get { return _parent; }
            set
            {
                _parent = value;
                OnPropertyChanged();
                OnPropertyChanged("Unit");
            }
        }

        public static UnitAndPower operator ^(UnitAndPower up, int i)
        {
            return new UnitAndPower(up.Unit, up.Power * i);
        }

        public override string ToString()
        {
            if (Power == 1)
            {
                if (Unit == null)
                {
                    return string.Format("(({0})null)^1", UnitName);
                }
                return this.Unit.Symbol;
            }
            return string.Format("({0}){1}^{2}", this.Unit == null ? "null" : "", this.UnitName, Power);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected bool Equals(UnitAndPower other)
        {
            return Equals(_unit, other._unit) && _power == other._power;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((UnitAndPower)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_unit != null ? _unit.GetHashCode() : 0) * 397) ^ _power;
            }
        }

        private sealed class UnitNamePowerEqualityComparer : IEqualityComparer<UnitAndPower>
        {
            public bool Equals(UnitAndPower x, UnitAndPower y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }
                if (ReferenceEquals(x, null))
                {
                    return false;
                }
                if (ReferenceEquals(y, null))
                {
                    return false;
                }
                if (x.GetType() != y.GetType())
                {
                    return false;
                }
                return string.Equals(x.UnitName, y.UnitName) && x._power == y._power;
            }
            public int GetHashCode(UnitAndPower obj)
            {
                unchecked
                {
                    return ((obj._unitName != null ? obj._unitName.GetHashCode() : 0) * 397) ^ obj._power;
                }
            }
        }
    }
}
