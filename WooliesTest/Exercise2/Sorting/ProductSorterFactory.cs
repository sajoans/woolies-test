using System;
using AzureFunctions.Autofac.Configuration;
using WooliesTest.Common;
using WooliesTest.Exercise2.Services;

namespace WooliesTest.Exercise2.Sorting
{
    public class ProductSorterFactory : IProductSorterFactory
    {
        private IShopperHistoryService _shopperHistoryService;

        public ProductSorterFactory(IShopperHistoryService shopperHistoryService)
        {
            _shopperHistoryService = shopperHistoryService;
        }

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
                    return new ProductSorterByPopularity(_shopperHistoryService, sortOrder: SortOrder.Descending);
            }

            throw new Exception("Invalid Sort Option");
        }
    }
}