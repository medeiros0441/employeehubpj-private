--create database chateau_local  
 update TB_CLIENTE set caminho_foto_CL='..\Cliente\Foto_Cliente\Foto_Cliente_1_Cod_422.png'
 select * from  tb_cliente 

-- Opcionalmente, você também pode definir a configuração de data e hora
ALTER DATABASE bdtemporario
SET DATEFORMAT dmy;
SET LANGUAGE Portuguese
CREATE TABLE tb_sessao (
    ID_sessao INT PRIMARY KEY IDENTITY(1,1),
    ip_cliente_SS VARCHAR(255) NOT NULL,
    navegador_SS VARCHAR(255) NOT NULL,
    status_SS BIT NOT NULL,
    date_time_insert_SS DATETIME NOT NULL,
    date_time_update_SS DATETIME  NULL,
    time_online_SS TIME null ,
    iniciou_SS DATETIME NOT NULL,
    finalizou_SS DATETIME  NULL
);  

CREATE TABLE tb_log (
    id_log INT PRIMARY KEY IDENTITY(1,1),
    date_time_insert_LG DATETIME NOT NULL,
    date_time_update_LG DATETIME  NULL,
    descricao_LG text NOT NULL,
    descricao_sistema_LG text NOT NULL,
    nivel_gravidade_LG VARCHAR(20) not NULL,
    dados_adicionais_LG TEXT NULL,
	fk_sessao_LG int not null,
	CONSTRAINT fk_tb_log_tb_sessao FOREIGN KEY (fk_sessao_LG) REFERENCES tb_sessao(id_sessao) 
); 

CREATE TABLE TB_CLIENTE (
  id_cliente int PRIMARY KEY IDENTITY(1,1),
  nome_completo_CL VARCHAR(100) not NULL,
  primeironome_CL VARCHAR(50) not NULL,
  sobrenome_CL VARCHAR(50) NOT NULL,
  email_CL VARCHAR(50) not NULL,
  usuario_CL VARCHAR(50) not NULL,
  senha_CL VARCHAR(50) not NULL,
  data_Nascimento_CL date  NULL,
  numero_telefone_CL  int  NULL,
  sexo_CL VARCHAR(30) not NULL,
  descricao_rua_CL VARCHAR(50)  NULL,
  numero_casa_CL VARCHAR(50)  NULL,
  descricao_complemento_CL VARCHAR(50)  NULL,
  numero_cep_CL VARCHAR(50)  NULL,
  descricao_bairro_CL VARCHAR(50)  NULL,
  descricao_cidade_CL VARCHAR(50) NULL,
  descricao_estado_CL VARCHAR(50)  NULL,
  caminho_foto_CL TEXT not NULL,
  status_CL bit NOT NULL,
    date_time_insert_CL datetime NOT NULL,
    date_time_update_CL DATETIME  NULL,
  nro_cpf_CL VARCHAR(50)  NULL,
  biografia_CL text  NULL,
  status_verificacao_CL BIT NOT NULL,
  saldo_atual_CL DECIMAL(10, 2) NULL,
); 
CREATE TABLE tb_google_users (
  id_cliente_google INT PRIMARY KEY IDENTITY(1,1),
  id_email_GL TEXT not NULL,
  nome_completo_GL TEXT not NULL,
  primeironome_GL TEXT NOT NULL,
  sobrenome_GL TEXT NOT NULL,
  email_GL TEXT not NULL,
  fk_cliente_GL int not nULL,
    date_time_insert_GL datetime NOT NULL,
    date_time_update_GL DATETIME  NULL,
  CONSTRAINT FK_tb_google_users_tb_cliente FOREIGN KEY (fk_cliente_GL) REFERENCES tb_cliente(id_cliente) 
);

CREATE TABLE tb_visita(
  id_visita int primary key identity (1,1),
  fk_cliente_VS int not null,
  fk_sessao_VS int not null,
    date_time_insert_VS datetime NOT NULL,
    date_time_update_VS DATETIME NULL,
  time_view_VS time  null,
  time_iniciou_VS time not null,
  time_finalizou_VS time null,
  CONSTRAINT FK_tb_visitas_tb_cliente FOREIGN KEY (fk_cliente_VS) REFERENCES tb_cliente(id_cliente) ,
  CONSTRAINT FK_tb_visitas_tb_sessao FOREIGN KEY (fk_sessao_VS) REFERENCES tb_sessao(id_sessao)
);

