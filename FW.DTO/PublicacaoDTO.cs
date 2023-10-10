using System;

namespace FW.DTO
{
    public class PublicacaoDTO : TipoUserDTO
    {
        public int IdPublicacao { get; set; }
        public int FkClientePb { get; set; }
        public DateTime DateTimeInsertPb { get; set; }
        public DateTime DateTimeUpdatePb { get; set; }
        public string DescricaoPb { get; set; }
        public string UrlImagen1Pb { get; set; }
        public string UrlImagen2Pb { get; set; }
        public string UrlImagen3Pb { get; set; }
        public string UrlVideo1Pb { get; set; }
        public string UrlVideo2Pb { get; set; }

    }

}
