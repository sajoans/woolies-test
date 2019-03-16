using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WooliesTest.Common;
using WooliesTest.Exercise2.Model;

namespace WooliesTest.Exercise2.Services
{
    public class ShopperHistoryService : IShopperHistoryService
    {
        private readonly IHttpClient _httpClient;

        public ShopperHistoryService(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ShopperHistory>> GetShopperHistoryAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/resource/shopperHistory");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<ShopperHistory>>();
            }
            throw new Exception("Unable to connect to Products api");
        }
    }
}