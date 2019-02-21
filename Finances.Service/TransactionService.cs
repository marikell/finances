using Finances.Data.Interfaces;
using Finances.Data.Models;
using Finances.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Service
{
    public class TransactionService: Service<Transaction>, ITransactionService
    {
        public ITransactionRepository Repository
        {
            get
            {
                return (ITransactionRepository)_repository;
            }
        }

        public TransactionService(ITransactionRepository repository): base(repository) { }

        public IEnumerable<Transaction> GetAllWithObjects()
        {
            return Repository.GetAllWithObjects();
        }
    }
}
