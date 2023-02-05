using System;
using FetchData.Models;

namespace FetchData.APIProcessing
{
	public interface IBlockAPIProcessing
	{
        Task<BlockNumber?> GetBlockByNumber(string blockNumber);
        Task<BlockTransactionCount?> GetBlockTransactionCountByNumber(string blockNumber);
        Task<BlockTransationIndex?> GetTransactionByBlockNumberAndIndex(string blockNumber, string index);
    }
}

