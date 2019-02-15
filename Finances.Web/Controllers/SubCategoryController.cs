using Finances.Data.Models;
using Finances.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finances.Web.Controllers
{
    public class SubCategoryController: ControllerBase<SubCategory>
    {
        public SubCategoryController(ISubCategoryService service):base(service) { }        

        [HttpGet]
        public IActionResult GetSubCategoriesByCategory(int id)
        {
            var subcategories = _service.Find(o => o.IdCategory == id).ToList();

            return Json(subcategories);
        }
    }
}
