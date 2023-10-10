using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;

namespace FW.DTO
{
    public class PagamentoDTO : TipoUserDTO
    {

        private decimal valorPg;
        public int IdPagamento { get; set; }
        public decimal ValorPg
        {
            get { return valorPg; }
            set { valorPg = value; }
        }
        public string TipoPagamentoPg { get; set; }
        public string NomeProdutoPg { get; set; }
        public string QrcodepixPg { get; set; }
        public string ImgQrcodebase64Pg { get; set; }
        public string PaymentidPg { get; set; }
        public string StatusPg { get; set; }
        public DateTime DateTimeInsertPg { get; set; }
        public DateTime DateTimeUpdatePg { get; set; }
        public int FkClientePg { get; set; }
        // Propriedade somente para exibição formatada
        public string ValorPgFormatado
        {
            get
            {
                CultureInfo cultura = CultureInfo.GetCultureInfo("pt-BR");
                NumberFormatInfo formatoMoeda = cultura.NumberFormat;
                formatoMoeda.CurrencySymbol = "R$";

                return valorPg.ToString("C", formatoMoeda);
            }
        }
    }
}
