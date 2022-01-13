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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE TABLE [Actors] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(35) NOT NULL,
        [LastName] nvarchar(35) NOT NULL,
        [Information] nvarchar(max) NULL,
        CONSTRAINT [PK_Actors] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [FullName] nvarchar(30) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE TABLE [Directors] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(15) NOT NULL,
        [LastName] nvarchar(18) NOT NULL,
        CONSTRAINT [PK_Directors] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE TABLE [Genres] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Genres] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE TABLE [Movies] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(35) NOT NULL,
        [Time] nvarchar(max) NOT NULL,
        [Overview] nvarchar(max) NOT NULL,
        [PictureUrl] nvarchar(max) NOT NULL,
        [Review] nvarchar(max) NOT NULL,
        [MovieUrl] nvarchar(max) NOT NULL,
        [ReleaseDate] datetime2 NOT NULL,
        [Rating] decimal(18,2) NOT NULL,
        [GenreId] int NOT NULL,
        CONSTRAINT [PK_Movies] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Movies_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE TABLE [Comments] (
        [Id] int NOT NULL IDENTITY,
        [Message] nvarchar(max) NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UserId] nvarchar(450) NULL,
        [MovieId] int NOT NULL,
        CONSTRAINT [PK_Comments] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Comments_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Comments_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE TABLE [DirectorMovie] (
        [DirectorsId] int NOT NULL,
        [MoviesId] int NOT NULL,
        CONSTRAINT [PK_DirectorMovie] PRIMARY KEY ([DirectorsId], [MoviesId]),
        CONSTRAINT [FK_DirectorMovie_Directors_DirectorsId] FOREIGN KEY ([DirectorsId]) REFERENCES [Directors] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_DirectorMovie_Movies_MoviesId] FOREIGN KEY ([MoviesId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE TABLE [MoviesActors] (
        [ActorsId] int NOT NULL,
        [MoviesId] int NOT NULL,
        CONSTRAINT [PK_MoviesActors] PRIMARY KEY ([ActorsId], [MoviesId]),
        CONSTRAINT [FK_MoviesActors_Actors_ActorsId] FOREIGN KEY ([ActorsId]) REFERENCES [Actors] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_MoviesActors_Movies_MoviesId] FOREIGN KEY ([MoviesId]) REFERENCES [Movies] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE INDEX [IX_Comments_MovieId] ON [Comments] ([MovieId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE INDEX [IX_Comments_UserId] ON [Comments] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE INDEX [IX_DirectorMovie_MoviesId] ON [DirectorMovie] ([MoviesId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE INDEX [IX_Movies_GenreId] ON [Movies] ([GenreId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    CREATE INDEX [IX_MoviesActors_MoviesId] ON [MoviesActors] ([MoviesId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726124159_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210726124159_InitialCreate', N'5.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210727134446_AddFirstAndLastNameColumn')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'FullName');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [AspNetUsers] DROP COLUMN [FullName];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210727134446_AddFirstAndLastNameColumn')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [FirstName] nvarchar(20) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210727134446_AddFirstAndLastNameColumn')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [LastName] nvarchar(20) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210727134446_AddFirstAndLastNameColumn')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210727134446_AddFirstAndLastNameColumn', N'5.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210803131047_CommentOnDeleteRestrict')
BEGIN
    ALTER TABLE [Comments] DROP CONSTRAINT [FK_Comments_Movies_MovieId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210803131047_CommentOnDeleteRestrict')
BEGIN
    ALTER TABLE [Comments] ADD CONSTRAINT [FK_Comments_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210803131047_CommentOnDeleteRestrict')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210803131047_CommentOnDeleteRestrict', N'5.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210803131334_DirectorMovieOnDeleteRestrict')
BEGIN
    ALTER TABLE [DirectorMovie] DROP CONSTRAINT [FK_DirectorMovie_Directors_DirectorsId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210803131334_DirectorMovieOnDeleteRestrict')
BEGIN
    ALTER TABLE [DirectorMovie] DROP CONSTRAINT [FK_DirectorMovie_Movies_MoviesId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210803131334_DirectorMovieOnDeleteRestrict')
BEGIN
    ALTER TABLE [DirectorMovie] ADD CONSTRAINT [FK_DirectorMovie_Directors_DirectorsId] FOREIGN KEY ([DirectorsId]) REFERENCES [Directors] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210803131334_DirectorMovieOnDeleteRestrict')
BEGIN
    ALTER TABLE [DirectorMovie] ADD CONSTRAINT [FK_DirectorMovie_Movies_MoviesId] FOREIGN KEY ([MoviesId]) REFERENCES [Movies] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210803131334_DirectorMovieOnDeleteRestrict')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210803131334_DirectorMovieOnDeleteRestrict', N'5.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210804125725_DirectorTableRefactor')
BEGIN
    DROP TABLE [DirectorMovie];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210804125725_DirectorTableRefactor')
BEGIN
    ALTER TABLE [Movies] ADD [DirectorId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210804125725_DirectorTableRefactor')
BEGIN
    DROP INDEX [IX_Comments_UserId] ON [Comments];
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Comments]') AND [c].[name] = N'UserId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Comments] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Comments] ALTER COLUMN [UserId] nvarchar(450) NOT NULL;
    ALTER TABLE [Comments] ADD DEFAULT N'' FOR [UserId];
    CREATE INDEX [IX_Comments_UserId] ON [Comments] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210804125725_DirectorTableRefactor')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Comments]') AND [c].[name] = N'Message');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Comments] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Comments] ALTER COLUMN [Message] nvarchar(max) NOT NULL;
    ALTER TABLE [Comments] ADD DEFAULT N'' FOR [Message];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210804125725_DirectorTableRefactor')
BEGIN
    CREATE INDEX [IX_Movies_DirectorId] ON [Movies] ([DirectorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210804125725_DirectorTableRefactor')
BEGIN
    ALTER TABLE [Movies] ADD CONSTRAINT [FK_Movies_Directors_DirectorId] FOREIGN KEY ([DirectorId]) REFERENCES [Directors] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210804125725_DirectorTableRefactor')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210804125725_DirectorTableRefactor', N'5.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210804135206_RefactorDirectorTabel')
BEGIN
    ALTER TABLE [Movies] DROP CONSTRAINT [FK_Movies_Genres_GenreId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210804135206_RefactorDirectorTabel')
BEGIN
    ALTER TABLE [Movies] ADD CONSTRAINT [FK_Movies_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210804135206_RefactorDirectorTabel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210804135206_RefactorDirectorTabel', N'5.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210804135342_CreateDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210804135342_CreateDb', N'5.0.9');
END;
GO

COMMIT;
GO

