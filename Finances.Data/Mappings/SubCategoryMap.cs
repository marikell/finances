using Finances.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Mappings
{
    public class SubCategoryMap : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.Property(o => o.IdSubCategory).ValueGeneratedOnAdd();
            builder.HasKey(o => o.IdSubCategory);
            builder.Property(o => o.DsSubCategory).HasMaxLength(50).IsRequired();
            builder.HasOne(o => o.Category).WithMany(o => o.SubCategories).HasForeignKey(o => o.IdCategory);
        }
    }
}
