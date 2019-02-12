using Finances.Data.Mappings;
using Finances.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Finances.Data
{
    public class FinancesDbContext: IdentityDbContext<User>,IDesignTimeDbContextFactory<DbContext>
    {
        public FinancesDbContext(DbContextOptions options): base(options)
        {

        }
        public FinancesDbContext()
        {

        }
        public DbSet<TransactionType> TransactionsType { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
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
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TransactionTypeMap());
            modelBuilder.ApplyConfiguration(new TransactionMap());
            modelBuilder.ApplyConfiguration(new SubCategoryMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
