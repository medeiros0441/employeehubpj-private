using FW.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace FW.DAL
{
    public class NotificacaoDAL : Conexao
    {

        public void CadastrarNotificacao(NotificacaoDTO NotificacaoDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand(" INSERT INTO tb_notificacao (titulo_NC, date_time_insert_NC, mensagem_NC, fk_cliente_NC, visibilidade_NC) values (@v1,@v2,@v3,@v4,@v5);", conn);
                cmd.Parameters.AddWithValue("@v1", NotificacaoDTO.TituloNc);
                cmd.Parameters.AddWithValue("@v2", NotificacaoDTO.DateTimeInsertNc =  DataHoraAtual);
                cmd.Parameters.AddWithValue("@v3", NotificacaoDTO.MensagemNc);
                cmd.Parameters.AddWithValue("@v4", NotificacaoDTO.FkClienteNc);
                cmd.Parameters.AddWithValue("@v5", NotificacaoDTO.VisibilidadeNc = false);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar Cliente!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public List<NotificacaoDTO> Listar_Notificacoes(int Fk_Cliente)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM tb_notificacao where fk_cliente_NC =@v1 ORDER BY date_time_update_NC  DESC", conn);
                cmd.Parameters.AddWithValue("@v1", Fk_Cliente);
                dr = cmd.ExecuteReader();
                List<NotificacaoDTO> Lista = new List<NotificacaoDTO>();
                return Lista = ListInsereDTO<NotificacaoDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar notificações!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
             
        }

        public void Excluir_Notificacao(int idNotificacao, int idCliente)
        {
            try
            {
                Conectar();
                SqlCommand cmd = new SqlCommand("DELETE FROM tb_notificacao WHERE   id_notificacao = @idNotificacao AND fk_cliente = @idCliente", conn);
                cmd.Parameters.AddWithValue("@idNotificacao", idNotificacao);
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir notificação: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public void AtualizarVisibilidade(int idNotificacao, bool visibilidade)
        {
            try
            {
                Conectar();
                SqlCommand cmd = new SqlCommand("UPDATE tb_notificacao SET visibilidade_NC = @visibilidade WHERE id_notificacao = @idNotificacao", conn);
                cmd.Parameters.AddWithValue("@idNotificacao", idNotificacao);
                cmd.Parameters.AddWithValue("@visibilidade", visibilidade);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar visibilidade da notificação: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

    }
}
