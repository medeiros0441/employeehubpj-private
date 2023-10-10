using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.DTO
{
    public class RedesocialDTO : TipoUserDTO
    {
        public int IdRede { get; set; }
        public string LinkRedeRs { get; set; }
        public string DescricaoRedeRs { get; set; }
        public DateTime DateTimeInsertRs { get; set; }
        public DateTime? DateTimeUpdateRs { get; set; }
        public int FkClienteRs { get; set; }

    }
}
