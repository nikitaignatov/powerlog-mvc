using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerLog.Model
{
    public class Weight
    {
        private readonly double poundToKgRatio = 2.2f;
        private double _value;

        public double Kilograms
        {
            get { return Math.Round(_value / 0.5) * 0.5; }
            set { _value = value; }
        }

        public double Pounds
        {
            get { return Math.Round((_value * poundToKgRatio) / 2.5) * 2.5; }
            set { _value = Math.Round(value / poundToKgRatio); }
        }

        public double WeightIn(WeightUnit unit)
        {
            switch (unit)
            {
                case WeightUnit.Kilogram:
                    return Kilograms;
                case WeightUnit.Pound:
                    return Pounds;
                default:
                    throw new ArgumentOutOfRangeException("unit");
            }
        }

        public static string LabelIn(WeightUnit unit)
        {
            switch (unit)
            {
                case WeightUnit.Kilogram:
                    return "kgs";
                case WeightUnit.Pound:
                    return "lbs";
                default:
                    throw new ArgumentOutOfRangeException("unit");
            }
        }
    }

    public enum WeightUnit
    {
        Kilogram,
        Pound
    }
}
