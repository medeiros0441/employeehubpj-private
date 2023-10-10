using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.DTO
{
    public  class LogDTO : SessaoDTO
    {
        public int IdLog { get; set; }
        public DateTime DateTimeInsertLg { get; set; }
        public DateTime? DateTimeUpdateLg { get; set; }
        public string DescricaoLg { get; set; }
        public string DescricaoSistemaLg { get; set; }
        public string NivelGravidadeLg { get; set; }
        public string DadosAdicionaisLg { get; set; }
        public int FkSessaoLg { get; set; }
    }
}
