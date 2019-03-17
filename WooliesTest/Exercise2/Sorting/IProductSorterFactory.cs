namespace WooliesTest.Exercise2.Sorting
{
    public interface IProductSorterFactory
    {
        IProductSorter Create(SortOptionType sortOption);
    }
}