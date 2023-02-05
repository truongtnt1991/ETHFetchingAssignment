using System;
using FetchData.APIProcessing;
using FetchData.Models;
using FetchData.Repositories;
using FetchData.Utils;
using Microsoft.Extensions.Logging;

namespace FetchData.BackgroundTasks
{
    internal interface IBlockProcessingService
    {
        Task DoWork(CancellationToken stoppingToken);
    }

    internal class BlockProcessingService : IBlockProcessingService
    {
        private readonly ILogger _logger;
        private readonly IBlockRepository _blockRepository;
        private readonly IBlockAPIProcessing _blockAPIProcessing;
        private readonly int blockNumberFrom = 12100001;
        private readonly int blockNumberTo = 12100500;

        public BlockProcessingService(ILogger<BlockProcessingService> logger, IBlockRepository blockRepository, IBlockAPIProcessing blockAPIProcessing)
        {
            _logger = logger;
            _blockRepository = blockRepository;
            _blockAPIProcessing = blockAPIProcessing;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            if(!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Block Processing Service is working");
                for (int i = blockNumberFrom;i<= blockNumberTo;i++)
                {
                    try
                    {
                        var hex = i.ConvertNumberToHex();
                        var block = await _blockAPIProcessing.GetBlockByNumber(hex);
                        if (block != null)
                        {
                            var blockTranss = await _blockAPIProcessing.GetBlockTransactionCountByNumber(hex);
                            if (block.Result != null)
                            {
                                var blockDTO = new BlockDTO
                                {
                                    BlockNumber = hex.FromHexToNumber(),
                                    Hash = block.Result.Hash,
                                    ParentHash = block.Result.ParentHash,
                                    Miner = block.Result.Miner,
                                    GasLimit = block.Result.GasLimit.FromHexToDecimal(),
                                    GasUsed = block.Result.GasUsed.FromHexToDecimal()
                                };
                                var blockID = await _blockRepository.InsertBlock(blockDTO);
                                foreach (var tran in block.Result.Transactions)
                                {
                                    var blockTrans = await _blockAPIProcessing.GetTransactionByBlockNumberAndIndex(tran.BlockNumber, tran.TransactionIndex);
                                    if (blockTrans != null && blockTrans.Result != null)
                                    {
                                        var tranDTO = new TransactionDTO
                                        {
                                            BlockID = blockID,
                                            Hash = blockTrans.Result.BlockHash,
                                            From = blockTrans.Result.From,
                                            To = blockTrans.Result.To,
                                            Value = blockTrans.Result.Value.FromHexToDecimal(),
                                            Gas = blockTrans.Result.Gas.FromHexToDecimal(),
                                            GasPrice = blockTrans.Result.GasPrice.FromHexToDecimal(),
                                            TransactionIndex = blockTrans.Result.TransactionIndex.FromHexToNumber()
                                        };
                                        await _blockRepository.InsertTransaction(tranDTO);
                                    }

                                }


                            }
                            else
                            {
                                var blockTrans = await _blockAPIProcessing.GetBlockTransactionCountByNumber(hex);
                                var blockDTO = new BlockDTO
                                {
                                    BlockNumber = hex.FromHexToNumber()
                                };
                                await _blockRepository.InsertBlock(blockDTO);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Error occurred at block", i, ex.Message);
                    }
                    
                }
                
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}

