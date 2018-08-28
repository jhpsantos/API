CREATE TABLE [dbo].[Patrimonio] (
    [PatrimonioId] INT           IDENTITY (1, 1) NOT NULL,
    [NrTombo]      VARCHAR (100) NULL,
    [Nome]         VARCHAR (100) NULL,
    [MarcaId]      INT           NOT NULL,
    [Descricao]    VARCHAR (500) NULL,
    CONSTRAINT [Pk_Tombo] PRIMARY KEY CLUSTERED ([PatrimonioId] ASC),
    CONSTRAINT [FK_MarcaId] FOREIGN KEY ([MarcaId]) REFERENCES [dbo].[Marca] ([MarcaId])
);


GO

	CREATE TRIGGER TR_Patrimonio 
	ON Patrimonio
	FOR INSERT
	AS
	BEGIN
		-- Always add this to your triggers: some libraries don't like
		-- triggers altering the number of rows affected by the DML operation
		SET NOCOUNT ON;

		
		UPDATE p
			SET p.NrTombo = CONVERT(varchar(max)
				,HASHBYTES('SHA1',CAST(ISNULL(i.PatrimonioId,0) AS NVARCHAR(10)) + i.Nome),2)
		FROM Patrimonio p 
			INNER JOIN inserted i
				ON i.PatrimonioId = p.PatrimonioId  
	END
	
