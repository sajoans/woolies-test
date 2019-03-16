using System;
using System.Collections.Generic;
using System.Text;

namespace WooliesTest.Exercise2.Model
{
    public class ShopperHistory
    {
        public long CustomerId { get; set; }
        public List<Product> Products { get; set; }
    }
}