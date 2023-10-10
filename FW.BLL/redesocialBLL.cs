using FW.DAL;
using FW.DTO;
using System.Collections.Generic;//

namespace FW.BLL
{
    public class RedesocialBLL : ObjetoCompartilhado
    {

        protected RedesocialDAL RedesocialDAL = new RedesocialDAL();

        //Cadastrar  - Insert
        public void Cadastrar_Link(RedesocialDTO objCad)
        {
            RedesocialDAL.Cadastrar(objCad);
        }

        //Listar
        public List<RedesocialDTO> Listar_Fkcliente(int id_cliente)
        {
            return RedesocialDAL.Listar_Fkcliente(id_cliente);
        }

        //Delete
        public void Excluir(int idrede, int idcliente)
        {
            RedesocialDAL.Excluir(idrede, idcliente);
        }
        public void Editar(RedesocialDTO objEdita)
        {
            RedesocialDAL.Editar(objEdita);
        }

        //sElecionar
        public RedesocialDTO GetRedesSociaisPorID(int id_rede)
        {
            return RedesocialDAL.GetRedesSociaisPorID(id_rede);
        }
        public RedesocialDTO SelecionarRede_ID_DESCRICAO(RedesocialDTO redesocialDTO)
        {
            return RedesocialDAL.SelecionarID_Descricao(redesocialDTO);
        }


         

    }
}
