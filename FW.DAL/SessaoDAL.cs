using FW.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FW.DAL
{
    public class SessaoDAL : Conexao
    {
        

        public int CadastrarSessao(SessaoDTO sessao)
        {
            int idSessao = 0;

            try
            {
                Conectar();
                SqlCommand cmd = new SqlCommand("INSERT INTO tb_sessao (ip_cliente_SS, navegador_SS, status_SS, date_time_insert_SS, iniciou_SS) OUTPUT INSERTED.ID_sessao VALUES (@ipCliente, @navegador, @status, @dateTimeInsert, @iniciou)", conn);
                cmd.Parameters.AddWithValue("@ipCliente", sessao.IpClienteSs);
                cmd.Parameters.AddWithValue("@navegador", sessao.NavegadorSs);
                cmd.Parameters.AddWithValue("@status", sessao.StatusSs);
                cmd.Parameters.AddWithValue("@dateTimeInsert", sessao.DateTimeInsertSs);
                cmd.Parameters.AddWithValue("@iniciou", sessao.IniciouSs);
                idSessao = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar sessão!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
            return idSessao;
        }
        public SessaoDTO ConsultarSessaoPorId(int id)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM tb_sessao WHERE ID_sessao = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();

                SessaoDTO obj = new SessaoDTO();
                return obj = InsereDTO<SessaoDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar sessão!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public SessaoDTO ConsultarSessaoPorIpCliente(string ip_cliente ,string navegador)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM tb_sessao WHERE ip_cliente_SS = @ip_cliente and navegador_SS = @navegador ", conn);
                cmd.Parameters.AddWithValue("@ip_cliente", ip_cliente);
                cmd.Parameters.AddWithValue("@navegador", navegador);
                SqlDataReader dr = cmd.ExecuteReader();
                SessaoDTO sessao = null;
                if (dr.Read())
                {
                    sessao = new SessaoDTO
                    {
                        IdSessao = Convert.ToInt32(dr["ID_sessao"]),
                        IpClienteSs = dr["ip_cliente_SS"].ToString(),
                        NavegadorSs = dr["navegador_SS"].ToString(),
                        StatusSs = Convert.ToBoolean(dr["status_SS"]),
                        DateTimeInsertSs = Convert.ToDateTime(dr["date_time_insert_SS"]),
                        DateTimeUpdateSs = dr.IsDBNull(dr.GetOrdinal("date_time_update_SS")) ? null : (DateTime?)dr.GetDateTime(dr.GetOrdinal("date_time_update_SS")),
                        TimeOnlineSs = dr.IsDBNull(dr.GetOrdinal("time_online_SS")) ? TimeSpan.Zero : TimeSpan.Parse(dr["time_online_SS"].ToString()),
                        IniciouSs = dr.IsDBNull(dr.GetOrdinal("iniciou_SS")) ? DateTime.MinValue : Convert.ToDateTime(dr["iniciou_SS"]),
                        FinalizouSs = dr.IsDBNull(dr.GetOrdinal("finalizou_SS")) ? DateTime.MinValue : Convert.ToDateTime(dr["finalizou_SS"])
                    };
                }
                return sessao;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar sessão!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public void Atualizar_Sessao(SessaoDTO objAtu)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand($"UPDATE tb_sessao SET  status_SS = @v3, date_time_update_SS = @v4, time_online_SS = @v5, finalizou_SS = @v6 WHERE ID_sessao = @v7", conn);
                cmd.Parameters.AddWithValue("@v3", Convert.ToByte(objAtu.StatusSs));
                cmd.Parameters.AddWithValue("@v4", DataHoraAtual);
                cmd.Parameters.AddWithValue("@v5", objAtu.TimeOnlineSs);
                cmd.Parameters.AddWithValue("@v6", objAtu.FinalizouSs);
                cmd.Parameters.AddWithValue("@v7", objAtu.IdSessao);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar Sessão!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public List<SessaoDTO> Listar_Sessoes()
        {
            List<SessaoDTO> listaSessoes = new List<SessaoDTO>();

            try
            {
                Conectar();
                cmd = new SqlCommand($"SELECT * FROM TB_sessao", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    SessaoDTO sessao = new SessaoDTO
                    {
                        IdSessao = Convert.ToInt32(dr["ID_sessao"]),
                        IpClienteSs = Convert.ToString(dr["ip_cliente_SS"]),
                        NavegadorSs = Convert.ToString(dr["navegador_SS"]),
                        StatusSs = Convert.ToBoolean(dr["status_SS"]),
                        DateTimeInsertSs = Convert.ToDateTime(dr["date_time_insert_SS"]),
                        DateTimeUpdateSs = dr["date_time_update_SS"] == DBNull.Value ? null : (DateTime?)dr["date_time_update_SS"],
                        TimeOnlineSs = TimeSpan.Parse(dr["time_online_SS"].ToString()),
                        IniciouSs = Convert.ToDateTime(dr["iniciou_SS"]),
                        FinalizouSs = Convert.ToDateTime(dr["finalizou_SS"])
                    };
                    listaSessoes.Add(sessao);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar sessões!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }

            return listaSessoes;
        }

        public List<SessaoDTO> ListarSessoesTemporarias()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM tb_sessao WHERE status_SS = 1", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                List<SessaoDTO> listaSessoes = new List<SessaoDTO>();
                while (dr.Read())
                {
                    SessaoDTO sessao = new SessaoDTO
                    {
                        IdSessao = Convert.ToInt32(dr["ID_sessao"]),
                        IpClienteSs = dr["ip_cliente_SS"].ToString(),
                        NavegadorSs = dr["navegador_SS"].ToString(),
                        StatusSs = Convert.ToBoolean(dr["status_SS"]),
                        DateTimeInsertSs = Convert.ToDateTime(dr["date_time_insert_SS"]),
                        DateTimeUpdateSs = dr["date_time_update_SS"] != DBNull.Value ? Convert.ToDateTime(dr["date_time_update_SS"]) : (DateTime?)null,
                        TimeOnlineSs = TimeSpan.Parse(dr["time_online_SS"].ToString()),
                        IniciouSs = Convert.ToDateTime(dr["iniciou_SS"]),
                        FinalizouSs = Convert.ToDateTime(dr["finalizou_SS"])
                    };
                    listaSessoes.Add(sessao);
                }
                return listaSessoes;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar sessões temporárias: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public void AtualizarStatusTempoOnline(int idSessao, bool statusSs, TimeSpan tempoOnlineSs)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE tb_sessao SET status_SS = @statusSs, time_online_SS = @tempoOnlineSs WHERE ID_sessao = @idSessao", conn);
                cmd.Parameters.AddWithValue("@statusSs", statusSs);
                cmd.Parameters.AddWithValue("@tempoOnlineSs", tempoOnlineSs);
                cmd.Parameters.AddWithValue("@idSessao", idSessao);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar sessão!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }


    }
}
