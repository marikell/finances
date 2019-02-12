using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Models
{
    public class Transaction
    {
        public long IdTransaction { get; set; }
        public long IdTransactionType { get; set; }
        public DateTime DatTransaction { get; set; }
        public DateTime DatCreation { get; set; }
        public decimal VlTransaction { get; set; }
        public string DsTransaction { get; set; }
        public long IdCategory { get; set; }
        public string IdUser { get; set; }
        public string IdUserDestination { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
        public User UserDestination { get; set; }

        public TransactionType TransactionType { get; set; }
    }
}
