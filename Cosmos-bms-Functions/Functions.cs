using Cosmos_bms_Functions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Cosmos_bms_Functions
{
    public static class Functions
    {
        [FunctionName("negotiate")]
        public static SignalRConnectionInfo Negotiate(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req,
            [SignalRConnectionInfo(HubName = "Cosmoshub")] SignalRConnectionInfo connectionInfo, ILogger log)
        {
            log.LogInformation("Returning connetion:" + connectionInfo.Url + "" + connectionInfo.AccessToken);

            return connectionInfo;
        }

        [FunctionName("broadcast")]
        public static void Broadcast(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req,
            [SignalR(HubName = "CosmosHub")] IAsyncCollector<SignalRMessage> signalRMessage, ILogger log)
        {
            StateInBody stateObject = GetObjectFromRequestBody<StateInBody>(req.Body);
            signalRMessage.AddAsync(
                new SignalRMessage
                {
                    Target = "ReceiveState",
                    Arguments = new[] { stateObject.State }
                });
            log.LogInformation("Broadcasted data on demand at " + DateTime.Now);
        }


        private static T GetObjectFromRequestBody<T>(Stream stream)
        {
            var serializer = new JsonSerializer();

            using (var sr = new StreamReader(stream))
            {
                using (var jsonTextReader = new JsonTextReader(sr))
                {
                    return serializer.Deserialize<T>(jsonTextReader);
                }
            }
        }
    }
}



