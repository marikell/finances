using Finances.Data.Interfaces;
using Finances.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(FinancesDbContext context) : base(context) { }
    }
}
