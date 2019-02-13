using Finances.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Mappings
{
    public class TransactionTypeMap : IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.HasKey(o => o.IdTransactionType);
            builder.Property(o => o.IdTransactionType).UseSqlServerIdentityColumn();
            builder.Property(o => o.DsTransactionType).HasMaxLength(50).IsRequired();
        }

    }
}
