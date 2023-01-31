using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public static class PostHttpTrigger
    {
        [FunctionName("PostHttp")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Post), Route = null)]
            HttpRequestMessage req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = default;
            var person = await req.Content.ReadAsAsync<Person>();

            ObjectResult result;
            string responseMessage = default;

            name = person.Name;

            if (string.IsNullOrEmpty(name))
            {
                responseMessage = "Provide a value";
                result = new OkObjectResult(responseMessage);
            }
            else
            {
                responseMessage = $"Hey {name} from body";
                result = new OkObjectResult(responseMessage);
            }
            return result;
        }
    }
}