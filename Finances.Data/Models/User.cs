using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Models
{
    public class User: IdentityUser
    {
        public string CelUser { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Transaction> TransactionsDestined { get; set; }

    }
}
