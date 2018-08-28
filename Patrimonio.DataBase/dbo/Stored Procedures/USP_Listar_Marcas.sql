
-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Listar todos as Marcas
-- =============================================
CREATE PROCEDURE [dbo].[USP_Listar_Marcas]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		MarcaId
	,	Nome
	FROM Marca (NOLOCK)

END