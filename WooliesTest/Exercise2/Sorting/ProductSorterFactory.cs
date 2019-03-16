using System;
using WooliesTest.Common;
using WooliesTest.Exercise2.Services;

namespace WooliesTest.Exercise2.Sorting
{
    public class ProductSorterFactory
    {
        public IProductSorter Create(SortOptionType sortOption)
        {
            switch (sortOption)
            {
                case SortOptionType.Low:
                    return new ProductSorterByPrice();

                case SortOptionType.High:
                    return new ProductSorterByPrice(SortOrder.Descending);

                case SortOptionType.Ascending:
                    return new ProductSorterByName();

                case SortOptionType.Descending:
                    return new ProductSorterByName(SortOrder.Descending);

                case SortOptionType.Recommended:
                    return new ProductSorterByPopularity(new ShopperHistoryService(new WooliesHttpClient()), SortOrder.Descending);
            }

            throw new Exception("Invalid Sort Option");
        }
    }
}