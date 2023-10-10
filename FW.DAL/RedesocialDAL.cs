using FW.DTO;//
using System;
using System.Collections.Generic;
using System.Data.SqlClient;//


namespace FW.DAL
{
    public class RedesocialDAL : Conexao
    {

        //inserir - Create
        public void Cadastrar(RedesocialDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO tb_redesocial (link_rede_RS, descricao_rede_RS, date_time_insert_RS, FK_Cliente_RS) values(@v1, @v2,@v3,@v4)", conn);
                cmd.Parameters.AddWithValue("@v1", objCad.LinkRedeRs);
                cmd.Parameters.AddWithValue("@v2", objCad.DescricaoRedeRs);
                cmd.Parameters.AddWithValue("@v3", objCad.DateTimeInsertRs = DataHoraAtual);
                cmd.Parameters.AddWithValue("@v4", objCad.FkClienteRs);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar Rede Social!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }


        //Listar
        public List<RedesocialDTO> Listar_Fkcliente(int FkClienteRs)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT link_rede_RS, descricao_rede_RS, date_time_insert_RS, FK_Cliente_RS FROM tb_redesocial   where  fk_cliente_Rs=@v1 ", conn);
                cmd.Parameters.AddWithValue("@v1", FkClienteRs);

                dr = cmd.ExecuteReader();
                List<RedesocialDTO> obj = ListInsereDTO<RedesocialDTO>(dr);
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Rede!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public RedesocialDTO GetRedesSociaisPorID(int id_rede)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM tb_redesocial WHERE   id_rede = @v1", conn);
                cmd.Parameters.AddWithValue("@v1", id_rede);
                dr = cmd.ExecuteReader();

                RedesocialDTO obj = InsereDTO<RedesocialDTO>(dr);
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar redesocial" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //Delete
        public void Excluir(int idrede, int idcliente)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE TB_Redesocial where fk_Cliente_rs=@v2 and id_rede=@v1 ", conn);
                cmd.Parameters.AddWithValue("@v1", idrede);
                cmd.Parameters.AddWithValue("@v2", idcliente);
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
        public void Editar(RedesocialDTO redesocialDTO)
        {
            try
            {
                Conectar(); 
                cmd = new SqlCommand("UPDATE TB_Redesocial SET link_rede_RS=@v3 ,date_time_insert_RS=@v4 WHERE Id_rede=@v1 and FK_Cliente_RS=@v2 ", conn);
                cmd.Parameters.AddWithValue("@v1", redesocialDTO.IdRede);
                cmd.Parameters.AddWithValue("@v2", redesocialDTO.FkClienteRs);
                cmd.Parameters.AddWithValue("@v3", redesocialDTO.LinkRedeRs);
                cmd.Parameters.AddWithValue("@v4", redesocialDTO.DateTimeUpdateRs = DataHoraAtual);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Editar Vaga!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
         
        //Selecionar
        public RedesocialDTO SelecionarID_Descricao(RedesocialDTO redesocialDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT id_rede, link_rede_RS, descricao_rede_RS, FK_Cliente_RS FROM  TB_Redesocial where FK_Cliente_RS = @v1 and descricao_rede_RS=@v2", conn);
                cmd.Parameters.AddWithValue("@v1", redesocialDTO.FkClienteRs);
                cmd.Parameters.AddWithValue("@v2", redesocialDTO.DescricaoRedeRs);
                dr = cmd.ExecuteReader();

                RedesocialDTO obj = InsereDTO<RedesocialDTO>(dr);
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar redesocial" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        
         
    }
}
