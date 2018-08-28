
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