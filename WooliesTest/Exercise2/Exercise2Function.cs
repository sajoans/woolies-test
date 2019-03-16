using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WooliesTest.Common;
using WooliesTest.Exercise2.Services;
using WooliesTest.Exercise2.Sorting;

namespace WooliesTest.Exercise2
{
    public static class Exercise2Function
    {
        [FunctionName("sort")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            HttpRequest req, ILogger log)
        {
            string sortOption = req.Query["sortOption"];
            SortOptionType sortOptionType;
            var productsService = new ProductsService(new WooliesHttpClient());
            var products = await productsService.GetProductsAsync();
            if (!Enum.TryParse(sortOption, true, out sortOptionType))
            {
                return new BadRequestResult();
            }

            var productSorter = new ProductSorterFactory().Create(sortOptionType);
            return (ActionResult)new OkObjectResult(await productSorter.Sort(products));
        }
    }
}