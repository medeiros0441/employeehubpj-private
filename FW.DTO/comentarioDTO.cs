using System;

namespace FW.DTO
{
    public class ComentarioDTO : PublicacaoDTO
    {
        public int IdComentario { get; set; }
        public DateTime DateTimeInsertCm { get; set; }
        public DateTime? DateTimeUpdateCm { get; set; }
        public string ComentarioCm { get; set; }
        public int FkPublicacaoCm { get; set; }
        public int FkClienteCm { get; set; }

    }
}
