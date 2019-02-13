using Finances.Data.Models;
using Finances.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finances.Web.Controllers
{
    public class TransactionTypeController: ControllerBase<TransactionType>
    {
        public TransactionTypeController(ITransactionTypeService service) : base(service) { }
    }
}
