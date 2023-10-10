using FW.DAL;
using FW.DTO;
using System.Collections.Generic;

namespace FW.BLL
{
    public class HistoricoBLL : ObjetoCompartilhado
    {

        protected HistoricoDTO HistoricoDTO = new HistoricoDTO();
        protected HistoricoDAL HistoricoDAL = new HistoricoDAL();
        //Cadastrar  - Insert
        public void Cadastrar(HistoricoDTO objCad)
        {
            HistoricoDAL.Cadastrar(objCad);
        }  //Cadastrar   - Insert
        public void Cadastrar_Senha_Historico(HistoricoDTO objCad)
        {
            HistoricoDAL.Cadastrar_Senha(objCad);
        }  //Cadastrar   - Insert
        public void Cadastrar_Inclusao(HistoricoDTO objCad)
        {
            HistoricoDAL.Cadastrar_Inclusao(objCad);
        }


        //autentica Cadastro
        public HistoricoDTO Autenticar_Historico_ID_email( int objClienteID)
        {
            return HistoricoDAL.AutenticarHistorico( objClienteID);
        }

        public HistoricoDTO EditarHistorico(HistoricoDTO objEdita)
        {
            return HistoricoDAL.EditarHistorico(objEdita);
        }

       

    }
}
