using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Models
{
    public class TransactionType
    {
        public long IdTransactionType { get; set; }
        public string DsTransactionType { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