CREATE TABLE tb_visualizacao (
    id_visualizacao INT PRIMARY KEY IDENTITY(1,1),
    fk_visita_VZ INT NOT NULL,
    fk_cliente_VZ int not null,
    date_time_insert_VZ datetime NOT NULL,
    date_time_update_VZ DATETIME  NULL,
    time_view_VZ TIME NOT NULL,
    CONSTRAINT FK_tb_visualizacao_tb_cliente FOREIGN KEY (fk_cliente_VZ) REFERENCES tb_cliente(id_cliente) ,
    CONSTRAINT FK_tb_visualizacao_tb_visita FOREIGN KEY (fk_visita_VZ) REFERENCES tb_visita(id_visita)
);

CREATE TABLE tb_acessos (
    id_acesso INT PRIMARY KEY IDENTITY(1,1),
    fk_cliente_AS INT NOT NULL,
    fk_sessao_AS INT NOT NULL,
	date_time_insert_AS DATETIME NOT NULL,
    date_time_update_AS DATETIME null ,
    tempo_view_AS TIME NULL,
    CONSTRAINT FK_tb_acessos_tb_cliente FOREIGN KEY (fk_cliente_AS) REFERENCES tb_cliente(id_cliente) ,
	CONSTRAINT FK_tb_acesso_tb_sessao FOREIGN KEY (fk_sessao_AS) REFERENCES tb_sessao(id_sessao) 
);

CREATE TABLE tb_redesocial (
    ID_rede INT PRIMARY KEY IDENTITY(1,1),
    link_rede_RS text NOT NULL,
    descricao_rede_RS VARCHAR(50) NOT NULL,
    date_time_insert_RS DATETIME NOT NULL,
    date_time_update_RS DATETIME null ,
    FK_Cliente_RS INT NOT NULL,
    FOREIGN KEY (FK_Cliente_RS) REFERENCES tb_cliente(id_cliente) 
);

CREATE TABLE tb_notificacao (
  id_notificacao int PRIMARY KEY IDENTITY(1,1),
  titulo_NC VARCHAR(50) not NULL,
    date_time_insert_NC DATETIME NOT NULL,
    date_time_update_NC DATETIME null ,
  mensagem_NC TEXT not NULL,
  fk_cliente_NC INT not NULL,
  visibilidade_NC BIT not NULL,
    CONSTRAINT FK_tb_notificacao_tb_cliente FOREIGN KEY (fk_cliente_NC) REFERENCES tb_cliente(id_cliente) 
);
 
CREATE TABLE tb_cliente_status_adm (
    id_cliente_CLA INT PRIMARY KEY IDENTITY(1,1),
    status_adm_CLA bit not null,
    data_time_insert_CLA DATETIME NOT NULL,
    data_time_update_CLA DATETIME null ,
    descricao_CLA VARCHAR(MAX) not  NULL,
    fk_cliente_CLA INT NOT NULL,
   CONSTRAINT FK_tb_cliente_tb_cliente_status_adm FOREIGN KEY (fk_cliente_CLA) REFERENCES tb_cliente(id_cliente) 
);

CREATE TABLE tb_pagamento (
    id_pagamento INT PRIMARY KEY IDENTITY(1,1),
    valor_PG DECIMAL(10, 2) NOT NULL,
    tipo_pagamento_PG VARCHAR(50) NOT NULL,
    nome_produto_PG VARCHAR(50) NOT NULL,
    qrcodepix_PG VARCHAR(MAX) NULL,
    img_qrcodebase64_PG text  NULL,
    paymentid_PG VARCHAR(50) NOT NULL,
    status_PG VARCHAR(30) NOT NULL,
	date_time_insert_PG DATETIME NOT NULL,
    date_time_update_PG DATETIME NULL,
    fk_cliente_PG INT NOT NULL,
  CONSTRAINT FK_tb_cliente_tb_pagamento  FOREIGN KEY (fk_cliente_PG) REFERENCES tb_cliente(id_cliente) 
);

