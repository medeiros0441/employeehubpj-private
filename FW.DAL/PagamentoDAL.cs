using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FW.DTO;
using System.Data.SqlClient;
using System.Data;
namespace FW.DAL
{
    public class PagamentoDAL : Conexao
    {

        // Método para inserir um novo pagamento no banco de dados


        public int CadastrarPagamento(PagamentoDTO pagamento)
        {
            try
            {
                Conectar();


                string query = @"INSERT INTO tb_pagamento (valor_PG, tipo_pagamento_PG, nome_produto_PG, qrcodepix_PG, img_qrcodebase64_PG, paymentid_PG, status_PG, date_time_insert_PG, date_time_update_PG, fk_cliente_PG) 
                             VALUES (@valor, @tipoPagamento, @nomeProduto, @qrcodePix, @imgQrCodeBase64, @paymentId, @status, @dateTimeInsert, @dateTimeUpdate, @fkCliente);
                             SELECT SCOPE_IDENTITY();";
                //Comando para inserir pagamento e retornar o ID do pagamento inserido
                  cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@valor", pagamento.ValorPg);
                cmd.Parameters.AddWithValue("@tipoPagamento", pagamento.TipoPagamentoPg = "PIX");
                cmd.Parameters.AddWithValue("@nomeProduto", pagamento.NomeProdutoPg);
                cmd.Parameters.AddWithValue("@qrcodePix", pagamento.QrcodepixPg);
                cmd.Parameters.AddWithValue("@imgQrCodeBase64", pagamento.ImgQrcodebase64Pg);
                cmd.Parameters.AddWithValue("@paymentId", pagamento.PaymentidPg);
                cmd.Parameters.AddWithValue("@status", pagamento.StatusPg);
                cmd.Parameters.AddWithValue("@dateTimeInsert", DataHoraAtual);
                cmd.Parameters.AddWithValue("@dateTimeUpdate",  DataHoraAtual);
                cmd.Parameters.AddWithValue("@fkCliente", pagamento.FkClientePg);
 

                int idPagamento = Convert.ToInt32(cmd.ExecuteScalar()); //Executa a query e obtém o ID do pagamento inserido

                return idPagamento;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar pagamento!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public List<PagamentoDTO> ListarPagamentos()
        {
            try
            {
                Conectar();
                SqlCommand cmd = new SqlCommand("SELECT  * FROM TB_Pagamento  ORDER BY date_time_update_PG DESC", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                List<PagamentoDTO> Lista = new List<PagamentoDTO>();
                return Lista = ListInsereDTO<PagamentoDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar pagamentos!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public List<PagamentoDTO> ListarPagamentos(int fkCliente)
        {

            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM TB_Pagamento  where fk_cliente_PG = @fkCliente  ORDER BY date_time_update_PG DESC", conn);
                cmd.Parameters.AddWithValue("@fkCliente", fkCliente);

                SqlDataReader dr = cmd.ExecuteReader();
                List<PagamentoDTO> Lista = new List<PagamentoDTO>();
                return Lista = ListInsereDTO<PagamentoDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar pagamentos! " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public PagamentoDTO SelecionarPagamento(int fkCliente, int idPagamento)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM TB_Pagamento WHERE fk_cliente_PG = @fkCliente AND Id_Pagamento = @idPagamento  ORDER BY date_time_update_PG DESC", conn);
                cmd.Parameters.AddWithValue("@fkCliente", fkCliente);
                cmd.Parameters.AddWithValue("@idPagamento", idPagamento);

                SqlDataReader dr = cmd.ExecuteReader();
                PagamentoDTO obj = new PagamentoDTO();
                return obj = InsereDTO<PagamentoDTO>( dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar pagamento! " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public void AtualizarPagamento(int idPagamento, int fkCliente, string novoStatus)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE tb_pagamento SET status_PG = @novoStatus, date_time_update_PG = @dataAtualizacao WHERE id_pagamento = @idPagamento AND fk_cliente_PG = @fkCliente", conn);
                cmd.Parameters.AddWithValue("@novoStatus", novoStatus);
                cmd.Parameters.AddWithValue("@dataAtualizacao",DataHoraAtual);
                cmd.Parameters.AddWithValue("@idPagamento", idPagamento);
                cmd.Parameters.AddWithValue("@fkCliente", fkCliente);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar pagamento!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
