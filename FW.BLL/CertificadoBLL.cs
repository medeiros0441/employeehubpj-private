using FW.DAL;
using FW.DTO;
using System.Collections.Generic;

namespace FW.BLL
{
    public class CertificadoBLL
    {
        protected CertificadoDAL objDAL = new CertificadoDAL();
        protected HistoricoDTO HistoricoDTO = new HistoricoDTO();
      protected  HistoricoBLL HistoricoBLL = new HistoricoBLL();
        



        //Cadastrar Certificado - Insert
        public void CadastrarCertificado(CertificadoDTO objCad)
        {
            objDAL.Cadastrar(objCad);
        }

        //Listar
        public List<CertificadoDTO> ListarCertificado()
        {
            return objDAL.Listar();
        }

        //Editar
        public void EditarCertificado(CertificadoDTO objEdita)
        {
            objDAL.Editar(objEdita);
        }

        //Delete
        public void ExcluirCertificado(int objExclui)
        {
            objDAL.Excluir(objExclui);
        }
        public CertificadoDTO SelecionarCertificado(int idCertificado)
        {
            return objDAL.Selecionar_IDCertificado(idCertificado);
        }


        public List<CertificadoDTO> ListarCertificado_IDProfissional(int idProfissional)
        {
            return objDAL.ListarCertificado(idProfissional);
        }
        
       
    }
}
