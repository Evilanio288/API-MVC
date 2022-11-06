IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Usuarios] (
    [Id] nvarchar(450) NOT NULL,
    [Nome] nvarchar(50) NOT NULL,
    [Email] nvarchar(80) NOT NULL,
    [Senha] nvarchar(10) NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [DataAtivacao] datetime2 NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Vagas] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] nvarchar(50) NOT NULL,
    [Descricacao] nvarchar(50) NOT NULL,
    [DataInclusao] datetime2 NOT NULL,
    [DataEncerramento] datetime2 NOT NULL,
    [Remuneracao] decimal(18,2) NOT NULL,
    [Anunciante] nvarchar(50) NOT NULL,
    [Rua] nvarchar(50) NOT NULL,
    [Bairro] nvarchar(50) NOT NULL,
    [Cidade] nvarchar(50) NOT NULL,
    [Estado] nvarchar(2) NOT NULL,
    [Email] nvarchar(50) NOT NULL,
    [Telefone] nvarchar(15) NOT NULL,
    CONSTRAINT [PK_Vagas] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221101230246_Initial', N'6.0.10');
GO

COMMIT;
GO

