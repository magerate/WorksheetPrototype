using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;

namespace WorksheetPrototype
{
    public class GroupHeaderTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NormalTemplate { get; set; }
        public DataTemplate MaterialTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
            {
                return base.SelectTemplate(item, container);
            }

            CollectionViewGroup group = item as CollectionViewGroup;
            if (group != null && group.Name is MaterialInfo)
            {
                return MaterialTemplate;
            }


            return NormalTemplate;
        }
    }
}
