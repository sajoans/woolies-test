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
    public class ProductsServiceTests
    {
        private readonly List<Product> _testProductList;

        public ProductsServiceTests()
        {
            _testProductList = new List<Product>()
            {
                new Product() {Name = "Product A", Price = 10M, Quantity = 2M},
                new Product() {Name = "Product B", Price = 10M, Quantity = 3M}
            };
        }

        [Fact]
        public async Task Should_call_woolies_endpoint_to_retrieve_product_list()
        {
            // Arrange
            var mockedHttpClient = Mock.Of<IHttpClient>();
            var productsService = new ProductsService(mockedHttpClient);
            var mockedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Product>>(
                    _testProductList, new JsonMediaTypeFormatter())
            };

            Mock.Get(mockedHttpClient).Setup(x => x.GetAsync("api/resource/products"))
                .ReturnsAsync(mockedResponse);

            // Act
            var productsServiceData = (await productsService.GetProductsAsync()).ToList();

            // Assert
            Assert.True(_testProductList.SequenceEqual(productsServiceData));
            Mock.Get(mockedHttpClient).Verify(x => x.GetAsync("api/resource/products"), Times.Once);
        }
    }
}