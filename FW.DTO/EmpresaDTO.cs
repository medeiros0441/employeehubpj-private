using System;

namespace FW.DTO
{
    public class EmpresaDTO : TipoUserDTO
    {

        public int IdEmpresa { get; set; }
        public string NumeroCnpjEp { get; set; }
        public string NomeFantasiaEp { get; set; }
        public string RazaoSocialEp { get; set; }
        public DateTime DateTimeTermosEp { get; set; }
        public DateTime DateTimePrivacidadeEp { get; set; }
        public DateTime DateTimeInsertEp { get; set; }
        public DateTime? DateTimeUpdateEp { get; set; }
        public DateTime DateAberturaEp { get; set; }
        public int FkTipouserEp { get; set; }
    }
}
