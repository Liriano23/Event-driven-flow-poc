using Azure.Messaging.EventHubs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public static class EventHubTrigger
    {
        [FunctionName(nameof(EventHubTrigger))]
        public static async Task Run(
            [EventHubTrigger("poc-event-hub", Connection = "EventHubConnectionAppSetting")] EventData[] events,
            ILogger log)
        {
            var exceptions = new List<Exception>();
            foreach (EventData eventData in events)
            {
                try
                {
                    log.LogInformation($"C# Event Hub trigger function processed a message: {eventData.EventBody}");
                    await Task.Yield();
                }
                catch (Exception e)
                {
                    exceptions.Add(e);
                }
            }

            if (exceptions.Count > 1)
                throw new AggregateException(exceptions);

            if (exceptions.Count == 1)
                throw exceptions.Single();
        }
    }
}