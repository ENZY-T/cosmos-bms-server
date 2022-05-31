using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cosmos_bms_server.Services
{
    public static class AzureSignalRManagement
    {
        private static readonly string HubName = "CosmosHub";
        private static ServiceManager? serviceManager;
        private static ServiceHubContext? _hubContext;

        static AzureSignalRManagement()
        {

            try
            {
                serviceManager = new ServiceManagerBuilder()
                                .WithOptions(option =>
                                {
                                    option.ConnectionString = "Endpoint=https://cosmos-bms-signalr-hub.service.signalr.net;AccessKey=syKq2dT5KvvvMOTuUCboD9lE01ogxiRlPR0ZnAXLk8E=;Version=1.0;";
                                })
                                //.WithLoggerFactory(LoggerFactory)
                                .BuildServiceManager();

                Debug.WriteLine("Connection Success");
            }
            catch {
                Debug.WriteLine("Connection Failed");
            }


        }

        private static async void CreateHubContext()
        {
            //serviceHubContext = await serviceManager?.CreateHubContextAsync("<Your Hub Name>", cancellationToken);
            _hubContext = await serviceManager?.CreateHubContextAsync(HubName, default);
        }

        public static async void SendAll(string message = "No Conent")
        {
            object?[] msgObject = new object?[] { message };
            await _hubContext?.Clients.All.SendCoreAsync("OnMessage", msgObject);

            

        }
    }
}
