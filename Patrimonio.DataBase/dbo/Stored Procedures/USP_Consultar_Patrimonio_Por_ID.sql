

-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Consultar o Patrimônio por um ID/Código;
-- =============================================
CREATE PROCEDURE USP_Consultar_Patrimonio_Por_ID
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