using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;

namespace WorksheetPrototype
{
    //material of all items should be identical
    public class MaterialGroupItem : ProposalItem
    {
        private IEnumerable<ProposalItem> m_items;

        public MaterialGroupItem(IEnumerable<ProposalItem> items)
        {
            Debug.Assert(items != null && items.Count() > 0);
            if (items == null)
            {
                throw new ArgumentNullException();
            }

            if (items.Count() == 0 || !IsSameMaterial(items))
            {
                throw new ArgumentException();
            }

            m_items = items;

            items.First().Material.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
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
                    default:
                        break;
                }
            };
        }

        private bool IsSameMaterial(IEnumerable<ProposalItem> items)
        {
            var first = items.First();
            foreach (var item in items)
            {
                if (item.Material != first.Material)
                    return false;
            }
            return true;
        }

        public override PrecisionDouble EstimateQuantity
        {
            get { return m_items.Sum(item => item.EstimateQuantity); }
            set { m_items.First().EstimateQuantity += value - EstimateQuantity; }
        }

        public override PrecisionDouble UsedQuantity
        {
            get { return m_items.Sum(item => item.UsedQuantity); }
            set 
            {
                var amount = value - UsedQuantity;
                m_items.First().UsedQuantity += amount;
                FirePropertyChanged("CostAmount");
                FirePropertyChanged("SalesAmount");
                FirePropertyChanged("Total");
                FirePropertyChanged("Profit");
            }
        }


        public override MaterialInfo Material
        {
            get { return m_items.First().Material; }
        }

        public override PrecisionDouble CostAmount
        {
            get { return m_items.Sum(item => item.CostAmount); }
        }

        public override PrecisionDouble SalesAmount
        {
            get { return m_items.Sum(item => item.SalesAmount); }
        }

        public override PrecisionDouble TaxAmount
        {
            get { return m_items.Sum(item => item.TaxAmount); }
        }

        public override PrecisionDouble Total
        {
            get { return m_items.Sum(item => item.Total); }
        }
    }
}
