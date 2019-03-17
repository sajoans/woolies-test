using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WooliesTest.Common
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string path);
    }

    public class WooliesHttpClient : IHttpClient
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public WooliesHttpClient()
        {
            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri("http://dev-wooliesx-recruitment.azurewebsites.net/");
            }
        }

        public async Task<HttpResponseMessage> GetAsync(string path)
        {
            path = path + $"?token={Globals.ApiToken}";
            return await _httpClient.GetAsync(path);
        }
    }
}