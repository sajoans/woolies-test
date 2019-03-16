using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooliesTest.Exercise2.Model;

namespace WooliesTest.Exercise2.Sorting
{
    public class ProductSorterByName : IProductSorter
    {
        public SortOrder SortOrder { get; }

        public ProductSorterByName(SortOrder sortOrder = SortOrder.Ascending)
        {
            SortOrder = sortOrder;
        }

        public async Task<IEnumerable<Product>> Sort(IEnumerable<Product> products)
        {
            return SortOrder == SortOrder.Ascending
                ? products.OrderBy(p => p.Name)
                : products.OrderByDescending(p => p.Name);
        }
    }
}