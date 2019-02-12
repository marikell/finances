using Finances.Data.Models;
using Finances.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finances.Web.Controllers
{
    public class CategoryController: Controller
    {
        private ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("api/categories")]
        public IActionResult Index()
        {
            var categories = _service.GetAll();

            return Json(categories);
        }

        [HttpGet("api/category/{id}")]
        public IActionResult Get()
        {
            return new OkObjectResult("GET");
        }


        [HttpPost("api/category")]
        public IActionResult Post([FromBody]Category category)
        {
            _service.Add(category);

            return Json(category);
        }

        [HttpPut("api/category/{id}")]
        public IActionResult Put()
        {
            return new OkObjectResult("PUT");
        }

        [HttpDelete("api/category/{id}")]
        public IActionResult Delete()
        {
            return new OkObjectResult("Delete");
        }








    }
}
