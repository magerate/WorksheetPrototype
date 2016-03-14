using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;


namespace WorksheetPrototype
{
    public class ProposalItemCollection : ObservableCollection<ProposalItem>
    {

        public IEnumerable<ProposalItem> GroupMaterialItem()
        {
            return (from item in this
                    group item by item.Material).Select(i => new MaterialGroupItem(i));
        }

        protected override void InsertItem(int index, ProposalItem item)
        {
            base.InsertItem(index, item);
            item.PropertyChanged += ItemPropertyChange;
        }

        private void ItemPropertyChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CostAmount" ||
                e.PropertyName == "SalesAmount" ||
                e.PropertyName == "Profit")
            {
                OnPropertyChanged(new PropertyChangedEventArgs(e.PropertyName));
            }
        }

        protected override void RemoveItem(int index)
        {
            this[index].PropertyChanged -= ItemPropertyChange;
            base.RemoveItem(index);
        }

        protected override void SetItem(int index, ProposalItem item)
        {
            this[index].PropertyChanged -= ItemPropertyChange;
            base.SetItem(index, item);
            item.PropertyChanged += ItemPropertyChange;
        }

       

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
        }



        public PrecisionDouble SalesAmount
        {
            get { return this.Sum(item => item.SalesAmount); }
        }

        public PrecisionDouble CostAmount
        {
            get { return this.Sum(item => item.CostAmount); }
        }

        public PrecisionDouble Profit
        {
            get { return this.Sum(item => item.Profit); }
        }
    }
}
