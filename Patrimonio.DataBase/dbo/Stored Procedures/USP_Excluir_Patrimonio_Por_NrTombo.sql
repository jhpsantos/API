
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