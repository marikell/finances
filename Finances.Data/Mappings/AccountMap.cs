using Finances.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Mappings
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(o => o.Description).HasMaxLength(150).IsRequired();
            //builder.HasMany(o => o.Categories).WithOne(o => o.Account).HasForeignKey(o => o.IdCategory);
        }
    }
}
