using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WooliesTest
{
    public static class Exercise1Function
    {
        [FunctionName("user")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            HttpRequest req, ILogger log)
        {
            return (ActionResult)new OkObjectResult(new { name = "Sajan Suwal", token = Globals.ApiToken });
        }
    }
}