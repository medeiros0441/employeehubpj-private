SELECT id_candidato_cs ,nome_cs, email_cs, telefone_cs, date_time_insert_cs FROM  tb_candidato_simplificado 


SELECT * FROM tb_candidato_simplificado_relacionamento
delete from tb_candidato_simplificado_relacionamento
-- ID_sessao, ip_cliente_SS, navegador_SS, status_SS, date_time_insert_SS, date_time_update_SS, time_online_SS, iniciou_SS, finalizou_SS

-- id_log, date_time_insert_LG, date_time_update_LG, descricao_LG, descricao_sistema_LG, nivel_gravidade_LG, dados_adicionais_LG, fk_sessao_LG

--id_cliente, nome_completo_CL, primeironome_CL, sobrenome_CL, email_CL, usuario_CL, senha_CL, data_Nascimento_CL, numero_telefone_CL, sexo_CL,
--descricao_rua_CL, numero_casa_CL, descricao_complemento_CL, numero_cep_CL, descricao_bairro_CL, descricao_cidade_CL, descricao_estado_CL,
--caminho_foto_CL, status_CL, date_time_insert_CL, date_time_update_CL, nro_cpf_CL, biografia_CL, status_verificacao_CL, saldo_atual_CL

--id_cliente_google, id_email_GL, nome_completo_GL, primeironome_GL, sobrenome_GL, email_GL, fk_cliente_GL, date_time_insert_GL, date_time_update_GL 

--id_visita, fk_cliente_VS, fk_sessao_VS, date_time_insert_VS, date_time_update_VS, time_view_VS, time_iniciou_VS, time_finalizou_VS

--id_visualizacao, fk_visita_VZ, fk_cliente_VZ, date_time_insert_VZ, date_time_update_VZ, time_view_VZ
 
-- id_acesso, fk_cliente_AS, fk_sessao_AS, date_time_insert_AS, date_time_update_AS, tempo_view_AS 
 
-- ID_rede, link_rede_RS, descricao_rede_RS, date_time_insert_RS, date_time_update_RS, FK_Cliente_RS 
 
-- id_notificacao, titulo_NC, date_time_insert_NC, date_time_update_NC, mensagem_NC, fk_cliente_NC, visibilidade_NC 

-- id_cliente_CLA, status_adm_CLA, data_time_insert_CLA, data_time_update_CLA, descricao_CLA, fk_cliente_CLA

-- id_pagamento, valor_PG, tipo_pagamento_PG, nome_produto_PG, qrcodepix_PG, img_qrcodebase64_PG, paymentid_PG, status_PG, date_time_insert_PG
-- date_time_update_PG, fk_cliente_PG
  
  SELECT id_empresa, fk_cliente_Tu, email_cl FROM tb_empresa INNER JOIN tb_tipouser ON tb_tipouser.id_tipouser = tb_empresa.fk_tipouser_EP join  tb_cliente as CL on CL.id_cliente = Fk_cliente_Tu
-- id_saldo, saldo_atual_GS, saldo_anterior_GS, date_time_insert_GS, date_time_update_GS, descricao_GS, fk_cliente_GS, fk_pagamento_GS
  
--  id_historico, descricao_HT, date_time_insert_HT, date_time_update_HT, fk_cliente_HT

-- id_publicacao, FK_cliente_PB, date_time_insert_PB, date_time_update_PB, descricao_PB, URL_imagen1_PB, URL_imagen2_PB, URL_imagen3_PB, URL_Video1_PB, URL_Video2_PB 

--    id_comentario_CM,    date_time_insert_CM, date_time_update_CM, comentario_CM, FK_publicacao_CM,  FK_Cliente_CM  

--     id_tipouser, descricao_TU, codigo_TU, Status_TU, Fk_cliente_TU,     date_time_insert_TU,     date_time_update_TU 

--    id_empresa, numero_cnpj_EP, nome_fantasia_EP, razao_social_EP, date_time_termos_EP, date_time_privacidade_EP, date_time_insert_EP, date_time_update_EP, date_abertura_EP, fk_tipouser_EP 
      
--      id_vaga, nome_VG, tempo_experiencia_VG, tipo_registro_VG, descricao_VG, sexo_VG, descricao_validade_VG, date_time_insert_VG, date_time_update_VG, status_VG, fk_empresa_VG

--      id_status_VSA, status_VSA, descricao_VSA, date_time_insert_VSA, date_time_update_VSA, fk_vaga_VSA  ;
      
--      id_profissional, formacao_escolar_PF, fk_tipouser_PF, date_time_insert_PF, date_time_update_PF, caminho_doc_curriculo_PF, date_time_privacidade_PF, date_time_termos_PF
--      id_visita_VGA, fk_vaga_VGA, fk_profissional_VGA,date_time_insert_VGA, date_time_update_VGA, time_view_VGA
--         id_candidato, fk_profissional_CT, date_time_insert_CT, date_time_update_CT, fk_vaga_CT, status_CT

-- id_consumo, fk_empresa_CS, fk_profissional_CS, fk_sessao_CS, date_time_insert_CS, date_time_update_CS, tempo_view_CS, valor_descontado_CS

