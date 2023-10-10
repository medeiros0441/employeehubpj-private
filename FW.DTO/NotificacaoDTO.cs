using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.DTO
{
    public class NotificacaoDTO : TipoUserDTO
    {
        public int IdNotificacao { get; set; }
        public string TituloNc { get; set; }
        public DateTime DateTimeInsertNc { get; set; }
        public DateTime? DateTimeUpdateNc { get; set; }
        public string MensagemNc { get; set; }
        public int FkClienteNc { get; set; }
        public bool VisibilidadeNc { get; set; }

    }
}
