using FW.DAL;
using FW.DTO;
using System.Collections.Generic;

namespace FW.BLL
{
    public class PublicacaoBLL
    {
        protected PublicacaoDAL PublicacaoDAL = new PublicacaoDAL();
        //Cadastrar_Publicacao
        public PublicacaoDTO Cadastrar_Publicacao(PublicacaoDTO PublicacaoDTO) => _ = PublicacaoDAL.Cadastrar_Publicacao(PublicacaoDTO);
        //Listar
        public List<PublicacaoDTO> Filtrar()
        {
            return PublicacaoDAL.Filtrar();
        }
        //Editar
        public void Editar_cliente(PublicacaoDTO PublicacaoDTO)
        {
            PublicacaoDAL.Editar_cliente(PublicacaoDTO);
        }
        //Delete
        public void Excluir_Publicacao(PublicacaoDTO PublicacaoDTO)
        {
            PublicacaoDAL.Excluir_Publicacao(PublicacaoDTO);
        }
        //Filtrar
        public List<PublicacaoDTO> Filtrar_ID(PublicacaoDTO PublicacaoDTO)
        {
            return PublicacaoDAL.Filtrar_ID(PublicacaoDTO);
        }
        //Selecionar
        public PublicacaoDTO Selecionar_IdCliente_IdPublicacao(PublicacaoDTO PublicacaoDTO)
        {
            return PublicacaoDAL.Selecionar_ID(PublicacaoDTO);
        }
        

    }
}
