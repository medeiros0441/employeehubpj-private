using FW.DAL;
using FW.DTO;
using System.Collections.Generic;

namespace FW.BLL
{
    public class CandidatoBLL : ObjetoCompartilhado
    {
        protected CandidatoDAL CandidatosDAL = new CandidatoDAL();

        //Cadastrar Vaga - Insert
        public void Cadastrar_Profissional_Vaga(CandidatoDTO objCad)
        {
            CandidatosDAL.CadastrarVP(objCad);
        }

        //Listar
        public List<CandidatoDTO> ListarCandidatos()
        {
            return CandidatosDAL.Listar();
        }
  


        //Delete
        public void ExcluirCandidatura(int idVaga, int idProfissional)
        {
            CandidatosDAL.Excluir(idVaga, idProfissional);
        }

        //status
        public void AtualizarStatusCandidatura(int idVaga, int idProfissional, bool status)
        {
            CandidatosDAL.AtualizarStatusCandidatura(idVaga, idProfissional, status);
        }

        //Filtrar
        public List<CandidatoDTO> FiltrarVaga(int ID_vaga)
        {
            return CandidatosDAL.Filtrar(ID_vaga);
        }
        //Filtrar ID
        //public List<CandidatoDTO> FiltrarID(int idProfissional)
        //{
        //    return CandidatosDAL.FiltrarID(idProfissional);
        //}
         
        public List<CandidatoDTO> ListCantdidaturaProfissional(int id_profissional)
        {
            return CandidatosDAL.ListCantdidaturaProfissional(id_profissional);

        }
        public List<CandidatoDTO> List_Candidato_Empresa(CandidatoDTO CandidatosDTO)
        {
            return CandidatosDAL.List_Candidato_Empresa_IDVAGA(CandidatosDTO);
        }
        public List<CandidatoDTO> List_Candidato_Empresa_IDVaga(CandidatoDTO CandidatosDTO)
        {
            return CandidatosDAL.List_Candidato_Empresa_IDVAGA(CandidatosDTO);

        }
        //Selecionar

        //public CandidatoDTO SelecionaProfissional(CandidatoDTO CandidatosDTO)
        //{
        //    return CandidatosDAL.SelecionarProfissional(CandidatosDTO);
        //}
        public bool AutenticandoVeP(int idVaga, int idProfissional)
        {
            CandidatoDTO CandidatoDTO = CandidatosDAL.AutenticandoVeP(idVaga, idProfissional);
            if (CandidatoDTO.IdCandidato != 0)
            {
                return true;
            }
            return false;

        }
    }
}
