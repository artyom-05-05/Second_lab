using System;
using System.Linq;
using System.Xml;

namespace Second_lab
{
    class XML_Document
    {
        public static void SaveToXML(string path, Discount_journal journal)
        {
            XmlDocument xdoc = new XmlDocument();

            XmlElement xroot = xdoc.CreateElement("DiscountJournal");
            xroot.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            xroot.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");

            journal.DiscountList.ForEach(discount =>
            {
                XmlElement disEl = xdoc.CreateElement("Discount");

                XmlElement shopEl = xdoc.CreateElement("Shop");
                shopEl.InnerText = discount.Shop;
                disEl.AppendChild(shopEl);

                XmlElement sizeOfDisEl = xdoc.CreateElement("SizeOfDiscount");
                sizeOfDisEl.InnerText = discount.SizeOfDiscount.ToString();
                disEl.AppendChild(sizeOfDisEl);

                XmlElement expirationDateEl = xdoc.CreateElement("ExpirationDate");
                expirationDateEl.InnerText = discount.ExpirationDate.ToString("dd-MM-yyyy");
                disEl.AppendChild(expirationDateEl);

                xroot.AppendChild(disEl);
            }
                );

            xdoc.AppendChild(xroot);
            xdoc.Save(path);
        }

        public static Discount_journal LoadFromXML(string path)
        {
            Discount_journal journal = new Discount_journal();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);

            foreach (var disEl in xDoc.ChildNodes.OfType<XmlElement>().Where(e => e.Name == "DiscountJournal"))
                foreach (var data in disEl.ChildNodes.OfType<XmlElement>().Where(e => e.Name == "Discount"))
                {
                    journal.AddNewDiscount(
                        data.SelectSingleNode("Shop").InnerText,
                        int.Parse(data.GetElementsByTagName("SizeOfDiscount").Item(0).InnerText),
                        DateTime.Parse(data.GetElementsByTagName("ExpirationDate").Item(0).InnerText));
                }
            return journal;
        }
    }
}