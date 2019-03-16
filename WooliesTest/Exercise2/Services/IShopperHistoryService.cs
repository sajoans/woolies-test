using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesTest.Exercise2.Model;

namespace WooliesTest.Exercise2.Services
{
    public interface IShopperHistoryService
    {
        Task<IEnumerable<ShopperHistory>> GetShopperHistoryAsync();
    }
}