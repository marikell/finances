using Finances.Data.Interfaces;
using Finances.Data.Models;
using Finances.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Service
{
    public class CategoryService: Service<Category>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository):base(repository)
        {

        }
    }
}
