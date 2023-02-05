using System;
using Newtonsoft.Json;

namespace FetchData.Models
{
	public class BlockTransationIndex: BaseBlock
	{
        [JsonProperty("result")]
        public BlockTransationIndexItem Result { get; set; }
    }

	public class BlockTransationIndexItem
	{
        [JsonProperty("blockHash")]
        public string BlockHash { get; set; }

        [JsonProperty("blockNumber")]
        public string BlockNumber { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("gas")]
        public string Gas { get; set; }

        [JsonProperty("gasPrice")]
        public string GasPrice { get; set; }

        [JsonProperty("transactionIndex")]
        public string TransactionIndex { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}

