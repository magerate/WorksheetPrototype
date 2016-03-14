using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Xml.Linq;
using System.IO;

namespace WorksheetPrototype
{
    public class ProposalImporter
    {
        public Proposal Load(Stream stream)
        {
            XElement root = XElement.Load(stream);
            XElement room =
                (from item in root.Element("proposals").Elements("Proposal")
                 where item.Element("type").Value == "1"
                 select item).First();
            return LoadProposal(room);
        }

        public Proposal Load(string fileName)
        {
            return Load(File.OpenRead(fileName));
        }

        private Proposal LoadProposal(XElement element)
        {
            Proposal proposal = new Proposal();
            LoadMaterial(proposal, element.Element("materialInfoItems"));
            LoadItems(proposal, element.Element("Items"));
            return proposal;
        }

        private void LoadMaterial(Proposal proposal, XElement element)
        {
            if (element == null)
            {
                return;
            }
            foreach (var item in element.Elements("item"))
            {
                MaterialInfo material = new ProductInfo();
                proposal.Materials.Add(item.Attribute("id").Value, material);

                material.CostPrice = double.Parse(item.Element("materialInfo").Attribute("CostPrice").Value);
                material.SalesPrice = double.Parse(item.Element("materialInfo").Attribute("SalesPrice").Value);
                material.TaxRate = double.Parse(item.Element("materialInfo").Attribute("TaxRate").Value)/100;
            }
        }

        private void LoadItems(Proposal proposal, XElement element)
        {
            foreach (var layer in element.Elements("Item"))
            {
                foreach (var room in layer.Elements("Item"))
                {
                    foreach (var item in room.Elements("Item"))
                    {
                        string id = item.Attribute("StyleNumber").Value + "|" + item.Attribute("ColorNumber").Value;
                        ProductInfo product = proposal.Materials[id] as ProductInfo;
                        LoadProductInfo(product, item);
                        ProposalItem pi = new ProposalItem(product, proposal);
                        proposal.Items.Add(pi);
                        pi.Layer = layer.Attribute("Layer").Value;
                        pi.Room = layer.Attribute("Room").Value;
                        if (string.IsNullOrEmpty(pi.Room))
                        {
                            pi.Room = item.Attribute("Room").Value;
                        }
                        LoadProposalItem(pi, item);
                    }
                }
            }
        }

        private void LoadProductInfo(ProductInfo product,XElement element)
        {
            product.Trade = element.Attribute("Trade").Value;
            product.Type = (MaterialType)int.Parse(element.Attribute("MaterialType").Value);
            product.Manufacturer = element.Attribute("Manufactory").Value;
            product.SKU = element.Attribute("Sku").Value;
            product.StyleCode = element.Attribute("StyleNumber").Value;
            product.StyleName = element.Attribute("StyleName").Value;
            product.ColorCode = element.Attribute("ColorNumber").Value;
            product.ColorName = element.Attribute("ColorName").Value;
            product.DisplayColor = ParseColor(element.Attribute("DisplayColor").Value);
        }

        private Color ParseColor(string s)
        {
            string[] values = s.Split('(', ',', ')');
            return Color.FromRgb(byte.Parse(values[1]), byte.Parse(values[2]), byte.Parse(values[3]));
        }

        private void LoadProposalItem(ProposalItem item,XElement element)
        {
            item.EstimateQuantity = double.Parse(element.Attribute("Qty").Value);
            item.UsedQuantity = item.EstimateQuantity;
        }
    }
}
