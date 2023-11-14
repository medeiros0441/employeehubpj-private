using FW.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace FW.DAL
{
     
    public class EmpresaDAL : Conexao
    {
        
         
        //inserir - create
        public int Cadastrar(EmpresaDTO empresaDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO tb_Empresa(numero_cnpj_EP, nome_fantasia_EP, razao_social_EP, date_time_termos_EP, date_time_privacidade_EP, date_time_insert_EP, date_abertura_EP, fk_tipouser_EP) OUTPUT INSERTED.id_empresa VALUES (@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8)", conn);
                cmd.Parameters.AddWithValue("@v1",  DBNull.Value);
                cmd.Parameters.AddWithValue("@v2", DBNull.Value);
                cmd.Parameters.AddWithValue("@v3",  DBNull.Value);
                cmd.Parameters.AddWithValue("@v4", empresaDTO.DateTimeTermosEp = DATA_HORA_BR.Data_Hora);
                cmd.Parameters.AddWithValue("@v5", empresaDTO.DateTimePrivacidadeEp = DATA_HORA_BR.Data_Hora);
                cmd.Parameters.AddWithValue("@v6", empresaDTO.DateTimeInsertEp = DATA_HORA_BR.Data_Hora);
                cmd.Parameters.AddWithValue("@v7", DBNull.Value);
                cmd.Parameters.AddWithValue("@v8", empresaDTO.FkTipouserEp);

                int idGerado = (int)cmd.ExecuteScalar();

                return idGerado;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar Empresa!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Autenticar CNPJ
        public EmpresaDTO AutenticarCnpj(EmpresaDTO EmpresaDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT ID_Empresa FROM tb_Empresa INNER JOIN tb_TipoUser ON tb_Empresa.FK_TipoUser_ep = tb_TipoUser.ID_TipoUser " +
                    "INNER JOIN tb_Cliente ON tb_TipoUser.FK_Cliente_tu = tb_Cliente.ID_Cliente WHERE tb_Empresa.Numero_CNPJ_EP = @cnpj", conn);
                cmd.Parameters.AddWithValue("@cnpj", EmpresaDTO.NumeroCnpjEp);
                dr = cmd.ExecuteReader();


                EmpresaDTO obj = new EmpresaDTO() ;
                return obj = InsereDTO < EmpresaDTO>(dr); 
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao autenticar CNPJ!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public List<EmpresaDTO> ListarEmpresas()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM tb_empresa INNER JOIN tb_tipouser ON tb_empresa.fk_tipouser_EP = tb_tipouser.id_tipouser", conn);
                dr = cmd.ExecuteReader();

                List<EmpresaDTO> Lista = new List<EmpresaDTO>();
                return Lista = ListInsereDTO<EmpresaDTO>( dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar empresas!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

       
        public EmpresaDTO ConsultarPorId(int idEmpresa)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand($"SELECT id_empresa, fk_cliente_Tu, email_cl, {dados_basico} FROM tb_empresa INNER JOIN tb_tipouser ON tb_tipouser.id_tipouser = tb_empresa.fk_tipouser_EP join  tb_cliente as CL on CL.id_cliente = Fk_cliente_Tu" +
                    " WHERE id_empresa = @v1", conn);
                cmd.Parameters.AddWithValue("@v1", idEmpresa);
                dr = cmd.ExecuteReader();




                EmpresaDTO obj = new EmpresaDTO();
                return obj = InsereDTO<EmpresaDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Consultar Empresa!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public EmpresaDTO Select_Empresa_IdCliente(int IdCliente)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand($"SELECT id_empresa,{colunas_empresa}, {dados_basico} FROM tb_empresa INNER JOIN tb_tipouser as T ON T.id_tipouser = tb_empresa.fk_tipouser_EP join tb_cliente on id_cliente = T.FK_cliente_Tu WHERE fk_Cliente_Tu = @v1", conn);
                cmd.Parameters.AddWithValue("@v1", IdCliente);
                dr = cmd.ExecuteReader();
                EmpresaDTO obj = new EmpresaDTO();
                return obj = InsereDTO<EmpresaDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Consultar Empresa!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }




        public EmpresaDTO EditarEmpresa(EmpresaDTO empresaDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE tb_empresa SET numero_cnpj_EP=@v1, nome_fantasia_EP=@v2, razao_social_EP=@v3 ,date_time_update_EP=@v6, date_abertura_EP=@v7 WHERE id_empresa=@v9", conn);
                cmd.Parameters.AddWithValue("@v1", empresaDTO.NumeroCnpjEp);
                cmd.Parameters.AddWithValue("@v2", empresaDTO.NomeFantasiaEp);
                cmd.Parameters.AddWithValue("@v3", empresaDTO.RazaoSocialEp);
                cmd.Parameters.AddWithValue("@v6", empresaDTO.DateTimeUpdateEp = DATA_HORA_BR.Data_Hora);
                cmd.Parameters.AddWithValue("@v7", empresaDTO.DateAberturaEp);
                cmd.Parameters.AddWithValue("@v9", empresaDTO.IdEmpresa);
                cmd.ExecuteNonQuery();

                // Recupera os dados atualizados da empresa
                cmd = new SqlCommand("SELECT * FROM tb_empresa INNER JOIN tb_tipouser ON tb_tipouser.id_tipouser = tb_empresa.fk_tipouser_EP WHERE id_empresa=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", empresaDTO.IdEmpresa);
                dr = cmd.ExecuteReader();


                EmpresaDTO obj = new EmpresaDTO();
                return obj = InsereDTO<EmpresaDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar empresa!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
          
    }
}
