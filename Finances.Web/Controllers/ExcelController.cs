using Finances.Data.Models;
using Finances.Service.Interfaces;
using Finances.Service.Utils;
using Finances.Web.ViewModels;
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
                transactions = _transactionService.Find(o => o.DatTransaction.Month == dtFilter.Value.Month);
                    
            }
            else
            {
                transactions = _transactionService.GetAllWithObjects().ToList();
            }

            var transactionViewModels = transactions.Select(o => new TransactionViewModel
            {

                DatTransaction = o.DatTransaction,
                DsCategory = o.Category.DsCategory,
                DsSubCategory = o.SubCategory.DsSubCategory,
                DsTransaction = o.DsTransaction,
                DsTransactionType = o.TransactionType.DsTransactionType,
                DsUser = o.User.UserName,
                DsUserDestination = (o.UserDestination != null) ? o.UserDestination.UserName : string.Empty,
                VlTransaction = o.VlTransaction

            }).ToList();

            var groupedTransactions = transactionViewModels.GroupBy(o => o.DatTransaction.Month)
                .Select(o => new {

                    o.Key,
                    Transactions = o.ToList()

                });      


                
            var columns = Extension.GetPropertiesDescription<TransactionViewModel>();

            ExcelPackage package = new ExcelPackage();

            ExcelWorksheet excelWorksheet = package.Workbook.Worksheets.Add("Entradas/Saídas");
                       
            for (int i = 1; i <= columns.Count(); i++)
            {
                excelWorksheet.Cells[1, i].Value = columns.ElementAt(i-1);
            }

            for (int i = 0; i < groupedTransactions.Count(); i++)
            {
                var transactionGrouped = groupedTransactions.ElementAt(i);

                for (int j = 0; j < transactionGrouped.Transactions.Count(); j++)
                {
                    var transaction = transactionGrouped.Transactions.ElementAt(j);

                    for (int k = 0; k < columns.Length; k++)
                    {
                        string propertyName = (Extension.GetPropertyNameByDescription<TransactionViewModel>(
                            Convert.ToString(excelWorksheet.Cells[1, k+1].Value)));

                        object value = Extension.GetPropertyValue(propertyName, transaction);

                        excelWorksheet.Cells[(k + j + i + 1), k + 1].Value = (value == null) ? string.Empty : Convert.ToString(value);
                    }
                }
            }
                       


            excelWorksheet.Cells["A:AZ"].AutoFitColumns();

            var t = package.GetAsByteArray();

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Headers.Add("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            await Response.Body.WriteAsync(t, 0, t.Count());
            }
        
    }
}
