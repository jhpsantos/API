-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Consultar o Marca por Id;
-- =============================================
CREATE PROCEDURE [dbo].[USP_Consultar_Marca_Por_ID]
(
	@MarcaId INT
)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		m.MarcaId
	,	m.Nome
	FROM Marca m (NOLOCK)
	WHERE 
		m.MarcaId = @MarcaId

END