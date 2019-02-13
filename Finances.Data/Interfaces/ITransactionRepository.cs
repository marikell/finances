using Finances.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Interfaces
{
    public interface ITransactionRepository: IRepository<Transaction>
    {
    }
}
