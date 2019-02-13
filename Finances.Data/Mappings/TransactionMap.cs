using Finances.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Mappings
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(o => o.IdTransaction);
            builder.Property(o => o.IdTransaction).UseSqlServerIdentityColumn();
            builder.HasOne(o => o.TransactionType).WithMany(o => o.Transactions).HasForeignKey(o => o.IdTransactionType);
            builder.HasOne(o => o.Category).WithMany(o => o.Transactions).HasForeignKey(o => o.IdCategory);
            builder.Property(o => o.DsTransaction).HasMaxLength(200).IsRequired();
            builder.Property(o => o.IdUser).IsRequired();
            builder.Property(o => o.HasReceipt).IsRequired();
            builder.HasOne(o => o.User).WithMany(o => o.Transactions).HasForeignKey(o => o.IdUser);
            builder.HasOne(o => o.UserDestination).WithMany(o => o.TransactionsDestined).HasForeignKey(o => o.IdUserDestination);

        }
    }
}
