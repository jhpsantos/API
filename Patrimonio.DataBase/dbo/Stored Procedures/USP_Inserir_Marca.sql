
-- =============================================
-- Author:		João Henrique
-- Create date: 2018-08-28
-- Description:	Inserir Marca via WEBAPI
-- =============================================
CREATE PROCEDURE [dbo].[USP_Inserir_Marca] 
	@Nome		VARCHAR(100)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO Marca
	( Nome )
	VALUES
	( @Nome )

END