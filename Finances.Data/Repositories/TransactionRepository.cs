using Finances.Data.Interfaces;
using Finances.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Repositories
{
    public class TransactionRepository: Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(FinancesDbContext context): base(context) { }
    }
}
