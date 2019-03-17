using System;
using System.Threading.Tasks;
using AzureFunctions.Autofac;
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
    [DependencyInjectionConfig(typeof(DIConfig))]
    public static class Exercise2Function
    {
        [FunctionName("sort")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            HttpRequest req,
            ILogger log,
            [Inject]IProductsService productsService,
            [Inject]IProductSorterFactory productSorterFactory
            )
        {
            string sortOption = req.Query["sortOption"];
            if (!Enum.TryParse(sortOption, true, out SortOptionType sortOptionType))
            {
                return new BadRequestResult();
            }
            var productSorter = productSorterFactory.Create(sortOptionType);
            var products = await productsService.GetProductsAsync();
            return (ActionResult)new OkObjectResult(await productSorter.Sort(products));
        }
    }
}