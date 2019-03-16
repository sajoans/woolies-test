using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WooliesTest.Common;
using WooliesTest.Exercise2.Model;

namespace WooliesTest.Exercise2.Services
{
    public class ProductsService
    {
        private readonly IHttpClient _httpClient;

        public ProductsService(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/resource/products");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<Product>>();
            }
            throw new Exception("Unable to connect to Products api");
        }
    }
}