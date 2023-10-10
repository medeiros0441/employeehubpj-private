using FW.DAL;
using FW.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FW.BLL
{
    public class NotificacaoBLL
    {
        protected  ClienteDAL ClienteDAL = new ClienteDAL();
        protected HistoricoDAL HistoricoDAL = new HistoricoDAL();
        protected TipoUserDAL TipoUserDAL = new TipoUserDAL();
        protected ProfissionalDAL ProfissionalDAL = new ProfissionalDAL();
        protected EmpresaDAL EmpresaDAL = new EmpresaDAL();
        protected NotificacaoDAL NotificacaoDAL = new NotificacaoDAL();

        protected EmpresaDTO EmpresaDTO = new EmpresaDTO();
        protected ProfissionalDTO ProfissionalDTO = new ProfissionalDTO();
        protected TipoUserDTO TipoUserDTO = new TipoUserDTO();
        protected ClienteDTO ClienteDTO = new ClienteDTO();
        protected HistoricoDTO HistoricoDTO = new HistoricoDTO();

        public void CadastrarNotificacao(NotificacaoDTO notificacao)
        {
            try
            {
                // Aqui você deve validar os dados da notificação antes de chamar o método do DAL.
                // Se os dados não estiverem válidos, lance uma exceção informando o motivo.

                NotificacaoDAL.CadastrarNotificacao(notificacao);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar notificação! " + ex.Message);
            }
        }

        public void ExcluirNotificacao(int id_notificacao, int fk_cliente)
        {
            try
            {
                // Aqui você deve validar se o cliente tem permissão para excluir a notificação com o id especificado.
                // Se ele não tiver permissão, lance uma exceção informando o motivo.

                NotificacaoDAL.Excluir_Notificacao(id_notificacao, fk_cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir notificação! " + ex.Message);
            }
        }
        public List<NotificacaoDTO> ListarNotificacoes(int Fk_Cliente)
        {
            try
            {
                // Aqui você pode fazer validações adicionais, como verificar se o cliente existe ou se ele tem permissão para acessar as notificações.

                return NotificacaoDAL.Listar_Notificacoes(Fk_Cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar notificações! " + ex.Message);
            }
        }

        public void AtualizarVisibilidade(int idNotificacao, bool visibilidade)
        {
            try
            {
                NotificacaoDAL.AtualizarVisibilidade(idNotificacao, visibilidade);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar visibilidade da notificação: " + ex.Message);
            }
        }
    }


}
