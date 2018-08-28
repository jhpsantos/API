-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Consultar os patrimônios relacionados a Marca por Id;
-- =============================================
CREATE PROCEDURE [dbo].[USP_Consultar_Patrimonios_Por_Marca_D]
(
	@MarcaId INT
)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		p.PatrimonioId
	,	p.NrTombo
	,	p.Nome
	,	p.MarcaId
	,	m.Nome as 'NomeMarca'
	,	p.Descricao
	FROM Patrimonio p (NOLOCK)
		--DoubleCheck para verificar a existencia da Marca na base;
		INNER JOIN Marca m (NOLOCK)
			ON m.MarcaId = p.MarcaId
	WHERE 
		p.MarcaId = @MarcaId

END