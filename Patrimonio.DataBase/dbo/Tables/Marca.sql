CREATE TABLE [dbo].[Marca] (
    [MarcaId] INT           IDENTITY (1, 1) NOT NULL,
    [Nome]    VARCHAR (100) NOT NULL,
    CONSTRAINT [Pk_Marca] PRIMARY KEY CLUSTERED ([MarcaId] ASC),
    CONSTRAINT [UQ_Nome] UNIQUE NONCLUSTERED ([Nome] ASC)
);

