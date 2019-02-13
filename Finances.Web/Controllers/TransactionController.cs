using Finances.Data.Models;
using Finances.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Finances.Web.Controllers
{
    public class TransactionController: ControllerBase<Transaction>
    {
        public TransactionController(ITransactionService service) : base(service) { }

        public override IActionResult Post([FromBody] Transaction entity)
        {
            entity.DatCreation = DateTime.Now;
            return base.Post(entity);
        }
    }
}
