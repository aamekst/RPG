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

BEGIN TRANSACTION;
GO

ALTER TABLE [personagens] ADD [FotoPersonagem] varbinary(max) NULL;
GO

ALTER TABLE [personagens] ADD [UsuarioId] int NULL;
GO

CREATE TABLE [Armas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Dano] int NOT NULL,
    CONSTRAINT [PK_Armas] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Foto] varbinary(max) NULL,
    [Latitude] nvarchar(max) NULL,
    [Longitude] nvarchar(max) NULL,
    [DataAcesso] datetime2 NULL,
    CONSTRAINT [PK_usuarios] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Foto', N'Latitude', N'Longitude', N'PasswordHash', N'PasswordSalt', N'Username') AND [object_id] = OBJECT_ID(N'[usuarios]'))
    SET IDENTITY_INSERT [usuarios] ON;
INSERT INTO [usuarios] ([Id], [DataAcesso], [Foto], [Latitude], [Longitude], [PasswordHash], [PasswordSalt], [Username])
VALUES (1, NULL, NULL, NULL, NULL, 0xECEEE89D7973BE50D618C08BD0614139085B7989A5FBABDC465DB065651B8E9A9BD0AEB18A2799BB54A121BD09860643549E702F7F7EFA03F2ED48583B217FE3, 0xD11774D934FEF3E4CE9BA56B3CBECEFE16F68992E6197AB756FDAFBE77036512875CDE639E4D15B8BD641B30E33FFCA2A22548EB8CAF734DEDC4E442D453EC4675A4BDA5A26C582D19B7BD4BAED037414246762ABD4CAF84E679EB5ED832DAB651CD3F8219FB9F5EA854CC00C55A64DFCDD920328A3C12DF36C9356F7973B6E8, N'UsuarioAdmin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Foto', N'Latitude', N'Longitude', N'PasswordHash', N'PasswordSalt', N'Username') AND [object_id] = OBJECT_ID(N'[usuarios]'))
    SET IDENTITY_INSERT [usuarios] OFF;
GO

CREATE INDEX [IX_personagens_UsuarioId] ON [personagens] ([UsuarioId]);
GO

ALTER TABLE [personagens] ADD CONSTRAINT [FK_personagens_usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [usuarios] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220408003401_MigracaoUsuario', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Armas] ADD [PersonagemId] int NOT NULL DEFAULT 0;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[Armas]'))
    SET IDENTITY_INSERT [Armas] ON;
INSERT INTO [Armas] ([Id], [Dano], [Nome], [PersonagemId])
VALUES (1, 35, N'Arco e Flecha', 1),
(2, 33, N'Espada', 2),
(3, 31, N'Machado', 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[Armas]'))
    SET IDENTITY_INSERT [Armas] OFF;
GO

UPDATE [usuarios] SET [PasswordHash] = 0xC71CB7A5C924EE26B3E772F4F181FDB5452AF4EA52066FE49D2B815CF73549E55CE71D4575922E4B97936FD4649D81599B3F578FCE5B3E13A84A85AC03CABE32, [PasswordSalt] = 0xB6182EBB088DB2FB793A6A37261364AD75C5A056F602CD9A4732739E6B8FB7559C2003A46F4256F8A23D52B4B9034D663D30900339F3835CF3CE610678F40CF2962E0D131F8818694117F9EAE2186DB03174F7D40116AB4F3EC457FFC5FE6D8770FECBD2A8EC0AE7FEFDD8F134A79892E17D8F617380266DC4CB09C8C6873D18
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_Armas_PersonagemId] ON [Armas] ([PersonagemId]);
GO

ALTER TABLE [Armas] ADD CONSTRAINT [FK_Armas_personagens_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [personagens] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220408011507_MigracaoUmParaUm', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Habilidades] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Dano] int NOT NULL,
    CONSTRAINT [PK_Habilidades] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [PersonagemHabilidades] (
    [PersonagemId] int NOT NULL,
    [HabilidadeId] int NOT NULL,
    CONSTRAINT [PK_PersonagemHabilidades] PRIMARY KEY ([PersonagemId], [HabilidadeId]),
    CONSTRAINT [FK_PersonagemHabilidades_Habilidades_HabilidadeId] FOREIGN KEY ([HabilidadeId]) REFERENCES [Habilidades] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PersonagemHabilidades_personagens_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [personagens] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Habilidades]'))
    SET IDENTITY_INSERT [Habilidades] ON;
INSERT INTO [Habilidades] ([Id], [Dano], [Nome])
VALUES (1, 39, N'Adormecer'),
(2, 41, N'Congelar'),
(3, 37, N'Hipnotizar');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Habilidades]'))
    SET IDENTITY_INSERT [Habilidades] OFF;
GO

UPDATE [usuarios] SET [PasswordHash] = 0x88CF22A90FB58B307FF9018DD37226DBFFF6CB202AF1AE64209BE136FDF2832048732FE9765CF39D49FD5701A753C45383403A24C4FA75A3BDBCDCFD7193CA84, [PasswordSalt] = 0x93BD8C8E68BD06229A1612B8D68F324153A4903B8A3194E0382C59146CAFDA11F69E21F837E96AE2BBD4A1B7D7DE65B886CEB04AAE0AEF061F42708BFD526694F7C3D77DEC4889166DA4668CA795E403C008EB671CD8CBA7264AFCAE25A4313A6EBBAAAD4B56D108BEFE9D73B806FE986D54F7FEC57CF2E1940987B9E1F7C18C
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'HabilidadeId', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[PersonagemHabilidades]'))
    SET IDENTITY_INSERT [PersonagemHabilidades] ON;
INSERT INTO [PersonagemHabilidades] ([HabilidadeId], [PersonagemId])
VALUES (1, 1),
(1, 5),
(2, 1),
(2, 2),
(2, 3),
(2, 6),
(3, 3),
(3, 4),
(3, 7);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'HabilidadeId', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[PersonagemHabilidades]'))
    SET IDENTITY_INSERT [PersonagemHabilidades] OFF;
GO

CREATE INDEX [IX_PersonagemHabilidades_HabilidadeId] ON [PersonagemHabilidades] ([HabilidadeId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220408013702_MigracaoMuitosParaMuitos', N'5.0.15');
GO

COMMIT;
GO