CREATE TABLE tb_gerenciamento_saldo (
    id_saldo INT PRIMARY KEY IDENTITY(1,1),
    saldo_atual_GS DECIMAL(10, 2) NOT NULL,
    saldo_anterior_GS DECIMAL(10, 2) NOT NULL,
    date_time_insert_GS DATETIME NOT NULL,
    date_time_update_GS DATETIME NULL,
    descricao_GS VARCHAR(50) NOT NULL,
    fk_cliente_GS INT NOT NULL,
    fk_pagamento_GS INT NOT NULL,
    CONSTRAINT FK_tb_cliente_tb_gerenciamento_saldo FOREIGN KEY (fk_cliente_GS) REFERENCES tb_cliente(id_cliente) ,
   CONSTRAINT FK_tb_pagamento_tb_gerenciamento_saldo FOREIGN KEY (fk_pagamento_GS) REFERENCES tb_pagamento(id_pagamento) 
);

CREATE TABLE tb_historico (
    id_historico INT PRIMARY KEY IDENTITY(1,1),
    descricao_HT TEXT NOT NULL,
    date_time_insert_HT DATETIME NOT NULL,
    date_time_update_HT DATETIME NULL,
    fk_cliente_HT INT NOT NULL,
   CONSTRAINT FK_tb_cliente_tb_historico FOREIGN KEY (fk_cliente_HT) REFERENCES tb_cliente(id_cliente) 
);

CREATE TABLE tb_publicacao (
    id_publicacao INT PRIMARY KEY IDENTITY(1,1),
    FK_cliente_PB INT NOT NULL,
    date_time_insert_PB DATETIME NOT NULL,
    date_time_update_PB DATETIME NULL,
    descricao_PB TEXT NOT NULL,
    URL_imagen1_PB text NULL,
    URL_imagen2_PB  text NULL,
    URL_imagen3_PB text NULL,
    URL_Video1_PB text NULL,
    URL_Video2_PB text NULL,
    FOREIGN KEY (FK_cliente_PB) REFERENCES tb_cliente(id_cliente)  
);

CREATE TABLE tb_comentario (
    id_comentario_CM INT PRIMARY KEY IDENTITY(1,1),
    date_time_insert_CM DATETIME NOT NULL,
    date_time_update_CM DATETIME  NULL,
    comentario_CM TEXT NOT NULL,
    FK_publicacao_CM INT NOT NULL,
    FK_Cliente_CM INT NOT NULL,
    FOREIGN KEY (FK_publicacao_CM) REFERENCES tb_publicacao(id_publicacao) ON DELETE CASCADE,
    FOREIGN KEY (FK_Cliente_CM) REFERENCES tb_cliente(id_cliente) 
);

CREATE TABLE tb_tipouser (
    id_tipouser INT PRIMARY KEY IDENTITY(1,1),
    descricao_TU text NOT NULL,
    codigo_TU int NOT NULL,
    Status_TU BIT NOT NULL,
    Fk_cliente_TU INT NOT NULL,
    date_time_insert_TU DATETIME NOT NULL,
    date_time_update_TU DATETIME  NULL
   CONSTRAINT FK_tb_cliente_tb_tipouser FOREIGN KEY (Fk_cliente_TU) REFERENCES tb_cliente(id_cliente)  
);

-- Tabela de Configurações Genérica
CREATE TABLE tb_configuracoes (
  id_configuracao int PRIMARY KEY NOT NULL AUTO_INCREMENT,
  fk_tipouser_cfc int NOT NULL,
  configuracao_type_cfc text,
  configuracao_desc_cfc text,
  configuracao_value_cfc bit,
  date_time_insert_cfc datetime NOT NULL,
  date_time_update_cfc datetime,
  
  -- Chave estrangeira que referencia o tipo de usuário
  FOREIGN KEY (fk_tipouser_cfc) REFERENCES tb_tipouser (id_tipouser)
);

