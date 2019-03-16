using System;
using System.Collections.Generic;
using System.Linq;
using WooliesTest.Exercise2.Model;
using WooliesTest.Exercise2.Sorting;
using Xunit;

namespace WooliesTest.UnitTests
{
    public class ProductSorterByNameTests
    {
        [Theory]
        [MemberData(nameof(UnsortedProducts))]
        public void Should_Sort_Products_by_Name_In_Ascending_Order(IEnumerable<Product> products)
        {
            // Arrange
            var productSorter = new ProductSorterByName();

            // Act
            var sortedProducts = productSorter.Sort(products).Result.ToList();

            // Assert
            Assert.Equal("Product A", sortedProducts[0].Name);
            Assert.Equal("Product B", sortedProducts[1].Name);
            Assert.Equal("Product C", sortedProducts[2].Name);
        }

        [Theory]
        [MemberData(nameof(UnsortedProducts))]
        public void Should_Sort_Products_by_Name_In_Descending_Order(IEnumerable<Product> products)
        {
            // Arrange
            var productSorter = new ProductSorterByName(SortOrder.Descending);

            // Act
            var sortedProducts = productSorter.Sort(products).Result.ToList();

            // Assert
            Assert.Equal("Product C", sortedProducts[0].Name);
            Assert.Equal("Product B", sortedProducts[1].Name);
            Assert.Equal("Product A", sortedProducts[2].Name);
        }

        public static IEnumerable<Object[]> UnsortedProducts =>
            new List<Object[]>
            {
                new object[]
                {
                    new List<Product>()
                    {
                        new Product
                        {
                            Name = "Product C",
                            Quantity = 2.0M,
                            Price = 999M
                        },
                        new Product
                        {
                            Name = "Product B",
                            Quantity = 3.0M,
                            Price = 10M
                        },
                        new Product
                        {
                            Name = "Product A",
                            Quantity = 1.0M,
                            Price = 99M
                        }
                    }
                }
            };
    }
}