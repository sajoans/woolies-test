using System;
using System.Collections.Generic;
using System.Text;
using WooliesTest.Exercise2.Model;

namespace WooliesTest.Exercise3.Trolley.Model
{
    public class Trolley
    {
        public List<ProductPrice> Products { get; set; }
        public List<Special> Specials { get; set; }
        public List<ProductQuantity> Quantities { get; set; }
    }

    public class ProductPrice
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Special
    {
        public List<ProductQuantity> Quantities { get; set; }
        public Decimal Total { get; set; }
    }

    public class ProductQuantity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}