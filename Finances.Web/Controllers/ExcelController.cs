using Finances.Data.Models;
using Finances.Service.Interfaces;
using Finances.Service.Utils;
using Finances.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Finances.Web.Controllers
{
    [Route("api/[controller]")]
    public class ExcelController : Controller
    {
        protected ITransactionService _transactionService;

        #region Constructor
        public ExcelController(ITransactionService service)
        {
            _transactionService = service;
        }

        #endregion

        #region Data Preparation

        private ICollection<TransactionViewModel> GetData(DateTime? dtFilter)
        {
            ICollection<Transaction> transactions = new List<Transaction>();

            if (dtFilter.HasValue)
            {
                transactions = _transactionService.Find(o => o.DatTransaction.Month == dtFilter.Value.Month);

            }
            else
            {
                transactions = _transactionService.GetAllWithObjects().OrderBy(o => o.DatTransaction).ToList();
            }

            return transactions.Select(o => new TransactionViewModel
            {
                DatTransaction = o.DatTransaction.ToString("dd/MM/yyyy"),
                DsCategory = o.Category.DsCategory,
                DsSubCategory = o.SubCategory.DsSubCategory,
                DsTransaction = o.DsTransaction,
                DsTransactionType = o.TransactionType.DsTransactionType,
                DsUser = o.User.UserName,
                DsUserDestination = (o.UserDestination != null) ? o.UserDestination.UserName : "-",
                VlTransaction = o.VlTransaction,
                HasReceipt = (o.HasReceipt) ? "Sim" : "Não"

            }).ToList();
        }

        private void StyleWorksheet(ref ExcelPackage package, Tuple<int, int> values)
        {
            ExcelWorksheet excelWorksheet = package.Workbook.Worksheets.FirstOrDefault();

            if (excelWorksheet != null)
            {
                //Styling header
                for (int i = 0; i < values.Item2; i++)
                {
                    excelWorksheet.Cells[1, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    excelWorksheet.Cells[1, i + 1].Style.Font.Bold = true;
                    excelWorksheet.Cells[1, i + 1].Style.Font.Size = 10;
                    excelWorksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    excelWorksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#cc99ff"));
                    excelWorksheet.Cells[1, i + 1].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    excelWorksheet.Cells[1, i + 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                }

                //Styling rows

                for (int i = 1; i < values.Item1; i++)
                {
                    for (int j = 0; j < values.Item2; j++)
                    {
                        string value = Convert.ToString(excelWorksheet.Cells[i + 1, j + 1].Value);

                        if (!DateUtils.FormattedMonths.ContainsValue(value))
                        {
                            excelWorksheet.Cells[i + 1, j + 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                            excelWorksheet.Cells[i + 1, j + 1].Style.Font.Size = 10;
                            excelWorksheet.Cells[i + 1, j + 1].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            excelWorksheet.Cells[i + 1, j + 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        }
                    }
                }

                //Styling footer

                for (int i = 0; i < values.Item2; i++)
                {
                    excelWorksheet.Cells[values.Item1, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    excelWorksheet.Cells[values.Item1, i + 1].Style.Font.Bold = true;
                    excelWorksheet.Cells[values.Item1, i + 1].Style.Font.Size = 10;
                    excelWorksheet.Cells[values.Item1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    excelWorksheet.Cells[values.Item1, i + 1].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#ff6699"));
                    excelWorksheet.Cells[values.Item1, i + 1].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    excelWorksheet.Cells[values.Item1, i + 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                }

                //merging columns of footer
                excelWorksheet.Cells[values.Item1, 3, values.Item1, 9].Merge = true;
                excelWorksheet.Cells[values.Item1, 3].Value = "Arquivo gerado em: " + DateTime.Now.ToString("dd-MM-yyyy HH:mm");
                excelWorksheet.Cells["A:AZ"].AutoFitColumns();
            }

        }

        private void StyleDefaultColor(int row, int columns, ref ExcelWorksheet excelWorksheet, string hexadecimalColor)
        {
            for (int i = 0; i < columns; i++)
            {
                excelWorksheet.Cells[row, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                excelWorksheet.Cells[row, i + 1].Style.Font.Bold = true;
                excelWorksheet.Cells[row, i + 1].Style.Font.Size = 10;
                excelWorksheet.Cells[row, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                excelWorksheet.Cells[row, i + 1].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(hexadecimalColor));
                excelWorksheet.Cells[row, i + 1].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                excelWorksheet.Cells[row, i + 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            }

            excelWorksheet.Cells[row, 3, row, 9].Merge = true;

        }

        private Tuple<int, int> PrepareData(ref ExcelPackage package, ICollection<TransactionViewModel> transactionViewModels)
        {

            var columns = Extension.GetPropertiesDescription<TransactionViewModel>();

            int rows = 0;

            ExcelWorksheet excelWorksheet = package.Workbook.Worksheets.Add("Entradas/Saídas");
            for (int i = 1; i <= columns.Count(); i++)
            {
                excelWorksheet.Cells[1, i].Value = columns.ElementAt(i - 1);
            }

            //for the header
            rows += 2;

            int lastMonth = 0, currentMonth = 0;
            decimal totalByMonth = 0;

            foreach (var tr in transactionViewModels)
            {
                string dtTransaction = tr.DatTransaction;

                currentMonth = Convert.ToInt32(dtTransaction.Substring(dtTransaction.IndexOf('/') + 1, 2));

                if (currentMonth != lastMonth)
                {
                    //total by month
                    excelWorksheet.Cells[rows, 1].Value = "R$" + Convert.ToString(transactionViewModels.Sum(o => o.VlTransaction));
                    excelWorksheet.Cells[rows, 2].Value = totalByMonth;
                    StyleDefaultColor(rows, columns.Count(), ref excelWorksheet, "#ffff99");
                    totalByMonth = 0;
                    rows++;

                    StyleDefaultColor(rows, columns.Count(), ref excelWorksheet, "#b3cccc");
                    excelWorksheet.Cells[rows, 1].Value = DateUtils.FormattedMonths[currentMonth];
                    rows++;                    
                }


                for (int k = 0; k < columns.Length; k++)
                {
                    string propertyName = (Extension.GetPropertyNameByDescription<TransactionViewModel>(
                        Convert.ToString(excelWorksheet.Cells[1, k + 1].Value)));

                    object value = Extension.GetPropertyValue(propertyName, tr);

                    excelWorksheet.Cells[rows, k + 1].Value = (value == null) ? string.Empty : Convert.ToString(value);
                }

                lastMonth = currentMonth;
                totalByMonth += tr.VlTransaction;
                rows++;

                

            }

            excelWorksheet.Cells[rows, 1].Value = "Total";
            excelWorksheet.Cells[rows, 2].Value = "R$" + Convert.ToString(transactionViewModels.Sum(o => o.VlTransaction));

            return new Tuple<int, int>(rows, columns.Count());

        }

        #endregion

        [HttpGet]
        public async Task CreateDocumentAsync(DateTime? dtFilter)
        {
            ExcelPackage package = new ExcelPackage();

            Tuple<int, int> values = PrepareData(ref package, GetData(dtFilter));
            StyleWorksheet(ref package, values);

            var excelBytesArray = package.GetAsByteArray();

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Headers.Add("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            await Response.Body.WriteAsync(excelBytesArray, 0, excelBytesArray.Count());
        }

    }
}
