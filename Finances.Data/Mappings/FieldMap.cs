using Finances.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Mappings
{
    public class FieldMap : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.HasKey(o => o.IdField);
            builder.Property(o => o.Description).HasMaxLength(150).IsRequired();
            builder.HasOne(o => o.Category).WithMany(o => o.Fields).HasForeignKey(o => o.IdCategory);

        }
    }
}
