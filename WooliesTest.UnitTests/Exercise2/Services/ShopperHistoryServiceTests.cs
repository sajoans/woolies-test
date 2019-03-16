using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Moq;
using WooliesTest.Common;
using WooliesTest.Exercise2.Model;
using WooliesTest.Exercise2.Services;
using WooliesTest.Exercise2.Sorting;
using Xunit;

namespace WooliesTest.UnitTests.Exercise2.Services
{
    public class ShopperHistoryServiceTests
    {
        private readonly List<ShopperHistory> _testShopperHistory;

        public ShopperHistoryServiceTests()
        {
            _testShopperHistory = new List<ShopperHistory>
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
        }

        [Fact]
        public async Task Should_call_woolies_endpoint_to_retrieve_shopperHistory()
        {
            // Arrange
            var mockedHttpClient = Mock.Of<IHttpClient>();
            var shopperHistoryService = new ShopperHistoryService(mockedHttpClient);
            var mockedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<ShopperHistory>>(
                    _testShopperHistory, new JsonMediaTypeFormatter())
            };

            Mock.Get(mockedHttpClient).Setup(x => x.GetAsync("api/resource/shopperHistory"))
                .ReturnsAsync(mockedResponse);

            // Act
            var shopperHistoryData = (await shopperHistoryService.GetShopperHistoryAsync()).ToList();

            // Assert
            Assert.True(_testShopperHistory.SequenceEqual(shopperHistoryData));
            Mock.Get(mockedHttpClient).Verify(x => x.GetAsync("api/resource/shopperHistory"), Times.Once);
        }
    }
}