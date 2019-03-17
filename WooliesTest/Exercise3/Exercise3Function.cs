using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WooliesTest.Exercise3.Trolley;
using WooliesTest.Exercise3.Trolley.Model;

namespace WooliesTest
{
    public static class Exercise3Function
    {
        [FunctionName("trolleyTotal")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]
            HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<Trolley>(requestBody);
            var trolleyCalculator = new TrolleyCalculator();

            return (ActionResult)new OkObjectResult(trolleyCalculator.Calculate(data));
        }
    }
}