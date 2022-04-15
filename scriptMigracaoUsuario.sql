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

