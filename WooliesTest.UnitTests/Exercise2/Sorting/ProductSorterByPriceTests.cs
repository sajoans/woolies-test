using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooliesTest.Exercise2.Model;
using WooliesTest.Exercise2.Sorting;
using Xunit;

namespace WooliesTest.UnitTests
{
    public class ProductSorterByPriceTests
    {
        [Theory]
        [MemberData(nameof(UnsortedProducts))]
        public async Task Should_Sort_Products_by_Price_In_Ascending_Order(IEnumerable<Product> products)
        {
            // Arrange
            var productSorter = new ProductSorterByPrice();

            // Act
            var sortedProducts = (await productSorter.Sort(products)).ToList();

            // Assert
            Assert.Equal(10M, sortedProducts[0].Price);
            Assert.Equal(99M, sortedProducts[1].Price);
            Assert.Equal(999M, sortedProducts[2].Price);
        }

        [Theory]
        [MemberData(nameof(UnsortedProducts))]
        public async Task Should_Sort_Products_by_Price_In_Descending_Order(IEnumerable<Product> products)
        {
            // Arrange
            var productSorter = new ProductSorterByPrice(SortOrder.Descending);

            // Act
            var sortedProducts = (await productSorter.Sort(products)).ToList();

            // Assert
            Assert.Equal(999M, sortedProducts[0].Price);
            Assert.Equal(99M, sortedProducts[1].Price);
            Assert.Equal(10M, sortedProducts[2].Price);
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