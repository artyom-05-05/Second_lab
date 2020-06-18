using System;
using System.Linq;
using System.Collections.Generic;

namespace Second_lab
{
    class Discount_journal
    {
        private readonly string discountJournalName;
        private List<Discount> journal = new List<Discount>();

        public Discount_journal(String discountJournalName)
        {
            this.discountJournalName = discountJournalName;
        }

        public bool AddNewDiscount(string shop, int sizeOfDiscount, DateTime expirationDate)
        {
            if (journal.Any(o => o.Shop == shop)) return false;

            journal.Add(new Discount(shop, sizeOfDiscount, expirationDate));
            return true;
        }

        public bool DeleteDiscount(string shop)
        {
            if (!journal.Any(o => o.Shop == shop)) return false;

            journal.Remove(journal.Find(o => o.Shop == shop));
            return true;
        }

        public List<Discount> GetSortList()
        {
            List<Discount> sortList = journal.OrderBy(d => d.Shop).ToList();
            return sortList;
        }
    }
}
