using FW.DAL;
using FW.DTO;
using System.Collections.Generic;

namespace FW.BLL
{
    public class ComentarioBLL : ObjetoCompartilhado
    {
        protected ComentarioDAL ComentarioDAL = new ComentarioDAL();


        public void Cadastrar_Publicacao(ComentarioDTO ComentarioDTO)
        {
            ComentarioDAL.CadastrarComentario(ComentarioDTO);
        }

        public List<ComentarioDTO> Filtrar(ComentarioDTO ComentarioDTO)
        {
            return ComentarioDAL.Filtrar(ComentarioDTO);
        }
        //Editar
        public void Editar_cliente(ComentarioDTO ComentarioDTO)
        {
            ComentarioDAL.Editar_cliente(ComentarioDTO);
        }
        //Delete
        public void Excluir_Publicacao(ComentarioDTO ComentarioDTO)
        {
            ComentarioDAL.Excluir_comentario(ComentarioDTO.IdComentario);
        }


    }
}
