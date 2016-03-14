using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorksheetPrototype
{
    public class CarpetItem : MaterialItem
    {
        public string SeamLength { get; set; }
        public string Dylot { get; set; }
        public double WasteRatio { get; set; }
    }
}
