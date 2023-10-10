using FW.DAL;
using FW.DTO;
using System;
using System.Collections.Generic;

namespace FW.BLL
{
    public class ProfissionalBLL
    {
        readonly ProfissionalDAL ProfissionalDAL = new ProfissionalDAL();
        private readonly HistoricoDTO HistoricoDTO = new HistoricoDTO();
        readonly HistoricoBLL HistoricoBLL = new HistoricoBLL();

        //Cadastrar Profissional - Insert
        public void CadastrarProfissional(ProfissionalDTO objCad)
        {
             ProfissionalDAL.Cadastrar(objCad);
            HistoricoDTO.FkClienteHt = objCad.FkClienteTu;
            HistoricoBLL.Cadastrar_Inclusao(HistoricoDTO);
        }

        //Listar
        public List<ProfissionalDTO> ListaProfissional()
        {
            return ProfissionalDAL.Listar();
        }
           
        public ProfissionalDTO Autentica_IDCliente(int idcliente)
        {
            return ProfissionalDAL.Autentica_IDCliente(idcliente);
        }
        
        //selecionar
        public ProfissionalDTO SelecionarIdProfissional(int IdProfissional)
        {
            return ProfissionalDAL.SelecionarIdProfissional(IdProfissional);
        }
        public ProfissionalDTO Select_Profissional_IdCliente(int IdCliente)
        {
            return ProfissionalDAL.Select_Profissional_IdCliente(IdCliente);
        }
        public void Editar_FormacaoEscolar_CaminhoCurriculo(ProfissionalDTO objEdita)
        {
            ProfissionalDAL.Editar_FormacaoEscolar_CaminhoCurriculo(objEdita);
            HistoricoDTO.FkClienteHt = objEdita.FkClienteTu;
            HistoricoDTO.DescricaoHt = "Dados de perfil profissional atualizado";
            HistoricoBLL.Cadastrar(HistoricoDTO);
        }

       
       
      
        public List<ProfissionalDTO> Pesquisa_profissional(ProfissionalDTO profissionalDTO)
        {
            return ProfissionalDAL.Pesquisa_profissional(profissionalDTO);
        }
    }
}
