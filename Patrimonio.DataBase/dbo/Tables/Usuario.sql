CREATE TABLE [dbo].[Usuario] (
    [UsuarioId] INT           IDENTITY (1, 1) NOT NULL,
    [Nome]      VARCHAR (100) NOT NULL,
    [Email]     VARCHAR (30)  NOT NULL,
    [Senha]     VARCHAR (10)  NOT NULL,
    CONSTRAINT [Pk_Usuario] PRIMARY KEY CLUSTERED ([UsuarioId] ASC)
);

