using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.DTO
{
    public class GoogleDTO : TipoUserDTO
    {
        public int IdClienteGoogle { get; set; }
        public string IdEmailGl { get; set; }
        public string NomeCompletoGl { get; set; }
        public string PrimeiroNomeGl { get; set; }
        public string SobrenomeGl { get; set; }
        public string EmailGl { get; set; }
        public int FkClienteGl { get; set; }
        public DateTime DateTimeInsertGl { get; set; }
        public DateTime? DateTimeUpdateGl { get; set; }
    }
}
