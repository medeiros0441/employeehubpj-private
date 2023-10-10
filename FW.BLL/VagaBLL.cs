using FW.DAL;
using FW.DTO;
using System;
using System.Collections.Generic;

namespace FW.BLL
{
    public class VagaBLL : ObjetoCompartilhado
    {
        protected VagaDAL VagaDAL = new VagaDAL();

        //Cadastrar Vaga - Insert
        public void CadastrarVaga(VagaDTO objCad)
        {
            VagaDAL.Cadastrar(objCad);
        }

        //Listar
        public List<VagaDTO> ListarVaga(bool status_adm)
        {
            return VagaDAL.Listar(status_adm);
        }
        public VagaDTO SelecionarVaga(int IdVaga, bool status_adm)
        {
            return VagaDAL.Selecionar(IdVaga, status_adm);
        }

        public void ExcluirVaga(VagaDTO objEdita)
        {
            VagaDAL.Excluir(objEdita);
        }//Editar

        public void EditarVaga(VagaDTO objEdita)
        {
            VagaDAL.Editar(objEdita);
        }
        public List<VagaDTO> Listar_Vagas_ativa_Empresa(int idempresa)
        {
            return VagaDAL.Listar_Vagas_ativa_Empresa(idempresa);
        }
     
        public List<VagaDTO> BuscarVaga(VagaDTO vagaDTO)
        {
            return VagaDAL.Buscar_Vaga_Geral(vagaDTO);
        }
        //Filtrar por id

        public VagaDTO SelecionarVagaAtivaEmpresa(int idVaga, int idEmpresa)
        {
            try
            {
                return VagaDAL.Selecionar_Vaga_Ativa_Empresa(idVaga, idEmpresa);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Filtrar!" + ex.Message);
            }
        }
    }

}
