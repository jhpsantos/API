USE [master]
GO
/****** Object:  Database [ESXDESAFIO]    Script Date: 29/08/2018 08:15:05 ******/
CREATE DATABASE [ESXDESAFIO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ESXDESAFIO', FILENAME = N'D:\SQLSERVER2012\Data\ESXDESAFIO_Primary.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ESXDESAFIO_log', FILENAME = N'D:\SQLSERVER2012\Data\ESXDESAFIO_Primary.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ESXDESAFIO] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ESXDESAFIO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ESXDESAFIO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ESXDESAFIO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ESXDESAFIO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ESXDESAFIO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ESXDESAFIO] SET ARITHABORT OFF 
GO
ALTER DATABASE [ESXDESAFIO] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ESXDESAFIO] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ESXDESAFIO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ESXDESAFIO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ESXDESAFIO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ESXDESAFIO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ESXDESAFIO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ESXDESAFIO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ESXDESAFIO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ESXDESAFIO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ESXDESAFIO] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ESXDESAFIO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ESXDESAFIO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ESXDESAFIO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ESXDESAFIO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ESXDESAFIO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ESXDESAFIO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ESXDESAFIO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ESXDESAFIO] SET RECOVERY FULL 
GO
ALTER DATABASE [ESXDESAFIO] SET  MULTI_USER 
GO
ALTER DATABASE [ESXDESAFIO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ESXDESAFIO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ESXDESAFIO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ESXDESAFIO] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ESXDESAFIO', N'ON'
GO
USE [ESXDESAFIO]
GO
/****** Object:  User [esxapp]    Script Date: 29/08/2018 08:15:06 ******/
CREATE USER [esxapp] FOR LOGIN [esxapp] WITH DEFAULT_SCHEMA=[dbo]
GO


IF EXISTS (SELECT name
     FROM SYSOBJECTS
    WHERE id = OBJECT_ID(N'USP_Atualizar_Marca')
      AND OBJECTPROPERTY(id, N'ISPROCEDURE') = 1)
     DROP PROCEDURE USP_Atualizar_Marca
GO


/****** Object:  StoredProcedure [dbo].[USP_Atualizar_Marca]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Atualizar a marca pelo id;
-- =============================================
CREATE PROCEDURE [dbo].[USP_Atualizar_Marca]
(
	@MarcaId		INT
,	@Nome			VARCHAR(100)
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE m
		SET m.Nome = @Nome
	FROM Marca m 
	WHERE 
		m.MarcaId = @MarcaId

END
GO


IF EXISTS (SELECT name
     FROM SYSOBJECTS
    WHERE id = OBJECT_ID(N'USP_Atualizar_Patrimonio')
      AND OBJECTPROPERTY(id, N'ISPROCEDURE') = 1)
     DROP PROCEDURE USP_Atualizar_Patrimonio
GO

/****** Object:  StoredProcedure [dbo].[USP_Atualizar_Patrimonio]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Atualizar o patrimônio pelo id;
-- =============================================
CREATE PROCEDURE [dbo].[USP_Atualizar_Patrimonio]
(
	@PatrimonioId	INT
,	@Nome			VARCHAR(100)
,	@MarcaId		INT
,	@Descricao		VARCHAR(500)
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE p
		SET p.Nome = @Nome
	,		p.MarcaId = @MarcaId
	,		p.Descricao = @Descricao
	FROM Patrimonio p 
	WHERE 
		P.PatrimonioId = @PatrimonioId

END
GO

/****** Object:  StoredProcedure [dbo].[USP_Atualizar_Usuario]    Script Date: 29/08/2018 08:15:07 ******/

