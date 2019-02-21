using Finances.Data.Models;
using System.Collections.Generic;

namespace Finances.Service.Interfaces
{
    public interface ITransactionService: IService<Transaction>
    {
        IEnumerable<Transaction> GetAllWithObjects();
    }
}
