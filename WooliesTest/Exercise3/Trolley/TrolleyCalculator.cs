using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WooliesTest.Exercise3.Trolley.Model;

namespace WooliesTest.Exercise3.Trolley
{
    public class TrolleyCalculator
    {
        public decimal Calculate(Model.Trolley trolley)
        {
            var productQuantities = trolley.Quantities;
            var specialsTotal = trolley.Specials.Sum(x => x.Total);

            var specialQuantities = trolley.Specials.SelectMany(x => x.Quantities);

            // reduce from product quantities
            foreach (var quantity in specialQuantities)
            {
                productQuantities.Single(x => x.Name == quantity.Name).Quantity -= quantity.Quantity;
            }

            // add remaining product quantities to total
            var productsWithDetails = from product in trolley.Products
                                      join quantity in productQuantities
                                          on product.Name equals quantity.Name
                                      select new
                                      {
                                          product.Name,
                                          product.Price,
                                          quantity.Quantity,
                                          total = quantity.Quantity * product.Price
                                      };

            var remainingTotal = productsWithDetails.Sum(x => x.total);

            return specialsTotal + remainingTotal;
        }
    }
}