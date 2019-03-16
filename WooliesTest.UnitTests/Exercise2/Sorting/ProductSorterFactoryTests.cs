using System;
using WooliesTest.Exercise2.Sorting;
using Xunit;

namespace WooliesTest.UnitTests
{
    public class ProductSorterFactoryTests
    {
        private readonly ProductSorterFactory _productSorterFactory = new ProductSorterFactory();

        [Theory]
        [InlineData(SortOptionType.Descending, typeof(ProductSorterByName), SortOrder.Descending)]
        [InlineData(SortOptionType.Ascending, typeof(ProductSorterByName))]
        [InlineData(SortOptionType.Low, typeof(ProductSorterByPrice))]
        [InlineData(SortOptionType.High, typeof(ProductSorterByPrice), SortOrder.Descending)]
        [InlineData(SortOptionType.Recommended, typeof(ProductSorterByPopularity), SortOrder.Descending)]
        public void Should_create_correct_ProductSorter_for_given_sortOption(SortOptionType sortOption, Type productSorterType, SortOrder sortOrder = SortOrder.Ascending)
        {
            // Act
            var productSorter = _productSorterFactory.Create(sortOption);

            // Assert
            Assert.Equal(productSorter.GetType(), productSorterType);
            Assert.Equal(productSorter.SortOrder, sortOrder);
        }
    }
}