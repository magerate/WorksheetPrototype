using System;
using System.ComponentModel;
using System.Windows.Media;

namespace WorksheetPrototype
{
    public class MaterialInfo : INotifyPropertyChanged,IComparable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double m_salesPrice;
        private double m_costPrice;
        private double m_taxRate;

        public double TaxRate
        {
            get { return m_taxRate; }
            set 
            {
                if (value != m_taxRate)
                {
                    m_taxRate = value;
                    FirePropertyChanged("TaxRate");
                }
            }
        }

        public double CostPrice
        {
            get { return m_costPrice; }
            set
            {
                if (m_costPrice != value)
                {
                    m_costPrice = value;
                    FirePropertyChanged("CostPrice");
                    FirePropertyChanged("Margin");
                    FirePropertyChanged("Markup");
                }
            }
        }

        public double SalesPrice
        {
            get { return m_salesPrice; }
            set 
            {
                if (m_salesPrice != value)
                {
                    m_salesPrice = value;
                    FirePropertyChanged("SalesPrice");
                    FirePropertyChanged("Margin");
                    FirePropertyChanged("Markup");
                }
            }
        }

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Color DisplayColor { get; set; }
        public string Unit { get; set; }
        public MaterialType Type { get; set; }

        public virtual string Description
        {
            get { return string.Empty; }
        }

        public double Margin
        {
            get
            {
                if (SalesPrice == 0)
                {
                    return 0;
                }
                return (SalesPrice - CostPrice) / SalesPrice;
            }

            set
            {
                if (value >= 0 && value < 1)
                {
                    SalesPrice = CostPrice / (1 - value);
                    FirePropertyChanged("SalesPrice");
                    FirePropertyChanged("Margin");
                    FirePropertyChanged("Markup");
                }
            }
        }

        public double Markup
        {
            get
            {
                if (CostPrice == 0)
                {
                    return 0;
                }
                return (SalesPrice - CostPrice) / CostPrice;
            }

            set
            {
                if (value >= 0)
                {
                    SalesPrice = CostPrice * (1 + value);
                    FirePropertyChanged("SalesPrice");
                    FirePropertyChanged("Margin");
                    FirePropertyChanged("Markup");
                }
            }
        }

        public int CompareTo(object obj)
        {
            MaterialInfo mi = obj as MaterialInfo;
            if (null != mi)
            {
                return Description.CompareTo(mi.Description);
            }
            return -1;
        }
    }
}
