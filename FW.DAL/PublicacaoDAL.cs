using FW.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FW.DAL
{
    public class PublicacaoDAL : Conexao
    {

        //inserir - create
        public PublicacaoDTO Cadastrar_Publicacao(PublicacaoDTO objDTO)
        {
            try
            {
                objDTO.DateTimeInsertCl = DataHoraAtual;
                Conectar();
                if (objDTO.UrlImagen1Pb == null && objDTO.UrlVideo1Pb == null)
                {
                    cmd = new SqlCommand("  begin transaction; COMMIT transaction; INSERT INTO tb_publicacao  (fk_cliente,ds_data,ds_descricao) VALUES (@v1,@v2,@v3); exec Seleciona_Publicacao_IdCliente_IdPublicacao @id_cliente=@v1, @id_publicacao=@@IDENTITY;", conn);

                    cmd.Parameters.AddWithValue("@v1", objDTO.FkClientePb);
                    cmd.Parameters.AddWithValue("@v2", objDTO.DateTimeInsertPb);
                    cmd.Parameters.AddWithValue("@v3", objDTO.DescricaoPb);
                }
                else
                if (objDTO.UrlImagen1Pb != null && objDTO.UrlImagen2Pb == null)
                {
                    cmd = new SqlCommand("  begin transaction; COMMIT transaction;INSERT INTO tb_publicacao (fk_cliente,ds_data,ds_descricao,URL_imagen1) VALUES (@v1,@v2,@v3,@v4);exec Seleciona_Publicacao_IdCliente_IdPublicacao @id_cliente=@v1, @id_publicacao=@@IDENTITY;", conn);
                    cmd.Parameters.AddWithValue("@v1", objDTO.FkClientePb);
                    cmd.Parameters.AddWithValue("@v2", objDTO.DateTimeInsertPb);
                    cmd.Parameters.AddWithValue("@v3", objDTO.DescricaoPb);
                    cmd.Parameters.AddWithValue("@v4", objDTO.UrlImagen1Pb);
                }
                else
                if (objDTO.UrlImagen2Pb != null && objDTO.UrlImagen3Pb == null)
                {
                    cmd = new SqlCommand("begin transaction; COMMIT transaction;INSERT INTO tb_publicacao (fk_cliente,ds_data,ds_descricao,URL_imagen1,URL_imagen2) VALUES (@v1,@v2,@v3,@v4,@v5);exec Seleciona_Publicacao_IdCliente_IdPublicacao @id_cliente=@v1, @id_publicacao=@@IDENTITY;", conn);
                    cmd.Parameters.AddWithValue("@v1", objDTO.FkClientePb);
                    cmd.Parameters.AddWithValue("@v2", objDTO.DateTimeInsertPb);
                    cmd.Parameters.AddWithValue("@v3", objDTO.DescricaoPb);
                    cmd.Parameters.AddWithValue("@v4", objDTO.UrlImagen1Pb);
                    cmd.Parameters.AddWithValue("@v5", objDTO.UrlImagen2Pb);
                }
                else
                if (objDTO.UrlImagen3Pb != null && objDTO.UrlImagen2Pb != null && objDTO.UrlImagen1Pb != null)
                {
                    cmd = new SqlCommand("begin transaction; COMMIT transaction;INSERT INTO tb_publicacao (fk_cliente,ds_data,ds_descricao,URL_imagen1,URL_imagen2,URL_imagen3) VALUES (@v1,@v2,@v3,@v4,@v5,@v6);exec Seleciona_Publicacao_IdCliente_IdPublicacao @id_cliente=@v1, @id_publicacao=@@IDENTITY;", conn);
                    cmd.Parameters.AddWithValue("@v1", objDTO.FkClientePb);
                    cmd.Parameters.AddWithValue("@v2", objDTO.DateTimeInsertPb);
                    cmd.Parameters.AddWithValue("@v3", objDTO.DescricaoPb);
                    cmd.Parameters.AddWithValue("@v4", objDTO.UrlImagen1Pb);
                    cmd.Parameters.AddWithValue("@v5", objDTO.UrlImagen2Pb);
                    cmd.Parameters.AddWithValue("@v6", objDTO.UrlImagen3Pb);
                }
                if (objDTO.UrlVideo1Pb != null && objDTO.UrlImagen1Pb == null)
                {
                    cmd = new SqlCommand("begin transaction; COMMIT transaction;INSERT INTO tb_publicacao (fk_cliente,ds_data,ds_descricao,URL_Video1) VALUES (@v1,@v2,@v3,@v4);exec Seleciona_Publicacao_IdCliente_IdPublicacao @id_cliente=@v1, @id_publicacao=@@IDENTITY;", conn);
                    cmd.Parameters.AddWithValue("@v1", objDTO.FkClientePb);
                    cmd.Parameters.AddWithValue("@v2", objDTO.DateTimeInsertPb);
                    cmd.Parameters.AddWithValue("@v3", objDTO.DescricaoPb);
                    cmd.Parameters.AddWithValue("@v4", objDTO.UrlVideo1Pb);
                }
                dr = cmd.ExecuteReader();
                PublicacaoDTO obj = new PublicacaoDTO();
                return obj = InsereDTO<PublicacaoDTO>( dr);

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar em Publicacao!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //Delete
        public void Excluir_Publicacao(PublicacaoDTO PublicacaoDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("exec Delete_Publicacao_Comentarios @ID_cliente=@v1 ,@Fk_publicacao=@v2", conn);
                cmd.Parameters.AddWithValue("@v1", PublicacaoDTO.FkClientePb);
                cmd.Parameters.AddWithValue("@v2", PublicacaoDTO.IdPublicacao);
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
        public void Editar_cliente(PublicacaoDTO objDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE tb_publicacao SET fk_cliente=@v1,ds_data@v2,ds_descricao=@v3,URL_imagen1=@v4,URL_imagen2=@v5,URL_imagen3=@v6,URL_Video1=@v7,URL_Vide2=@v8", conn);
                cmd.Parameters.AddWithValue("@v1", objDTO.FkClientePb);
                cmd.Parameters.AddWithValue("@v2", objDTO.DateTimeUpdatePb =DataHoraAtual);
                cmd.Parameters.AddWithValue("@v3", objDTO.DescricaoPb);
                cmd.Parameters.AddWithValue("@v4", objDTO.UrlImagen1Pb);
                cmd.Parameters.AddWithValue("@v5", objDTO.UrlImagen2Pb);
                cmd.Parameters.AddWithValue("@v6", objDTO.UrlImagen3Pb);
                cmd.Parameters.AddWithValue("@v7", objDTO.UrlVideo1Pb);
                cmd.Parameters.AddWithValue("@v8", objDTO.UrlVideo2Pb);
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
        public List<PublicacaoDTO> Filtrar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("exec Filtrar_Publicacao_Cliente ", conn);
                dr = cmd.ExecuteReader();
                List<PublicacaoDTO> Lista = new List<PublicacaoDTO>();
                return Lista = ListInsereDTO<PublicacaoDTO>(dr);
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

        public List<PublicacaoDTO> Filtrar_ID(PublicacaoDTO PublicacaoDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("exec Lista_Publicacao_Cliente @ID_Cliente=@v1 ", conn);
                cmd.Parameters.AddWithValue("@v1", PublicacaoDTO.IdCliente);
                dr = cmd.ExecuteReader();
                List<PublicacaoDTO> Lista = new List<PublicacaoDTO>();
                return Lista = ListInsereDTO<PublicacaoDTO>( dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Filtrar Publicacao!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public PublicacaoDTO Selecionar_ID(PublicacaoDTO PublicacaoDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("exec Seleciona_Publicacao_IdCliente_IdPublicacao @id_cliente=@v1, @id_publicacao=@v2 ", conn);
                cmd.Parameters.AddWithValue("@v1", PublicacaoDTO.IdCliente);
                cmd.Parameters.AddWithValue("@v2", PublicacaoDTO.IdPublicacao);
                dr = cmd.ExecuteReader();
                PublicacaoDTO obj = new PublicacaoDTO();
                return obj = InsereDTO<PublicacaoDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Selecionar Publicacao!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
