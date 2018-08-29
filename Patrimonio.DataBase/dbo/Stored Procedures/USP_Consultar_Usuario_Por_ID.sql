

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