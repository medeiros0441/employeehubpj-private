using FW.DTO;//
using System;
using System.Data.SqlClient;

namespace FW.DAL
{
    public class GoogleDAL : Conexao
    {
        
         

        public int Inserir(GoogleDTO dto)
        {
            try
            {
                Conectar();

                string sql = @"INSERT INTO tb_google_users (id_email_GL, nome_completo_GL, primeironome_GL, sobrenome_GL, email_GL, fk_cliente_GL, date_time_insert_GL, date_time_update_GL)
                       VALUES (@id_email_GL, @nome_completo_GL, @primeironome_GL, @sobrenome_GL, @email_GL, 
                               @fk_cliente_GL, @date_time_insert_GL, @date_time_update_GL);
                       SELECT SCOPE_IDENTITY();";

                cmd = new SqlCommand(sql, conn);

                // adiciona os parâmetros
                cmd.Parameters.AddWithValue("@id_email_GL", dto.IdEmailGl);
                cmd.Parameters.AddWithValue("@nome_completo_GL", dto.NomeCompletoGl);
                cmd.Parameters.AddWithValue("@primeironome_GL", dto.PrimeiroNomeGl);
                cmd.Parameters.AddWithValue("@sobrenome_GL", dto.SobrenomeGl);
                cmd.Parameters.AddWithValue("@email_GL", dto.EmailGl);
                cmd.Parameters.AddWithValue("@fk_cliente_GL", dto.FkClienteGl);
                cmd.Parameters.AddWithValue("@date_time_insert_GL", dto.DateTimeInsertGl = DATA_HORA_BR.Data_Hora);
                cmd.Parameters.AddWithValue("@date_time_update_GL", dto.DateTimeUpdateGl ?? (object)DBNull.Value);

                // executa o comando e retorna o valor do SCOPE_IDENTITY()
                int id = Convert.ToInt32(cmd.ExecuteScalar());

                return id;
            }
            catch (Exception ex)
            { 
                throw new Exception("Erro ao inserir cliente do Google: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public GoogleDTO ConsultarPorEmail(string email)
        {
            try
            {
                Conectar();

                SqlCommand cmd = new SqlCommand("SELECT id_cliente_google, id_email_GL, nome_completo_GL, primeironome_GL, sobrenome_GL, email_GL, fk_cliente_GL, date_time_insert_GL, date_time_update_GL FROM tb_google_users WHERE email_GL = @email", conn);
                cmd.Parameters.AddWithValue("@email", email);

                SqlDataReader dr = cmd.ExecuteReader();

                GoogleDTO obj = new GoogleDTO();
                return obj = InsereDTO<GoogleDTO>(dr);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar usuário do Google por email: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public T Cadastrar_Cliente<T>(GoogleDTO GoogleDTO)
        {
            try
            {


                Conectar();
                cmd = new SqlCommand("EXEC Criar_usuario_google  @nome_completo = @nomecompletoV, @primeironome = @primeironomeV, " +
                    "@sobrenome = @sobrenomeV, @email = @emailV,@usuario = @usuarioV, @senha = @senhaV, @sexo = @sexoV," +
                    "@caminho_foto = @caminho_fotoV, @status = @statusV,@date_time_insert = @date_time_insertV," +
                    " @status_verificacao = @status_verificacaoV, @id_email = @id_emailV,@codigo_tipouser = @codigo_tipouserV," +
                    "@Descricao_Tipouser = @Descricao_TipouserV," +
                    " @date_time_privacidade = @date_time_privacidadeV, @date_time_termos =  @date_time_termosV;", conn);

                cmd.Parameters.AddWithValue("@nomecompletoV", GoogleDTO.NomeCompletoGl);
                cmd.Parameters.AddWithValue("@primeironomeV", GoogleDTO.PrimeiroNomeGl);
                cmd.Parameters.AddWithValue("@sobrenomeV", GoogleDTO.SobrenomeGl);
                cmd.Parameters.AddWithValue("@emailV", GoogleDTO.EmailGl);
                cmd.Parameters.AddWithValue("@usuarioV", GoogleDTO.UsuarioCl);
                cmd.Parameters.AddWithValue("@senhaV", GoogleDTO.SenhaCl);
                cmd.Parameters.AddWithValue("@sexoV", GoogleDTO.SexoCl);
                cmd.Parameters.AddWithValue("@caminho_fotoV", GoogleDTO.CaminhoFotoCl);
                cmd.Parameters.AddWithValue("@statusV", Convert.ToByte(true));
                cmd.Parameters.AddWithValue("@date_time_insertV", GoogleDTO.DateTimeInsertCl = DATA_HORA_BR.Data_Hora);
                cmd.Parameters.AddWithValue("@status_verificacaoV", Convert.ToByte(true));
                cmd.Parameters.AddWithValue("@id_emailV", GoogleDTO.IdEmailGl);
                cmd.Parameters.AddWithValue("@codigo_tipouserV", GoogleDTO.CodigoTu);
                cmd.Parameters.AddWithValue("@Descricao_TipouserV", GoogleDTO.DescricaoTu);
                cmd.Parameters.AddWithValue("@date_time_privacidadeV", DATA_HORA_BR.Data_Hora);
                cmd.Parameters.AddWithValue("@date_time_termosV", DATA_HORA_BR.Data_Hora);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int codigo_tu = Convert.ToInt32(dr["codigo_tipouser"]);
                    if(codigo_tu == 2)
                    {

                        ProfissionalDTO obj = new ProfissionalDTO
                        {
                            FkClienteTu = Convert.ToInt32(dr["id_cliente"]),
                            FkTipouserPf = Convert.ToInt32(dr["id_tipouser"]),
                            CodigoTu = Convert.ToInt32(dr["codigo_tipouser"]),
                            IdProfissional = Convert.ToInt32(dr["ID_profissional"])
                        };
                        return (T)Convert.ChangeType(obj, typeof(T));
                    }
                    else
                    if (codigo_tu == 3)
                    {
                        EmpresaDTO obj = new EmpresaDTO
                        {
                            FkClienteTu = Convert.ToInt32(dr["id_cliente"]),
                            FkTipouserEp = Convert.ToInt32(dr["id_tipouser"]),
                            CodigoTu = Convert.ToInt32(dr["codigo_tipouser"]),
                            IdEmpresa = Convert.ToInt32(dr["ID_empresa"])
                        };
                        return (T)Convert.ChangeType(obj, typeof(T));
                    }
                }

                return default;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Autenticar!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public dynamic VerificarTipoClienteEmail(string EmailCl)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("  SELECT g.fk_cliente_GL ,c.id_cliente, t.id_tipouser, t.codigo_TU, CASE WHEN t.codigo_TU = 2 THEN p.id_profissional  WHEN t.codigo_TU = 3 THEN e.id_empresa END AS id_associado FROM tb_cliente c INNER JOIN tb_tipouser t ON t.Fk_cliente_TU = c.id_cliente left join tb_google_users as g on g.fk_cliente_GL = c.id_cliente LEFT JOIN tb_profissional p ON p.fk_tipouser_PF = t.id_tipouser AND t.codigo_TU = 2 LEFT JOIN tb_empresa e ON e.fk_tipouser_EP = t.id_tipouser AND  t.codigo_TU = 3 WHERE c.email_cl = @email_cliente", conn);
                cmd.Parameters.AddWithValue("@email_cliente", EmailCl);
                dr = cmd.ExecuteReader();

                dynamic result = null;
                if (dr.Read())
                {
                    int codigo_tu = Convert.ToInt32(dr["codigo_TU"]);
                    if (dr.IsDBNull(dr.GetOrdinal("id_cliente")))
                    {
                        return result;
                    }
                    else if (dr.IsDBNull(dr.GetOrdinal("fk_cliente_GL")))
                    {
                        GoogleDTO obj = new GoogleDTO
                        {
                            FkClienteTu = Convert.ToInt32(dr["id_cliente"]),
                            IdTipouser = Convert.ToInt32(dr["id_tipouser"]),
                            CodigoTu = Convert.ToInt32(dr["codigo_TU"])
                        };
                        result = obj;
                    }
                    else
                    {

                        if (codigo_tu == 2)
                        {
                            ProfissionalDTO obj = new ProfissionalDTO
                            {
                                FkClienteTu = Convert.ToInt32(dr["id_cliente"]),
                                FkTipouserPf = Convert.ToInt32(dr["id_tipouser"]),
                                CodigoTu = Convert.ToInt32(dr["codigo_TU"]),
                                IdProfissional = Convert.ToInt32(dr["id_associado"])
                            };
                            result = obj;
                        }
                        else if (codigo_tu == 3)
                        {
                            EmpresaDTO obj = new EmpresaDTO
                            {

                                FkClienteTu = Convert.ToInt32(dr["id_cliente"]),
                                FkTipouserEp = Convert.ToInt32(dr["id_tipouser"]),
                                CodigoTu = Convert.ToInt32(dr["codigo_TU"]),
                                IdEmpresa = Convert.ToInt32(dr["id_associado"])
                            };
                            result = obj;
                        }
                    }


                }
                return result;


            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar por ID" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public GoogleDTO Cadastrar_Cliente_google(GoogleDTO GoogleDTO)
        {
            try
            {


                Conectar();
                cmd = new SqlCommand("begin TRANSACTION; INSERT INTO tb_google_users (id_email_GL,nome_completo_GL,primeironome_GL,sobrenome_GL,email_GL,fk_cliente_GL,date_time_insert_GL) " +
                    "VALUES (@id_email,@nome_completo,@primeironome,@sobrenome,@email,@Fk_Cliente,@date_time_insert);    	COMMIT TRANSACTION; select * from tb_google_users where fk_cliente=@@IDENTITY;", conn);
                cmd.Parameters.AddWithValue("@id_email", GoogleDTO.IdEmailGl);
                cmd.Parameters.AddWithValue("@nome_completo", GoogleDTO.NomeCompletoGl);
                cmd.Parameters.AddWithValue("@primeironome", GoogleDTO.PrimeiroNomeGl);
                cmd.Parameters.AddWithValue("@sobrenome", GoogleDTO.SobrenomeGl);
                cmd.Parameters.AddWithValue("@email", GoogleDTO.EmailGl);
                cmd.Parameters.AddWithValue("@Fk_Cliente", GoogleDTO.IdCliente);
                cmd.Parameters.AddWithValue("@Fk_Cliente", GoogleDTO.DateTimeInsertGl = DATA_HORA_BR.Data_Hora);
                dr = cmd.ExecuteReader();
                GoogleDTO obj = null;
                if (dr.Read())
                {
                    obj = new GoogleDTO
                    {
                        FkClienteGl = Convert.ToInt32(dr["Fk_cliente"]),
                    };
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Autenticar!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

    }
}
