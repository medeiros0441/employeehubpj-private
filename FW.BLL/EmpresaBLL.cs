using FW.DAL;
using FW.DTO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
    
namespace FW.BLL
{
   

    public class EmpresaBLL : ObjetoCompartilhado
    {

        protected HistoricoDTO HistoricoDTO = new HistoricoDTO();
        protected HistoricoDAL HistoricoDAL = new HistoricoDAL();
        protected EmpresaDAL EmpresaDAL = new EmpresaDAL();

        public int CadastrarEmpresaRetornandoId(EmpresaDTO empresaDTO)
        {
            try
            { 
                int id_empresa = EmpresaDAL.Cadastrar(empresaDTO);

                HistoricoDTO.IdCliente = empresaDTO.IdCliente;
                HistoricoDAL.Cadastrar_Inclusao(HistoricoDTO);
                return id_empresa; 
                                                            
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar empresa e retornar id!" + ex.Message);
            }
        }

        public EmpresaDTO AutenticarCnpj(EmpresaDTO cnpj)
        {

            EmpresaDTO EmpresaDTO = EmpresaDAL.AutenticarCnpj(cnpj);
            return EmpresaDTO;
        }

        public EmpresaDTO ConsultarPorId(int idEmpresa)
        {
            try
            {
                return EmpresaDAL.ConsultarPorId(idEmpresa);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Consultar Empresa!" + ex.Message);
            }
        }

        public EmpresaDTO Select_Empresa_IdCliente(int IdCliente)
        {
            try
            {
                return EmpresaDAL.Select_Empresa_IdCliente(IdCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Consultar Empresa!" + ex.Message);
            }
        }
        public List<EmpresaDTO> Listar()
        {
            try
            {
                return EmpresaDAL.ListarEmpresas();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar  Empresa!" + ex.Message);
            }
        }

        public EmpresaDTO EditarEmpresa(EmpresaDTO empresaDTO)
        {
            // Validações de negócio...
            EmpresaDTO retorno =  EmpresaDAL.EditarEmpresa(empresaDTO);
            HistoricoDTO.FkClienteHt = empresaDTO.FkClienteTu;
            HistoricoDTO.DescricaoHt = "Dados Empresa Alterado!";
             HistoricoDAL.Cadastrar(HistoricoDTO);
            return retorno;
        }

 

    }



}
