using FW.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;


namespace FW.DAL
{
    public class ExperienciaDAL : Conexao
    {
        //inserir - create
        public void Cadastrar(ExperienciaDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO tb_experiencia (nome_cargo_EX, nome_empresa_EX,  tipo_contrato_EX, date_time_insert_EX, descricao_EX, date_inicio_EX, date_finalizou_EX, fk_profissional_EX) VALUES (@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8)", conn);
                cmd.Parameters.AddWithValue("@v1", objCad.NomeCargoEx);
                cmd.Parameters.AddWithValue("@v2", objCad.NomeEmpresaEx);
                cmd.Parameters.AddWithValue("@v3", objCad.TipoContratoEx);
                cmd.Parameters.AddWithValue("@v4", objCad.DateTimeInsertEx = DataHoraAtual);
                cmd.Parameters.AddWithValue("@v5", objCad.DescricaoEx);
                cmd.Parameters.AddWithValue("@v6", objCad.DateInicioEx);
                cmd.Parameters.AddWithValue("@v7", objCad.DateFinalizouEx);
                cmd.Parameters.AddWithValue("@v8", objCad.FkProfissionalEx);


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar Experiencia!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Listar
        public List<ExperienciaDTO> Listar(int id_cliente)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT id_experiencia, nome_cargo_EX, nome_empresa_EX, date_time_insert_EX, tipo_contrato_EX, descricao_EX, date_inicio_EX, date_finalizou_EX, fk_profissional_EX FROM " +
                    "TB_Experiencia as E " +
                    "JOIN TB_Profissional as P ON P.ID_Profissional = E.FK_Profissional_Ex " +
                    "inner join tb_tipouser as T on T.id_tipouser = P.Fk_tipouser_pf " +
                    "inner join tb_cliente as C on C.id_cliente = T.fk_cliente_tu    " +
                    " where C.ID_CLIENTE =@v1  order by date_time_insert_EX desc ", conn);
                cmd.Parameters.AddWithValue("@v1", id_cliente);

                dr = cmd.ExecuteReader();
                List<ExperienciaDTO> Lista = new List<ExperienciaDTO>();
                return Lista = ListInsereDTO<ExperienciaDTO>(dr);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Experiencia!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Editar - Update
        public void Editar(ExperienciaDTO ExperienciaDTO)
        {
            try
            {
                Conectar();
                string query = @"update tb_experiencia  set nome_cargo_EX = @NomeCargoEx, nome_empresa_EX =@NomeEmpresaEx, date_time_update_EX =  @DateTimeUpdateEx, tipo_contrato_EX = @TipoContratoEx, descricao_EX = @DescricaoEx, date_inicio_EX =@DateInicioEx,  date_finalizou_EX =@DateFinalizouEx where fk_profissional_EX = @FkProfissionalEx ";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@NomeCargoEx", ExperienciaDTO.NomeCargoEx);
                command.Parameters.AddWithValue("@NomeEmpresaEx", ExperienciaDTO.NomeEmpresaEx);
                command.Parameters.AddWithValue("@DateTimeUpdateEx",DATA_HORA_BR.Data_Hora);
                command.Parameters.AddWithValue("@TipoContratoEx", ExperienciaDTO.TipoContratoEx);
                command.Parameters.AddWithValue("@DescricaoEx", ExperienciaDTO.DescricaoEx);
                command.Parameters.AddWithValue("@DateInicioEx", ExperienciaDTO.DateInicioEx);
                command.Parameters.AddWithValue("@DateFinalizouEx", ExperienciaDTO.DateFinalizouEx);
                command.Parameters.AddWithValue("@FkProfissionalEx", ExperienciaDTO.FkProfissionalEx);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Editar Experiencia!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Delete
        public void Excluir(int idProfissional, int objExclui)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM tb_experiencia WHERE  Id_Experiencia=@v1 and FK_profissional_ex=@v2", conn);
                cmd.Parameters.AddWithValue("@v2", idProfissional);
                cmd.Parameters.AddWithValue("@v1", objExclui);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Excluir Experiencia!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        

        //Selecionar ID
        public ExperienciaDTO SelecionarExperienciaPorId(int idExperiencia)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM tb_experiencia WHERE id_experiencia = @IdExperiencia", conn);
                cmd.Parameters.AddWithValue("@IdExperiencia", idExperiencia);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    ExperienciaDTO experiencia = new ExperienciaDTO
                    {
                        IdExperiencia = Convert.ToInt32(dr["id_experiencia"]),
                        NomeCargoEx = dr["nome_cargo_EX"].ToString(),
                        NomeEmpresaEx = dr["nome_empresa_EX"].ToString(),
                        DateTimeInsertEx = Convert.ToDateTime(dr["date_time_insert_EX"]),
                        TipoContratoEx = dr["tipo_contrato_EX"].ToString(),
                        DescricaoEx = dr["descricao_EX"].ToString(),
                        DateInicioEx = Convert.ToDateTime(dr["date_inicio_EX"]),
                        DateFinalizouEx = Convert.ToDateTime(dr["date_finalizou_EX"]),
                        FkProfissionalEx = Convert.ToInt32(dr["fk_profissional_EX"])
                    };

                    return experiencia;
                }
                return null;

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar Experiencia" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
       
         

    }
}
