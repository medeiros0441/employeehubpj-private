using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.DTO
{
    public class CandidatoSimplificadoDTO : VagaDTO
    {
        public int IdCandidatoCs { get; set; }
        public string NomeCs { get; set; }
        public string EmailCs { get; set; }
        public string TelefoneCs { get; set; }
        public DateTime DateTimeInsertCs { get; set; }
        public string CaminhoDocCs { get; set; }
        public int FkCandidatoCsr { get; set; }
        public DateTime DateTimeInsertCsr { get; set; }
        public int FkVagaCsr { get; set; }
        public string StatusCandidatoCs { get; set; }
         
    }

}
