using Finances.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(o => o.IdCategory);
            builder.Property(o => o.IdCategory).UseSqlServerIdentityColumn();
            builder.Property(o => o.DsCategory).HasMaxLength(50).IsRequired();
        }
    }

}