CREATE TABLE tb_empresa (
    id_empresa INT PRIMARY KEY IDENTITY(1,1),
    numero_cnpj_EP int  NULL,
    nome_fantasia_EP VARCHAR(100)  NULL,
    razao_social_EP VARCHAR(100)  NULL,
    date_time_termos_EP DATETIME NOT NULL,
    date_time_privacidade_EP DATETIME NOT NULL,
	date_time_insert_EP DATETIME NOT NULL,
    date_time_update_EP DATETIME NULL,
    date_abertura_EP DATE  NULL,
    fk_tipouser_EP INT NOT NULL,
   CONSTRAINT FK_tb_tipouser_tb_empresa FOREIGN KEY (fk_tipouser_EP) REFERENCES tb_tipouser(id_tipouser) 
);

 CREATE TABLE tb_vaga (
    id_vaga INT IDENTITY(1,1) PRIMARY KEY,
    nome_VG VARCHAR(70) NOT NULL,
    tempo_experiencia_VG VARCHAR(70) NOT NULL,
    tipo_registro_VG VARCHAR(70) NOT NULL,
    descricao_VG text not NULL,
    sexo_VG VARCHAR(70) NOT NULL,
    descricao_validade_VG VARCHAR(70) NOT NULL,
    date_time_insert_VG datetime NOT NULL,
    date_time_update_VG datetime  NULL,
    status_VG bit NOT NULL, 
    tipovaga_vg INT NOT NULL,
    fk_empresa_VG INT NOT NULL,
     CONSTRAINT FK_tb_empresa_tb_vaga FOREIGN KEY (fk_empresa_VG) REFERENCES tb_empresa(id_empresa) 
);
CREATE TABLE tb_candidato_simplificado (
  id_candidato_cs INT PRIMARY KEY IDENTITY(1,1),
  nome_cs VARCHAR(255) NOT NULL,
  Email_cs VARCHAR(50) NOT NULL,
  Telefone_cs VARCHAR(50) NOT NULL,
  date_time_insert_cs datetime NOT NULL,
  caminho_doc_cs VARCHAR(50) NOT NULL
); 

CREATE TABLE tb_candidato_simplificado_relacionamento (
  id_csr INT PRIMARY KEY IDENTITY(1,1),
  Fk_candidato_csr INT NOT NULL,
  date_time_insert_csr datetime NOT NULL,
  Fk_vaga_csr INT NOT NULL,
  FOREIGN KEY (Fk_candidato_csr) REFERENCES tb_candidato_simplificado (id_candidato_cs),
  FOREIGN KEY (Fk_vaga_csr) REFERENCES tb_vaga (id_vaga)
);


 CREATE TABLE tb_vaga_status_adm (
    id_status_VSA INT IDENTITY(1,1) PRIMARY KEY,
    status_VSA  bit NOT NULL,
    descricao_VSA  varchar(50) NOT NULL,
    date_time_insert_VSA datetime NOT NULL,
    date_time_update_VSA datetime  NULL,
	fk_vaga_VSA int not null
	constraint fk_tb_vaga_tb_vaga_status_adm foreign key (fk_vaga_VSA) references tb_vaga(id_vaga) 
);
 
   
CREATE TABLE tb_profissional(
	id_profissional int  PRIMARY KEY  IDENTITY(1,1) NOT NULL,
	formacao_escolar_PF varchar(30) NULL,
	fk_tipouser_PF int NOT NULL,
	date_time_insert_PF DATETIME NOT NULL,
    date_time_update_PF DATETIME NULL,
	caminho_doc_curriculo_PF text NULL,
	date_time_privacidade_PF datetime NULL,
	date_time_termos_PF datetime NULL,
   CONSTRAINT  fk_tb_tipouser_tb_profissional FOREIGN KEY (fk_tipouser_PF) REFERENCES tb_tipouser(id_tipouser) 
	);
	
CREATE TABLE tb_visita_vaga_adm(
  id_visita_VGA int primary key identity (1,1),
  fk_vaga_VGA int not null,
  fk_profissional_VGA int not null,
    date_time_insert_VGA datetime NOT NULL,
    date_time_update_VGA DATETIME NULL,
  time_view_VGA time  null,
  CONSTRAINT FK_tb_vaga_tb_visita_vaga_adm FOREIGN KEY (fk_vaga_VGA) REFERENCES tb_vaga(id_vaga) ,
  CONSTRAINT FK_tb_profissional_tb_visita_vaga_adm FOREIGN KEY (fk_profissional_VGA) REFERENCES tb_profissional(id_profissional)
);

CREATE TABLE tb_candidato (
	id_candidato int PRIMARY KEY  IDENTITY(1,1) NOT NULL,
	fk_profissional_CT int NOT NULL,
	date_time_insert_CT DATETIME NOT NULL,
    date_time_update_CT DATETIME NULL,
	fk_vaga_CT int NOT NULL,
	status_CT bit NULL,
   CONSTRAINT FK_tb_profissional_tb_candidato FOREIGN KEY (fk_profissional_CT) REFERENCES tb_profissional(id_profissional) ,
   CONSTRAINT FK_tb_vaga_tb_candidato FOREIGN KEY (fk_vaga_CT) REFERENCES tb_vaga(id_vaga)  
 );

