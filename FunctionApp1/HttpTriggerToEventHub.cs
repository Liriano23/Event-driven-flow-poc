using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace FunctionApp1
{
    public static class HttpTriggerToEventHub
    {
        [FunctionName(nameof(HttpTriggerToEventHub))]
        [return: EventHub("poc-event-hub", Connection = "EventHubConnectionAppSetting")]
        public static string Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Post), Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            log.LogInformation($"Content: {req.Content.ReadAsStringAsync().Result}");
            //for (int i = 0; i < 10; i++)
            //{
            //    list.Add($"This is event {i}");
            //}

            return "This is an event";

            //return list;
        }
    }
}