using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace Second_lab
{
    class Auto_serialization
    {
        public static Discount_journal LoadFromXML(string path)
        {
            Discount_journal journal = new Discount_journal();
            DiscountJournalType currentList;

            XmlSerializer formatter = new XmlSerializer(typeof(DiscountJournalType));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                currentList = (DiscountJournalType)formatter.Deserialize(fs);
            }

            currentList.Discount.ToList().ForEach(o => journal.AddNewDiscount(o.Shop, o.SizeOfDiscount, o.ExpirationDate));

            return journal;
        }

        public static void SaveToXML(string path, Discount_journal journal)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(DiscountJournalType));

            DiscountJournalType currentList = new DiscountJournalType();
            var discounts = new List<DiscountType>();

            journal.DiscountList.ForEach(o => discounts.Add(new DiscountType(o.Shop, o.SizeOfDiscount, o.ExpirationDate)));
            currentList.Discount = discounts.ToArray();    /// эта строчка не понятна

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, currentList);
            }
        }
    }
}