using FW.DTO;
using System;
using System.Data.SqlClient;


namespace FW.DAL
{
    internal class Vaga_Status_Adm_DAL : Conexao
    {
        //inserir - create
        public void Cadastrar(Vaga_Status_Adm_DTO objCad)
        {
            try
            {
                Conectar(); cmd = new SqlCommand("INSERT INTO tb_vaga_status_Adm (dt_atualizacao,Dt_Termos,Dt_Privacidade,fk_tipouser) VALUES(@v1,@v2,@v3,@v4);", conn);
                cmd.Parameters.AddWithValue("@v1", objCad.DateVsa =DataHoraAtual);
                cmd.Parameters.AddWithValue("@v2", objCad.DescricaoVsa);
                cmd.Parameters.AddWithValue("@v3", objCad.StatusVsam);
                cmd.Parameters.AddWithValue("@v4", objCad.IdVagaStatusVsa);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }


    }
}
