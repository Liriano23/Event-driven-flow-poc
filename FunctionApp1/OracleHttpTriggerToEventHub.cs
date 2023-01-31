using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public static class OracleHttpTriggerToEventHub
    {
        [FunctionName(nameof(OracleHttpTriggerToEventHub))]
        [return: EventHub("poc-event-hub", Connection = "EventHubConnectionAppSetting")]
        public static async Task Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Post), Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            Console.WriteLine("Starting our Event Huv Producer");

            log.LogInformation("Starting our Event Huv Producer");
            log.LogInformation($"Content: {req.Content.ReadAsStringAsync().Result}");

            string namespaceConnectionString = "Endpoint=sb://event-driven-poc-hub-test1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=gkwI1lWT8gH5HO77Rw4cnY5B7NCnNQFiTo4M1kM9wDA=";
            string eventHubName = "poc-event-hub";

            EventHubProducerClient producer = new EventHubProducerClient(namespaceConnectionString, eventHubName);
            List<EventData> list = new List<EventData>();

            list.Add(new EventData(req.Content.ReadAsStringAsync().Result));

            await producer.SendAsync(list);

            Console.WriteLine("Sent Events");
            log.LogInformation("Sent Events");
        }
    }
}