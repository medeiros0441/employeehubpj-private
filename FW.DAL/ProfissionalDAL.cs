using FW.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace FW.DAL
{
    public class ProfissionalDAL : Conexao
    {
        readonly DateTime Data_Hora = DATA_HORA_BR.Data_Hora;
       
        //inserir - create
        public int Cadastrar(ProfissionalDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO tb_Profissional(fk_tipouser_PF, date_time_insert_PF , date_time_privacidade_PF, date_time_termos_PF) VALUES(@fk_tipouser_PF,@date_time_insert_PF,@date_time_privacidade_PF,@date_time_termos_PF);  SELECT SCOPE_IDENTITY()", conn);
                cmd.Parameters.AddWithValue("@date_time_insert_PF", objCad.DateTimeInsertPf = Data_Hora);
                cmd.Parameters.AddWithValue("@date_time_termos_PF", objCad.DateTimeTermosPf = Data_Hora);
                cmd.Parameters.AddWithValue("@date_time_privacidade_PF", objCad.DateTimePrivacidadePf = Data_Hora);
                cmd.Parameters.AddWithValue("@fk_tipouser_PF", objCad.FkTipouserPf);
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                return id;
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
         
        public List<ProfissionalDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand($"SELECT {dados_basico}, id_profissional,formacao_escolar_PF,fk_tipouser_PF,caminho_doc_curriculo_PF date_time_update_PF FROM  tb_Profissional  as p left join tb_tipouser as t  on t.id_tipouser=p.fk_tipouser_PF left join TB_CLIENTE as c  on c.ID_CLIENTE= t.Fk_cliente_TU    order by primeironome_cl", conn);
                dr = cmd.ExecuteReader();

                List<ProfissionalDTO> Lista = new List<ProfissionalDTO>();
                 return Lista = ListInsereDTO<ProfissionalDTO>( dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Profissional!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
       


        public ProfissionalDTO Autentica_IDCliente(int ID_Cliente)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand($" select {dados_basico}, id_profissional,formacao_escolar_PF,fk_tipouser_PF,caminho_doc_curriculo_PF date_time_update_PF FROM  tb_Profissional  as p left join tb_tipouser as t  on t.id_tipouser=p.fk_tipouser_PF left join TB_CLIENTE as c  on c.ID_CLIENTE= t.Fk_cliente_TU WHERE  fk_cliente=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", ID_Cliente);
                dr = cmd.ExecuteReader();

                ProfissionalDTO obj = new ProfissionalDTO();
                return obj = InsereDTO<ProfissionalDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Autenticar User!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        } 

        public ProfissionalDTO SelecionarIdProfissional(int IdProfissional)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand($"SELECT  {dados_basico},{dados_endereco}, id_profissional,formacao_escolar_PF,fk_tipouser_PF,caminho_doc_curriculo_PF, date_time_update_PF FROM  tb_Profissional  as p left join tb_tipouser as t  on t.id_tipouser=p.fk_tipouser_PF left join TB_CLIENTE as c  on c.ID_CLIENTE= t.Fk_cliente_TU WHERE  ID_Profissional=@ID_Profissional", conn);
                cmd.Parameters.AddWithValue("@ID_Profissional", IdProfissional);
                dr = cmd.ExecuteReader();


                ProfissionalDTO obj = new ProfissionalDTO();
                    return obj = InsereDTO<ProfissionalDTO>(dr);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar Profissional" + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }
        public ProfissionalDTO Select_Profissional_IdCliente(int IdCliente)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand($"SELECT  {dados_basico},{dados_endereco}, id_profissional,formacao_escolar_PF,fk_tipouser_PF,caminho_doc_curriculo_PF, date_time_update_PF FROM  tb_Profissional  as p left join tb_tipouser as t  on t.id_tipouser=p.fk_tipouser_PF left join TB_CLIENTE as c  on c.ID_CLIENTE= t.Fk_cliente_TU WHERE  Fk_cliente_TU=@Fk_cliente_TU", conn);
                cmd.Parameters.AddWithValue("@Fk_cliente_TU", IdCliente);
                dr = cmd.ExecuteReader();


                ProfissionalDTO obj = new ProfissionalDTO();
                return obj = InsereDTO<ProfissionalDTO>(dr);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar Profissional" + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

        public void Editar_FormacaoEscolar_CaminhoCurriculo(ProfissionalDTO objEdita)
        {
         
            try
            {
                Conectar();
                string queryString = "update tb_profissional set";
                    
              if (objEdita.FormacaoEscolarPf != null) {
                    queryString += " formacao_escolar_PF ='" + objEdita.FormacaoEscolarPf + "'," ;
                }

                if (objEdita.CaminhoDocCurriculoPf != null)
                {
                    queryString += " caminho_doc_curriculo_PF='" + objEdita.CaminhoDocCurriculoPf + "',";
                }
                cmd = new SqlCommand(queryString + "date_time_update_PF = @date_time_update_PF from TB_profissional as P    where id_profissional = @id_profissional", conn);

                cmd.Parameters.AddWithValue("@id_profissional", objEdita.IdProfissional);
                cmd.Parameters.AddWithValue("@date_time_update_PF", objEdita.DateTimeUpdatePf = Data_Hora);
             
                cmd.ExecuteNonQuery();

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
     
           
        
        // pesquisa 
        public List<ProfissionalDTO> Pesquisa_profissional(ProfissionalDTO ProfissionalDTO)
        {
            try
            {
                Conectar();
                string queryString = $"select {dados_basico} from tb_Profissional as P inner join TB_Tipouser as T on P.fk_tipouser_PF = T.ID_TIPOUSER left join tb_cliente as C on T.Fk_cliente_TU = c.ID_Cliente left join tb_cliente_status_adm as CSA on  CSA.fk_cliente_CLA = c.id_cliente where status_cl=1  ";

                if (ProfissionalDTO.PrimeiroNomeCl != null)
                {
                    queryString += "and primeironome_CL like'%" + ProfissionalDTO.PrimeiroNomeCl + "%'";

                }
                if (ProfissionalDTO.SobrenomeCl  != null)
                {
                    queryString += "and sobrenome_cl like'%" + ProfissionalDTO.SobrenomeCl + "%'";

                }
                if (ProfissionalDTO.UsuarioCl != null)
                {

                    queryString += " and usuario_CL like'%" + ProfissionalDTO.UsuarioCl + "%'";
                }
                if (ProfissionalDTO.FormacaoEscolarPf != null)
                {

                    queryString += " and formacao_escolar_PF='" + ProfissionalDTO.FormacaoEscolarPf + "'";

                }
                if (ProfissionalDTO.SexoCl != null)
                {

                    queryString += " and sexo_CL='" + ProfissionalDTO.SexoCl + "'";
                }
                if (ProfissionalDTO.DescricaoEstadoCl != null)
                {
                    queryString += "   and descricao_estado_cl = '" + ProfissionalDTO.DescricaoEstadoCl + "'";

                }
                if (ProfissionalDTO.DescricaoCidadeCl != null)
                {
                    queryString += "   and descricao_cidade_cl = '" + ProfissionalDTO.DescricaoCidadeCl + "'";
                }
                queryString += " order by  C.date_time_update_cl desc, C.primeironome_Cl";
                cmd = new SqlCommand(queryString, conn);

                dr = cmd.ExecuteReader();
                List<ProfissionalDTO> Lista = new List<ProfissionalDTO>();
                return Lista = ListInsereDTO<ProfissionalDTO>(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Profissional!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }
    }
}
