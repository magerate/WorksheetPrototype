using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Reflection;

namespace WorksheetPrototype
{
    public class GroupMarginConverter : IValueConverter
    {
        public CollectionView View { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null == value)
            {
                return new Thickness();
            }

            int level = GetGroupLevel(value as CollectionViewGroup);
            return new Thickness((level - 1) * 8, 0, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // If necessary, here you can convert back. Check if which brush it is (if its one),
            // get its Color-value and return it.

            throw new NotImplementedException();
        }

        private int GetGroupLevel(CollectionViewGroup group)
        {
            int level = 0;
            object parent = group;
            while (true)
            {
                Type type = parent.GetType();
                PropertyInfo pi = type.GetProperty("Parent", BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic);
                parent = pi.GetValue(parent, null);

                if (null == parent)
                {
                    break;
                }
                level++;
            }
            return level;
        }
    }
}
