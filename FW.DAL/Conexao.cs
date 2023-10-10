using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using FW.DTO;
 
namespace FW.DAL
{ 
    public static class DATA_HORA_BR
    {
        private static readonly TimeZoneInfo _timeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        public static DateTime Data_Hora => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _timeZone);
        public static DateTime Data => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _timeZone).Date;
        public static TimeSpan Hora => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _timeZone).TimeOfDay;
    }

     
    public class Conexao
    {
        public DateTime DataHoraAtual => DATA_HORA_BR.Data_Hora;
        


        protected string dados_endereco = "id_cliente,descricao_rua_CL, numero_casa_CL , descricao_complemento_CL , numero_cep_CL  , descricao_bairro_CL, descricao_cidade_CL, descricao_estado_CL";
        protected string dados_basico = "id_cliente,nome_completo_cl,primeironome_CL, sobrenome_CL, usuario_CL,data_Nascimento_CL, sexo_CL,caminho_foto_CL,status_CL,status_verificacao_CL,biografia_cl";
        protected string dados_senciveis = "id_cliente,email_CL,senha_cl,numero_telefone_cl,date_time_insert_cl,date_time_update_cl,nro_cpf_cl,saldo_atual_cl";





        //variaveis
        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataReader dr;

        //metodos
        protected SqlConnection Conectar()
        {
            try
            {
               // string   Local_BD = @"Data Source=(localdb)\MSSQLLocalDB;user id= desk_home\medei;Initial Catalog=chateau_local;Connect Timeout=30;persist security info=False";
              string   Somee_BD = @"workstation id=BDTemporario.mssql.somee.com;packet size=4096;user id=medeiros0441_SQLLogin_1;pwd=pqj6fw5pvi;data source=BDTemporario.mssql.somee.com;persist security info=False;initial catalog=BDTemporario";
                 conn = new SqlConnection(Somee_BD);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void Desconectar()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        



        public T InsereDTO<T>(SqlDataReader dr) where T : new()
        {

            // Define um dicionário para mapear as colunas do banco de dados com as propriedades do DTO
            Dictionary<string, string> columnMappings = Coluna_Propriedade();
            T dto = new T();
            if (dr.Read())
            {
                // Loop através das colunas no SqlDataReader
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    // Obtém o nome da coluna atual
                    string columnName = dr.GetName(i);

                    // Verifica se a coluna atual está mapeada
                    if (columnMappings.ContainsKey(columnName.ToLower()))
                    {
                        // Obtém o nome da propriedade correspondente usando o mapeamento de coluna
                        string propertyName = columnMappings[columnName.ToLower()];

                        // Obtém a propriedade correspondente no DTO usando o nome da propriedade
                        PropertyInfo property = typeof(T).GetProperty(propertyName);

                        // Verifica se a propriedade foi encontrada e se o valor da coluna não é nulo
                        if (property != null && dr.IsDBNull(i) == false)
                        {
                            // Converte o valor da coluna para o tipo da propriedade e define o valor da propriedade no DTO
                            SetPropertyValueFromDatabase(dto, property, dr[i]);


                        }
                    }
                }
            }
            // Retorna o DTO preenchido com os dados lidos do SqlDataReader
            return dto;
        }

        public List<T> ListInsereDTO<T>(SqlDataReader dr) where T : new()
        {
            // Define um dicionário para mapear as colunas do banco de dados com as propriedades do DTO
            Dictionary<string, string> columnMappings = Coluna_Propriedade();

            List<T> listaDTO = new List<T>();

            while (dr.Read())
            {
                T dto = new T();

                for (int i = 0; i < dr.FieldCount; i++)
                {
                    // Obtém o nome da coluna atual converter o nome da coluna para minusculo assim cono o dicionario retorna a key minusculo
                    string columnName = dr.GetName(i).ToLower();

                    // Verifica se a coluna atual está mapeada
                    if (columnMappings.ContainsKey(columnName))
                    {
                        // Obtém o nome da propriedade correspondente usando o mapeamento de coluna
                        string propertyName = columnMappings[columnName];

                        // Obtém a propriedade correspondente no DTO usando o nome da propriedade
                        PropertyInfo property = typeof(T).GetProperty(propertyName);

                        // Verifica se a propriedade foi encontrada e se o valor da coluna não é nulo
                        if (property != null && dr.IsDBNull(i) == false)
                        {
                            // Converte o valor da coluna para o tipo da propriedade e define o valor da propriedade no DTO
                            SetPropertyValueFromDatabase(dto, property, dr[i]);
                        }
                    }
                }

                listaDTO.Add(dto);
            }

            // Retorna a lista de DTOs preenchidos com os dados lidos do SqlDataReader
            return listaDTO;
        }
        private void SetPropertyValueFromDatabase<T>(T dto, PropertyInfo property, object databaseValue)
        {
            if (property.PropertyType == typeof(bool))
            {
                // Conversão para bool
                bool.TryParse(databaseValue.ToString(), out bool parsedValue);
                property.SetValue(dto, parsedValue);
            }
            else if (property.PropertyType == typeof(DateTime))
            {
                // Conversão para DateTime
                DateTime.TryParse(databaseValue.ToString(), out DateTime parsedValue);
                property.SetValue(dto, parsedValue);
            }
            else if (property.PropertyType == typeof(DateTime?))
            {
                // Conversão para Nullable<DateTime>
                DateTime? parsedValue = null;

                // Verifica se o valor do banco não é nulo
                if (!Convert.IsDBNull(databaseValue))
                {

                    // Tenta converter o valor do banco para DateTime
                    if (DateTime.TryParse(databaseValue.ToString(), out DateTime tempValue))
                    {
                        parsedValue = tempValue;
                    }
                }

                property.SetValue(dto, parsedValue);
            }
            else
            {
                // Outros tipos de conversão

                // Converte o valor do banco para o tipo da propriedade usando Convert.ChangeType
                property.SetValue(dto, Convert.ChangeType(databaseValue, property.PropertyType));
            }
        }


        // Adiciona parâmetros a partir de um DTO para um SqlCommand e retorna o SqlCommand
        // T é o tipo do DTO
        public SqlCommand AddParamsFromDTO<T>(SqlCommand cmd, T dto) where T : class
        {
            // Obtém o mapeamento entre nome das colunas e nome das propriedades do DTO
            Dictionary<string, string> columnMappings = Coluna_Propriedade();

            // Obtém as propriedades do DTO
            PropertyInfo[] properties = typeof(T).GetProperties();

            // Itera por todas as colunas do mapeamento
            foreach (var mapping in columnMappings)
            {
                // Obtém o nome da coluna e o nome da propriedade do DTO
                string columnName = mapping.Key;
                string propName = mapping.Value;

                // Verifica se a propriedade do DTO existe
                if (properties.Any(prop => prop.Name == propName))
                {
                    // Define o nome do parâmetro com base no nome da coluna
                    string paramName = "@" + columnName;

                    // Verifica se o SqlCommand contém o parâmetro
                    if (cmd.Parameters.Contains(paramName))
                    {
                        // Obtém a propriedade do DTO
                        PropertyInfo prop = properties.First(p => p.Name == propName);

                        // Obtém o valor da propriedade do DTO
                        object propValue = prop.GetValue(dto);

                        // Verifica se o valor da propriedade não é nulo
                        if (propValue != null)
                        {
                            // Verifica se a propriedade é um bool
                            if (prop.PropertyType == typeof(bool))
                            {
                                // Adiciona o valor 1 ou 0 para o parâmetro de bool
                                cmd.Parameters.AddWithValue(paramName, Convert.ToByte(propValue));
                            }
                            else
                            {
                                // Adiciona o valor da propriedade para o parâmetro
                                cmd.Parameters.AddWithValue(paramName, propValue);
                            }
                        }
                    }
                }
            }
            return cmd;
        }

            public readonly string colunas_sessao = "ID_sessao, ip_cliente_SS, navegador_SS, status_SS, date_time_insert_SS, date_time_update_SS, time_online_SS, iniciou_SS, finalizou_SS";
            public readonly string colunas_log = "id_log, date_time_insert_LG, date_time_update_LG, descricao_LG, descricao_sistema_LG, nivel_gravidade_LG, dados_adicionais_LG, fk_sessao_LG";
            public readonly string colunas_cliente = "id_cliente, nome_completo_CL, primeironome_CL, sobrenome_CL, email_CL, usuario_CL, senha_CL, data_Nascimento_CL, numero_telefone_CL, sexo_CL, descricao_rua_CL, numero_casa_CL, descricao_complemento_CL, numero_cep_CL, descricao_bairro_CL, descricao_cidade_CL, descricao_estado_CL, caminho_foto_CL, status_CL, date_time_insert_CL, date_time_update_CL, nro_cpf_CL, biografia_CL, status_verificacao_CL, saldo_atual_CL";
            public readonly string colunas_cliente_google = "id_cliente_google, id_email_GL, nome_completo_GL, primeironome_GL, sobrenome_GL, email_GL, fk_cliente_GL, date_time_insert_GL, date_time_update_GL";
            public readonly string colunas_visita = "id_visita, fk_cliente_VS, fk_sessao_VS, date_time_insert_VS, date_time_update_VS, time_view_VS, time_iniciou_VS, time_finalizou_VS";
            public readonly string colunas_visualizacao = "id_visualizacao, fk_visita_VZ, fk_cliente_VZ, date_time_insert_VZ, date_time_update_VZ, time_view_VZ";
            public readonly string colunas_acesso = "id_acesso, fk_cliente_AS, fk_sessao_AS, date_time_insert_AS, date_time_update_AS, tempo_view_AS";
            public readonly string colunas_rede_social = "ID_rede, link_rede_RS, descricao_rede_RS, date_time_insert_RS, date_time_update_RS, FK_Cliente_RS";
            public readonly string colunas_notificacao = "id_notificacao, titulo_NC, date_time_insert_NC, date_time_update_NC, mensagem_NC, fk_cliente_NC, visibilidade_NC";
            public readonly string colunas_historico = "id_historico, descricao_HT, date_time_insert_HT, date_time_update_HT, fk_cliente_HT";
            public readonly string colunas_cliente_administrador = "id_cliente_CLA, status_adm_CLA, data_time_insert_CLA, data_time_update_CLA, descricao_CLA, fk_cliente_CLA";
            public readonly string colunas_pagamento = "id_pagamento, valor_PG, tipo_pagamento_PG, nome_produto_PG, qrcodepix_PG, img_qrcodebase64_PG, paymentid_PG, status_PG, date_time_insert_PG, date_time_update_PG, fk_cliente_PG";
            public readonly string colunas_saldo = "id_saldo, saldo_atual_GS, saldo_anterior_GS, date_time_insert_GS, date_time_update_GS, descricao_GS, fk_cliente_GS, fk_pagamento_GS";
            public readonly string colunas_publicacao = "id_publicacao, FK_cliente_PB, date_time_insert_PB, date_time_update_PB, descricao_PB, URL_imagen1_PB, URL_imagen2_PB, URL_imagen3_PB, URL_Video1_PB, URL_Video2_PB";
            public readonly string colunas_comentario = "id_comentario_CM, date_time_insert_CM, date_time_update_CM, comentario_CM, FK_publicacao_CM, FK_Cliente_CM";
            public readonly string colunas_tipouser = "id_tipouser, descricao_TU, codigo_TU, Status_TU, Fk_cliente_TU, date_time_insert_TU, date_time_update_TU";
            public readonly string colunas_empresa = "id_empresa, numero_cnpj_EP, nome_fantasia_EP, razao_social_EP, date_time_termos_EP, date_time_privacidade_EP, date_time_insert_EP, date_time_update_EP, date_abertura_EP, fk_tipouser_EP";
            public readonly string colunas_vaga = "id_vaga, nome_VG, tempo_experiencia_VG, tipo_registro_VG, descricao_VG, sexo_VG, descricao_validade_VG, date_time_insert_VG, date_time_update_VG, status_VG, fk_empresa_VG,tipovaga_vg";
            public readonly string colunas_vaga_status = "id_status_VSA, status_VSA, descricao_VSA, date_time_insert_VSA, date_time_update_VSA, fk_vaga_VSA";
            public readonly string colunas_visita_vaga = "id_visita_VGA, fk_vaga_VGA, fk_profissional_VGA,date_time_insert_VGA, date_time_update_VGA, time_view_VGA";
            public readonly string colunas_profissional = "id_profissional, formacao_escolar_PF, fk_tipouser_PF, date_time_insert_PF, date_time_update_PF, caminho_doc_curriculo_PF, date_time_privacidade_PF, date_time_termos_PF";
            public readonly string colunas_candidato = "id_candidato, fk_profissional_CT, date_time_insert_CT, date_time_update_CT, fk_vaga_CT, status_CT";
            public readonly string colunas_consumo = "id_consumo, fk_empresa_CS, fk_profissional_CS, fk_sessao_CS, date_time_insert_CS, date_time_update_CS, tempo_view_CS, valor_descontado_CS";
            public readonly string colunas_certificado = "id_certificado_CF, nome_curso_CF,nome_instituicao_CF,descricao_CF,date_time_insert_CF,date_time_update_CF,date_inicio_CF, date_finalizou_CF, fk_Profissional_CF";
            public readonly string colunas_experiencia = "  id_experiencia, nome_cargo_EX, nome_empresa_EX, date_time_insert_EX, date_time_update_EX, tipo_contrato_EX, descricao_EX, date_inicio_EX, date_finalizou_EX, fk_profissional_EX";

        protected Dictionary<string, string> Coluna_Propriedade()
        {
            Dictionary<string, string> columnToPropertyMap = new Dictionary<string, string>
                {
                //sessao
                {"ID_sessao", "IdSessao"},
                {"ip_cliente_SS", "IpClienteSs"},
                {"navegador_SS", "NavegadorSs"},
                {"status_SS", "StatusSs"},
                {"date_time_insert_SS", "DateTimeInsertSs"},
                {"date_time_update_SS", "DateTimeUpdateSs"},
                {"time_online_SS", "TimeOnlineSs"},
                {"iniciou_SS", "IniciouSs"},
                {"finalizou_SS", "FinalizouSs"},
                // log
                {"id_log", "IdLog"},
                {"date_time_insert_LG", "DateTimeInsertLg"},
                {"date_time_update_LG", "DateTimeUpdateLg"},
                {"descricao_LG", "DescricaoLg"},
                {"descricao_sistema_LG", "DescricaoSistemaLg"},
                {"nivel_gravidade_LG", "NivelGravidadeLg"},
                {"dados_adicionais_LG", "DadosAdicionaisLg"},
                {"fk_sessao_LG", "FkSessaoLg"},
                //cliente
                {"id_cliente", "IdCliente"},
                {"nome_completo_CL", "NomeCompletoCl"},
                {"primeironome_CL", "PrimeiroNomeCl"},
                {"sobrenome_CL", "SobrenomeCl"},
                {"email_CL", "EmailCl"},
                {"usuario_CL", "UsuarioCl"},
                {"senha_CL", "SenhaCl"},
                {"data_Nascimento_CL", "DataNascimentoCl"},
                {"numero_telefone_CL", "NumeroTelefoneCl"},
                {"sexo_CL", "SexoCl"},
                {"descricao_rua_CL", "DescricaoRuaCl"},
                {"numero_casa_CL", "NumeroCasaCl"},
                {"descricao_complemento_CL", "DescricaoComplementoCl"},
                {"numero_cep_CL", "NumeroCepCl"},
                {"descricao_bairro_CL", "DescricaoBairroCl"},
                {"descricao_cidade_CL", "DescricaoCidadeCl"},
                {"descricao_estado_CL", "DescricaoEstadoCl"},
                {"caminho_foto_CL", "CaminhoFotoCl"},
                {"status_CL", "StatusCl"},
                {"date_time_insert_CL", "DateTimeInsertCl"},
                {"date_time_update_CL", "DateTimeUpdateCl"},
                {"nro_cpf_CL", "NroCpfCl"},
                {"biografia_CL", "BiografiaCl"},
                {"status_verificacao_CL", "StatusVerificacaoCl"},
                {"saldo_atual_CL", "SaldoAtualCl"},

                //google
                {"id_cliente_google", "IdClienteGoogle"},
                {"id_email_GL", "IdEmailGl"},
                {"nome_completo_GL", "NomeCompletoGl"},
                {"primeironome_GL", "PrimeiroNomeGl"},
                {"sobrenome_GL", "SobrenomeGl"},
                {"email_GL", "EmailGl"},
                {"fk_cliente_GL", "FkClienteGl"},
                {"date_time_insert_GL", "DateTimeInsertGl"},
                {"date_time_update_GL", "DateTimeUpdateGl"},

                //visita
                 {"id_visita", "IdVisita"},
                {"fk_cliente_VS", "FkClienteVs"},
                {"fk_sessao_VS", "FkSessaoVs"},
                {"date_time_insert_VS", "DateTimeInsertVs"},
                {"date_time_update_VS", "DateTimeUpdateVs"},
                {"time_view_VS", "TimeViewVs"},
                {"time_iniciou_VS", "TimeIniciouVs"},
                {"time_finalizou_VS", "TimeFinalizouVs"},
                //VISUALIZACAO 
                {"id_visualizacao", "IdVisualizacao"},
                {"fk_visita_VZ", "FkVisitaVz"},
                {"fk_cliente_VZ", "FkClienteVz"},
                {"date_time_insert_VZ", "DateTimeInsertVz"},
                {"date_time_update_VZ", "DateTimeUpdateVz"},
                {"time_view_VZ", "TimeViewVz"},
                //acesso 
                {"id_acesso", "IdAcesso"},
                {"fk_cliente_AS", "FkClienteAs"},
                {"fk_sessao_AS", "FkSessaoAs"},
                {"date_time_insert_AS", "DateTimeInsertAs"},
                {"date_time_update_AS", "DateTimeUpdateAs"},
                {"tempo_view_AS", "TempoViewAs"},
                 
                //rede social
                { "ID_rede", "IdRede" },
                { "link_rede_RS", "LinkRedeRs" },
                { "descricao_rede_RS", "DescricaoRedeRs" },
                { "date_time_insert_RS", "DateTimeInsertRs" },
                { "date_time_update_RS", "DateTimeUpdateRs" },
                { "FK_Cliente_RS", "FkClienteRs" },
                //notificacao
                { "id_notificacao", "IdNotificacao" },
                { "titulo_NC", "TituloNc" },
                { "date_time_insert_NC", "DateTimeInsertNc" },
                { "date_time_update_NC", "DateTimeUpdateNc" },
                { "mensagem_NC", "MensagemNc" },
                { "fk_cliente_NC", "FkClienteNc" },
                { "visibilidade_NC", "VisibilidadeNc" },
                //cliente status adm
                { "id_cliente_CLA", "IdCliente" },
                { "status_adm_CLA", "StatusAdmCla" },
                { "data_time_insert_CLA", "DateTimeInsertCla" },
                { "data_time_update_CLA", "DateTimeUpdateCla" },
                { "descricao_CLA", "DescricaoCla" },
                { "fk_cliente_CLA", "FkClienteCla" },
                //pagamento
                { "id_pagamento", "IdPagamento" },
                { "valor_PG", "ValorPg" },
                { "tipo_pagamento_PG", "TipoPagamentoPg" },
                { "nome_produto_PG", "NomeProdutoPg" },
                { "qrcodepix_PG", "QrcodepixPg" },
                { "img_qrcodebase64_PG", "ImgQrcodebase64Pg" },
                { "paymentid_PG", "PaymentidPg" },
                { "status_PG", "StatusPg" },
                { "date_time_insert_PG", "DateTimeInsertPg" },
                { "date_time_update_PG", "DateTimeUpdatePg" },
                { "fk_cliente_PG", "FkClientePg" },
                //gerenciamento saldo   
                { "id_saldo", "IdSaldo" },
                { "saldo_atual_GS", "SaldoAtualGs" },
                { "saldo_anterior_GS", "SaldoAnteriorGs" },
                { "date_time_insert_GS", "DateTimeInsertGs" },
                { "date_time_update_GS", "DateTimeUpdateGs" },
                { "descricao_GS", "DescricaoGs" },
                { "fk_cliente_GS", "FkClienteGs" },
                { "fk_pagamento_GS", "FkPagamentoGs" },
               //historico
                { "id_historico", "IdHistorico" },
                { "descricao_HT", "DescricaoHt" },
                { "date_time_insert_HT", "DateTimeInsertHt" },
                { "date_time_update_HT", "DateTimeUpdateHt" },
                { "fk_cliente_HT", "FkClienteHt" },
                //publicacao
                { "id_publicacao", "IdPublicacao" },
                { "FK_cliente_PB", "FkClientePb" },
                { "date_time_insert_PB", "DateTimeInsertPb" },
                { "date_time_update_PB", "DateTimeUpdatePb" },
                { "descricao_PB", "DescricaoPb" },
                { "URL_imagen1_PB", "UrlImagen1Pb" },
                { "URL_imagen2_PB", "UrlImagen2Pb" },
                { "URL_imagen3_PB", "UrlImagen3Pb" },
                { "URL_Video1_PB", "UrlVideo1Pb" },
                { "URL_Video2_PB", "UrlVideo2Pb" },
                //tipouser
                { "id_tipouser", "IdTipouser" },
                { "descricao_TU", "DescricaoTu" },
                { "codigo_TU", "CodigoTu" },
                { "Status_TU", "StatusTu" },
                { "Fk_cliente_TU", "FkClienteTu" },
                { "date_time_insert_TU", "DateTimeInsertTu" },
                { "date_time_update_TU", "DateTimeUpdateTu" },
                // empresa
                { "id_empresa", "IdEmpresa" },
                { "numero_cnpj_EP", "NumeroCnpjEp" },
                { "nome_fantasia_EP", "NomeFantasiaEp" },
                { "razao_social_EP", "RazaoSocialEp" },
                { "date_time_termos_EP", "DateTimeTermosEp" },
                { "date_time_privacidade_EP", "DateTimePrivacidadeEp" },
                { "date_time_insert_EP", "DateTimeInsertEp" },
                { "date_time_update_EP", "DateTimeUpdateEp" },
                { "date_abertura_EP", "DateAberturaEp" },
                { "fk_tipouser_EP", "FkTipouserEp" },
                //vaga
                { "id_vaga", "IdVaga" },
                { "nome_VG", "NomeVg" },
                { "tempo_experiencia_VG", "TempoExperienciaVg" },
                { "tipo_registro_VG", "TipoRegistroVg" },
                { "descricao_VG", "DescricaoVg" },
                { "sexo_VG", "SexoVg" },
                { "descricao_validade_VG", "DescricaoValidadeVg" },
                { "date_time_insert_VG", "DateTimeInsertVg" },
                { "date_time_update_VG", "DateTimeUpdateVg" },
                { "status_VG", "StatusVg" },
                { "tipovaga_vg", "TipoVagaVg" }, 
                { "fk_empresa_VG", "FkEmpresaVg" }, 
                 //vaga status adm
                { "id_status_VSA", "IdStatusVsa" },
                { "status_VSA", "StatusVsa" },
                { "date_time_insert_VSA", "dateVsa" },
                { "descricao_VSA", "DescricaoVsa" },
                { "fk_vaga_VSA", "FkVagaVsa" },
                //visita vaga adm
                { "id_visita_VGA", "IdVisitaVga" },
                { "fk_vaga_VGA", "FkVagaVga" },
                { "fk_profissional_VGA", "FkProfissionalVga" },
                { "date_time_insert_VGA", "DateTimeInsertVga" },
                { "date_time_update_VGA", "DateTimeUpdateVga" },
                { "time_view_VGA", "TimeViewVga" },
                //profissional
                { "id_profissional", "IdProfissional" },
                { "formacao_escolar_PF", "FormacaoEscolarPf" },
                { "fk_tipouser_PF", "FkTipouserPf" },
                { "date_time_insert_PF", "DateTimeInsertPf" },
                { "date_time_update_PF", "DateTimeUpdatePf" },
                { "caminho_doc_curriculo_PF", "CaminhoDocCurriculoPf" },
                { "date_time_privacidade_PF", "DateTimePrivacidadePf" },
                { "date_time_termos_PF", "DateTimeTermosPf" },
                //candidato
                { "id_candidato", "IdCandidato" },
                { "fk_profissional_CT", "FkProfissionalCt" },
                { "date_time_insert_CT", "DateTimeInsertCt" },
                { "date_time_update_CT", "DateTimeUpdateCt" },
                { "fk_vaga_CT", "FkVagaCt" },
                { "status_CT", "StatusCt" },
                //consumo
                {"id_consumo", "IdConsumo"},
                {"fk_empresa_CS", "FkEmpresaCs"},
                {"fk_profissional_CS", "FkProfissionalCs"},
                {"fk_sessao_CS", "FkSessaoCs"},
                {"date_time_insert_CS", "DateTimeInsertCs"},
                {"date_time_update_CS", "DateTimeUpdateCs"},
                {"tempo_view_CS", "TempoViewCs"},
                {"valor_descontado_CS", "ValorDescontadoCs"},
                //certificado
                { "id_certificado", "IdCertificado" },
                { "nome_curso_CF", "NomeCursoCf" },
                { "nome_instituicao_CF", "NomeInstituicaoCf" },
                { "descricao_CF", "DescricaoCf" },
                { "date_time_insert_CF", "DateTimeInsertCf" },
                { "date_time_update_CF", "DateTimeUpdateCf" },
                { "date_inicio_CF", "DateInicioCf" },
                { "date_finalizou_CF", "DateFinalizouCf" },
                { "fk_Profissional_CF", "FkProfissionalCf" },
                //exeperiencia
                  { "id_experiencia", "IdExperiencia" },
                { "nome_cargo_EX", "NomeCargoEx" },
                { "nome_empresa_EX", "NomeEmpresaEx" },
                { "date_time_insert_EX", "DateTimeInsertEx" },
                { "date_time_update_EX", "DateTimeUpdateEx" },
                { "tipo_contrato_EX", "TipoContratoEx" },
                { "descricao_EX", "DescricaoEx" },
                { "date_inicio_EX", "DateInicioEx" },
                { "date_finalizou_EX", "DateFinalizouEx" },
                { "fk_profissional_EX", "FkProfissionalEx" }


            };
            return columnToPropertyMap.ToDictionary(kvp => kvp.Key.ToLower(), kvp => kvp.Value); ;
        } 
    }
}
