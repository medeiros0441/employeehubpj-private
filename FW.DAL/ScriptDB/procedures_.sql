USE [chateau]
GO
/****** Object:  StoredProcedure [dbo].[Create_Vaga]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Create_Vaga] 
@nome Varchar(70),@experiencia Varchar(70),@TipoRegistro Varchar(70), @descricao varchar(1500),
@sexo Varchar(50),@validade Varchar(70),@publicacao Varchar(70),@status Varchar(70),@FK_Empresa int,@atualizacao Varchar(70)
 as begin transaction;
 insert into tb_Vagas 
(ds_nome,ds_experiencia,ds_tiporegistro,ds_descricao,ds_sexo,ds_validade,dt_publicacao,ds_status,fk_empresa,dt_atualizacao)
values(@nome,@experiencia,@tiporegistro,@descricao,@sexo,@validade,@publicacao,@status,@FK_empresa,@atualizacao); 
COMMIT transaction;
insert into Tb_Vaga_Status_ADM (Ds_status_Adm, ds_Data_Adm, Descricao_Adm, FK_Vaga) values ('Ativo',@publicacao,'Publicado',@@IDENTITY);
GO
/****** Object:  StoredProcedure [dbo].[Criar_usuario_google]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 --criando usuario googe  
       CREATE PROCEDURE [dbo].[Criar_usuario_google]
       @nome_completo varchar(max) ,@primeiro_nome varchar(max),@sobrenome varchar(max), @sub_email varchar(max), @email_google varchar(max),  
       @Sexo varchar(max), @senha varchar(max),@usuario varchar(max),@tipo_user int,@url_img varchar(max)  
       as    
     begin TRANSACTION   
   insert into tb_cliente (Ds_nome,ds_sobrenome,Ds_usuario,Ds_Senha,Ds_Sexo,Ds_Email,Url_foto) values (@primeiro_nome,@sobrenome,@usuario,@senha,@sexo,@email_google,@url_img);  
     DECLARE  @Fk_Cliente INT;  
     set @Fk_Cliente = @@IDENTITY;  
   insert into tb_google_users (id_email,ds_nome_completo,ds_primeiro_nome,ds_sobrenome,ds_email_google,Fk_cliente) values (@sub_email,@nome_completo,@primeiro_nome,@sobrenome,@email_google,@Fk_Cliente);  
  COMMIT TRANSACTION;  
  
     if (@tipo_user = 2)  
     begin   
  
     insert into tb_tipouser(Ds_Tipouser,COD_Tipouser,Ds_Status,Fk_cliente) values ('Profissional',2,'Ativo',@Fk_Cliente);  
         DECLARE @Fk_tipouser INT = @@IDENTITY;  
  insert into TB_Profissional (Dt_Privacidade,Dt_Termos,FK_Tipouser,Dt_atualizacao) values ('','',@Fk_tipouser,'');  
    
  Select FK_Tipouser,Fk_cliente,COD_Tipouser from TB_Tipouser as T join TB_Profissional as P  on P.FK_Tipouser= T.ID_TIPOUSER  
 join TB_CLIENTE as C on C.ID_CLIENTE= T.Fk_cliente end;  
      
 if(@tipo_user = 3)  
     begin    
     insert into tb_tipouser(Ds_Tipouser,COD_Tipouser,Ds_Status,Fk_cliente) values ('Empresa',3,'Ativo',@Fk_Cliente);  
 DECLARE @Fk_tipouser_empresa INT = @@IDENTITY;  
  insert into TB_Empresa (fk_tipouser,dt_termos,Dt_Privacidade,Dt_Atualizacao) values (@Fk_tipouser_empresa,'','','');  
 Select FK_Tipouser,Fk_cliente,COD_Tipouser from TB_Tipouser as T join TB_Empresa as E  on E.FK_Tipouser= T.ID_TIPOUSER  
 join TB_CLIENTE as C on C.ID_CLIENTE= T.Fk_cliente   
  
  end ;  
GO
/****** Object:  StoredProcedure [dbo].[Deletar_Cliente]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Deletar_Cliente] 
    @ID_Cliente INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @FK_Tipouser INT;
    DECLARE  @FK_Cliente INT;
   DECLARE @FK_Empresa INT;

    SELECT @FK_Tipouser = id_Tipouser, @FK_Cliente = fk_Cliente
    FROM TB_Tipouser
    WHERE FK_Cliente = @ID_Cliente;

    IF EXISTS(SELECT * FROM TB_Tipouser WHERE id_Tipouser = @FK_Tipouser AND COD_Tipouser = 2)
    BEGIN
        DELETE FROM TB_Profissional WHERE FK_Tipouser = @FK_Tipouser;
        DELETE FROM TB_Experiencia WHERE FK_Profissional IN (SELECT ID_Profissional FROM TB_Profissional WHERE FK_Tipouser = @FK_Tipouser);
        DELETE FROM TB_Certificado WHERE FK_Profissional IN (SELECT ID_Profissional FROM TB_Profissional WHERE FK_Tipouser = @FK_Tipouser);
    END
    ELSE IF EXISTS(SELECT * FROM TB_Tipouser WHERE id_Tipouser = @FK_Tipouser AND COD_Tipouser = 3)
    BEGIN
        BEGIN
            SELECT @FK_Empresa = ID_Empresa FROM TB_Empresa WHERE FK_Tipouser = @FK_Tipouser;
            DELETE FROM TB_Vagas WHERE FK_Empresa = @FK_Empresa;
            DELETE FROM Tb_Vaga_Status_ADM WHERE fk_vaga IN (SELECT ID_Vaga FROM TB_Vagas WHERE fk_Empresa = @FK_Empresa) ;
            DELETE FROM TB_Candidatos WHERE FK_Vaga IN (SELECT ID_Vaga FROM TB_Vagas WHERE fk_Empresa = @FK_Empresa);
            DELETE FROM TB_Empresa WHERE ID_Empresa = @FK_Empresa;
        END
    END

    DELETE FROM TB_Redesociais WHERE FK_Cliente = @FK_Cliente;
    DELETE FROM TB_Publicacao WHERE FK_Cliente = @FK_Cliente;
    DELETE FROM TB_Comentarios WHERE FK_Cliente = @FK_Cliente;
    DELETE FROM tb_cliente_status_ADM WHERE FK_Cliente = @FK_Cliente;
    DELETE FROM tb_google_users WHERE FK_Cliente = @FK_Cliente;
    DELETE FROM tb_notificacao WHERE FK_Cliente = @FK_Cliente;
    DELETE FROM tb_saldo WHERE FK_Cliente = @FK_Cliente;
    DELETE FROM TB_Pagamento WHERE FK_Cliente = @FK_Cliente;
    DELETE FROM TB_Historico WHERE FK_Cliente = @FK_Cliente;
    DELETE FROM tb_consumo WHERE FK_Cliente = @FK_Cliente;
    DELETE FROM tb_cliente WHERE id_Cliente = @FK_Cliente;
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_Publicacao_Comentarios]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[Delete_Publicacao_Comentarios] @ID_cliente int, @FK_Publicacao int as
DELETE FROM Tb_Comentarios  WHERE Fk_publicacao=@FK_Publicacao
DELETE FROM tb_publicacao  WHERE id_publicacao=@FK_Publicacao and FK_cliente=@ID_cliente
GO
/****** Object:  StoredProcedure [dbo].[Editar_Perfil_Cliente]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Editar_Perfil_Cliente]  
@Nome varchar(100),@Sobrenome varchar(100),@Telefone varchar(30),@Biografia Varchar(2000),@Data_Nascimento varchar(40),@Sexo varchar(40),  
@Dt_Atualizacao varchar(50),@CPF varchar(50),@Usuario varchar(50),@FK_profissional int as  

update tb_cliente set  ds_nome=@Nome,ds_sobrenome=@Sobrenome,Nro_Telefone=@Telefone,Ds_Biografia=@Biografia,Dt_Nascimento=@Data_Nascimento,Ds_Sexo=@Sexo,DT_atualizacao=@Dt_Atualizacao,nro_cpf=@CPF,ds_usuario=@Usuario from   
tb_profissional as P   

inner join tb_tipouser as T on T.ID_tipouser = P.FK_tipouser   
inner join TB_CLIENTE as C on C.ID_CLIENTE = T.Fk_cliente   
WHERE   C.ID_CLIENTE = T.Fk_cliente and P.ID_Profissional=@FK_profissional  
GO
/****** Object:  StoredProcedure [dbo].[Excluir_Vaga]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Excluir_Vaga] @id_vaga int,@Date varchar(50) as
update Tb_Vaga_Status_ADM set Ds_status_Adm='Desativado',ds_Data_Adm=@Date,Descricao_Adm='exclusão solicitada' where FK_Vaga =@id_vaga;
update TB_VAGAS set Ds_Status='Desativado',Dt_atualizacao=@Date  where Id_Vaga=@id_vaga;

GO
/****** Object:  StoredProcedure [dbo].[Filtrar_Publicacao_Cliente]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Filtrar_Publicacao_Cliente] as
Select id_publicacao, fk_cliente,ds_data,ds_descricao, URL_imagen1, URL_imagen2, URL_imagen3, URL_Video1, URL_Video2 , C.ds_nome,C.ds_usuario,url_Foto from TB_Publicacao 
join TB_CLIENTE as C on C.ID_CLIENTE = FK_cliente	order by ds_Data
GO
/****** Object:  StoredProcedure [dbo].[Filtro_Vaga_Ativa]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Filtro_Vaga_Ativa] as
SELECT * FROM tb_Vagas inner join  Tb_Vaga_Status_ADM on Fk_vaga=ID_vaga   where ds_Status_adm='Ativo' and ds_status='Ativo' ORDER BY Dt_atualizacao
GO
/****** Object:  StoredProcedure [dbo].[Filtro_Vaga_ID]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Filtro_Vaga_ID] @Id_vaga int as 
SELECT * FROM tb_Vagas inner join  Tb_Vaga_Status_ADM on Fk_vaga=ID_vaga  where ds_Status_adm='Ativo' and Id_Vaga=@Id_vaga 
GO
/****** Object:  StoredProcedure [dbo].[Filtro_Vaga_IDEmpresa]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Filtro_Vaga_IDEmpresa] @ID_empresa int as 
SELECT * FROM tb_Vagas inner join  Tb_Vaga_Status_ADM on Fk_vaga=ID_vaga  where ds_Status_adm='Ativo' and FK_Empresa=@ID_empresa
GO
/****** Object:  StoredProcedure [dbo].[Lista_Candidato_FkEmpresa]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Lista_Candidato_FkEmpresa]
@FK_empresa int as  SELECT V.Ds_status as Vaga_Status, C.FK_Profissional, V.ds_nome as Nome_Vaga, P_C.ID_cliente as Cliente_Profisional,
  P_C.Ds_Nome as Nome_Profissional, P_C.Ds_Verificacao as Verificacao_Profissional, P.Doc_curriculo as Curriculo_Profissional
  FROM tb_Candidatos as C 
  join TB_VAGAS as V on Id_Vaga= C.FK_Vaga 
  join Tb_Profissional as P on P.ID_profissional=C.Fk_profissional
  join TB_Tipouser as P_T on P_T.ID_TIPOUSER= P.FK_Tipouser
  Join Tb_cliente as P_C on  P_C.ID_Cliente=P_T.FK_Cliente
  join TB_Empresa as E on V.Fk_empresa=E.ID_Empresa 
  join TB_Tipouser as E_T on E_T.ID_TIPOUSER= E.FK_Tipouser
  join TB_CLIENTE as E_C on E_C.ID_CLIENTE=E_T.Fk_cliente  where  V.Fk_empresa=@FK_empresa ORDER BY C.Ds_Data;
GO
/****** Object:  StoredProcedure [dbo].[Lista_Candidato_FkEmpresa_CandidatoStatus]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 
GO
/****** Object:  StoredProcedure [dbo].[Lista_Candidato_FkEmpresa_FKVaga_CandidatoStatus]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Lista_Candidato_FkEmpresa_FKVaga_CandidatoStatus]

@FK_empresa int, @Status varchar(30), @FK_vaga int as 
SELECT V.Ds_status as Vaga_Status, C.FK_Profissional, V.ds_nome as Nome_Vaga, P_C.ID_cliente as FK_Cliente,
  P_C.Ds_Nome as Nome_Profissional, P_C.Ds_Verificacao as Verificacao_Profissional, P.Doc_curriculo as Curriculo_Profissional, V.Id_Vaga as Fk_vaga
  FROM tb_Candidatos as C 
  join TB_VAGAS as V on Id_Vaga= C.FK_Vaga 
  join Tb_Profissional as P on P.ID_profissional=C.Fk_profissional
  join TB_Tipouser as P_T on P_T.ID_TIPOUSER= P.FK_Tipouser
  Join Tb_cliente as P_C on  P_C.ID_Cliente=P_T.FK_Cliente
  join TB_Empresa as E on V.Fk_empresa=E.ID_Empresa 
  join TB_Tipouser as E_T on E_T.ID_TIPOUSER= E.FK_Tipouser
  join TB_CLIENTE as E_C on E_C.ID_CLIENTE=E_T.Fk_cliente  where  V.Fk_empresa=@FK_empresa and V.id_vaga=@FK_vaga and C.ds_Status=@Status ORDER BY C.Ds_Data;
GO
/****** Object:  StoredProcedure [dbo].[Lista_Candidato_FkProfissional_StatusCandidato]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON 

GO
/****** Object:  StoredProcedure [dbo].[Lista_Certificado_IdCliente]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Lista_Certificado_IdCliente] @ID_Cliente int  as
Select  ID_CLIENTE,Id_Certificado,Ds_Curso,Ds_Instituicao,Ds_Descricao,Dt_inicio,Dt_conclusao From TB_Certificado as Certificado
JOIN TB_Profissional as P ON P.ID_Profissional = Certificado.FK_Profissional 
inner join tb_tipouser as T on T.id_tipouser = P.Fk_tipouser inner join tb_cliente as C on C.id_cliente = T.fk_cliente   where C.ID_CLIENTE =@ID_Cliente
GO
/****** Object:  StoredProcedure [dbo].[Lista_Experiencia_IdCliente]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Lista_Experiencia_IdCliente] @ID_Cliente int  as
SELECT Id_Experiencia, Ds_Cargo, Ds_Empresa, Ds_TipoContrato, Ds_Descricao, Dt_Inicio, Dt_Final, FK_Profissional FROM TB_Experiencia as E 
JOIN TB_Profissional as P ON P.ID_Profissional = E.FK_Profissional 
inner join tb_tipouser as T on T.id_tipouser = P.Fk_tipouser inner join tb_cliente as C on C.id_cliente = T.fk_cliente   where C.ID_CLIENTE =@ID_Cliente
GO
/****** Object:  StoredProcedure [dbo].[Lista_Publicacao]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Lista_Publicacao]   as 
  SELECT C.ds_nome,C.ds_usuario,C.Url_foto,P.ds_data as data_publi,ds_descricao,URL_imagen1,
  URL_imagen2,URL_imagen3,URL_Video1,URL_Video2,P.fk_cliente,id_publicacao  FROM  tb_publicacao as P 
  join TB_CLIENTE as C on C.Id_cliente=P.FK_cliente 
 
GO
/****** Object:  StoredProcedure [dbo].[Lista_Publicacao_Cliente]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Lista_Publicacao_Cliente] @ID_Cliente int as 
  SELECT C.ds_nome,C.ds_usuario,C.Url_foto,P.ds_data as data_publi,ds_descricao,URL_imagen1,
  URL_imagen2,URL_imagen3,URL_Video1,URL_Video2,P.fk_cliente,id_publicacao  FROM  tb_publicacao as P 
  join TB_CLIENTE as C on C.Id_cliente=P.FK_cliente 
  where P.FK_cliente=@ID_CLiente
GO
/****** Object:  StoredProcedure [dbo].[Listar_Vaga_Ativa]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Listar_Vaga_Ativa]  as
Select * from TB_VAGAS  inner join  Tb_Vaga_Status_ADM on Fk_vaga=ID_vaga  where ds_Status_adm='Ativo' ORDER BY Dt_Publicacao 
GO
/****** Object:  StoredProcedure [dbo].[Seleciona_Publicacao_IdCliente_IdPublicacao]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Seleciona_Publicacao_IdCliente_IdPublicacao] @ID_Cliente int, @ID_Publicacao int as 
  SELECT C.ds_nome,C.ds_usuario,C.Url_foto,P.ds_data as data_publi,ds_descricao,URL_imagen1,
  URL_imagen2,URL_imagen3,URL_Video1,URL_Video2,P.fk_cliente,id_publicacao  FROM  tb_publicacao as P 
  join TB_CLIENTE as C on C.Id_cliente=P.FK_cliente 
  where P.FK_cliente=@ID_CLiente and P.id_publicacao =@ID_Publicacao
GO
/****** Object:  StoredProcedure [dbo].[Selecionar_idvaga_idempresa]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Selecionar_idvaga_idempresa] @ID_empresa int , @ID_vaga int as 
SELECT * FROM tb_Vagas  inner join  Tb_Vaga_Status_ADM on Fk_vaga=ID_vaga  where ds_Status_adm='Ativo' and id_vaga = @ID_vaga and fk_empresa=@ID_empresa   ORDER BY Dt_atualizacao
GO
/****** Object:  StoredProcedure [dbo].[Selecionar_Vaga_Ativa]    Script Date: 16/04/2023 12:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Selecionar_Vaga_Ativa] @Id_vaga int as 
SELECT * FROM tb_Vagas 
inner join  Tb_Vaga_Status_ADM on Fk_vaga=ID_vaga  where ds_Status_adm='Ativo' and Id_Vaga=@Id_vaga 
GO





select * from tb_Candidato
select * from tb_Candidato
select * from tb_cliente
ALTER TABLE Tb_empresa
ALTER COLUMN numero_cnpj_ep VARCHAR(50)


select * from Tb_empresa
select * from Tb_empresa

GO
CREATE PROCEDURE [dbo].[Lista_Candidato_FkProfissional_StatusCandidato]
@FK_Profissional int , @Status_Candidato bit
as SELECT * FROM tb_Candidato as Ct
join TB_Profissional as P on P.ID_Profissional = CT.fk_profissional_CT 
join TB_Tipouser as P_T on P_T.ID_TIPOUSER = P.fk_tipouser_PF 
join TB_CLIENTE as P_C on P_C.ID_CLIENTE = P_T.Fk_cliente_TU 
join TB_VAGA as V on Id_Vaga= CT.FK_Vaga_CT 
join Tb_Vaga_Status_ADM as VS on VS.fk_vaga_VSA = V.ID_vaga
join TB_empresa as E on V.fk_empresa_VG=ID_Empresa WHERE   CT.FK_Profissional_ct=@FK_Profissional and CT.status_Ct=@status_ct and VS.status_VSA=@status_vsa


SELECT ID_Candidato,FK_profissional_ct,Fk_vaga_ct,ct.status_ct,V.Fk_empresa_Vg FROM tb_Candidato as CT join TB_Profissional as P on P.ID_Profissional = ct.fk_profissional_ct 

join TB_Tipouser as P_T on P_T.ID_TIPOUSER = P.FK_Tipouser_pf join TB_CLIENTE as P_C on P_C.ID_CLIENTE = P_T.Fk_cliente_Tu join TB_VAGA as V on Id_Vaga = CT.FK_Vaga_ct where fk_vaga_CT=@v1 and FK_Profissional_CT=@v2



select * from TB_Certificado
INSERT INTO TB_Certificado (nome_curso_CF,nome_instituicao_CF,descricao_CF,date_time_insert_CF,date_inicio_CF,date_finalizou_CF,fk_Profissional_CF)  VALUES (@v1,@v2,@v5,@v6,@v3,@v4,@v5,@7,@v7)
 