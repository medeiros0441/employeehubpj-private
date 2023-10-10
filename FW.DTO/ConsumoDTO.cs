using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.DTO
{
    public class ConsumoDTO : GerenciamentoSaldoDTO
    {
        public int IdConsumo { get; set; }
        public int FkEmpresaCs { get; set; }
        public int FkProfissionalCs { get; set; }
        public int FkSessaoCs { get; set; }
        public DateTime DateTimeInsertCs { get; set; }
        public DateTime DateTimeUpdateCs { get; set; }
        public TimeSpan TempoViewCs { get; set; }
        public decimal ValorDescontadoCs { get; set; }
    }
}
