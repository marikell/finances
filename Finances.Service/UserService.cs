using Finances.Data.Interfaces;
using Finances.Data.Models;
using Finances.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Service
{
    public class UserService: Service<User>, IUserService
    {
        public UserService(IUserRepository repository):base(repository)
        {

        }
    }
}
