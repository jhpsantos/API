

-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Listar todos os Patrimônios via WEBAPI
-- =============================================
CREATE PROCEDURE USP_Listar_Patrimonios
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