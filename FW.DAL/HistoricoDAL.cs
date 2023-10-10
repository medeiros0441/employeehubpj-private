using FW.DTO;//
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FW.DAL
{
    public class HistoricoDAL : Conexao
    {


        //inserir - create
        public void Cadastrar(HistoricoDTO HistoricoDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO tb_Historico (fk_cliente_HT,descricao_HT,date_time_insert_HT)VALUES (@v1,@v2,@v3)", conn);
                cmd.Parameters.AddWithValue("@v1", HistoricoDTO.FkClienteHt);
                cmd.Parameters.AddWithValue("@v2", HistoricoDTO.DescricaoHt);
                cmd.Parameters.AddWithValue("@v3", HistoricoDTO.DateTimeInsertHt = DataHoraAtual);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao publicar historico!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //inserir - create
        public void Cadastrar_Senha(HistoricoDTO HistoricoDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO tb_Historico(fk_cliente_HT,descricao_HT,date_time_insert_HT) VALUES (@v1,@v2,@v3)", conn);
                cmd.Parameters.AddWithValue("@v1", HistoricoDTO.FkClienteHt);
                cmd.Parameters.AddWithValue("@v2", HistoricoDTO.DescricaoHt = "Senha Alterada");
                cmd.Parameters.AddWithValue("@v3", HistoricoDTO.DateTimeInsertHt = DataHoraAtual);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao publicar historico!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //inserir - create
        public void Cadastrar_Inclusao(HistoricoDTO HistoricoDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO tb_Historico(fk_cliente_HT,descricao_HT,date_time_insert_HT) VALUES (@v1,@v2,@v3)", conn);
                cmd.Parameters.AddWithValue("@v1", HistoricoDTO.FkClienteHt);
                cmd.Parameters.AddWithValue("@v2", HistoricoDTO.DescricaoHt = "Inclusão de cadastro");
                cmd.Parameters.AddWithValue("@v3", HistoricoDTO.DateTimeInsertHt = DataHoraAtual);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao publicar historico!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //Autenticar
        public HistoricoDTO AutenticarHistorico(int FkClienteHt)
        {

            try
            {

                Conectar();
                cmd = new SqlCommand("SELECT * FROM tb_historico WHERE  Fk_cliente_ht=@v2", conn);
                cmd.Parameters.AddWithValue("@v2", FkClienteHt);
                dr = cmd.ExecuteReader();

                HistoricoDTO obj = new HistoricoDTO();
                return obj = InsereDTO<HistoricoDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Autenticar Empresa!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Editar - Update
        public HistoricoDTO EditarHistorico(HistoricoDTO objEdita)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("update historico set  Ds_info=@v1,date_time_update_HT=@v2  where  Fk_cliente=@v3", conn);

                cmd.Parameters.AddWithValue("@v3", objEdita.IdCliente);
                cmd.Parameters.AddWithValue("@v1", objEdita.DescricaoHt);
                cmd.Parameters.AddWithValue("@v2", objEdita.DateTimeUpdateHt = DataHoraAtual);
                cmd.ExecuteNonQuery();
                HistoricoDTO obj = null;
                return obj = InsereDTO<HistoricoDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Editar Dados profissional !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }
    }
}
