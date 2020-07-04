using System;
using System.Linq;
using System.Xml.Linq;

namespace Second_lab
{
    class LINQ_to_XML
    {
        public static Discount_journal LoadFromXML(string path)
        {
            Discount_journal journal = new Discount_journal("Discount_journal_FROM_XML_File");

            XDocument.Load(path).Descendants("DiscountJournal").ToList().First().Descendants("Discount").ToList().
                ForEach(discount => journal.AddNewDiscount((string)discount.Element("Shop"), 
                (int)discount.Element("SizeOfDiscount"), (DateTime)discount.Element("ExpirationDate")));

            return journal;
        }

        public static void SaveToXML(string path, Discount_journal journal)
        {
            XNamespace xsd = "http://www.w3.org/2001/XMLSchema";
            XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";

            XDocument xdoc = new XDocument(new XElement("DiscountJournal",
                new XAttribute(XNamespace.Xmlns + "xsd", xsd.NamespaceName),
                new XAttribute(XNamespace.Xmlns + "xsi", xsi.NamespaceName),

                    journal.DiscountList.Select(o => new XElement("Discount",
                    new XElement[] { new XElement("Shop", o.Shop),
                                     new XElement("SizeOfDiscount", o.SizeOfDiscount),
                                     new XElement("ExpirationDate", o.ExpirationDate)})).ToArray()));
            xdoc.Save(path);
        }
    }
}