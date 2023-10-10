using System;

namespace FW.DTO
{
    public class ProfissionalDTO : TipoUserDTO
    {
        public int IdProfissional { get; set; }
        public string FormacaoEscolarPf { get; set; }
        public int FkTipouserPf { get; set; }
        public DateTime DateTimeInsertPf { get; set; }
        public DateTime? DateTimeUpdatePf { get; set; }
        public string CaminhoDocCurriculoPf { get; set; }
        public DateTime? DateTimePrivacidadePf { get; set; }
        public DateTime? DateTimeTermosPf { get; set; }
    }
}
