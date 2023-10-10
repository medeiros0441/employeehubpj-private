using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FW.DTO;
using System.Data.SqlClient;

namespace FW.DAL
{
   public  class CandidaturaSimplificadaDAL: Conexao
    {
        public bool InsertCandidato(CandidatoSimplificadoDTO obj)
        {
            try
            {
                using (SqlConnection connection = Conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO tb_candidato_simplificado (nome_cs, email_cs, telefone_cs, caminho_doc_cs, date_time_insert_cs) VALUES (@v1, @v2, @v3, @v4, @v5); SELECT SCOPE_IDENTITY();", connection);
                    cmd.Parameters.AddWithValue("@v1", obj.NomeCs);
                    cmd.Parameters.AddWithValue("@v2", obj.EmailCs);
                    cmd.Parameters.AddWithValue("@v3", obj.TelefoneCs);
                    cmd.Parameters.AddWithValue("@v4", obj.CaminhoDocCs= "doc nao armazenado!");
                    cmd.Parameters.AddWithValue("@v5", DataHoraAtual);

                    int idGerado = Convert.ToInt32(cmd.ExecuteScalar());
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir o candidato: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public bool InsertRelacionamento(int fkCandidato, int fkVaga)
        {
            using (SqlConnection conn = Conectar())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO tb_candidato_simplificado_relacionamento (Fk_candidato_csr, date_time_insert_csr, Fk_vaga_csr) VALUES (@fkCandidato, @dateInsert, @fkVaga)", conn);
                    cmd.Parameters.AddWithValue("@fkCandidato", fkCandidato);
                    cmd.Parameters.AddWithValue("@dateInsert", DataHoraAtual);
                    cmd.Parameters.AddWithValue("@fkVaga", fkVaga);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao inserir relacionamento!" + ex.Message);
                }
                finally
                {
                    Desconectar();
                }
            }
        }

        public CandidatoSimplificadoDTO ConsultarEmail(string email)
        {
            try
            {
                using (SqlConnection connection = Conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT id_candidato_cs ,nome_cs, email_cs, telefone_cs, date_time_insert_cs FROM tb_candidato_simplificado WHERE email_cs = @email", connection);
                    cmd.Parameters.AddWithValue("@email", email);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        CandidatoSimplificadoDTO candidato = new CandidatoSimplificadoDTO();

                        // Preencha o objeto candidato com os valores do DataReader
                        while (dr.Read())
                        {
                            candidato.IdCandidatoCs = Convert.ToInt32(dr["id_candidato_cs"]);
                            candidato.NomeCs = dr["nome_cs"].ToString();
                            candidato.EmailCs = dr["email_cs"].ToString();
                            candidato.TelefoneCs = dr["telefone_cs"].ToString();
                            candidato.DateTimeInsertCs = Convert.ToDateTime(dr["date_time_insert_cs"]);
                        }

                        return candidato;
                    }
                    return null;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar o email: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public bool VerificarRelacionamento(int fkCandidato, int fkVaga)
        {
            using (SqlConnection conn = Conectar())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tb_candidato_simplificado_relacionamento WHERE Fk_candidato_csr = @fkCandidato AND Fk_vaga_csr = @fkVaga", conn);
                    cmd.Parameters.AddWithValue("@fkCandidato", fkCandidato);
                    cmd.Parameters.AddWithValue("@fkVaga", fkVaga);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return true; // Relacionamento existe
                        }
                        return false; // Relacionamento não existe
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao verificar relacionamento: " + ex.Message);
                }
                finally
                {
                    Desconectar();
                }
            }
        }



    }
}