CREATE TABLE tb_consumo (
    id_consumo INT PRIMARY KEY IDENTITY(1,1),
    fk_empresa_CS INT NOT NULL,
    fk_profissional_CS INT NOT NULL,
    fk_sessao_CS INT NOT NULL,
    date_time_insert_CS datetime NOT NULL,
    date_time_update_CS TIME  NULL,
    tempo_view_CS TIME NULL,
    valor_descontado_CS DECIMAL(10, 2) NOT NULL,
     CONSTRAINT fk_tb_sessao_tb_consumo FOREIGN KEY (fk_sessao_CS) REFERENCES tb_sessao(id_sessao)ON DELETE CASCADE,
     CONSTRAINT fk_tb_empresa_tb_consumo  FOREIGN KEY (fk_empresa_CS) REFERENCES tb_empresa(id_empresa)ON DELETE CASCADE,
       CONSTRAINT fk_tb_profissional_tb_consumo FOREIGN KEY (fk_profissional_CS) REFERENCES tb_profissional(id_profissional),
); 

CREATE TABLE tb_certificado (
  id_certificado int PRIMARY KEY IDENTITY(1,1),
  nome_curso_CF VARCHAR(100) not null,
  nome_instituicao_CF VARCHAR(100) not null,
  descricao_CF text NULL,
  date_time_insert_CF DATETIME NOT NULL,
    date_time_update_CF DATETIME NULL,
  date_inicio_CF date NOT NULL,
  date_finalizou_CF date NOT NULL,
  fk_Profissional_CF INT not null,
  CONSTRAINT FK_tb_profissional_tb_certificado FOREIGN KEY (fk_Profissional_CF) REFERENCES tb_profissional(id_profissional) 
); 
   
CREATE TABLE tb_experiencia (
  id_experiencia int PRIMARY KEY IDENTITY(1,1),
  nome_cargo_EX VARCHAR(50) NOT NULL,
  nome_empresa_EX VARCHAR(50) NOT NULL,
  date_time_insert_EX DATETIME NOT NULL,
   date_time_update_EX DATETIME NULL,
  tipo_contrato_EX VARCHAR(15) NOT NULL,
  descricao_EX text  NULL,
  date_inicio_EX date NOT NULL,
  date_finalizou_EX date NOT NULL,
  fk_profissional_EX INT not null,
    CONSTRAINT FK_tb_profissional_tb_experiencia FOREIGN KEY (fk_profissional_EX) REFERENCES tb_profissional(id_profissional) 
);
 
--   ----------- CREATE PROCEDURE

-- create PROCEDURE Create_Vaga @nome_vg Varchar(70),@tipovagavg varchar(50),@experiencia Varchar(70),@TipoRegistro Varchar(70), @descricao text,@sexo Varchar(50),@validade Varchar(70),@date_time_insert datetime,@status bit,@status_adm bit,@descricao_adm varchar(50),@FK_Empresa int as begin transaction;
insert into tb_Vaga (nome_VG,tempo_experiencia_VG,tipo_registro_VG,descricao_VG,sexo_VG,descricao_validade_VG,date_time_insert_VG,status_VG,fk_empresa_VG,tipovaga_vg) 
values(@nome_vg,@experiencia,@tiporegistro,@descricao,@sexo,@validade,@date_time_insert,@status,@FK_empresa,@tipovagavg); DECLARE @VagaId int; 
SET @VagaId = SCOPE_IDENTITY(); COMMIT transaction; insert into Tb_Vaga_Status_ADM (status_VSA, descricao_VSA, date_time_insert_VSA, fk_vaga_VSA) values (@status_adm,@descricao_adm,@date_time_insert,@VagaId);

  
--  ----------- CREATE PROCEDURE

--   CREATE PROCEDURE Criar_usuario_google    @nome_completo varchar(150),@primeironome varchar(75),@sobrenome varchar(75),@email varchar(100),@usuario varchar(150),@senha varchar(50),@sexo varchar(50),@caminho_foto varchar(max),@status bit,@date_time_insert datetime,@status_verificacao bit,@id_email varchar(70),@codigo_tipouser int,@Descricao_Tipouser varchar(50),@date_time_privacidade datetime,@date_time_termos datetime
--AS    
--BEGIN
--  BEGIN TRY
--        BEGIN TRANSACTION
--            INSERT INTO tb_cliente (nome_completo_CL,primeironome_CL,sobrenome_CL,email_CL,usuario_CL,senha_CL,sexo_CL,caminho_foto_CL,status_CL,date_time_insert_CL,status_verificacao_CL)
--            VALUES (@nome_completo,@primeironome,@sobrenome,@email,@usuario,@senha,@sexo,@caminho_foto,@status,@date_time_insert,@status_verificacao);

