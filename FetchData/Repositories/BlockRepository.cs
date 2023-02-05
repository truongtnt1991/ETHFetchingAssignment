using System;
using AutoMapper;
using FetchData.BackgroundTasks;
using FetchData.Models;
using FetchEntity;
using FetchEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FetchData.Repositories
{
    public class BlockRepository : IBlockRepository
    {
        private readonly BlockContext _context;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;


        public BlockRepository(BlockContext context, IMapper mapper, ILogger<BlockRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<int> InsertBlock(BlockDTO model)
        {
            var strategy = _context.Database.CreateExecutionStrategy();
            return await strategy.ExecuteAsync(async  () =>
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var block = _mapper.Map<Block>(model);
                        _context.Blocks.Add(block);
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                        return block.BlockID;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _logger.LogError(ex.Message);
                        return -1;
                    }

                }
            });
            
        }


        public async Task<int> InsertTransaction(TransactionDTO model)
        {
            var strategy = _context.Database.CreateExecutionStrategy();
            return await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Transactions.Add(_mapper.Map<Transaction>(model));
                        var res = await _context.SaveChangesAsync();
                        transaction.Commit();
                        return res;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _logger.LogError(ex.Message);
                        return -1;
                    }

                }
            });

        }
    }
}

