
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