using System;

namespace FW.DTO
{
    public class VagaDTO : EmpresaDTO
    {
        public int IdVaga { get; set; }
        public string NomeVg { get; set; }
        public string TempoExperienciaVg { get; set; }
        public string TipoRegistroVg { get; set; }
        public string TipoVagaVg { get; set; }
        public string TipoContratoVg { get; set; }
        public string DescricaoVg { get; set; }
        public string SexoVg { get; set; }
        public string DescricaoValidadeVg { get; set; }
        public DateTime DateTimeInsertVg { get; set; }
        public DateTime DateTimeUpdateVg { get; set; }
        public bool StatusVg { get; set; }
        public int FkEmpresaVg { get; set; }
    } 
}
