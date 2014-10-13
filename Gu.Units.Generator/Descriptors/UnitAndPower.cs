﻿namespace Gu.Units.Generator
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;
    using Annotations;

    public class UnitAndPower : INotifyPropertyChanged
    {
        private IUnit _unit;
        private int _power;
        public UnitAndPower()
        {
            this.Unit = new SiUnit();
        }

        public UnitAndPower(SiUnit unit)
        {
            this.Unit = unit;
            Power = 1;
        }
      
        public UnitAndPower(SiUnit unit, int power)
        {
            if (power == 0)
            {
                throw new ArgumentException("power == 0", "power");
            }
            this.Unit = unit;
            Power = power;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static UnitAndPower Empty
        {
            get
            {
                return new UnitAndPower(new SiUnit(), 0);
            }
        }

        [XmlIgnore]
        public IUnit Unit
        {
            get { return this._unit; }
            set
            {
                if (Equals(value, this._unit))
                {
                    return;
                }
                this._unit = value;
                OnPropertyChanged();
                OnPropertyChanged("UnitName");
            }
        }

        public string UnitName
        {
            get
            {
                return this.Unit.ClassName;
            }
            set
            {
                this.Unit = new SiUnit { ClassName = value };
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

        public override string ToString()
        {
            if (Power == 1)
            {
                return this.Unit.ClassName;
            }
            return string.Format("{0}^{1}", this.Unit.ClassName, Power);
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
            return Equals(this._unit, other._unit) && this._power == other._power;
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
                return ((this._unit != null ? this._unit.GetHashCode() : 0) * 397) ^ this._power;
            }
        }
    }
}