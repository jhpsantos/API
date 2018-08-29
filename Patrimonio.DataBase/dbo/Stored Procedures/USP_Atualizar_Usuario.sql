

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