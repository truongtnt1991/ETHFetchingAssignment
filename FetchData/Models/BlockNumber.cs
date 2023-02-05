using System;
using Newtonsoft.Json;

namespace FetchData.Models
{
	public class BlockNumber : BaseBlock
    {
        [JsonProperty("result")]
        public BlockNumberItem? Result { get; set; }
    }

	public class BlockNumberItem
	{
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("transactions")]
        public List<BlockTransaction> Transactions { get; set; }

        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }

        [JsonProperty("extraData")]
        public string ExtraData { get; set; }

        [JsonProperty("gasLimit")]
        public string GasLimit { get; set; }

        [JsonProperty("gasUsed")]
        public string GasUsed { get; set; }

        [JsonProperty("logsBloom")]
        public string LogsBloom { get; set; }

        [JsonProperty("miner")]
        public string Miner { get; set; }

        [JsonProperty("mixHash")]
        public string MixHash { get; set; }

        [JsonProperty("nonce")]
        public string Nonce { get; set; }

        [JsonProperty("parentHash")]
        public string ParentHash { get; set; }

        [JsonProperty("receiptsRoot")]
        public string ReceiptsRoot { get; set; }

        [JsonProperty("sha3Uncles")]
        public string Sha3Uncles { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("stateRoot")]
        public string StateRoot { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("totalDifficulty")]
        public string TotalDifficulty { get; set; }

        [JsonProperty("transactionsRoot")]
        public string TransactionsRoot { get; set; }

        [JsonProperty("baseFeePerGas")]
        public string BaseFeePerGas { get; set; }
    }

    public class BlockTransaction
    {
        [JsonProperty("blockHash")]
        public string BlockHash { get; set; }

        [JsonProperty("blockNumber")]
        public string BlockNumber { get; set; }

        [JsonProperty("transactionIndex")]
        public string TransactionIndex { get; set; }
    }
}

