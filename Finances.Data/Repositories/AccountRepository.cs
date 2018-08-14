using Finances.Data.Interfaces;
using Finances.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Repositories
{
    public class AccountRepository: Repository<Account>, IAccountRepository
    {
        public AccountRepository(FinancesDbContext context) : base(context) { }
    }
}
