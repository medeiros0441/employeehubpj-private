using FW.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.DAL
{
    public class GerenciamentoSaldoDAL : Conexao
    {
      

        public decimal GetSaldo(int idCliente)
        {
            try
            {

                Conectar(); 
                string query = "SELECT saldo_atual_cl FROM tb_cliente WHERE id_cliente = @id";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", idCliente);

                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    return Convert.ToDecimal(result);
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro, SaldoDAL" + ex.Message);

            }
            finally
            {
                Desconectar();

            }
        }

        protected void SetSaldo(int idCliente, decimal novoSaldo)
        {
            try
            {
                Conectar();
                string query = "UPDATE tb_cliente SET saldo_atual_cl = @saldo WHERE id_cliente = @id";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@saldo", novoSaldo);
                command.Parameters.AddWithValue("@id", idCliente);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro, SaldoDAL" + ex.Message);

            }
            finally
            {
                Desconectar();
            }
        }
        public void AtualizarSaldo(int idCliente, decimal valor)
        {
            try
            {
                // Obtém o saldo atual do cliente
                decimal saldoAtual = GetSaldo(idCliente);

                // Soma o valor atual com o novo valor
                decimal novoSaldo = saldoAtual + valor;

                // Atualiza o saldo na coluna saldo_cl da tabela tb_cliente
                SetSaldo(idCliente, novoSaldo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro, SaldoDAL" + ex.Message);

            }
        }

        public void Create(GerenciamentoSaldoDTO gerenciamentoSaldo)
        {
            try
            {


                string query = @"INSERT INTO tb_gerenciamento_saldo (saldo_atual_GS, saldo_anterior_GS, date_time_insert_GS,date_time_update_GS, descricao_GS, fk_cliente_GS, fk_pagamento_GS)
                                VALUES (@saldo_atual, @saldo_anterior, @date_time_insert, @date_time_update,@descricao, @fk_cliente, @fk_pagamento)";
                Conectar();

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@saldo_atual", gerenciamentoSaldo.SaldoAtualGs);
                command.Parameters.AddWithValue("@saldo_anterior", gerenciamentoSaldo.SaldoAnteriorGs);
                command.Parameters.AddWithValue("@date_time_insert", gerenciamentoSaldo.DateTimeInsertGs = DataHoraAtual);
                command.Parameters.AddWithValue("@date_time_update", gerenciamentoSaldo.DateTimeUpdateGs= DataHoraAtual);
                command.Parameters.AddWithValue("@descricao", gerenciamentoSaldo.DescricaoGs);
                command.Parameters.AddWithValue("@fk_cliente", gerenciamentoSaldo.FkClienteGs);
                command.Parameters.AddWithValue("@fk_pagamento", gerenciamentoSaldo.FkPagamentoGs);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro, SaldoDAL" + ex.Message);

            }
            finally
            {
                Desconectar();
            }
        }

        public GerenciamentoSaldoDTO Read(int id)
        {
            try
            {
              Conectar();
                string query = "SELECT * FROM tb_gerenciamento_saldo WHERE id_saldo = @id";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    GerenciamentoSaldoDTO gerenciamentoSaldo = new GerenciamentoSaldoDTO
                    {
                        IdSaldo = (int)reader["id_saldo"],
                        SaldoAtualGs = (decimal)reader["saldo_atual_GS"],
                        SaldoAnteriorGs = (decimal)reader["saldo_anterior_GS"],
                        DateTimeInsertGs = (DateTime)reader["date_time_insert_GS"],
                        DateTimeUpdateGs = (DateTime)reader["date_time_update_GS"],
                        DescricaoGs = (string)reader["descricao_GS"],
                        FkClienteGs = (int)reader["fk_cliente_GS"],
                        FkPagamentoGs = (int)reader["fk_pagamento_GS"]
                    };

                    return gerenciamentoSaldo;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro, SaldoDAL" + ex.Message);

            }
            finally
            {
                Desconectar();
            }
        }

        public void Update(GerenciamentoSaldoDTO gerenciamentoSaldo)
        {
            try
            {
                Conectar();
                string query = @"UPDATE tb_gerenciamento_saldo SET saldo_atual_GS = @saldo_atual, saldo_anterior_GS = @saldo_anterior,
                                date_time_update_GS = @date_time_update, descricao_GS = @descricao, fk_cliente_GS = @fk_cliente, fk_pagamento_GS = @fk_pagamento
                                WHERE id_saldo = @id";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@saldo_atual", gerenciamentoSaldo.SaldoAtualGs);
                command.Parameters.AddWithValue("@saldo_anterior", gerenciamentoSaldo.SaldoAnteriorGs);
                command.Parameters.AddWithValue("@date_time_update", gerenciamentoSaldo.DateTimeUpdateGs);
                command.Parameters.AddWithValue("@descricao", gerenciamentoSaldo.DescricaoGs);
                command.Parameters.AddWithValue("@fk_cliente", gerenciamentoSaldo.FkClienteGs);
                command.Parameters.AddWithValue("@fk_pagamento", gerenciamentoSaldo.FkPagamentoGs);
                command.Parameters.AddWithValue("@id", gerenciamentoSaldo.IdSaldo);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro, SaldoDAL" + ex.Message);

            }
            finally
            {
                Desconectar();
            }
        }

        public void Delete(int id)
        {
            try
            {
              Conectar();
                string query = "DELETE FROM tb_gerenciamento_saldo WHERE id_saldo = @id";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro, SaldoDAL" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public List<GerenciamentoSaldoDTO> GetAll()
        {
            try
            {
              Conectar();
                string query = "SELECT * FROM tb_gerenciamento_saldo";
                SqlCommand command = new SqlCommand(query, conn);

                SqlDataReader reader = command.ExecuteReader();

                List<GerenciamentoSaldoDTO> gerenciamentoSaldos = new List<GerenciamentoSaldoDTO>();
                while (reader.Read())
                {
                    GerenciamentoSaldoDTO gerenciamentoSaldo = new GerenciamentoSaldoDTO
                    {
                        IdSaldo = (int)reader["id_saldo"],
                        SaldoAtualGs = (decimal)reader["saldo_atual_GS"],
                        SaldoAnteriorGs = (decimal)reader["saldo_anterior_GS"],
                        DateTimeInsertGs = (DateTime)reader["date_time_insert_GS"],
                        DateTimeUpdateGs = (DateTime)reader["date_time_update_GS"],
                        DescricaoGs = (string)reader["descricao_GS"],
                        FkClienteGs = (int)reader["fk_cliente_GS"],
                        FkPagamentoGs = (int)reader["fk_pagamento_GS"]
                    };

                    gerenciamentoSaldos.Add(gerenciamentoSaldo);
                }

                return gerenciamentoSaldos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro, SaldoDAL" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
    }
   
}
