namespace FW.DTO
{
    public class AdministrativoDTO : TipoUserDTO
    {
        public int IdAdministrativo { get; set; }
        public string Email_Adm { get; set; }
        public string Nome_Admin { get; set; }
        public string Senha_Admin { get; set; }
        public string Url_foto { get; set; }
        public int FK_TipoUser { get; set; }
    }
}
