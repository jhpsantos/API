-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Atualizar o patrimônio pelo id;
-- =============================================
CREATE PROCEDURE USP_Atualizar_Patrimonio
(
	@PatrimonioId	INT
,	@Nome			VARCHAR(100)
,	@MarcaId		INT
,	@Descricao		VARCHAR(500)
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE p
		SET p.Nome = @Nome
	,		p.MarcaId = @MarcaId
	,		p.Descricao = @Descricao
	FROM Patrimonio p 
	WHERE 
		P.PatrimonioId = @PatrimonioId

END