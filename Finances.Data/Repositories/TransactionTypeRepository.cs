using Finances.Data.Interfaces;
using Finances.Data.Models;

namespace Finances.Data.Repositories
{
    public class TransactionTypeRepository: Repository<TransactionType>, ITransactionTypeRepository
    {
        public TransactionTypeRepository(FinancesDbContext context):base(context) { }     
    }
}
