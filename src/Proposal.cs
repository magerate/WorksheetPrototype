using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorksheetPrototype
{
    public class Proposal
    {
        private ProposalItemCollection m_items = new ProposalItemCollection();
        private Dictionary<string, MaterialInfo> m_materials = new Dictionary<string, MaterialInfo>();

        public Dictionary<string, MaterialInfo> Materials
        {
            get { return m_materials; }
        }

        public ProposalItemCollection Items
        {
            get { return m_items; }
        }

        public RoundMode QuantityMode { get; set; }
        public int QuantityDigits { get; set; }
    }
}
