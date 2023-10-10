using FW.DTO;//
using System;
using System.Collections.Generic;//
using System.Data.SqlClient;

namespace FW.DAL
{
    public class TipoUserDAL : Conexao
    {


        //Autenticar
        public TipoUserDTO AutenticarEmail(TipoUserDTO TipoUserDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand($"SELECT * FROM tb_tipouser as T  join tb_cliente as C on C.ID_CLIENTE=T.fk_cliente_Tu WHERE C.Email_CL=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", TipoUserDTO.EmailCl);
                dr = cmd.ExecuteReader();
                TipoUserDTO obj = new TipoUserDTO();
                return obj = InsereDTO<TipoUserDTO>(dr);
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
        //Autenticar
        public TipoUserDTO AutenticarUser(TipoUserDTO TipoUserDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM tb_tipouser inner join tb_cliente on fk_cliente_tu=ID_CLIENTE WHERE  usuario_CL=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", TipoUserDTO.UsuarioCl);
                dr = cmd.ExecuteReader();
                TipoUserDTO obj = new TipoUserDTO();
                return obj = InsereDTO<TipoUserDTO>(dr);
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
        //inserir - create empresa
        public void Cadastrar_Cliente(TipoUserDTO TipoUserDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO tb_tipouser (Descricao_Tu,Codigo_Tu,Status_TU,Fk_Cliente_tu,date_time_insert_Tu) VALUES (@v2,@v3,@v4,@v5,@v6)", conn);
                cmd.Parameters.AddWithValue("@v2", TipoUserDTO.DescricaoTu);
                cmd.Parameters.AddWithValue("@v3", TipoUserDTO.CodigoTu);
                cmd.Parameters.AddWithValue("@v4", TipoUserDTO.StatusTu);
                cmd.Parameters.AddWithValue("@v5", TipoUserDTO.FkClienteTu);
                cmd.Parameters.AddWithValue("@v6", TipoUserDTO.DateTimeInsertTu = DataHoraAtual);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar TipoUser !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //inserir - create empresa
        public void Cadastrar_empresa(TipoUserDTO DTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("exec insert_cliente  @nome_completo = @v1,  @primeironome = @v2,  @sobrenome = @v3,   @email = @v4, @usuario = @v5,    @senha = @v6,   @sexo = @v7," +
                    " @caminho_foto = @v8, @status = @v9, @date_time_insert = @v10,   @status_verificacao = @v11,  @Descricao_Tipouser = @v12,  @codigo_tipouser = @v13,  @date_time_privacidade = @v14, @date_time_termos = v15", conn);
                cmd.Parameters.AddWithValue("@v1", DTO.NomeCompletoCl = DTO.PrimeiroNomeCl + " " + DTO.SobrenomeCl);
                cmd.Parameters.AddWithValue("@v2", DTO.PrimeiroNomeCl);
                cmd.Parameters.AddWithValue("@v3", DTO.SobrenomeCl);
                cmd.Parameters.AddWithValue("@v4", DTO.EmailCl);
                cmd.Parameters.AddWithValue("@v5", DTO.UsuarioCl);
                cmd.Parameters.AddWithValue("@v6", DTO.SenhaCl);
                cmd.Parameters.AddWithValue("@v7", DTO.SexoCl);
                cmd.Parameters.AddWithValue("@v8", DTO.DataNascimentoCl);
                cmd.Parameters.AddWithValue("@v9", DTO.CaminhoFotoCl);
                cmd.Parameters.AddWithValue("@v10", Convert.ToByte(DTO.StatusCl = true));
                cmd.Parameters.AddWithValue("@v11", DTO.DateTimeInsertCl = DataHoraAtual);
                cmd.Parameters.AddWithValue("@v12", Convert.ToByte(DTO.StatusVerificacaoCl = false));

                cmd.Parameters.AddWithValue("@v13", DTO.DescricaoTu);
                cmd.Parameters.AddWithValue("@v14", DTO.CodigoTu);
                cmd.Parameters.AddWithValue("@v15", DTO.StatusTu);
                cmd.Parameters.AddWithValue("@v16", DTO.FkClienteTu);


                cmd = new SqlCommand("INSERT INTO tb_tipouser (Descricao_Tu,Codigo_Tu,Status_TU,Fk_Cliente_tu,date_time_insert_Tu) VALUES (@v2,@v3,@v4,@v5,@v6)", conn);
                cmd.Parameters.AddWithValue("@v2", DTO.DescricaoTu);
                cmd.Parameters.AddWithValue("@v3", DTO.CodigoTu);
                cmd.Parameters.AddWithValue("@v4", DTO.StatusTu);
                cmd.Parameters.AddWithValue("@v5", DTO.FkClienteTu);
                cmd.Parameters.AddWithValue("@v6", DTO.DateTimeInsertTu = DataHoraAtual);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("INSERT INTO tb_Profissional(fk_tipouser_PF, date_time_insert_PF , date_time_privacidade_PF, date_time_termos_PF) VALUES(@fk_tipouser_PF,@date_time_insert_PF,@date_time_privacidade_PF,@date_time_termos_PF);  SELECT SCOPE_IDENTITY()", conn);
                cmd.Parameters.AddWithValue("@date_time_insert_PF",  DataHoraAtual);
                cmd.Parameters.AddWithValue("@date_time_termos_PF", DataHoraAtual);
                cmd.Parameters.AddWithValue("@date_time_privacidade_PF", DataHoraAtual);
                cmd.Parameters.AddWithValue("@fk_tipouser_PF", DTO.IdTipouser);
                int id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar Vaga !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        // insert create profissional
        public void Cadastrar_profissional(TipoUserDTO TipoUserDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO tb_tipouser (Cod_tipouser,DescricaoUser,DsStatus,Ds_usuario) VALUES (2,@v2,'profissional','Ativo',@v5)", conn);
                cmd.Parameters.AddWithValue("@v2", TipoUserDTO.EmailCl);
                cmd.Parameters.AddWithValue("@v5", TipoUserDTO.UsuarioCl);
                cmd.Parameters.AddWithValue("@v6", TipoUserDTO.FkClienteTu);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar cliente !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        // insert create profissional
        public void Cadastrar_Adm(string objEmail, string objUsuario)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO Tb_tipouser (ID_TipoUser,Email_cliente,DescricaoUser,Ds_Status,Ds_usuario) VALUES (1,@v2,administrativo,Ativo,@v5)", conn);
                cmd.Parameters.AddWithValue("@v2", objEmail);
                cmd.Parameters.AddWithValue("@v5", objUsuario);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar Vaga !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }



        public List<TipoUserDTO> Buscar_Cliente(TipoUserDTO TipoUserDTO)
        {
            try
            {

                Conectar();
                string queryString = " SELECT " + dados_basico +  ", Fk_cliente_tu,ID_TIPOUSER FROM" +
                    " tb_cliente as C join Tb_tipouser as T on T.fk_cliente_tu = C.id_cliente where C.status_cl=1 and T.codigo_TU in (3,2) ";

                if (TipoUserDTO.NomeCompletoCl != null)
                {
                    queryString += "and C.primeironome_Cl like '%" + TipoUserDTO.NomeCompletoCl + "%' ";
                }

                if (TipoUserDTO.UsuarioCl != null)
                {
                    queryString += "and C.usuario_cl like '%" + TipoUserDTO.UsuarioCl + "%' ";

                }
                if (TipoUserDTO.SexoCl != null)
                {
                    queryString += "and C.sexo_cl='" + TipoUserDTO.SexoCl + "' ";

                }

                queryString += " ORDER BY C.date_time_update_cl desc";
                cmd = new SqlCommand(queryString, conn);
                dr = cmd.ExecuteReader();


                List<TipoUserDTO> Lista = new List<TipoUserDTO>();
                return Lista = ListInsereDTO<TipoUserDTO>(dr);
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


        //Listar
        public List<TipoUserDTO> Listar_cliente()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT "+ dados_basico + " FROM Tb_tipouser join tb_cliente as C on fk_cliente_tu=C.id_cliente order by C.date_time_update_cl desc", conn);
                dr = cmd.ExecuteReader();
                
                List<TipoUserDTO> Lista = new List<TipoUserDTO>();
                //criando lista vazia
                return Lista = ListInsereDTO<TipoUserDTO>(dr);
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

        public List<TipoUserDTO> Listar_Empresas()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Tb_tipouser where cod_tipouser=3", conn);
                dr = cmd.ExecuteReader();

                List<TipoUserDTO> Lista = new List<TipoUserDTO>();
                //criando lista vazia
                return Lista = ListInsereDTO<TipoUserDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Vaga!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public List<TipoUserDTO> Listar_Profissional()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM tipouser where cod_tipouser=2", conn);
                dr = cmd.ExecuteReader();

                List<TipoUserDTO> Lista = new List<TipoUserDTO>();
                return Lista = ListInsereDTO<TipoUserDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Vaga!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
            
          
          

    }
}
