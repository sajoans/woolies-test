using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesTest.Exercise2.Model;

namespace WooliesTest.Exercise2.Sorting
{
    public interface IProductSorter
    {
        SortOrder SortOrder { get; }

        Task<IEnumerable<Product>> Sort(IEnumerable<Product> products);
    }
}