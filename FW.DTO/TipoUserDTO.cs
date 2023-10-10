using System;

namespace FW.DTO
{
    public class TipoUserDTO : ClienteDTO
    {
        public int IdTipouser { get; set; }
        public string DescricaoTu { get; set; }
        public int CodigoTu { get; set; }
        public bool StatusTu { get; set; }
        public int FkClienteTu { get; set; }
        public DateTime DateTimeInsertTu { get; set; }
        public DateTime? DateTimeUpdateTu { get; set; }
    }
}
