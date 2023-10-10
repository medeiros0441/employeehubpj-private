using FW.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace FW.DAL
{
    public class ClienteDAL : Conexao
    {
     
         
        public int Cadastrar(TipoUserDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand(@"INSERT INTO TB_CLIENTE 
                (nome_completo_CL, primeironome_CL, sobrenome_CL, email_CL, usuario_CL, senha_CL, data_Nascimento_CL, sexo_CL,Numero_Telefone_Cl, caminho_foto_CL, status_CL, date_time_insert_CL, status_verificacao_CL,saldo_atual_cl) 
                VALUES 
                (@nome_completo_CL, @primeironome_CL, @sobrenome_CL, @email_CL, @usuario_CL, @senha_CL, @data_Nascimento_CL, @sexo_CL,@telefone, @caminho_foto_CL, @status_CL, @date_time_insert_CL, @status_verificacao_CL,@saldo);
                SELECT SCOPE_IDENTITY();", conn);
                cmd.Parameters.AddWithValue("@nome_completo_CL", objCad.NomeCompletoCl =  objCad.PrimeiroNomeCl + " " + objCad.SobrenomeCl);
                cmd.Parameters.AddWithValue("@primeironome_CL", objCad.PrimeiroNomeCl);
                cmd.Parameters.AddWithValue("@sobrenome_CL", objCad.SobrenomeCl);
                cmd.Parameters.AddWithValue("@email_CL", objCad.EmailCl);
                cmd.Parameters.AddWithValue("@usuario_CL", objCad.UsuarioCl);
                cmd.Parameters.AddWithValue("@senha_CL", objCad.SenhaCl);
                cmd.Parameters.AddWithValue("@data_Nascimento_CL", objCad.DataNascimentoCl);
                cmd.Parameters.AddWithValue("@sexo_CL", objCad.SexoCl);
                cmd.Parameters.AddWithValue("@telefone", objCad.NumeroTelefoneCl);
                cmd.Parameters.AddWithValue("@caminho_foto_CL", objCad.CaminhoFotoCl);
                cmd.Parameters.AddWithValue("@status_CL", Convert.ToByte(objCad.StatusCl = true));
                cmd.Parameters.AddWithValue("@date_time_insert_CL", objCad.DateTimeInsertCl = DataHoraAtual);
                cmd.Parameters.AddWithValue("@status_verificacao_CL", Convert.ToByte(objCad.StatusVerificacaoCl = false));
                cmd.Parameters.AddWithValue("@saldo",objCad.StatusVerificacaoCl);

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar cliente! " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public void Atualizar(ClienteDTO objAtualizar)
        {
            try
            {
                Conectar();

                cmd = new SqlCommand(@"UPDATE TB_CLIENTE SET nome_completo_CL = @nome_completo_CL,numero_telefone_cl=@numero_telefone_cl,Biografia_Cl = @Biografia_Cl,  primeironome_CL = @primeironome_CL, sobrenome_CL = @sobrenome_CL,       usuario_CL = @usuario_CL,  data_Nascimento_CL = @data_Nascimento_CL, sexo_CL = @sexo_CL, date_time_update_cl = @date_time_update, nro_cpf_CL =@nro_cpf_CL WHERE id_cliente = @id_cliente", conn);

                cmd.Parameters.AddWithValue("@id_cliente", objAtualizar.IdCliente);
                cmd.Parameters.AddWithValue("@nome_completo_CL", objAtualizar.NomeCompletoCl = objAtualizar.PrimeiroNomeCl + " " + objAtualizar.SobrenomeCl);
                cmd.Parameters.AddWithValue("@primeironome_CL", objAtualizar.PrimeiroNomeCl);
                cmd.Parameters.AddWithValue("@sobrenome_CL", objAtualizar.SobrenomeCl);
                cmd.Parameters.AddWithValue("@usuario_CL", objAtualizar.UsuarioCl);
                cmd.Parameters.AddWithValue("@data_Nascimento_CL", objAtualizar.DataNascimentoCl);
                cmd.Parameters.AddWithValue("@nro_cpf_CL", objAtualizar.NroCpfCl);
                cmd.Parameters.AddWithValue("@sexo_CL", objAtualizar.SexoCl);
                cmd.Parameters.AddWithValue("@date_time_update", DataHoraAtual);
                cmd.Parameters.AddWithValue("@status_verificacao_CL", objAtualizar.StatusVerificacaoCl);
                cmd.Parameters.AddWithValue("@Biografia_Cl", objAtualizar.BiografiaCl);
                cmd.Parameters.AddWithValue("@numero_telefone_cl", objAtualizar.NumeroTelefoneCl);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar cliente! " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public void AtualizarEndereco(ClienteDTO cliente)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE TB_CLIENTE SET date_time_update_CL=@update, descricao_rua_CL = @rua, numero_casa_CL = @numero_casa, descricao_complemento_CL = @complemento, numero_cep_CL = @cep, descricao_bairro_CL = @bairro, descricao_cidade_CL = @cidade, descricao_estado_CL = @estado WHERE id_cliente = @id", conn);

                cmd.Parameters.AddWithValue("@update", cliente.DateTimeUpdateCl = DataHoraAtual);
                cmd.Parameters.AddWithValue("@id", cliente.IdCliente);
                cmd.Parameters.AddWithValue("@rua", cliente.DescricaoRuaCl);
                cmd.Parameters.AddWithValue("@numero_casa", cliente.NumeroCasaCl);
                cmd.Parameters.AddWithValue("@complemento", cliente.DescricaoComplementoCl);
                cmd.Parameters.AddWithValue("@cep", cliente.NumeroCepCl);
                cmd.Parameters.AddWithValue("@bairro", cliente.DescricaoBairroCl);
                cmd.Parameters.AddWithValue("@cidade", cliente.DescricaoCidadeCl);
                cmd.Parameters.AddWithValue("@estado", cliente.DescricaoEstadoCl);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar endereço do cliente: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public ClienteDTO SelecionarEnderecoPorId(int idCliente)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand($"SELECT {dados_endereco} FROM Tb_cliente WHERE IdCliente=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", idCliente);
                dr = cmd.ExecuteReader();
                ClienteDTO obj = new ClienteDTO();
                return obj = InsereDTO<ClienteDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Selecionar Endereço do Cliente!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public ClienteDTO ConsultarUsuario(ClienteDTO ClienteDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT id_cliente, usuario_cl  FROM Tb_cliente WHERE usuario_cl=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", ClienteDTO.UsuarioCl);
                dr = cmd.ExecuteReader();
                ClienteDTO obj = new ClienteDTO();
                return obj = InsereDTO<ClienteDTO>( dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar usuário!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public ClienteDTO ConsultarTelefone(string Telefone )
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT id_cliente, numero_telefone_cl  FROM Tb_cliente WHERE numero_telefone_cl=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", Telefone);
                dr = cmd.ExecuteReader();
                ClienteDTO obj = new ClienteDTO();
                return obj = InsereDTO<ClienteDTO>( dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar usuário!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public ClienteDTO ConsultarEmail(string email)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand($"SELECT id_cliente, email_cl, {dados_basico} FROM Tb_cliente WHERE Email_cl=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", email);
                dr = cmd.ExecuteReader();
                ClienteDTO obj = new ClienteDTO();
                return obj = InsereDTO<ClienteDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar e-mail!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public ClienteDTO ConsultarPorCpf(ClienteDTO ClienteDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT email_cl,usuario_Cl, status_cl, id_cliente FROM Tb_cliente WHERE nro_cpf_CL = @cpf", conn);
                cmd.Parameters.AddWithValue("@cpf", ClienteDTO.NroCpfCl);
                dr = cmd.ExecuteReader();
                ClienteDTO obj = new ClienteDTO();
                return obj = InsereDTO<ClienteDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar por CPF!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public dynamic VerificarTipoClienteID(int idClienteCl)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("  SELECT g.fk_cliente_GL ,c.id_cliente, c.email_cl ,t.id_tipouser, t.codigo_TU, CASE WHEN t.codigo_TU = 2 THEN p.id_profissional  WHEN t.codigo_TU = 3 THEN e.id_empresa END AS id_associado FROM tb_cliente c INNER JOIN tb_tipouser t ON t.Fk_cliente_TU = c.id_cliente left join tb_google_users as g on g.fk_cliente_GL = c.id_cliente LEFT JOIN tb_profissional p ON p.fk_tipouser_PF = t.id_tipouser AND t.codigo_TU = 2 LEFT JOIN tb_empresa e ON e.fk_tipouser_EP = t.id_tipouser AND  t.codigo_TU = 3 WHERE c.id_cliente = @idClienteCl", conn);
                cmd.Parameters.AddWithValue("@idClienteCl", idClienteCl);
                dr = cmd.ExecuteReader();

                dynamic result = null;
                if (dr.Read())
                {
                    int codigo_tu = Convert.ToInt32(dr["codigo_TU"]);
                    if (dr.IsDBNull(dr.GetOrdinal("id_cliente")) && dr.IsDBNull(dr.GetOrdinal("id_associado")) && codigo_tu != 0)
                    {
                        return result;
                    }
                    else
                    {
                        if (codigo_tu == 2)
                        {
                            ProfissionalDTO obj = new ProfissionalDTO
                            {
                                FkClienteTu = Convert.ToInt32(dr["id_cliente"]),
                                FkTipouserPf = Convert.ToInt32(dr["id_tipouser"]),
                                EmailCl = dr["email_cl"].ToString(),
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
                                EmailCl = dr["email_cl"].ToString(),
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
                throw new Exception("Erro ao consultar por CPF!" + ex.Message);
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
                    if (dr.IsDBNull(dr.GetOrdinal("id_cliente")) && dr.IsDBNull(dr.GetOrdinal("id_associado")) && codigo_tu != 0)
                    {
                        return result;
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
                                IdEmpresa = Convert.ToInt32(dr["id_associado"]),
                            };
                            result = obj;
                        }
                    }
                }
                return result;


            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar por CPF!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public dynamic AutenticarEmailSenha(string EmailCl,string Senha)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("  SELECT g.fk_cliente_GL, status_CL,c.id_cliente, t.id_tipouser, t.codigo_TU, " +
                    "CASE WHEN t.codigo_TU = 2 THEN p.id_profissional  WHEN t.codigo_TU = 3 THEN e.id_empresa END AS id_associado FROM" +
                    " tb_cliente c INNER JOIN tb_tipouser t ON t.Fk_cliente_TU = c.id_cliente left join tb_google_users as g on g.fk_cliente_GL = c.id_cliente" +
                    " LEFT JOIN tb_profissional p ON p.fk_tipouser_PF = t.id_tipouser AND t.codigo_TU = 2 " +
                    "LEFT JOIN tb_empresa e ON e.fk_tipouser_EP = t.id_tipouser AND  t.codigo_TU = 3 WHERE c.email_cl = @email_cliente and c.senha_CL = @senha_CL", conn);
                cmd.Parameters.AddWithValue("@email_cliente", EmailCl);
                cmd.Parameters.AddWithValue("@senha_CL", Senha);
                dr = cmd.ExecuteReader();

                dynamic result = null;
                if (dr.Read())
                {
                    int codigo_tu = Convert.ToInt32(dr["codigo_TU"]);
                    if (dr.IsDBNull(dr.GetOrdinal("id_cliente")) && dr.IsDBNull(dr.GetOrdinal("id_associado"))  && codigo_tu != 0)
                    {
                        return result;
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
                                StatusCl = Convert.ToBoolean(dr["status_CL"]),
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
                                IdEmpresa = Convert.ToInt32(dr["id_associado"]),
                                 StatusCl = Convert.ToBoolean(dr["status_CL"] ?? false),
                            };
                            result = obj;
                        }
                    }
                }
                return result;


            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar por CPF!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public TipoUserDTO AutenticarTipouserPorIdCliente(int idCliente)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT tu.id_tipouser, tu.descricao_TU, tu.codigo_TU, tu.Status_TU, tu.Fk_cliente_TU, tu.date_time_insert_TU, tu.date_time_update_TU, c.email_CL, c.usuario_CL FROM tb_tipouser tu JOIN tb_cliente c ON tu.Fk_cliente_TU = c.id_cliente WHERE c.id_cliente = @v1", conn);
                cmd.Parameters.AddWithValue("@v1", idCliente);
                dr = cmd.ExecuteReader();
                TipoUserDTO obj = null;
                if (dr.Read())
                {
                    obj = new TipoUserDTO
                    {
                        IdTipouser = Convert.ToInt32(dr["id_tipouser"]),
                        DescricaoTu = dr["descricao_TU"].ToString(),
                        CodigoTu = Convert.ToInt32(dr["codigo_TU"]),
                        StatusTu = Convert.ToBoolean(dr["Status_TU"]),
                        FkClienteTu = Convert.ToInt32(dr["Fk_cliente_TU"]),
                        DateTimeInsertTu = Convert.ToDateTime(dr["date_time_insert_TU"]),
                        DateTimeUpdateTu = dr["date_time_update_TU"] == DBNull.Value ? null : (DateTime?)dr["date_time_update_TU"],
                        EmailCl = dr["email_CL"].ToString(),
                        UsuarioCl = dr["usuario_CL"].ToString()
                    };
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao autenticar o usuário do tipo de usuário por ID do cliente!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
         
       
        public void AtualizarUrlFotoCliente(ClienteDTO clienteDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE TB_CLIENTE SET caminho_foto_CL = @v1, date_time_update_CL = @v2 WHERE id_cliente = @v3", conn);
                cmd.Parameters.AddWithValue("@v1", clienteDTO.CaminhoFotoCl);
                cmd.Parameters.AddWithValue("@v2", DATA_HORA_BR.Data_Hora);
                cmd.Parameters.AddWithValue("@v3", clienteDTO.IdCliente);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar URL da foto do cliente: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public void AtualizarSaldo(ClienteDTO clienteDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE tb_cliente SET saldo_atual_cl = @v1, date_time_update_CL = @v2 WHERE id_cliente = @v3", conn);
                cmd.Parameters.AddWithValue("@v1", clienteDTO.SaldoAtualCl); ;
                cmd.Parameters.AddWithValue("@v2", DATA_HORA_BR.Data_Hora);
                cmd.Parameters.AddWithValue("@v3", clienteDTO.IdCliente);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
           
                throw new Exception("Erro ao atualizar saldo do cliente!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public void AtualizarSenha(ClienteDTO clienteDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE tb_cliente SET  Senha_cl = @v1, date_time_update_CL = @v2 WHERE id_cliente = @v3", conn);
                cmd.Parameters.AddWithValue("@v1", clienteDTO.SenhaCl);
                cmd.Parameters.AddWithValue("@v2", DataHoraAtual);
                cmd.Parameters.AddWithValue("@v3", clienteDTO.IdCliente);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar senha do cliente!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        
        public void Atualizar_Email_Cliente(ClienteDTO clienteDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE tb_cliente SET Email_CL = @v1, date_time_update_CL = @v2 WHERE id_cliente = @v3", conn);
                cmd.Parameters.AddWithValue("@v1", clienteDTO.EmailCl);
                cmd.Parameters.AddWithValue("@v2", DataHoraAtual);
                cmd.Parameters.AddWithValue("@v3", clienteDTO.IdCliente);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Atualizar E-mail do Cliente!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public List<ClienteDTO> ListaBasicaClientes()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand($"SELECT {dados_basico}  FROM tb_cliente", conn);
                dr = cmd.ExecuteReader();
                List<ClienteDTO> Lista = new List<ClienteDTO>();
                return Lista = ListInsereDTO<ClienteDTO>( dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar clientes!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public ClienteDTO SelectBasicCliente(int ID_Cliente)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand($"SELECT  {dados_basico}  FROM tb_cliente WHERE id_cliente = @v1", conn);
                cmd.Parameters.AddWithValue("@v1", ID_Cliente);

                dr = cmd.ExecuteReader();
                ClienteDTO obj = new ClienteDTO();
                return obj = InsereDTO<ClienteDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar clientes!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public ClienteDTO SelectAvancedCliente(int ID_Cliente)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand($"SELECT {dados_senciveis},{dados_basico}  FROM tb_cliente WHERE id_cliente = @v1", conn);
                cmd.Parameters.AddWithValue("@v1", ID_Cliente);

                dr = cmd.ExecuteReader();
                ClienteDTO obj = new ClienteDTO();
                return obj = InsereDTO<ClienteDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar clientes!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public ClienteDTO SelectEndereco(int ID_Cliente)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand($"SELECT {dados_endereco}  FROM tb_cliente WHERE id_cliente = @v1", conn);
                cmd.Parameters.AddWithValue("@v1", ID_Cliente);

                dr = cmd.ExecuteReader();
                ClienteDTO obj = new ClienteDTO();
                return obj = InsereDTO<ClienteDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar clientes!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }



        public List<ClienteDTO> Buscar_Cliente(ClienteDTO ClienteDTO)
        {
            try
            {

                Conectar();
                string queryString = " SELECT " + dados_basico + " Fk_cliente_tu,ID_TIPOUSER FROM" +
                    " tb_cliente as C join Tb_tipouser as T on T.fk_cliente_tu = C.id_cliente where C.status_cl=1 and T.codigo_TU in (3,2) ";

                if (ClienteDTO.NomeCompletoCl != null)
                {
                    queryString += "and C.primeironome_Cl like '%" + ClienteDTO.NomeCompletoCl + "%' ";
                }

                if (ClienteDTO.UsuarioCl != null)
                {
                    queryString += "and C.usuario_cl like '%" + ClienteDTO.UsuarioCl + "%' ";

                }
                if (ClienteDTO.SexoCl != null)
                {
                    queryString += "and C.sexo_cl='" + ClienteDTO.SexoCl + "' ";

                }

                queryString += " ORDER BY C.date_time_update_cl desc";
                cmd = new SqlCommand(queryString, conn);
                dr = cmd.ExecuteReader();


                List<ClienteDTO> Lista = new List<ClienteDTO>();
                return Lista = ListInsereDTO<ClienteDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Clientes!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }



        public ClienteDTO Selecionar_Foto(int IdCliente)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT caminho_foto_CL, ID_cliente,sexo_CL FROM Tb_cliente  WHERE id_cliente=@v1 ", conn);
                cmd.Parameters.AddWithValue("@v1", IdCliente);
                dr = cmd.ExecuteReader();
                ClienteDTO obj = new ClienteDTO();
                return obj = InsereDTO<ClienteDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Autenticar !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public List<T> Lista_Cliente<T>() where T : new()
        {
            try
            {
                Conectar();
                string queryString = " SELECT " + dados_basico + "," + colunas_tipouser + ",razao_social_EP FROM" +
                    " tb_cliente as C join Tb_tipouser as T on T.fk_cliente_tu = C.id_cliente " +
                    "join tb_empresa as EP on EP.fk_tipouser_EP = T.id_tipouser " +
                    "where C.status_cl=1 and T.codigo_TU in (3,2) ";

                queryString += " ORDER BY C.date_time_update_cl desc";
                cmd = new SqlCommand(queryString, conn);
                dr = cmd.ExecuteReader();


                List<T> Lista = new List<T>();
                return Lista = ListInsereDTO<T>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Clientes!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
