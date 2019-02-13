using Finances.Data.Interfaces;
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
        public virtual IActionResult Index()
        {
            var entities = _service.GetAll();

            return Json(entities);
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(object key)
        {
            var entity = _service.Get(key);

            return Json(entity);
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody] T entity)
        {
            IException exception = _service.Add(entity);

            if (exception.IsValid)
            {
                return Json(entity);
            }

            else
            {
                return new BadRequestObjectResult(exception.GetException());
            }

        }

        [HttpPut("{id}")]
        public virtual IActionResult Put([FromBody] T entity)
        {
            IException exception = _service.Update(entity);

            if (exception.IsValid)
            {
                return Json(entity);
            }

            else
            {
                return new BadRequestObjectResult(exception.GetException());
            }
        }
        
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(long id)
        {
            IException exception = _service.Delete(id);

            if (exception.IsValid)
            {
                return new OkObjectResult("Deleted");
            }

            else
            {
                return new BadRequestObjectResult(exception.GetException());
            }
        }
    }
}
