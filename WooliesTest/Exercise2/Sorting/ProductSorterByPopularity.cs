using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooliesTest.Common;
using WooliesTest.Exercise2.Model;
using WooliesTest.Exercise2.Services;

namespace WooliesTest.Exercise2.Sorting
{
    public class ProductSorterByPopularity : IProductSorter
    {
        public SortOrder SortOrder { get; }
        private readonly IShopperHistoryService _shopperHistoryService;

        public ProductSorterByPopularity(IShopperHistoryService shopperHistoryService, SortOrder sortOrder = SortOrder.Ascending)
        {
            _shopperHistoryService = shopperHistoryService;
            SortOrder = sortOrder;
        }

        public async Task<IEnumerable<Product>> Sort(IEnumerable<Product> products)
        {
            var shopperHistory = await new ShopperHistoryService(new WooliesHttpClient()).GetShopperHistoryAsync();
            var productPopularity = shopperHistory.SelectMany(p => p.Products)
                .GroupBy(p => p.Name)
                .Select(x => new { Name = x.Key, QtySold = x.Sum(o => o.Quantity) });

            var result = (from product in products
                          join productSales in productPopularity on product.Name equals productSales.Name into joinedList
                          from productSales in joinedList.DefaultIfEmpty()
                          select new
                          {
                              Product = product,
                              Count = productSales?.QtySold ?? 0
                          }).OrderByDescending(p => p.Count).ToList();

            return result.Select(o => o.Product).ToList();
        }
    }
}