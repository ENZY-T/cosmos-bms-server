using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cosmos_bms_server.Services
{
    public static class AzureSignalRClient
    {
        private static readonly string functionAppUrl = "https://cosmos-bms-functions.azurewebsites.net";
        private static readonly HubConnection connection;

        static AzureSignalRClient()
        {
            connection = new HubConnectionBuilder()
                .WithUrl(functionAppUrl + "/api")
                .Build();


            connection.On<string>("ReceiveState", OnReceiveState);

            // Connect should call after connection.on configurations
            Connect();
        }

        public static void Connect()
        {
            try
            {
                connection.StartAsync().Wait();
                Logger.Log("Connected to the server");
            }
            catch (Exception ex)
            {
                Logger.Log("Failed connection\n\n Error:\n" + ex.Message);
            }
        }

        private static void OnReceiveState(string message)
        {
            Logger.Log(message);
        }

        public static void SendMessage(string msg)
        {
            connection.SendAsync("OnMessage");
        }
    }
}