--            DECLARE @Fk_Cliente INT;  
--            SET @Fk_Cliente = SCOPE_IDENTITY();

--            INSERT INTO tb_cliente_status_adm (status_adm_CLA,data_time_insert_CLA,descricao_CLA,fk_cliente_CLA) 
--            VALUES (@status,@date_time_insert,'Usuario Criado',@Fk_Cliente)         
--            INSERT INTO tb_google_users (id_email_GL,nome_completo_GL,primeironome_GL,sobrenome_GL,email_GL,fk_cliente_GL,date_time_insert_GL) 
--            VALUES (@id_email,@nome_completo,@primeironome,@sobrenome,@email,@Fk_Cliente,@date_time_insert);   

--            COMMIT TRANSACTION;      

--            INSERT INTO tb_tipouser (descricao_TU,codigo_TU,Status_TU,Fk_cliente_TU,date_time_insert_tu) 
--            VALUES (@Descricao_Tipouser,@codigo_tipouser,@status,@Fk_Cliente,@date_time_insert);  
--            DECLARE @Fk_tipouser INT = SCOPE_IDENTITY();  

--            IF (@codigo_tipouser = 2)  
--            BEGIN    
--                INSERT INTO TB_Profissional (date_time_privacidade_PF,date_time_termos_PF,fk_tipouser_PF,date_time_insert_PF) 
--                VALUES (@date_time_privacidade,@date_time_termos,@Fk_tipouser,@date_time_insert);        
--                DECLARE @ID_profissional INT = SCOPE_IDENTITY();  
--                SELECT @Fk_Cliente AS id_cliente, @Fk_tipouser AS id_tipouser, @codigo_tipouser AS codigo_tipouser,@ID_profissional as  ID_profissional;
--            END

--            IF (@codigo_tipouser = 3)  
--            BEGIN     
--                INSERT INTO TB_Empresa (date_time_termos_EP,date_time_privacidade_EP,date_time_insert_EP,fk_tipouser_EP) 
--                VALUES (@date_time_termos, @date_time_privacidade,@date_time_insert,@Fk_tipouser);
--                DECLARE @ID_empresa INT = SCOPE_IDENTITY();  
--                SELECT @Fk_Cliente AS id_cliente, @Fk_tipouser AS id_tipouser, @codigo_tipouser AS codigo_tipouser,@ID_empresa as  ID_empresa;
--            END
--   END TRY
--        BEGIN CATCH
--            IF @@TRANCOUNT > 0
--                ROLLBACK TRANSACTION;
--            THROW;
--        END CATCH;
--    END

SELECT nome_cargo_EX, nome_empresa_EX, date_time_insert_EX, tipo_contrato_EX, descricao_EX, date_inicio_EX, date_finalizou_EX, fk_profissional_EX FROM TB_Experiencia as E 
JOIN TB_Profissional as P ON P.ID_Profissional = E.FK_Profissional_Ex 
inner join tb_tipouser as T on T.id_tipouser = P.Fk_tipouser_pf inner join tb_cliente as C on C.id_cliente = T.fk_cliente_tu     where C.ID_CLIENTE =@ID_Cliente  order by date_time_insert_EX desc 
 


  SELECT g.fk_cliente_GL, status_CL,c.id_cliente, t.id_tipouser, t.codigo_TU,
   CASE WHEN t.codigo_TU = 2 THEN p.id_profissional  WHEN t.codigo_TU = 3 THEN e.id_empresa END AS id_associado FROM 
   tb_cliente c INNER JOIN tb_tipouser t ON t.Fk_cliente_TU = c.id_cliente left join tb_google_users as g on g.fk_cliente_GL = c.id_cliente
   LEFT JOIN tb_profissional p ON p.fk_tipouser_PF = t.id_tipouser AND t.codigo_TU = 2 
   LEFT JOIN tb_empresa e ON e.fk_tipouser_EP = t.id_tipouser AND  t.codigo_TU = 3

    