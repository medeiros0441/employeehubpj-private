using System.Data.SqlClient;
using FW.DTO;
using System;
using System.Collections.Generic;

namespace FW.DAL
{
    public class CandidatoDAL : Conexao
    {

        //inserir - create
        public void CadastrarVP(CandidatoDTO CandidatoDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO tb_Candidato (fk_profissional_CT,date_time_insert_CT ,fk_vaga_CT,status_CT) VALUES (@v1,@v2,@v3,@v4);", conn);
                cmd.Parameters.AddWithValue("@v1", CandidatoDTO.FkProfissionalCt);
                cmd.Parameters.AddWithValue("@v2", CandidatoDTO.DateTimeInsertCt = DataHoraAtual);
                cmd.Parameters.AddWithValue("@v3", CandidatoDTO.FkVagaCt);
                cmd.Parameters.AddWithValue("@v4", Convert.ToByte(true));


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

        //Listar
        public List<CandidatoDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM tb_Candidato ORDER BY date_time_update_ct desc", conn);
                dr = cmd.ExecuteReader();
                List<CandidatoDTO> Lista = new List<CandidatoDTO>();
                return Lista = ListInsereDTO<CandidatoDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Candidatos!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //Listar
        public List<CandidatoDTO> Listar_IdProfissional(int IdProfissional)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM tb_Candidato where fk_profissional_ct=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", IdProfissional);

                dr = cmd.ExecuteReader();
                List<CandidatoDTO> Lista = new List<CandidatoDTO>();
                return Lista = ListInsereDTO<CandidatoDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Candidatos!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Selecionar
        public List<CandidatoDTO> Lista_Candidato_Profissional(int idprofissional)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand(" SELECT "+ colunas_candidato + "," + colunas_empresa + "," + colunas_tipouser + " FROM tb_Candidato as CT" +
                    "join TB_Profissional as P on P.ID_Profissional = CT.fk_profissional_CT " + 
                    "join TB_VAGA as V on Id_Vaga= CT.FK_Vaga_CT " +
                    "join Tb_Vaga_Status_ADM as VS on VS.fk_vaga_VSA = V.ID_vaga" +
                    "join TB_empresa as E on V.fk_empresa_VG=ID_Empresa join Tb_Tipouser as T_E on T_E.ID_TipoUser = E.fk_Tipouser_EP "+
                    "join TB_CLIENTE as E_C on E_C.ID_CLIENTE = T_E.Fk_cliente_TU  WHERE   CT.FK_Profissional_ct=@FK_Profissional and CT.status_Ct=@status_ct and VS.status_VSA=@status_vsa ", conn);
                cmd.Parameters.AddWithValue("@FK_Profissional", idprofissional);
                cmd.Parameters.AddWithValue("@status_ct", Convert.ToByte(true));
                cmd.Parameters.AddWithValue("@status_vsa", Convert.ToByte(true));
                dr = cmd.ExecuteReader();
                List<CandidatoDTO> Lista = new List<CandidatoDTO>();
                return Lista = ListInsereDTO<CandidatoDTO>(dr);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar Candidatura" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //Selecionar
        public CandidatoDTO AutenticandoVeP(int idVaga, int idProfissional)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT ID_Candidato,FK_profissional_ct,Fk_vaga_ct,ct.status_ct,V.Fk_empresa_Vg FROM tb_Candidato as CT" +
                    " join TB_Profissional as P on P.ID_Profissional = ct.fk_profissional_ct " +
                    "join TB_VAGA as V on Id_Vaga = CT.FK_Vaga_ct " +
                    "join TB_empresa as E on V.fk_empresa_VG = E.ID_Empresa join Tb_Tipouser as T_E on T_E.ID_TipoUser = E.fk_Tipouser_EP "+
                    "join TB_CLIENTE as E_C on E_C.ID_CLIENTE = T_E.Fk_cliente_TU  where fk_vaga_CT=@v1 and FK_Profissional_CT=@v2", conn);
                cmd.Parameters.AddWithValue("@v1", idVaga);
                cmd.Parameters.AddWithValue("@v2", idProfissional);
                dr = cmd.ExecuteReader();

