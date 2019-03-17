using System;
using Moq;
using WooliesTest.Exercise2.Services;
using WooliesTest.Exercise2.Sorting;
using Xunit;

namespace WooliesTest.UnitTests
{
    public class ProductSorterFactoryTests
    {
        [Theory]
        [InlineData(SortOptionType.Descending, typeof(ProductSorterByName), SortOrder.Descending)]
        [InlineData(SortOptionType.Ascending, typeof(ProductSorterByName))]
        [InlineData(SortOptionType.Low, typeof(ProductSorterByPrice))]
        [InlineData(SortOptionType.High, typeof(ProductSorterByPrice), SortOrder.Descending)]
        [InlineData(SortOptionType.Recommended, typeof(ProductSorterByPopularity), SortOrder.Descending)]
        public void Should_create_correct_ProductSorter_for_given_sortOption(SortOptionType sortOption, Type productSorterType, SortOrder sortOrder = SortOrder.Ascending)
        {
            // Arrange
            var mockedShopperHistoryService = Mock.Of<IShopperHistoryService>();
            var productSorterFactory = new ProductSorterFactory(mockedShopperHistoryService);

            // Act
            var productSorter = productSorterFactory.Create(sortOption);

            // Assert
            Assert.Equal(productSorter.GetType(), productSorterType);
            Assert.Equal(productSorter.SortOrder, sortOrder);
        }
    }
}