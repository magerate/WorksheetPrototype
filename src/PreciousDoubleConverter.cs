using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;

namespace WorksheetPrototype
{
    public class PrecisionDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = value as string;
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }
            double result;
            if (double.TryParse(s, out result))
                return (PrecisionDouble)result;
            return null;
        }
    }
}
