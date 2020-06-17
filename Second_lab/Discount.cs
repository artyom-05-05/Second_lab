using System;

namespace Second_lab
{
    class Discount
    {
        private readonly string shop;
        private readonly int sizeOfDiscount;
        private readonly DateTime expirationDate;

        public Discount(string shop, int sizeOfDiscount, DateTime expirationDate)
        {
            this.shop = shop;
            this.sizeOfDiscount = sizeOfDiscount;
            this.expirationDate = expirationDate;
        }

        public string GetShop() { return this.shop; }

        public int GetSizeOfDiscount() { return this.sizeOfDiscount; }

        public DateTime GetExpirationDate() { return this.expirationDate; }
    }
}
