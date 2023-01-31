using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public static class HttpTriggerToEventHub
    {
        private const string EventHubConnectionAppSetting = "Endpoint=sb://event-driven-poc-hub-test1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=gkwI1lWT8gH5HO77Rw4cnY5B7NCnNQFiTo4M1kM9wDA=";

        [FunctionName(nameof(HttpTriggerToEventHub))]
        [return: EventHub("poc-event-hub", Connection = "EventHubConnectionAppSetting")]
        public static Task<string> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Post), Route = null)] HttpRequest req)
        {
            List<string> list = new List<string>();

            //for (int i = 0; i < 10; i++)
            //{
            //    list.Add($"This is event {i}");
            //}

            return Task.FromResult("This is an event");

            //return list;
        }
    }
}