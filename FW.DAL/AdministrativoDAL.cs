using FW.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FW.DAL
{
    public class AdministrativoDAL : Conexao
    {
        //inserir - create
        public void Cadastrar(AdministrativoDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO Administrativo(dsEmail,SenhaADM,UrlImage,fk_cliente) VALUES (@v1,@v2,@v3,@v4)", conn);
                cmd.Parameters.AddWithValue("@v1", objCad.Nome_Admin);
                cmd.Parameters.AddWithValue("@v2", objCad.Senha_Admin);
                cmd.Parameters.AddWithValue("@v3", objCad.Url_foto);
                cmd.Parameters.AddWithValue("@v4", objCad.FK_TipoUser);


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar Admin!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Delete
        public void Excluir(int objExclui)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM Administrativo WHERE IdAdministrativo=@v5", conn);
                cmd.Parameters.AddWithValue("@v5", objExclui);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Excluir!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Autenticar
        public AdministrativoDTO Autenticar(AdministrativoDTO AdministrativoDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT  ADM.ds_Email,ADM.Senha_ADM,IdAdministrativo,fk_cliente,fk_tipouser,Cod_tipouser FROM tb_Administrativo as ADM join tb_tipouser on id_tipouser=fk_tipouser join tb_cliente on id_cliente=Fk_cliente WHERE adm.ds_Email =@v1  AND  adm.Senha_ADM =@v2", conn);
                cmd.Parameters.AddWithValue("@v1", AdministrativoDTO.Email_Adm);
                cmd.Parameters.AddWithValue("@v2", AdministrativoDTO.Senha_Admin);
                dr = cmd.ExecuteReader();
                AdministrativoDTO obj = new AdministrativoDTO();
                if (dr.Read())
                {
                    obj = new AdministrativoDTO
                    {
                        Email_Adm = dr["ds_Email"].ToString(),
                        Senha_Admin = dr["Senha_ADM"].ToString(),
                        FK_TipoUser = Convert.ToInt32(dr["fk_cliente"]),
                        IdCliente = Convert.ToInt32(dr["fk_tipouser"]),
                        CodigoTu = Convert.ToInt32(dr["Cod_TipoUser"]),
                        IdAdministrativo = Convert.ToInt32(dr["IdAdministrativo"])
                    };
                }
                return obj;
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

        //Editar - Update
        public void Editar(AdministrativoDTO objEdita)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Administrativo SET NmADM = @v1,SenhaADM = @v2,UrlImagem = @v3,fk_cliente = @v4, WHERE IdUsuario = @v5", conn);

                cmd.Parameters.AddWithValue("@v1", objEdita.Nome_Admin);
                cmd.Parameters.AddWithValue("@v2", objEdita.Senha_Admin);
                cmd.Parameters.AddWithValue("@v3", objEdita.Url_foto);
                cmd.Parameters.AddWithValue("@v4", objEdita.FK_TipoUser);
                cmd.Parameters.AddWithValue("@v5", objEdita.IdAdministrativo);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Editar Administrativo !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Listar
        public List<AdministrativoDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdAdministrativo, NmADM, SenhaADM, UrlImage, FKTipoUser FROM Administrativo JOIN TipoUser ON FKTipoUser=IdTipoUser", conn);
                dr = cmd.ExecuteReader();
                List<AdministrativoDTO> Lista = new List<AdministrativoDTO>();//criando lista vazia

                while (dr.Read())
                {
                    AdministrativoDTO obj = new AdministrativoDTO
                    {
                        IdAdministrativo = Convert.ToInt32(dr["IdAdministrativo"]),
                        Nome_Admin = dr["NmADM"].ToString(),
                        Senha_Admin = dr["SenhaADM"].ToString(),
                        Url_foto = dr["UrlImage"].ToString(),
                        FK_TipoUser = Convert.ToInt32(dr["FKTipoUser"])
                    };


                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Admin!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Filtrar
        public List<AdministrativoDTO> Filtrar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Administrativo ORDER BY NmADM", conn);
                dr = cmd.ExecuteReader();
                List<AdministrativoDTO> Lista = new List<AdministrativoDTO>();
                while (dr.Read())
                {
                    AdministrativoDTO obj = new AdministrativoDTO
                    {
                        IdAdministrativo = Convert.ToInt32(dr["IdVaga"]),
                        Nome_Admin = dr["NmVaga"].ToString(),
                        Senha_Admin = dr["DsExperiencia"].ToString(),
                        Url_foto = dr["DsTipoRegistro"].ToString(),
                        FK_TipoUser = Convert.ToInt32(dr["DsDescricao"])
                    };
                    ;

                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Filtrar Admin!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //Filtrar
        public List<AdministrativoDTO> FiltrarID(int idOperador)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Administrativo where IdAdministrativo=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", idOperador);

                dr = cmd.ExecuteReader();
                List<AdministrativoDTO> Lista = new List<AdministrativoDTO>();
                while (dr.Read())
                {
                    AdministrativoDTO obj = new AdministrativoDTO
                    {
                        IdAdministrativo = Convert.ToInt32(dr["IdVaga"]),
                        Nome_Admin = dr["NmVaga"].ToString(),
                        Senha_Admin = dr["DsExperiencia"].ToString(),
                        Url_foto = dr["DsTipoRegistro"].ToString(),
                        FK_TipoUser = Convert.ToInt32(dr["DsDescricao"])
                    };


                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Filtrar Admin!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
