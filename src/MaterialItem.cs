using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorksheetPrototype
{
    public class MaterialItem
    {
        public string Description
        {
            get { return StyleCode + ColorCode; }
        }

        public string StyleCode { get; set; }
        public string StyleName { get; set; }

        public string ColorCode { get; set; }
        public string ColorName { get; set; }

        public string SKU { get; set; }
        public string Manufacturer { get; set; }
    }
}
