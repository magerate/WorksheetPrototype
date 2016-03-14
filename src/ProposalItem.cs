using System;
using System.ComponentModel;
using System.Windows.Media;

namespace WorksheetPrototype
{
    public enum MaterialType
    {
        Material,
        Labor,
        Freight,
    }


    public class ProposalItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private MaterialInfo m_material;
        private Proposal m_proposal;
        private PrecisionDouble m_usedQuantity;


        protected ProposalItem()
        {
            Layer = string.Empty;
            Room = string.Empty;
        }

        public ProposalItem(MaterialInfo material, Proposal proposal)
        {
            if (material == null || proposal == null)
            {
                throw new ArgumentNullException();
            }
            m_material = material;
            m_proposal = proposal;

            m_material.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
            {
                switch (e.PropertyName)
                {
                    case "SalesPrice":
                        FirePropertyChanged("SalesAmount");
                        FirePropertyChanged("Total");
                        FirePropertyChanged("Profit");
                        break;
                    case "CostPrice":
                        FirePropertyChanged("CostAmount");
                        FirePropertyChanged("Profit");
                        break;
                    case "TaxRate":
                        FirePropertyChanged("TaxAmount");
                        FirePropertyChanged("Total");
                        break;
                    default:
                        break;
                }

            };
        }

        protected void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public virtual PrecisionDouble UsedQuantity
        {
            get { return m_usedQuantity; }
            set
            {
                if (m_usedQuantity != value)
                {
                    m_usedQuantity = value;
                    FirePropertyChanged("CostAmount");
                    FirePropertyChanged("SalesAmount");
                    FirePropertyChanged("Total");
                    FirePropertyChanged("TaxAmount");
                    FirePropertyChanged("Profit");
                }
            }
        }


        public virtual MaterialInfo Material
        {
            get { return m_material; }
        }

        public virtual PrecisionDouble EstimateQuantity { get; set; }

        public string Layer { get; set; }
        public string Room { get; set; }



        public virtual PrecisionDouble SalesAmount
        {
            get { return UsedQuantity * Material.SalesPrice; }
        }

        public virtual PrecisionDouble CostAmount
        {
            get { return UsedQuantity * Material.CostPrice; }
        }

        public virtual PrecisionDouble TaxAmount
        {
            get { return SalesAmount * Material.TaxRate; }
        }

        public virtual PrecisionDouble Total
        {
            get { return SalesAmount + TaxAmount; }
        }

        public PrecisionDouble Profit
        {
            get { return SalesAmount - CostAmount; }
        }
    }
}
