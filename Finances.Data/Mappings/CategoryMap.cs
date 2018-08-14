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
            builder.HasOne(o => o.Account).WithMany(o => o.Categories).HasForeignKey(o => o.Id);
            builder.Property(o => o.Description).HasMaxLength(150).IsRequired();
            builder.HasMany(o => o.SubCategories).WithOne(o => o.Category).HasForeignKey(o => o.IdSubCategory);
            builder.HasMany(o => o.Fields).WithOne(o => o.Category).HasForeignKey(o => o.IdField);
        }
    }
}
