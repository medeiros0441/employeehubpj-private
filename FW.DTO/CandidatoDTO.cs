using System;

namespace FW.DTO
{
    public class CandidatoDTO : VagaDTO
    {
        public int IdCandidato { get; set; }
        public int FkProfissionalCt { get; set; }
        public DateTime DateTimeInsertCt { get; set; }
        public DateTime DateTimeUpdateCt { get; set; }
        public int FkVagaCt { get; set; }
        public bool StatusCt { get; set; }
    }
}
