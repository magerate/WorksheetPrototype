using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WorksheetPrototype
{
    public class ColumnInfo
    {
        public double Width { get; set; }
        public int DisplayIndex { get; set; }
        public Visibility Visibility { get; set; }

        public ColumnInfo(){}

        public ColumnInfo(double width,int index,Visibility visibility)
        {
            this.Width = width;
            this.DisplayIndex = index;
            this.Visibility = visibility;
        }
    }
}
