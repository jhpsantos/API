

-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Consultar o Patrimônio pelo número do tombo;
-- =============================================
CREATE PROCEDURE USP_Consultar_Por_NrTombo
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