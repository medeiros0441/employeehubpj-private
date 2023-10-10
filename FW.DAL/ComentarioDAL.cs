using FW.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FW.DAL
{
    public class ComentarioDAL : Conexao
    {

        //inserir - create
        public void CadastrarComentario(ComentarioDTO objDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO tb_comentarios (ds_data,ds_comentario,fk_publicacao,fk_cliente) VALUES (@v1,@v2,@v3,@v4)", conn);
                cmd.Parameters.AddWithValue("@v1", objDTO.DateTimeUpdateCm = DataHoraAtual);
                cmd.Parameters.AddWithValue("@v2", objDTO.ComentarioCm);
                cmd.Parameters.AddWithValue("@v3", objDTO.FkPublicacaoCm);
                cmd.Parameters.AddWithValue("@v4", objDTO.FkClienteCm);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar em vaga!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //Delete
        public void Excluir_comentario(int id_Comentario)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM tb_comentarios WHERE id_comentario=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", id_Comentario);
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

        //Editar - Update
        public void Editar_cliente(ComentarioDTO ComentarioDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE tb_comentarios SET ds_comentario=@v2,ds_data=@v1 WHERE fk_cliente=@v4 and fk_publicacao=@v3", conn);
                cmd.Parameters.AddWithValue("@v1", ComentarioDTO.DateTimeUpdateCm);
                cmd.Parameters.AddWithValue("@v2", ComentarioDTO.ComentarioCm);
                cmd.Parameters.AddWithValue("@v3", ComentarioDTO.FkPublicacaoCm);
                cmd.Parameters.AddWithValue("@v4", ComentarioDTO.FkClienteCm);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Editar Comentario!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public List<ComentarioDTO> Filtrar(ComentarioDTO ComentarioDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM tb_comentarios as C where C.fK_publicacao=@v1 ORDER BY C.ds_data", conn);
                cmd.Parameters.AddWithValue("@v1", ComentarioDTO.FkPublicacaoCm);
                dr = cmd.ExecuteReader();
                List<ComentarioDTO> Lista = new List<ComentarioDTO>();
                while (dr.Read())
                {
                    ComentarioDTO obj = new ComentarioDTO
                    {
                        IdComentario = Convert.ToInt32(dr["id_comentario"]),
                        DateTimeInsertCm = Convert.ToDateTime(dr["Dt_Conclusao"]),
                        DateTimeUpdateCm = Convert.ToDateTime(dr["Dt_Conclusao"]),
                        ComentarioCm = dr["ds_comentario"].ToString(),
                        FkClienteCm = Convert.ToInt32(dr["id_cliente"]),
                        FkPublicacaoCm = Convert.ToInt32(dr["fk_publicacao"])
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
