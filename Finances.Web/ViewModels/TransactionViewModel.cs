using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Finances.Web.ViewModels
{
    public class TransactionViewModel
    {
        [Description("Data da Transação")]
        public DateTime DatTransaction { get; set; }
        [Description("Valor")]
        public decimal VlTransaction { get; set; }
        [Description("Descrição")]
        public string DsTransaction { get; set; }
        [Description("Categoria")]
        public string DsCategory { get; set; }
        [Description("Sub-Categoria")]
        public string DsSubCategory { get; set; }
        [Description("Remetente")]
        public string DsUser { get; set; }
        [Description("Destinatário")]
        public string DsUserDestination { get; set; }
        [Description("Tipo de Entrada")]
        public string DsTransactionType { get; set; }
        [Description("Possui Comprovante?")]
        protected bool HasReceipt { get; set; }
        public string FormattedHasReceipt
        {
            get
            {
                return (HasReceipt) ? "Sim" : "Não";
            }
        }

        public string FormattedVlTransaction
        {
            get
            {
                return (String.Format("R$ {0}", Convert.ToString(VlTransaction)));
            }
        }
    }
}
