using Finances.Data.Models;
using Finances.Service.Interfaces;

namespace Finances.Web.Controllers
{
    public class TransactionController: ControllerBase<Transaction>
    {
        public TransactionController(ITransactionService service) : base(service) { }
    }
}
