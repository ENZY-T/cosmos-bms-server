﻿using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cosmos_bms_server.Services
{
    internal static class Firebase
    {
        private static readonly FirebaseApp? firebaseApp;

        static Firebase()
        {
            try
            {
                firebaseApp = FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.Combine("Keys", "cosmos-bms-firebase-adminsdk-key.json")))
                });
                Logger.Log("Connected to " + firebaseApp.Name);
            }
            catch (Exception ex)
            {
                Logger.Log("Error in connection...");
            }
        }

        public static FirebaseAdmin.Messaging.Message CreateMessage(string title, string body, string state)
        {
            FirebaseAdmin.Messaging.Message message = new FirebaseAdmin.Messaging.Message()
            {
                Topic = "bms-state",
                Notification = new Notification() { Title = title, Body = body },
                Data = new Dictionary<string, string>()
                {
                    { "title", "State"},
                    { "body", state },
                },
                Android = new AndroidConfig()
                {
                    Priority = Priority.High,
                    Notification = new AndroidNotification()
                    {
                        ChannelId = "cosmos-bms-1",
                    }
                }
            };

            return message;
        }

        public static async Task<string> SendMessageAsync(string state)
        {
            FirebaseAdmin.Messaging.Message message = CreateMessage("Survailance alert !", "Motion Detected on a sensor !", state);
            return await FirebaseMessaging.DefaultInstance.SendAsync(message);
        }

        public static void ListenToTopic()
        {

        }
    }
}
