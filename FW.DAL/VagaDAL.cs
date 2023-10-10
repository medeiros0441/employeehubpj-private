using FW.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FW.DAL
{
    public class VagaDAL : Conexao
    { 
        public int Cadastrar(VagaDTO objCad)
        {
            try
            {

                Conectar();
                cmd = new SqlCommand("exec Create_Vaga @nome_vg=@v1,@tipovagavg =@TipoVagaVg,@experiencia=@v2,@tiporegistro=@v3,@descricao=@v4,@sexo=@v5,@validade=@v6,@date_time_insert=@v7,@status=@v8,@status_adm=@v9,@fk_empresa=@v10,@descricao_adm=@v11", conn);
                cmd.Parameters.AddWithValue("@v1", objCad.NomeVg);
                cmd.Parameters.AddWithValue("@v2", objCad.TempoExperienciaVg);
                cmd.Parameters.AddWithValue("@v3", objCad.TipoRegistroVg);
                cmd.Parameters.AddWithValue("@v4", objCad.DescricaoVg);
                cmd.Parameters.AddWithValue("@v5", objCad.SexoVg);
                cmd.Parameters.AddWithValue("@v6", objCad.DescricaoValidadeVg);
                cmd.Parameters.AddWithValue("@TipoVagaVg", objCad.TipoVagaVg);
                cmd.Parameters.AddWithValue("@v7", DataHoraAtual);
                cmd.Parameters.AddWithValue("@v8", Convert.ToByte(objCad.StatusVg));
                cmd.Parameters.AddWithValue("@v9",Convert.ToByte(true));
                cmd.Parameters.AddWithValue("@v10", objCad.FkEmpresaVg);
                cmd.Parameters.AddWithValue("@v11", "PLUBLICADO");

                int id =  cmd.ExecuteNonQuery();
                return id;
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

        //Listar
        public List<VagaDTO> Listar(bool Status)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("Select * from TB_VAGA as vg inner join  tb_vaga_status_adm as vsa on vsa.fk_vaga_VSA= vg.id_vaga  where  status_VSA=@status_vsa ORDER BY date_time_update_VG desc", conn);
                cmd.Parameters.AddWithValue("@status_vsa", Convert.ToByte(Status));
                dr = cmd.ExecuteReader();
                List<VagaDTO> Lista = new List<VagaDTO>();
                return Lista = ListInsereDTO<VagaDTO>(dr);
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

        //Selecionar
        public VagaDTO Selecionar(int IdVaga, bool status_adm )
        {
            try
            {
                Conectar();
                cmd = new SqlCommand($"SELECT {colunas_vaga},{dados_endereco} FROM tb_Vaga vg inner join  tb_vaga_status_adm as vsa on vsa.fk_vaga_VSA= id_vaga   join tb_empresa as em on id_empresa=vg.fk_empresa_VG join tb_tipouser on id_tipouser=em.fk_tipouser_EP  join tb_cliente as cl on id_cliente=Fk_cliente_TU where status_VSA=@v2 and Id_Vaga=@v1 ", conn);
                cmd.Parameters.AddWithValue("@v1", IdVaga);
                cmd.Parameters.AddWithValue("@v2", status_adm);
                dr = cmd.ExecuteReader();

                VagaDTO obj = new VagaDTO();
                return obj = InsereDTO<VagaDTO>( dr);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar Vaga" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Delete
        public void Excluir(VagaDTO VagaDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("update  Tb_Vaga_Status_ADM set  status_VSA=@status_VSA,date_time_update_VSA=@date_time_update_vsa,descricao_VSA=@descricao_VSA where Fk_Vaga_vsa =@FK_vaga_VSA; " +
                    "update TB_VAGA set status_vg=status_VG ,date_time_update_vg=@date_time_update_vg  where Id_Vaga=@id_vaga;", conn);

                cmd.Parameters.AddWithValue("@status_VSA", Convert.ToByte(false));
                cmd.Parameters.AddWithValue("@date_time_update_VSA", DataHoraAtual);
                cmd.Parameters.AddWithValue("@descricao_VSA", "Excluido");
                cmd.Parameters.AddWithValue("@Fk_Vaga_vsa", VagaDTO.IdVaga);
                cmd.Parameters.AddWithValue("@status_VG", Convert.ToByte(false));
                cmd.Parameters.AddWithValue("@date_time_update_vg", DataHoraAtual);
                cmd.Parameters.AddWithValue("@id_vaga", VagaDTO.IdVaga);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Excluir Vaga!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        } 
      
        //Editar - Update
        public void Editar(VagaDTO VagaDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE tb_Vaga  SET   nome_VG = @nome_VG, tempo_experiencia_VG = @tempo_experiencia_VG,TipoVaga_vg=@TipoVagaVg," +
                    " tipo_registro_VG =@tipo_registro_VG, descricao_VG = @descricao_VG, sexo_VG = @sexo_VG, descricao_validade_VG = @descricao_validade_VG," +
                    " date_time_update_VG = @date_time_update_VG,status_VG=@status_VG WHERE Id_Vaga = @Id_Vaga and fk_empresa_VG=@FkEmpresaVg ", conn);
                cmd.Parameters.AddWithValue("@nome_VG", VagaDTO.NomeVg);
                cmd.Parameters.AddWithValue("@tempo_experiencia_VG", VagaDTO.TempoExperienciaVg);
                cmd.Parameters.AddWithValue("@tipo_registro_VG", VagaDTO.TipoRegistroVg);
                cmd.Parameters.AddWithValue("@descricao_VG", VagaDTO.DescricaoVg);
                cmd.Parameters.AddWithValue("@sexo_VG", VagaDTO.SexoVg);
                cmd.Parameters.AddWithValue("@descricao_validade_VG", VagaDTO.DescricaoValidadeVg);
                cmd.Parameters.AddWithValue("@date_time_update_VG", DataHoraAtual);
                cmd.Parameters.AddWithValue("@status_VG", Convert.ToByte(VagaDTO.StatusVg));
                cmd.Parameters.AddWithValue("@Id_Vaga", VagaDTO.IdVaga);
                cmd.Parameters.AddWithValue("@TipoVagaVg", VagaDTO.TipoVagaVg);
                cmd.Parameters.AddWithValue("@FkEmpresaVg", VagaDTO.FkEmpresaVg);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Editar Vaga !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
 
      
        public List<VagaDTO> Listar_Vagas_ativa_Empresa(int idempresa)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand($"SELECT {colunas_vaga} FROM tb_Vaga as vg inner join  Tb_Vaga_Status_ADM as vsa on vsa.Fk_vaga_vsa=vg.ID_vaga " +
                    " where vsa.status_vsa=@status_vsa and FK_Empresa_vg=@ID_empresa order by vg.date_time_update_vg desc", conn);
                cmd.Parameters.AddWithValue("@ID_empresa", idempresa);
                cmd.Parameters.AddWithValue("@status_vsa", Convert.ToByte(true));

                dr = cmd.ExecuteReader();
                List<VagaDTO> Lista = new List<VagaDTO>();
                return Lista = ListInsereDTO< VagaDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Filtrar!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public List<VagaDTO> Buscar_Vaga_Geral(VagaDTO VagaDTO)
        {

            try
            {
                Conectar();
                string queryString = $"SELECT {colunas_vaga},{dados_endereco} FROM tb_Vaga as vg  inner join  Tb_Vaga_Status_ADM as adm on adm.fk_vaga_VSA=id_vaga  join tb_empresa as em on id_empresa=vg.fk_empresa_VG join tb_tipouser on id_tipouser=em.fk_tipouser_EP  join tb_cliente as cl on id_cliente=Fk_cliente_TU where status_vsa =1";
                if (VagaDTO.NomeVg != null)
                {
                    queryString += " and  nome_vg LIKE '" + VagaDTO.NomeVg + "%'";

                }
                if (VagaDTO.TipoRegistroVg != null)
                {
                    queryString += " and tipo_registro_vg= '" + VagaDTO.TipoRegistroVg + "'";

                }
                if (VagaDTO.TempoExperienciaVg != null)
                {
                    queryString += "   and tempo_experiencia_vg = '" + VagaDTO.TempoExperienciaVg + "'";

                }
                if (VagaDTO.TipoVagaVg != null)
                {
                    queryString += "   and TipoVaga_Vg = '" + VagaDTO.TipoVagaVg + "'";

                }
                if (VagaDTO.DescricaoEstadoCl != null)
                {
                    queryString += "   and descricao_estado_cl = '" + VagaDTO.DescricaoEstadoCl + "'";

                }
                if (VagaDTO.DescricaoCidadeCl != null)
                {
                    queryString += "   and descricao_cidade_cl = '" + VagaDTO.DescricaoCidadeCl + "'";
                }
                queryString += " order by date_time_insert_vg desc ";
                cmd = new SqlCommand(queryString, conn);
                dr = cmd.ExecuteReader();
                List<VagaDTO> Lista = new List<VagaDTO>();
                return Lista = ListInsereDTO<VagaDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Filtrar!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public VagaDTO Selecionar_Vaga_Ativa_Empresa(int idvaga, int idempresa)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM tb_Vaga as vg  " +
                    "inner join  Tb_Vaga_Status_ADM as vsa on vsa.Fk_vaga_vsa=vg.ID_vaga  " +
                    "where status_vsa=@status_vsa and id_vaga=@ID_vaga and fk_empresa_vg=@ID_empresa  order by vg.date_time_update_vg desc", conn);
                cmd.Parameters.AddWithValue("@ID_empresa", idempresa);
                cmd.Parameters.AddWithValue("@ID_vaga", idvaga);
                cmd.Parameters.AddWithValue("@status_vsa", Convert.ToByte(true));

                dr = cmd.ExecuteReader();

                VagaDTO obj = new VagaDTO();
                    return obj = InsereDTO<VagaDTO>( dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Filtrar!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public bool DeleteVaga_Permanente(int idvaga)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM tb_vaga_status_adm WHERE fk_vaga_vsa = @id_vaga; " +
                                     "DELETE FROM tb_candidato WHERE fk_vaga_ct = @id_vaga; " +
                                     "DELETE FROM tb_vaga WHERE id_vaga = @id_vaga", conn);
                cmd.Parameters.AddWithValue("@id_vaga", idvaga);
                int rowsAffected = cmd.ExecuteNonQuery();

                // Verificar se a exclusão foi bem-sucedida
                if (rowsAffected > 0)
                {
                    // Executado com sucesso
                    return true;
                }
                else
                {
                    // Nenhuma linha foi afetada
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Filtrar!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
