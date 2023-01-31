using Microsoft.Azure.WebJobs;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public static class EventHubTrigger
    {
        private const string EventHubConnectionAppSetting = "Endpoint=sb://event-driven-poc-hub-test1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=gkwI1lWT8gH5HO77Rw4cnY5B7NCnNQFiTo4M1kM9wDA=";

        [FunctionName(nameof(EventHubTrigger))]
        public static Task Run(
            [EventHubTrigger("poc-event-hub", Connection = "EventHubConnectionAppSetting")] string req)
        {
            return Task.CompletedTask;
        }
    }
}