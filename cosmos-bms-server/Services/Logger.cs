using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cosmos_bms_server.Services
{
    internal static class Logger 
    {
        public static void Log(string line)
        {
            Debug.WriteLine(line);
        }
    }
}
