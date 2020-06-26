using System;
using System.Linq;
using System.Collections.Generic;

namespace Second_lab
{
    class Discount_journal
    {
        private string discountJournalName;

        public List<Discount> DiscountList { get; private set; }

        public Discount_journal(string discountJournalName)
        {
            this.discountJournalName = discountJournalName;
        }

        public bool AddNewDiscount(string shop, int sizeOfDiscount, DateTime expirationDate)
        {
            if (DiscountList.Any(o => o.Shop == shop)) return false;

            DiscountList.Add(new Discount(shop, sizeOfDiscount, expirationDate));
            return true;
        }

        public bool DeleteDiscount(string shop)
        {
            if (!DiscountList.Any(o => o.Shop == shop)) return false;

            DiscountList.Remove(DiscountList.Find(o => o.Shop == shop));
            return true;
        }

        public List<Discount> GetSortList()
        {
            List<Discount> sortList = DiscountList.OrderBy(d => d.Shop).ToList();
            return sortList;
        }
    }
}
