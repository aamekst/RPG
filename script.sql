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

CREATE TABLE [personagens] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Pontosvida] int NOT NULL,
    [Forca] int NOT NULL,
    [Defesa] int NOT NULL,
    [Inteligencia] int NOT NULL,
    [Classe] int NOT NULL,
    CONSTRAINT [PK_personagens] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Classe', N'Defesa', N'Forca', N'Inteligencia', N'Nome', N'Pontosvida') AND [object_id] = OBJECT_ID(N'[personagens]'))
    SET IDENTITY_INSERT [personagens] ON;
INSERT INTO [personagens] ([Id], [Classe], [Defesa], [Forca], [Inteligencia], [Nome], [Pontosvida])
VALUES (1, 1, 23, 17, 33, N'Nathaniel', 100),
(2, 1, 25, 15, 30, N'Maddy', 100),
(3, 3, 21, 18, 35, N'Cinzeiro', 100),
(4, 2, 18, 18, 37, N'Cass', 100),
(5, 1, 17, 20, 31, N'Rue', 100),
(6, 3, 13, 21, 34, N'Lexi', 100),
(7, 2, 11, 25, 35, N'Fez', 100);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Classe', N'Defesa', N'Forca', N'Inteligencia', N'Nome', N'Pontosvida') AND [object_id] = OBJECT_ID(N'[personagens]'))
    SET IDENTITY_INSERT [personagens] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220324222523_InitialCreate', N'5.0.15');
GO

COMMIT;
GO

