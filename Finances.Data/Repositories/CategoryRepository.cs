using Finances.Data.Interfaces;
using Finances.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Repositories
{
    public class CategoryRepository: Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(FinancesDbContext context) : base(context) { }
    }
}
