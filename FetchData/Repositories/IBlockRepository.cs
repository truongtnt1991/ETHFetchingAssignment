using System;
using FetchData.Models;

namespace FetchData.Repositories
{
	public interface IBlockRepository
	{
		Task<int> InsertBlock(BlockDTO model);
        Task<int> InsertTransaction(TransactionDTO model);
    }
}

