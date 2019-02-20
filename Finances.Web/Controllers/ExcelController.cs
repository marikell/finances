using Finances.Data.Models;
using Finances.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Finances.Web.Controllers
{
    [Route("api/[controller]")]
    public class ExcelController:Controller
    {
        protected ITransactionService _transactionService;
        public ExcelController(ITransactionService service)
        {
            _transactionService = service;
        }

        

        [HttpGet]
        public async Task CreateDocumentAsync(DateTime? dtFilter)
        {

            ICollection<Transaction> transactions = new List<Transaction>();

            if (dtFilter.HasValue)
            {
                transactions = _transactionService.Find(o => o.DatTransaction.Month == dtFilter.Value.Month).ToList();
            }
            else
            {
                transactions = _transactionService.GetAll().ToList();
            }

            var groupedTransactions = transactions.GroupBy(o => o.DatTransaction.Month);


            var teste = groupedTransactions.ElementAt(0);

            ExcelPackage package = new ExcelPackage();

            ExcelWorksheet excelWorksheet = package.Workbook.Worksheets.Add("TESTE");

            for (int i = 1; i <= 9; i++)
            {
                excelWorksheet.Cells[1, i].Value = i;
            }

            excelWorksheet.Cells["A:AZ"].AutoFitColumns();

            var t = package.GetAsByteArray();

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Headers.Add("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            await Response.Body.WriteAsync(t, 0, t.Count());
            }
        
    }
}
