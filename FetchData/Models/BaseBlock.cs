using System;
using Newtonsoft.Json;

namespace FetchData.Models
{
	public class BaseBlock
	{
        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; set; }

        [JsonProperty("id")]
        public int ID { get; set; }
    }
}