IF EXISTS (SELECT name
     FROM SYSOBJECTS
    WHERE id = OBJECT_ID(N'USP_Atualizar_Usuario')
      AND OBJECTPROPERTY(id, N'ISPROCEDURE') = 1)
     DROP PROCEDURE USP_Atualizar_Usuario
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Atualizar o usuario pelo id;
-- =============================================
CREATE PROCEDURE [dbo].[USP_Atualizar_Usuario]
(
	@UsuarioId		INT
,	@Nome			VARCHAR(100)
,	@Email			VARCHAR(30)
,	@Senha			VARCHAR(10)
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE u
		SET u.Nome = @Nome
	,		u.Email = @Email
	,		u.Senha = @Senha
	FROM Usuario u 
	WHERE 
		u.UsuarioId = @UsuarioId

END
GO
/****** Object:  StoredProcedure [dbo].[USP_Consultar_Marca_Por_ID]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Consultar o Marca por Id;
-- =============================================
CREATE PROCEDURE [dbo].[USP_Consultar_Marca_Por_ID]
(
	@MarcaId INT
)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		m.MarcaId
	,	m.Nome
	FROM Marca m (NOLOCK)
	WHERE 
		m.MarcaId = @MarcaId

END
GO
/****** Object:  StoredProcedure [dbo].[USP_Consultar_Patrimonio_Por_ID]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Consultar o Patrimônio por um ID/Código;
-- =============================================
CREATE PROCEDURE [dbo].[USP_Consultar_Patrimonio_Por_ID]
(
	@PatrimonioId INT
)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		p.PatrimonioId
	,	p.NrTombo
	,	p.Nome
	,	p.MarcaId
	,	p.Descricao
	FROM Patrimonio p (NOLOCK)
	WHERE 
		p.PatrimonioId = @PatrimonioId

END
GO
/****** Object:  StoredProcedure [dbo].[USP_Consultar_Patrimonios_Por_Marca_ID]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Consultar os patrimônios relacionados a Marca por Id;
-- =============================================
CREATE PROCEDURE [dbo].[USP_Consultar_Patrimonios_Por_Marca_ID]
(
	@MarcaId INT
)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		p.PatrimonioId
	,	p.NrTombo
	,	p.Nome
	,	p.MarcaId
	,	p.Descricao
	FROM Patrimonio p (NOLOCK)
		--DoubleCheck para verificar a existencia da Marca na base;
		INNER JOIN Marca m (NOLOCK)
			ON m.MarcaId = p.MarcaId
	WHERE 
		p.MarcaId = @MarcaId

END
GO
/****** Object:  StoredProcedure [dbo].[USP_Consultar_Por_NrTombo]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Consultar o Patrimônio pelo número do tombo;
-- =============================================
CREATE PROCEDURE [dbo].[USP_Consultar_Por_NrTombo]
(
	@NrTombo VARCHAR(100)
)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		p.PatrimonioId
	,	p.NrTombo
	,	p.Nome
	,	p.MarcaId
	,	p.Descricao
	FROM Patrimonio p (NOLOCK)
	WHERE 
		p.NrTombo = @NrTombo

END
GO
/****** Object:  StoredProcedure [dbo].[USP_Consultar_Usuario_Por_ID]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Consultar o Usuário por Id;
-- =============================================
CREATE PROCEDURE [dbo].[USP_Consultar_Usuario_Por_ID]
(
	@UsuarioId INT
)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		u.UsuarioId
	,	u.Nome
	,	u.Email
	,	u.Senha
	FROM Usuario u (NOLOCK)
	WHERE 
		u.UsuarioId = @UsuarioId

END
GO
/****** Object:  StoredProcedure [dbo].[USP_Excluir_Marca_Por_ID]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Excluir a Marca pelo identificador;
-- =============================================
CREATE PROCEDURE [dbo].[USP_Excluir_Marca_Por_ID]
(
	@MarcaId INT
)
AS
BEGIN

	SET NOCOUNT ON;

	IF( NOT EXISTS ( SELECT 1 FROM Patrimonio p (NOLOCK)
						WHERE p.MarcaId = @MarcaId))
	BEGIN

		DELETE Marca
		WHERE 
			MarcaId = @MarcaId

	END
	ELSE
	BEGIN
		
		DECLARE @Msg VARCHAR(500);
		SET @Msg = 'Não é possível excluir a Marca ' + CAST(@MarcaId AS VARCHAR(10)) + ' pois ela está em uso!'

		RAISERROR(
			@Msg
			,16
			,1)

	END

END
GO
/****** Object:  StoredProcedure [dbo].[USP_Excluir_Patrimonio_Por_ID]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Excluir o Patrimônio pelo identificador;
-- =============================================
CREATE PROCEDURE [dbo].[USP_Excluir_Patrimonio_Por_ID]
(
	@PatrimonioId INT
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE Patrimonio
	WHERE 
		PatrimonioId = @PatrimonioId

END
GO
/****** Object:  StoredProcedure [dbo].[USP_Excluir_Patrimonio_Por_NrTombo]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Excluir o Patrimônio pelo número do tombo;
-- =============================================
CREATE PROCEDURE [dbo].[USP_Excluir_Patrimonio_Por_NrTombo]
(
	@NrTombo VARCHAR(100)
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE Patrimonio
	WHERE 
		NrTombo = @NrTombo

END
GO
/****** Object:  StoredProcedure [dbo].[USP_Excluir_Usuario_Por_ID]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Excluir o Usuário pelo identificador;
-- =============================================
CREATE PROCEDURE [dbo].[USP_Excluir_Usuario_Por_ID]
(
	@UsuarioId INT
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE Usuario
	WHERE 
		UsuarioId = @UsuarioId

END
GO
/****** Object:  StoredProcedure [dbo].[USP_Inserir_Marca]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Inserir Marca via WEBAPI
-- =============================================
CREATE PROCEDURE [dbo].[USP_Inserir_Marca] 
	@Nome		VARCHAR(100)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO Marca
	( Nome )
	VALUES
	( @Nome )

END
GO
/****** Object:  StoredProcedure [dbo].[USP_Inserir_Patrimonio]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Inserir Patrimônios via WEBAPI
-- =============================================
CREATE PROCEDURE [dbo].[USP_Inserir_Patrimonio] 
	@Nome		VARCHAR(100)
,	@MarcaId	INT
,	@Descricao	VARCHAR(500)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO Patrimonio
	( Nome, MarcaId, Descricao )
	VALUES
	( @Nome,@MarcaId,@Descricao )

END
GO
/****** Object:  StoredProcedure [dbo].[USP_Inserir_Usuario]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Inserir Usuário via WEBAPI
-- =============================================
CREATE PROCEDURE [dbo].[USP_Inserir_Usuario] 
	@Nome		VARCHAR(100)
,	@Email		VARCHAR(30)
,	@Senha		VARCHAR(10)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO Usuario
	( Nome, Email, Senha )
	VALUES
	( @Nome,@Email,@Senha )

END
GO
/****** Object:  StoredProcedure [dbo].[USP_Listar_Marcas]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Listar todos as Marcas
-- =============================================
CREATE PROCEDURE [dbo].[USP_Listar_Marcas]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		MarcaId
	,	Nome
	FROM Marca (NOLOCK)

END
GO
/****** Object:  StoredProcedure [dbo].[USP_Listar_Patrimonios]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Listar todos os Patrimônios via WEBAPI
-- =============================================
CREATE PROCEDURE [dbo].[USP_Listar_Patrimonios]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		PatrimonioId
	,	NrTombo
	,	Nome
	,	MarcaId
	,	Descricao
	FROM Patrimonio (NOLOCK)

END
GO
/****** Object:  StoredProcedure [dbo].[USP_Listar_Usuarios]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Listar todos os Usuários via WEBAPI
-- =============================================
CREATE PROCEDURE [dbo].[USP_Listar_Usuarios]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		UsuarioId
	,	Nome
	,	Email
	,	Senha
	FROM Usuario (NOLOCK)

END
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Marca](
	[MarcaId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
 CONSTRAINT [Pk_Marca] PRIMARY KEY CLUSTERED 
(
	[MarcaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Nome] UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Patrimonio]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Patrimonio](
	[PatrimonioId] [int] IDENTITY(1,1) NOT NULL,
	[NrTombo] [varchar](100) NULL,
	[Nome] [varchar](100) NULL,
	[MarcaId] [int] NOT NULL,
	[Descricao] [varchar](500) NULL,
 CONSTRAINT [Pk_Tombo] PRIMARY KEY CLUSTERED 
(
	[PatrimonioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/08/2018 08:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Senha] [varchar](10) NOT NULL,
 CONSTRAINT [Pk_Usuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Patrimonio]  WITH CHECK ADD  CONSTRAINT [FK_MarcaId] FOREIGN KEY([MarcaId])
REFERENCES [dbo].[Marca] ([MarcaId])
GO
ALTER TABLE [dbo].[Patrimonio] CHECK CONSTRAINT [FK_MarcaId]
GO
USE [master]
GO
ALTER DATABASE [ESXDESAFIO] SET  READ_WRITE 
GO

CREATE TRIGGER TR_Patrimonio 
	ON Patrimonio
	FOR INSERT
	AS
	BEGIN
		-- Always add this to your triggers: some libraries don't like
		-- triggers altering the number of rows affected by the DML operation
		SET NOCOUNT ON;

		
		UPDATE p
			SET p.NrTombo = CONVERT(varchar(max)
				,HASHBYTES('SHA1',CAST(ISNULL(i.PatrimonioId,0) AS NVARCHAR(10)) + i.Nome),2)
		FROM Patrimonio p 
			INNER JOIN inserted i
				ON i.PatrimonioId = p.PatrimonioId  
	END
	
