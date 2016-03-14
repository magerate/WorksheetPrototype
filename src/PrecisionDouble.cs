using System;

namespace WorksheetPrototype
{
    public enum RoundMode
    {
        Ceiling,
        Floor,
        Round,
    }

    public struct PrecisionDouble : IComparable<PrecisionDouble>,IComparable
    {
        private double m_value;
        private int m_fractionalDigits;

        public int FractionalDigits
        {
            get { return m_fractionalDigits; }
            set
            {
                if (value < 0 | value > 15)
                {
                    throw new ArgumentOutOfRangeException();
                }
                m_fractionalDigits = value;
            }
        }

        public PrecisionDouble(double value)
        {
            m_value = value;
            m_fractionalDigits = 2;
        }

        public PrecisionDouble(double value, int digits)
        {
            m_value = value;

            if (digits < 0 | digits > 15)
            {
                throw new ArgumentOutOfRangeException();
            }
            m_fractionalDigits = digits;
        }

        public double Value
        {
            get { return Math.Round(m_value, m_fractionalDigits); }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is PrecisionDouble))
            {
                return false;
            }
            return Equals((PrecisionDouble)obj);
        }

        public bool Equals(PrecisionDouble number)
        {
            return Value == number.Value;
        }

        public override string ToString()
        {
            return Value.ToString("F" + m_fractionalDigits.ToString());
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static PrecisionDouble operator +(PrecisionDouble number1, PrecisionDouble number2)
        {
            return new PrecisionDouble(number1.Value + number2.Value, Math.Max(number1.FractionalDigits, number2.FractionalDigits));
        }

        public static PrecisionDouble operator -(PrecisionDouble number1, PrecisionDouble number2)
        {
            return new PrecisionDouble(number1.Value - number2.Value, Math.Max(number1.FractionalDigits, number2.FractionalDigits));
        }

        public static PrecisionDouble operator *(PrecisionDouble number1, PrecisionDouble number2)
        {
            return new PrecisionDouble(number1.Value * number2.Value, Math.Max(number1.FractionalDigits, number2.FractionalDigits));
        }

        public static PrecisionDouble operator /(PrecisionDouble number1, PrecisionDouble number2)
        {
            return new PrecisionDouble(number1.Value / number2.Value, Math.Max(number1.FractionalDigits, number2.FractionalDigits));
        }

        public static implicit operator double(PrecisionDouble number)
        {
            return number.Value;
        }

        public static implicit operator PrecisionDouble(double d)
        {
            return new PrecisionDouble(d, 2);
        }

        //public string ToString(string format)
        //{
        //    return Value.ToString(format);
        //}

        public int CompareTo(PrecisionDouble value)
        {
            return Value.CompareTo(value.Value);
        }

        public int CompareTo(object obj)
        {
            if (obj is PrecisionDouble)
            {
                return CompareTo((PrecisionDouble)obj);
            }
            return -1;
        }
    }
}
