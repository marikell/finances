using Finances.Data.Interfaces;
using Finances.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finances.Data.Repositories
{
    public class TransactionRepository: Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(FinancesDbContext context): base(context) { }

        public IQueryable<Transaction> GetAllWithObjects()
        {
            return GetAll()
                .Include(o => o.Category)
                .Include(o => o.SubCategory)
                .Include(o => o.TransactionType)
                .Include(o => o.User)                
                .Include(o => o.UserDestination);
                
        }
    }
}
