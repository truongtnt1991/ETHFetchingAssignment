using System;
using Newtonsoft.Json;

namespace FetchData.Models
{
	public class BlockTransactionCount: BaseBlock
    {
        [JsonProperty("result")]
        public string Result { get; set; }
    }
}

