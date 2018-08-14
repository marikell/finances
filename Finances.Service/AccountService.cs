using Finances.Data.Interfaces;
using Finances.Data.Models;
using Finances.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Service
{
    public class AccountService: Service<Account>, IAccountService
    {
        public AccountService(IAccountRepository repository):base(repository)
        {

        }
    }
}
