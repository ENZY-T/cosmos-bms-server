
using cosmos_bms_server.Services;

namespace cosmos_bms_server
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(AzureSignalRManagement).TypeHandle);
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(AzureSignalRClient).TypeHandle);

            Application.Run(new Form1());
        }
    }
}