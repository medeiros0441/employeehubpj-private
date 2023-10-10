using System;
using System.Globalization;

namespace FW.DTO
{
    public class CertificadoDTO : ProfissionalDTO
    {
        public int IdCertificado { get; set; }
        public string NomeCursoCf { get; set; }
        public string NomeInstituicaoCf { get; set; }
        public string DescricaoCf { get; set; }
        public DateTime DateTimeInsertCf { get; set; }
        public DateTime DateTimeUpdateCf { get; set; }
        public DateTime DateInicioCf { get; set; }
        public DateTime DateFinalizouCf { get; set; }


        public int FkProfissionalCf { get; set; }



        
    }
}
