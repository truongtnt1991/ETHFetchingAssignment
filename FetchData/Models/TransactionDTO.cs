using System;
namespace FetchData.Models
{
	public class TransactionDTO
	{
        public int TransactionID { get; set; }
        public int BlockID { get; set; }
        public string Hash { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Value { get; set; }
        public decimal Gas { get; set; }
        public decimal GasPrice { get; set; }
        public int TransactionIndex { get; set; }
    }
}

