using System;

namespace FW.DTO
{
    public class HistoricoDTO : TipoUserDTO
    {
        public int IdHistorico { get; set; }
        public string DescricaoHt { get; set; }
        public DateTime DateTimeInsertHt { get; set; }
        public DateTime? DateTimeUpdateHt { get; set; }
        public int FkClienteHt { get; set; }
    }
}
