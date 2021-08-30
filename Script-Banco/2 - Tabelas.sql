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

CREATE TABLE [clientes] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(80) NULL,
    CONSTRAINT [PK_clientes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [produtos] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(36) NOT NULL,
    [Preco] decimal(5,2) NOT NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_produtos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [pedidos] (
    [Id] uniqueidentifier NOT NULL,
    [ClienteId] uniqueidentifier NOT NULL,
    [Total] decimal(5,2) NOT NULL,
    CONSTRAINT [PK_pedidos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_pedidos_clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [clientes] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [pedidoItens] (
    [Id] uniqueidentifier NOT NULL,
    [PedidoId] uniqueidentifier NOT NULL,
    [ProdutoId] uniqueidentifier NOT NULL,
    [Quantidade] int NOT NULL,
    [Total] decimal(5,2) NOT NULL,
    CONSTRAINT [PK_pedidoItens] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_pedidoItens_pedidos_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [pedidos] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_pedidoItens_produtos_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [produtos] ([Id]) ON DELETE NO ACTION
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210830031101_Inicial', N'5.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210830034114_Inicialdois', N'5.0.9');
GO

COMMIT;
GO

