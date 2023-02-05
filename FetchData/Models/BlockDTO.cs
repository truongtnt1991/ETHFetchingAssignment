using System;
namespace FetchData.Models
{
	public class BlockDTO
	{
        public int BlockID { get; set; }
        public int BlockNumber { get; set; }
        public string Hash { get; set; }
        public string ParentHash { get; set; }
        public string Miner { get; set; }
        public decimal BlockReward { get; set; }
        public decimal GasLimit { get; set; }
        public decimal GasUsed { get; set; }
    }
}

