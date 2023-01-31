using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public static class Function2
    {
        [FunctionName("HttExample2")]
        public static async Task Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            System.Console.WriteLine("Starting our Event Huv Producer");
            string namespaceConnectionString = "Endpoint=sb://event-driven-poc-hub-test1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=gkwI1lWT8gH5HO77Rw4cnY5B7NCnNQFiTo4M1kM9wDA=";
            string eventHubNmae = "poc-event-hub";

            EventHubProducerClient producer = new EventHubProducerClient(namespaceConnectionString, eventHubNmae);

            List<EventData> list = new List<EventData>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(new EventData($"This is event {i}"));
            }

            await producer.SendAsync(list);
            System.Console.WriteLine("Sent Events");
        }
    }
}