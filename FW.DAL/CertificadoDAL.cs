using FW.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FW.DAL
{
    public class CertificadoDAL : Conexao
    {
        //inserir - Create
        public void Cadastrar(CertificadoDTO CertificadoDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO TB_Certificado (nome_curso_CF,nome_instituicao_CF,descricao_CF,date_time_insert_CF,date_inicio_CF,date_finalizou_CF,fk_Profissional_CF) " +
                    " VALUES (@v1,@v2 ,@v3,@v4,@v5,@v6,@v7)", conn);
                cmd.Parameters.AddWithValue("@v1", CertificadoDTO.NomeCursoCf);
                cmd.Parameters.AddWithValue("@v2", CertificadoDTO.NomeInstituicaoCf);
                cmd.Parameters.AddWithValue("@v3", CertificadoDTO.DescricaoCf);
                cmd.Parameters.AddWithValue("@v4", CertificadoDTO.DateTimeInsertCf = DataHoraAtual);
                cmd.Parameters.AddWithValue("@v5", CertificadoDTO.DateInicioCf);
                cmd.Parameters.AddWithValue("@v6", CertificadoDTO.DateFinalizouCf);
                cmd.Parameters.AddWithValue("@v7", CertificadoDTO.FkProfissionalCf);


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar Certificado!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Listar
        public List<CertificadoDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT nome_curso_CF,nome_instituicao_CF,descricao_CF,date_time_insert_CF,date_inicio_CF,date_finalizou_CF,fk_Profissional_CF FROM TB_Certificado" +
                    " JOIN TB_Profissional ON FK_Profissional_CF=Id_Profissional", conn);
                dr = cmd.ExecuteReader();

                List<CertificadoDTO> Lista = new List<CertificadoDTO>();

                return Lista = ListInsereDTO<CertificadoDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Certificado!" + ex.Message);
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
                cmd = new SqlCommand("DELETE FROM TB_Certificado WHERE Id_Certificado=@v7", conn);
                cmd.Parameters.AddWithValue("@v7", objExclui);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Excluir Certificado!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Editar - Update
        public void Editar(CertificadoDTO CertificadoDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE TB_Certificado SET nome_curso_CF = @v1,nome_instituicao_CF=@v2,descricao_CF=@v3,date_time_update_CF=@v4,date_inicio_CF=@v5,date_finalizou_CF=@v6 where  FK_Profissional_Cf = @v7 and Id_Certificado = @v8", conn);
               
                cmd.Parameters.AddWithValue("@v1", CertificadoDTO.NomeCursoCf);
                cmd.Parameters.AddWithValue("@v2", CertificadoDTO.NomeInstituicaoCf);
                cmd.Parameters.AddWithValue("@v3", CertificadoDTO.DescricaoCf);
                cmd.Parameters.AddWithValue("@v4",  DataHoraAtual);
                cmd.Parameters.AddWithValue("@v5", CertificadoDTO.DateInicioCf);
                cmd.Parameters.AddWithValue("@v6", CertificadoDTO.DateFinalizouCf);
                cmd.Parameters.AddWithValue("@v7", CertificadoDTO.FkProfissionalCf);
                cmd.Parameters.AddWithValue("@v8", CertificadoDTO.IdCertificado);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Editar Certificado!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }


        //Selecionar
        public CertificadoDTO Selecionar_IDCertificado(int ID_Certificado)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM TB_Certificado  WHERE ID_Certificado = @v1", conn);
                cmd.Parameters.AddWithValue("@v1", ID_Certificado);
                dr = cmd.ExecuteReader();
                CertificadoDTO obj = new CertificadoDTO();
                return obj = InsereDTO<CertificadoDTO>(dr);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar Certificados" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }


        public List<CertificadoDTO> ListarCertificado(int idProfissional)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM TB_Certificado  WHERE FK_Profissional_CF = @v1", conn);
                cmd.Parameters.AddWithValue("@v1", idProfissional);
                dr = cmd.ExecuteReader();


                List<CertificadoDTO> Lista = new List<CertificadoDTO>();

                return Lista = ListInsereDTO<CertificadoDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Certificados!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
       
         
    }
}
