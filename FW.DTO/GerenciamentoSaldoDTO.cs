using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.DTO
{
    public class GerenciamentoSaldoDTO : PagamentoDTO
    {

        public int IdSaldo { get; set; }
        public decimal SaldoAtualGs { get; set; }
        public decimal SaldoAnteriorGs { get; set; }
        public DateTime DateTimeInsertGs { get; set; }
        public DateTime DateTimeUpdateGs { get; set; }
        public string DescricaoGs { get; set; }
        public int FkClienteGs { get; set; }
        public int FkPagamentoGs { get; set; }
    }
}
