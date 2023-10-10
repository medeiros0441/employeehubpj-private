using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FW.DTO;

namespace FW.DAL
{
    public class LogDAL : Conexao
    {
        public void CadastrarLog(LogDTO log)
        {
            log.DateTimeInsertLg = DateTime.Now;
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO tb_log (date_time_insert_LG, date_time_update_LG, descricao_LG, descricao_sistema_LG, nivel_gravidade_LG, dados_adicionais_LG, fk_sessao_LG) VALUES (@insert, @update, @descricao, @sistema, @nivel, @dados, @sessao)", conn);
                cmd.Parameters.AddWithValue("@insert", log.DateTimeInsertLg);
                cmd.Parameters.AddWithValue("@update", (object)log.DateTimeUpdateLg ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@descricao", log.DescricaoLg);
                cmd.Parameters.AddWithValue("@sistema", log.DescricaoSistemaLg);
                cmd.Parameters.AddWithValue("@nivel", log.NivelGravidadeLg);
                cmd.Parameters.AddWithValue("@dados", (object)log.DadosAdicionaisLg ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@sessao", log.FkSessaoLg);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar log: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public List<LogDTO> ListarLogs()
        {
            List<LogDTO> logs = new List<LogDTO>();
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM tb_log", conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LogDTO log = new LogDTO
                    {
                        IdLog = Convert.ToInt32(dr["id_log"]),
                        DateTimeInsertLg = Convert.ToDateTime(dr["date_time_insert_LG"]),
                        DateTimeUpdateLg = dr["date_time_update_LG"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["date_time_update_LG"]),
                        DescricaoLg = dr["descricao_LG"].ToString(),
                        DescricaoSistemaLg = dr["descricao_sistema_LG"].ToString(),
                        NivelGravidadeLg = dr["nivel_gravidade_LG"].ToString(),
                        DadosAdicionaisLg = dr["dados_adicionais_LG"] == DBNull.Value ? null : dr["dados_adicionais_LG"].ToString(),
                        FkSessaoLg = Convert.ToInt32(dr["fk_sessao_LG"])
                    };
                    logs.Add(log);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar logs: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
            return logs;
        }

    }
}
