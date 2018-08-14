using Finances.Data.Mappings;
using Finances.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Finances.Data
{
    public class FinancesDbContext: IdentityDbContext<Account>,IDesignTimeDbContextFactory<DbContext>
    {
        public FinancesDbContext(DbContextOptions options): base(options)
        {

        }
        public FinancesDbContext()
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FinancesDbContext>();
            var connectionString = @"Server=NT-03321\SQLEXPRESS;Database=FinancesDb;Trusted_Connection=True;";
            builder.UseSqlServer(connectionString);
            return new FinancesDbContext(builder.Options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new FieldMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new SubCategoryMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