                CandidatoDTO obj = new CandidatoDTO();
                return obj = InsereDTO<CandidatoDTO>(dr);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar Profissional " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //Delete
        public void Excluir(int objExclui, int idprofissional)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM tb_Candidato WHERE FK_Profissional_CT=@v2 and FK_vaga_CT=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", objExclui);
                cmd.Parameters.AddWithValue("@v2", idprofissional);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Excluir Candidatura!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        } //alterandoStatus
        public void AtualizarStatusCandidatura(int id_vaga, int id_profissional, bool status)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("update tb_Candidato set status_CT=@v3, date_time_update_ct=@v4 where FK_Profissional_ct=@v2 and FK_vaga_CT=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", id_vaga);
                cmd.Parameters.AddWithValue("@v2", id_profissional);
                cmd.Parameters.AddWithValue("@v3", Convert.ToByte(status));
                cmd.Parameters.AddWithValue("@v4", DataHoraAtual);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar Status da Candidatura!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }


        //Filtrar
        public List<CandidatoDTO> Filtrar(int ID_Vaga)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM tb_Candidato" +
                   " join TB_VAGA as V on Id_Vaga = CT.FK_Vaga_CT  where FK_vaga_ct = @v1 ORDER BY CT.date_time_update_CT desc", conn);
                cmd.Parameters.AddWithValue("@v1", ID_Vaga);
                dr = cmd.ExecuteReader();
                List<CandidatoDTO> Lista = new List<CandidatoDTO>();
                return Lista = ListInsereDTO<CandidatoDTO>(dr);
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

        //Listar 
        public List<CandidatoDTO>ListCantdidaturaProfissional(int ID_profissiona)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand(" SELECT " + colunas_candidato + "," + colunas_vaga + "," + colunas_empresa + "," + colunas_vaga + "," + colunas_tipouser + " FROM tb_Candidato as Ct  " +
                    
                    "join TB_VAGA as V on Id_Vaga= CT.FK_Vaga_CT "+
                    "join Tb_Vaga_Status_ADM as VS on VS.fk_vaga_VSA = V.ID_vaga "+
                    "join TB_empresa as E on V.fk_empresa_VG=ID_Empresa " +
                    "join tb_tipouser as  T_E on T_E.id_Tipouser = E.fk_tipouser_EP " +
                    "WHERE   CT.FK_Profissional_ct=@FK_Profissional and CT.status_Ct=@status_ct and VS.status_VSA=@status_vsa", conn);
                cmd.Parameters.AddWithValue("@FK_Profissional", ID_profissiona);
                cmd.Parameters.AddWithValue("@status_vsa", Convert.ToByte(true));
                cmd.Parameters.AddWithValue("@status_ct", Convert.ToByte(true));
                dr = cmd.ExecuteReader();
                List<CandidatoDTO> Lista = new List<CandidatoDTO>();
                return Lista = ListInsereDTO<CandidatoDTO>(dr);
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


        public List<CandidatoDTO> List_Candidato_Empresa_IDVAGA(CandidatoDTO CandidatoDTO)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT VG.status_vg, CT.FK_Profissional_CT, VG.nome_vg,P_C.ID_cliente,P_C.Primeironome_cl,P_C.status_verificacao_Cl,PF.caminho_doc_curriculo_PF,CT.fk_vaga_CT " +
                    " FROM tb_Candidato as CT   " +
                    "join TB_VAGA as VG on Id_Vaga= CT.FK_Vaga_CT join Tb_Profissional as PF on PF.ID_profissional=CT.fk_profissional_CT  " +
                    "join TB_Tipouser as P_T on P_T.ID_TIPOUSER= PF.fk_tipouser_PF  Join Tb_cliente as P_C on  P_C.ID_Cliente=P_T.FK_Cliente_TU" +
                    "  join TB_Empresa as EP on EP.ID_Empresa = VG.fk_empresa_VG join TB_Tipouser as E_T on E_T.ID_TIPOUSER = EP.fk_tipouser_EP" +
                    "  join Tb_Vaga_Status_ADM as VSA on fk_vaga_VSA = VG.ID_vaga  join TB_CLIENTE as E_C on E_C.ID_CLIENTE = E_T.Fk_cliente_TU  " +
                    "where  VG.Fk_empresa_vg=@FK_empresa and CT.status_CT=@Status and VSA.status_VSA=@Status_VSA " + (CandidatoDTO.FkVagaCt != 0 ? " AND CT.Fk_Vaga_CT=@Fk_Vaga_CT " : " " ) +  " ORDER BY CT.date_time_update_CT desc;", conn);
                cmd.Parameters.AddWithValue("@FK_empresa", CandidatoDTO.FkEmpresaVg);
                cmd.Parameters.AddWithValue("@Status_VSA", Convert.ToByte(true));
                cmd.Parameters.AddWithValue("@Status", Convert.ToByte(true));
                if (CandidatoDTO.FkVagaCt != 0)
                {
                    cmd.Parameters.AddWithValue("@Fk_Vaga_CT", CandidatoDTO.FkVagaCt);
                }
                dr = cmd.ExecuteReader();
                List<CandidatoDTO> Lista = new List<CandidatoDTO>();
                return Lista = ListInsereDTO<CandidatoDTO>(dr);
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
