using System;
using FetchEntity.Entities;
using Microsoft.EntityFrameworkCore;

namespace FetchData
{
    public class BlockContext : DbContext
    {
        public BlockContext(DbContextOptions<BlockContext> options)
        : base(options)
        {
        }

        public DbSet<Block> Blocks { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Block>(entity =>
            {
                entity.HasKey(e => e.BlockID);

                entity.ToTable("blocks");

                entity.Property(e => e.BlockID).HasColumnName("blockID");

                entity.Property(e => e.BlockNumber).HasColumnName("blockNumber");

                entity.Property(e => e.Hash).HasColumnName("hash").HasColumnType("VARCHAR (66)");

                entity.Property(e => e.ParentHash).HasColumnName("parentHash").HasColumnType("VARCHAR (66)");

                entity.Property(e => e.Miner).HasColumnName("miner").HasColumnType("VARCHAR (42)");

                entity.Property(e => e.BlockReward).HasColumnName("blockReward").HasColumnType("DECIMAL (50,0)");

                entity.Property(e => e.GasLimit).HasColumnName("gasLimit").HasColumnType("DECIMAL (50,0)");

                entity.Property(e => e.GasUsed).HasColumnName("gasUsed").HasColumnType("DECIMAL (50,0)");

            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.TransactionID);

                entity.ToTable("transactions");

                entity.Property(e => e.TransactionID).HasColumnName("transactionID");

                entity.Property(e => e.BlockID).HasColumnName("blockID");

                entity.HasOne(a => a.Block).WithMany().HasForeignKey(v => v.BlockID);

                entity.Property(e => e.Hash).HasColumnName("hash").HasColumnType("VARCHAR (66)");

                entity.Property(e => e.From).HasColumnName("from").HasColumnType("VARCHAR (42)");

                entity.Property(e => e.To).HasColumnName("to").HasColumnType("VARCHAR (42)");

                entity.Property(e => e.Value).HasColumnName("value").HasColumnType("DECIMAL (50,0)");

                entity.Property(e => e.Gas).HasColumnName("gas").HasColumnType("DECIMAL (50,0)");

                entity.Property(e => e.GasPrice).HasColumnName("gasPrice").HasColumnType("DECIMAL (50,0)");

                entity.Property(e => e.TransactionIndex).HasColumnName("transactionIndex");

            });
        }
    }
}

