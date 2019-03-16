using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using WooliesTest.Exercise2.Model;
using WooliesTest.Exercise2.Services;
using WooliesTest.Exercise2.Sorting;
using Xunit;

namespace WooliesTest.UnitTests
{
    public class ProductSorterByPopularityTests
    {
        [Theory]
        [MemberData(nameof(UnsortedProducts))]
        public async Task Should_Sort_Products_by_Popularity_in_descending_order(IEnumerable<Product> products)
        {
            // Arrange
            var mockedShopperHistoryService = Mock.Of<IShopperHistoryService>();
            var testShopperHistory = new List<ShopperHistory>
            {
                new ShopperHistory()
                {
                    CustomerId = 21,
                    Products = new List<Product>()
                    {
                        new Product() {Name = "Product A", Price = 10M, Quantity = 2M},
                        new Product() {Name = "Product B", Price = 10M, Quantity = 3M}
                    }
                },
                new ShopperHistory()
                {
                    CustomerId = 22,
                    Products = new List<Product>()
                    {
                        new Product() {Name = "Product A", Price = 10M, Quantity = 1M},
                        new Product() {Name = "Product B", Price = 10M, Quantity = 3M}
                    }
                }
            };
            Mock.Get(mockedShopperHistoryService).Setup(x => x.GetShopperHistoryAsync())
                .ReturnsAsync(testShopperHistory);
            var productSorter = new ProductSorterByPopularity(mockedShopperHistoryService, SortOrder.Descending);

            // Act
            var sortedProducts = (await productSorter.Sort(products)).ToList();

            // Assert
            Assert.Equal("Product B", sortedProducts[0].Name);
            Assert.Equal("Product A", sortedProducts[1].Name);
            Assert.Equal("Product C", sortedProducts[2].Name);
            Mock.Get(mockedShopperHistoryService).Verify(x => x.GetShopperHistoryAsync(), Times.Once);
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