--  id_certificado_CF, nome_curso_CF,nome_instituicao_CF,descricao_CF,date_time_insert_CF,date_time_update_CF,date_inicio_CF, date_finalizou_CF, fk_Profissional_CF
  
--  id_experiencia, nome_cargo_EX, nome_empresa_EX, date_time_insert_EX, date_time_update_EX, tipo_contrato_EX, descricao_EX, date_inicio_EX, date_finalizou_EX, fk_profissional_EX 



select * from tb_Profissional as P inner join TB_Tipouser as T on P.fk_tipouser_PF = T.ID_TIPOUSER left join tb_cliente as C on T.Fk_cliente_TU = c.ID_Cliente left join tb_cliente_status_adm as CSA on  CSA.fk_cliente_CLA = c.id_cliente



alter  PROCEDURE [dbo].insert_cliente
(
    -- Parâmetros de entrada
    @nome_completo NVARCHAR(100),
    @primeironome NVARCHAR(50),
    @sobrenome NVARCHAR(50),
    @email NVARCHAR(100),
    @usuario NVARCHAR(50),
    @senha NVARCHAR(50),
    @sexo NVARCHAR(10),
    @caminho_foto NVARCHAR(100),
    @status NVARCHAR(50),
    @date_time_insert DATETIME,
    @status_verificacao NVARCHAR(50),
    @Descricao_Tipouser NVARCHAR(100),
    @codigo_tipouser INT,
    @date_time_privacidade DATETIME,
    @date_time_termos DATETIME
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION

        -- Inserir dados na tabela tb_cliente
        INSERT INTO tb_cliente (nome_completo_CL, primeironome_CL, sobrenome_CL, email_CL, usuario_CL, senha_CL, sexo_CL, caminho_foto_CL, status_CL, date_time_insert_CL, status_verificacao_CL)
        VALUES (@nome_completo, @primeironome, @sobrenome, @email, @usuario, @senha, @sexo, @caminho_foto, @status, @date_time_insert, @status_verificacao);

        -- Obter o ID do cliente recém-inserido
        DECLARE @Fk_Cliente INT;
        SET @Fk_Cliente = SCOPE_IDENTITY();

        -- Inserir dados na tabela tb_tipouser
        INSERT INTO tb_tipouser (descricao_TU, codigo_TU, Status_TU, Fk_cliente_TU, date_time_insert_tu)
        VALUES (@Descricao_Tipouser, @codigo_tipouser, @status, @Fk_Cliente, @date_time_insert);

        -- Obter o ID do tipouser recém-inserido
        DECLARE @Fk_tipouser INT = SCOPE_IDENTITY();

        IF (@codigo_tipouser = 2)
        BEGIN
            -- Inserir dados na tabela TB_Profissional
            INSERT INTO TB_Profissional (date_time_privacidade_PF, date_time_termos_PF, fk_tipouser_PF, date_time_insert_PF)
            VALUES (@date_time_privacidade, @date_time_termos, @Fk_tipouser, @date_time_insert);

            -- Obter o ID do profissional recém-inserido
            DECLARE @ID_profissional INT = SCOPE_IDENTITY();

            -- Retornar os IDs relevantes
            SELECT @Fk_Cliente AS id_cliente, @Fk_tipouser AS id_tipouser, @codigo_tipouser AS codigo_tipouser, @ID_profissional AS ID_profissional;
        END

        IF (@codigo_tipouser = 3)
        BEGIN
            -- Inserir dados na tabela TB_Empresa
            INSERT INTO TB_Empresa (date_time_termos_EP, date_time_privacidade_EP, date_time_insert_EP, fk_tipouser_EP)
            VALUES (@date_time_termos, @date_time_privacidade, @date_time_insert, @Fk_tipouser);

            -- Obter o ID da empresa recém-inserida
            DECLARE @ID_empresa INT = SCOPE_IDENTITY();

            -- Retornar os IDs relevantes
            SELECT @Fk_Cliente AS id_cliente, @Fk_tipouser AS id_tipouser, @codigo_tipouser AS codigo_tipouser, @ID_empresa AS ID_empresa;
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Caso ocorra um erro, realizar o rollback da transação
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END
 

 delete from tb_cliente where id_cliente=8
 delete from tb_tipouser where id_tipouser=7
 delete from tb_gerenciamento_saldo 
 delete from tb_consumo 
 delete from tb_consumo where id_cliente=4
 select * from tb_pagamento
 select * from tb_consumo
 select * from tb_tipouser =
 select * from tb_cliente 
 select * from tb_rede

 select *  from tb_gerenciamento_saldo
 update TB_CLIENTE set biografia_cl = '' where id_cliente=9;



 select * from tb_vaga 
 select * from  tb_vaga_status_adm
  
exec Create_Vaga 
  @nome_vg = 'Desenvolvedor Full-Stack',
  @tipovagavg = 'CLT',
  @experiencia = 'Pleno-sênior',
  @tiporegistro = 'CLT',
  @descricao = 'Estamos procurando um desenvolvedor Full-Stack altamente qualificado para se juntar à nossa equipe. Você será responsável pelo desenvolvimento e manutenção de nossos aplicativos web e móveis. Experiência anterior comprovada é essencial. O candidato ideal deve estar familiarizado com tecnologias como JavaScript, React, Node.js e ter pelo menos 5 anos de experiência em desenvolvimento web.',
  @sexo = 'Indiferente',
  @validade = '7 Dias',
  @date_time_insert = @RandomDate,
  @status = 1,
  @status_adm = 1,
  @fk_empresa = 1,
  @descricao_adm = 'PUBLICADO';

  --deletando vagas..

  delete from tb_vaga_status_adm
  delete from tb_candidato
  delete from tb_candidato_simplificado_relacionamento
  delete from tb_vaga 
   
 exec Create_Vaga 
  @nome_vg = 'Desenvolvedor Full-Stack',
  @experiencia = 'Pleno-sênior', --esse pode varia entre Júnior Assistente Pleno-sênior Diretor Excutivo 
  @tiporegistro = 'CLT', -- esse pode variar entre CLT Freelancer Temporário PJ Outro
  @descricao = 'Estamos procurando um desenvolvedor Full-Stack altamente qualificado para se juntar à nossa equipe. Você será responsável pelo desenvolvimento e manutenção de nossos aplicativos web e móveis. Experiência anterior comprovada é essencial. O candidato ideal deve estar familiarizado com tecnologias como JavaScript, React, Node.js e ter pelo menos 5 anos de experiência em desenvolvimento web.',
  @sexo = 'Indiferente', --esse pode varia entre  Indiferente Masculino ou feminino 
  @validade = '7 Dias', --esse é o valor padrao para todos ... 
  @date_time_insert = @RandomDate,
  @status = 1, --esse é o valor padrao para todos ... 
  @status_adm = 1, --esse é o valor padrao para todos ... 
  @fk_empresa = 1, --esse é o valor padrao para todos ... 
  @descricao_adm = 'PUBLICADO', --esse é o valor padrao para todos ... 
  @TipoVagaVg = 'Presencial';--esse pode varia entre   Presencial Remoto Híbrio  
  
  
 DECLARE @RandomSeconds INT = CAST(RAND() * 86400 AS INT); -- Gera um número aleatório entre 0 e 86400 segundos (24 horas)
DECLARE @RandomDate DATETIME = DATEADD(SECOND, -@RandomSeconds, GETDATE()); -- Modelo 1: Desenvolvedor Mobile Sênior - Trabalho Remoto

-- Modelo 25: Arquiteto - CLT - Trabalho Presencial
exec Create_Vaga 
@nome_vg = 'Arquiteto',
@experiencia = 'Pleno',
@tiporegistro = 'CLT',
@descricao = 'Procuramos um(a) arquiteto(a) talentoso(a) para projetar edifícios inspiradores e espaços funcionais. Suas responsabilidades incluirão planejamento, desenho e coordenação com equipes de construção. Requisitos incluem formação em Arquitetura e conhecimento em software de desenho. Junte-se a nós para dar vida a projetos arquitetônicos, trabalhando presencialmente em nosso escritório de arquitetura.',
@sexo = 'Indiferente',
@validade = '7 Dias',
@date_time_insert = @RandomDate,
@status = 1,
@status_adm = 1,
@fk_empresa = 1,
@descricao_adm = 'PUBLICADO',
@TipoVagaVg = 'Presencial';

-- Modelo 26: Veterinário - CLT - Trabalho Presencial
exec Create_Vaga 
@nome_vg = 'Veterinário',
@experiencia = 'Pleno',
@tiporegistro = 'CLT',
@descricao = 'Estamos em busca de um(a) veterinário(a) apaixonado(a) por cuidar de animais de estimação. Suas responsabilidades incluirão consultas, diagnósticos e tratamentos. Requisitos incluem formação em Medicina Veterinária e registro no conselho profissional. Junte-se a nós para cuidar da saúde e bem-estar dos animais, trabalhando presencialmente em nossa clínica veterinária.',
@sexo = 'Indiferente',
@validade = '7 Dias',
@date_time_insert = @RandomDate,
@status = 1,
@status_adm = 1,
@fk_empresa = 1,
@descricao_adm = 'PUBLICADO',
@TipoVagaVg = 'Presencial';

-- Modelo 27: Terapeuta Físico - CLT - Trabalho Presencial
exec Create_Vaga 
@nome_vg = 'Terapeuta Físico',
@experiencia = 'Pleno',
@tiporegistro = 'CLT',
@descricao = 'Procuramos um(a) terapeuta físico(a) dedicado(a) para ajudar pacientes na reabilitação física. Suas responsabilidades incluirão avaliação, exercícios terapêuticos e tratamentos. Requisitos incluem formação em Fisioterapia e registro no conselho profissional. Junte-se a nós para promover a recuperação física, trabalhando presencialmente em um ambiente de reabilitação.',
@sexo = 'Indiferente',
@validade = '7 Dias',
@date_time_insert = @RandomDate,
@status = 1,
@status_adm = 1,
@fk_empresa = 1,
@descricao_adm = 'PUBLICADO',
@TipoVagaVg = 'Presencial';