using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos_bms_Functions.Models
{
    internal class StateInBody
    {
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
