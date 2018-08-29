-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Atualizar a marca pelo id;
-- =============================================
CREATE PROCEDURE [dbo].[USP_Atualizar_Marca]
(
	@MarcaId		INT
,	@Nome			VARCHAR(100)
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE m
		SET m.Nome = @Nome
	FROM Marca m 
	WHERE 
		m.MarcaId = @MarcaId

END