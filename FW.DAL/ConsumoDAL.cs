using FW.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient; 

namespace FW.DAL
{
    public class ConsumoDAL : Conexao
    { 
        public int Create(ConsumoDTO consumo)
        {
            try
            {
                Conectar();
                string query = @"INSERT INTO tb_consumo (fk_empresa_CS, fk_profissional_CS, fk_sessao_CS, date_time_insert_CS, date_time_update_CS, valor_descontado_CS)
                     VALUES (@fk_empresa, @fk_profissional, @fk_sessao, @date_time_insert, @date_time_update, @valor_descontado);
                     SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@fk_empresa", consumo.FkEmpresaCs);
                command.Parameters.AddWithValue("@fk_profissional", consumo.FkProfissionalCs);
                command.Parameters.AddWithValue("@fk_sessao", consumo.FkSessaoCs);
                command.Parameters.AddWithValue("@date_time_insert", DataHoraAtual);
                command.Parameters.AddWithValue("@date_time_update", DataHoraAtual);
                command.Parameters.AddWithValue("@valor_descontado", consumo.ValorDescontadoCs);

                 int idCriado = Convert.ToInt32(command.ExecuteScalar());
                return idCriado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public ConsumoDTO Read(int id)
        {
            try
            {

                string query = "SELECT * FROM tb_consumo WHERE id_consumo = @id";
                Conectar();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader dr = cmd.ExecuteReader();
                ConsumoDTO ConsumoDTO = InsereDTO<ConsumoDTO>(dr);
                return ConsumoDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public void UpdateTime(ConsumoDTO consumo)
        {
            try
            {
                string query = @"UPDATE tb_consumo SET date_time_update_CS = @date_time_update, tempo_view_CS = @tempo_view, valor_descontado_CS = @valor_descontado WHERE id_consumo = @id";

                Conectar();
                SqlCommand command = new SqlCommand(query, conn); command.Parameters.AddWithValue("@date_time_update", DataHoraAtual);
                command.Parameters.AddWithValue("@tempo_view", consumo.TempoViewCs);

                command.Parameters.AddWithValue("@valor_descontado", consumo.ValorDescontadoCs);
                command.Parameters.AddWithValue("@id", consumo.IdConsumo);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                string query = "DELETE FROM tb_consumo WHERE id_consumo = @id";
                Conectar();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public List<ConsumoDTO> GetAll()
        {
            try
            {
                string query = "SELECT * FROM tb_consumo";
                Conectar();
                SqlCommand cmd = new SqlCommand(query, conn);


                List<ConsumoDTO> listaConsumos = new List<ConsumoDTO>();
                SqlDataReader reader = cmd.ExecuteReader();
                listaConsumos = ListInsereDTO<ConsumoDTO>(reader);
                return listaConsumos;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public List<ConsumoDTO> GetByEmpresa(int empresaId)
        {
            try
            {
                string query = "SELECT * FROM tb_consumo WHERE fk_empresa_CS = @empresaId";
                Conectar();
                SqlCommand cmd = new SqlCommand(query, conn); 
                cmd.Parameters.AddWithValue("@empresaId", empresaId);


                List<ConsumoDTO> listaConsumos = new List<ConsumoDTO>();
                SqlDataReader reader = cmd.ExecuteReader();
                listaConsumos = ListInsereDTO<ConsumoDTO>(reader);
                return listaConsumos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public ConsumoDTO GetConsumoByEmpresaEndProfissional(int empresaId, int profissionalId)
        {
            try
            {
                string query = "SELECT * FROM tb_consumo WHERE fk_empresa_CS = @empresaId and fk_profissional_cs = @profissionalId";
                Conectar();
               cmd = new SqlCommand(query, conn); 
                cmd.Parameters.AddWithValue("@empresaId", empresaId);
                cmd.Parameters.AddWithValue("@profissionalId", profissionalId);


                dr = cmd.ExecuteReader();
                ConsumoDTO ConsumoDTO = InsereDTO<ConsumoDTO>(dr);
                return ConsumoDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }



        public List<ConsumoDTO> ListarConsumosPorEmpresa(int idEmpresa)
        {
            try
            {
                Conectar();


              string  query = $"SELECT {dados_basico},{colunas_consumo},fk_cliente_Tu FROM tb_consumo c INNER JOIN tb_profissional p ON c.FK_profissional_cs = p.id_profissional  INNER JOIN tb_tipouser tu ON p.fk_tipouser_PF = tu.id_tipouser " +
                                      "INNER JOIN tb_cliente cl ON tu.fk_cliente_Tu = cl.id_cliente  WHERE c.FK_empresa_cs = @v1 ORDER BY c.date_time_update_cs DESC";
                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@v1", idEmpresa);
                List<ConsumoDTO> listaConsumos = new List<ConsumoDTO>();
                SqlDataReader reader = cmd.ExecuteReader();
                listaConsumos = ListInsereDTO<ConsumoDTO>(reader);
                return listaConsumos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar consumos por empresa: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }


    }
}