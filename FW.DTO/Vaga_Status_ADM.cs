using System;

namespace FW.DTO
{

    public class Vaga_Status_Adm_DTO : VagaDTO
    {
        public int IdVagaStatusVsa { get; set; }
        public string StatusVsam { get; set; }
        public DateTime DateVsa { get; set; }
        public string DescricaoVsa { get; set; }
        public int FkVagaVsa { get; set; }
    }
    public class Visita_Vaga_Adm_DTO
    {
        public int IdVisitaVga { get; set; }
        public int FkVagaVga { get; set; }
        public int FkProfissionalVga { get; set; }
        public DateTime DateTimeInsertVga { get; set; }
        public DateTime? DateTimeUpdateVga { get; set; }
        public TimeSpan? TimeViewVga { get; set; }
    }
}
