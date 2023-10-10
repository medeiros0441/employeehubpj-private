using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FW.DTO
{
    public class SessaoDTO : AcessoDTO
    {
        public int IdSessao { get; set; }
        public string IpClienteSs { get; set; }
        public string NavegadorSs { get; set; }
        public bool StatusSs { get; set; }
        public DateTime DateTimeInsertSs { get; set; }
        public DateTime? DateTimeUpdateSs { get; set; }
        public TimeSpan TimeOnlineSs { get; set; }
        public DateTime IniciouSs { get; set; }
        public DateTime FinalizouSs { get; set; }
    }

    public class AcessoDTO
    { 
        public int IdAcesso { get; set; }
        public int FkClienteAs { get; set; }
        public int FkSessaoAs { get; set; }
        public DateTime DateTimeInsertAs { get; set; }
        public DateTime? DateTimeUpdateAs { get; set; }
        public TimeSpan? TempoViewAs { get; set; }
    }

}
