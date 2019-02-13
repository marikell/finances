using Finances.Data.Interfaces;
using Finances.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Repositories
{
    public class SubCategoryRepository: Repository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(FinancesDbContext context) : base(context) { }
    }
}
