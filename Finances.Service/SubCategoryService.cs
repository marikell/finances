using Finances.Data.Interfaces;
using Finances.Data.Models;
using Finances.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Service
{
    public class SubCategoryService: Service<SubCategory>, ISubCategoryService
    {
        public SubCategoryService(ISubCategoryRepository repository): base(repository) { }
    }
}
