using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.DTO
{
    public class VisitaDTO
    {
        public int IdVisita { get; set; }
        public int FkClienteVs { get; set; }
        public int FkSessaoVs { get; set; }
        public DateTime DateTimeInsertVs { get; set; }
        public DateTime? DateTimeUpdateVs { get; set; }
        public TimeSpan? TimeViewVs { get; set; }
        public TimeSpan TimeIniciouVs { get; set; }
        public TimeSpan? TimeFinalizouVs { get; set; }
    }
    public class visualizacaoDTO
    {
        public int IdVisualizacao { get; set; }
        public int FkVisitaVz { get; set; }
        public int FkClienteVz { get; set; }
        public DateTime DateTimeInsertVz { get; set; }
        public DateTime? DateTimeUpdateVz { get; set; }
        public TimeSpan TimeViewVz { get; set; }
    }

}
