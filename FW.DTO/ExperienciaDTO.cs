using System;

namespace FW.DTO
{
    public class ExperienciaDTO : ProfissionalDTO
    {
        public int IdExperiencia { get; set; }
        public string NomeCargoEx { get; set; }
        public string NomeEmpresaEx { get; set; }
        public DateTime DateTimeInsertEx { get; set; }
        public DateTime DateTimeUpdateEx { get; set; }
        public string TipoContratoEx { get; set; }
        public string DescricaoEx { get; set; }
        public DateTime DateInicioEx { get; set; }
        public DateTime DateFinalizouEx { get; set; }
        public int FkProfissionalEx { get; set; }


    }
}
