

-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Excluir o Patrimônio pelo identificador;
-- =============================================
CREATE PROCEDURE USP_Excluir_Patrimonio_Por_ID
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