

-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Inserir Patrimônios via WEBAPI
-- =============================================
CREATE PROCEDURE USP_Inserir_Patrimonio 
	@Nome		VARCHAR(100)
,	@MarcaId	INT
,	@Descricao	VARCHAR(500)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO Patrimonio
	( Nome, MarcaId, Descricao )
	VALUES
	( @Nome,@MarcaId,@Descricao )

END