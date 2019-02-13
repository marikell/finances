using Finances.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finances.Web.Controllers
{
    [Route("api/[controller]")]
    public class ControllerBase<T>: Controller where T:class
    {
        private IService<T> _service;

        public ControllerBase(IService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entities = _service.GetAll();

            return Json(entities);
        }

        [HttpGet("{id}")]
        public IActionResult Get(object key)
        {
            var entity = _service.Get(key);

            return Json(entity);
        }

        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            _service.Add(entity);

            return Json(entity);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] T entity)
        {
            _service.Update(entity);

            return Json(entity);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(object key)
        {
            _service.Delete(key);

            return new OkObjectResult("Deleted");
        }




    }
}
