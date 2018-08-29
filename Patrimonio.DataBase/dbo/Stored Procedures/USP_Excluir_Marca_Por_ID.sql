
-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Excluir a Marca pelo identificador;
-- =============================================
CREATE PROCEDURE [dbo].[USP_Excluir_Marca_Por_ID]
(
	@MarcaId INT
)
AS
BEGIN

	SET NOCOUNT ON;

	IF( NOT EXISTS ( SELECT 1 FROM Patrimonio p (NOLOCK)
						WHERE p.MarcaId = @MarcaId))
	BEGIN

		DELETE Marca
		WHERE 
			MarcaId = @MarcaId

	END
	ELSE
	BEGIN
		
		DECLARE @Msg VARCHAR(500);
		SET @Msg = 'Não é possível excluir a Marca ' + CAST(@MarcaId AS VARCHAR(10)) + ' pois ela está em uso!'

		RAISERROR(
			@Msg
			,16
			,1)

	END

END