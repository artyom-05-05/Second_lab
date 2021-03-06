﻿using System;

namespace Second_lab
{
    class Discount
    {
        public string Shop { get; private set; }
        public int SizeOfDiscount { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        public Discount(string shop, int sizeOfDiscount, DateTime expirationDate)
        {
            this.Shop = shop;
            this.SizeOfDiscount = sizeOfDiscount;
            this.ExpirationDate = expirationDate;
        }
    }
}