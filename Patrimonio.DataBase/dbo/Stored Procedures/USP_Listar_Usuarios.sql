
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