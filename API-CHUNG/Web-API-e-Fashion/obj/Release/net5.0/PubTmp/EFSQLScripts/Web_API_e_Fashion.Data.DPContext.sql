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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [Discriminator] nvarchar(max) NOT NULL,
        [DiaChi] nvarchar(max) NULL,
        [SDT] nvarchar(max) NULL,
        [ImagePath] nvarchar(max) NULL,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [Quyen] nvarchar(max) NULL,
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE TABLE [Loais] (
        [Id] int NOT NULL IDENTITY,
        [Ten] nvarchar(max) NULL,
        CONSTRAINT [PK_Loais] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE TABLE [NhanHieus] (
        [Id] int NOT NULL IDENTITY,
        [Ten] nvarchar(max) NULL,
        [DateCreate] datetime2 NULL,
        CONSTRAINT [PK_NhanHieus] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE TABLE [NotificationCheckouts] (
        [Id] int NOT NULL IDENTITY,
        [ThongBaoMaDonHang] int NOT NULL,
        CONSTRAINT [PK_NotificationCheckouts] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE TABLE [Notifications] (
        [Id] int NOT NULL IDENTITY,
        [TenSanPham] nvarchar(max) NULL,
        [TranType] nvarchar(max) NULL,
        CONSTRAINT [PK_Notifications] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE TABLE [AuthHistories] (
        [Id] int NOT NULL IDENTITY,
        [IdentityId] nvarchar(450) NULL,
        CONSTRAINT [PK_AuthHistories] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AuthHistories_AspNetUsers_IdentityId] FOREIGN KEY ([IdentityId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE TABLE [HoaDons] (
        [Id] int NOT NULL IDENTITY,
        [NgayTao] datetime2 NOT NULL,
        [GhiChi] nvarchar(max) NULL,
        [TongTien] decimal(18,2) NOT NULL,
        [Id_User] nvarchar(450) NULL,
        CONSTRAINT [PK_HoaDons] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_HoaDons_AspNetUsers_Id_User] FOREIGN KEY ([Id_User]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE TABLE [JobSeekers] (
        [Id] int NOT NULL IDENTITY,
        [Id_Identity] nvarchar(450) NULL,
        [Location] nvarchar(max) NULL,
        CONSTRAINT [PK_JobSeekers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_JobSeekers_AspNetUsers_Id_Identity] FOREIGN KEY ([Id_Identity]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE TABLE [MauSacs] (
        [Id] int NOT NULL IDENTITY,
        [MaMau] nvarchar(max) NULL,
        [Id_Loai] int NULL,
        CONSTRAINT [PK_MauSacs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_MauSacs_Loais_Id_Loai] FOREIGN KEY ([Id_Loai]) REFERENCES [Loais] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE TABLE [Sizes] (
        [Id] int NOT NULL IDENTITY,
        [TenSize] nvarchar(max) NULL,
        [Id_Loai] int NULL,
        CONSTRAINT [PK_Sizes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Sizes_Loais_Id_Loai] FOREIGN KEY ([Id_Loai]) REFERENCES [Loais] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE TABLE [SanPhams] (
        [Id] int NOT NULL IDENTITY,
        [Ten] nvarchar(max) NULL,
        [MoTa] nvarchar(max) NULL,
        [Gia] decimal(18,0) NULL,
        [KhuyenMai] decimal(18,0) NULL,
        [Tag] nvarchar(max) NULL,
        [HuongDan] nvarchar(max) NULL,
        [ThanhPhan] nvarchar(max) NULL,
        [NgayCapNhat] datetime2 NULL,
        [NgayTao] datetime2 NULL,
        [TrangThaiSanPham] nvarchar(max) NULL,
        [TrangThaiHoatDong] nvarchar(max) NULL,
        [Id_NhanHieu] int NULL,
        [Id_Loai] int NULL,
        CONSTRAINT [PK_SanPhams] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SanPhams_Loais_Id_Loai] FOREIGN KEY ([Id_Loai]) REFERENCES [Loais] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_SanPhams_NhanHieus_Id_NhanHieu] FOREIGN KEY ([Id_NhanHieu]) REFERENCES [NhanHieus] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE TABLE [ImageSanPhams] (
        [Id] int NOT NULL IDENTITY,
        [ImageName] nvarchar(max) NULL,
        [IdSanPham] int NOT NULL,
        CONSTRAINT [PK_ImageSanPhams] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ImageSanPhams_SanPhams_IdSanPham] FOREIGN KEY ([IdSanPham]) REFERENCES [SanPhams] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE TABLE [SanPhamBienThes] (
        [Id] int NOT NULL IDENTITY,
        [Id_SanPham] int NULL,
        [Id_Mau] int NULL,
        [SoLuongTon] int NOT NULL,
        [SizeId] int NULL,
        CONSTRAINT [PK_SanPhamBienThes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SanPhamBienThes_MauSacs_Id_Mau] FOREIGN KEY ([Id_Mau]) REFERENCES [MauSacs] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_SanPhamBienThes_SanPhams_Id_SanPham] FOREIGN KEY ([Id_SanPham]) REFERENCES [SanPhams] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_SanPhamBienThes_Sizes_SizeId] FOREIGN KEY ([SizeId]) REFERENCES [Sizes] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE TABLE [ChiTietHoaDons] (
        [Id] int NOT NULL IDENTITY,
        [Soluong] int NOT NULL,
        [ThanhTien] decimal(18,2) NOT NULL,
        [Id_HoaDon] int NULL,
        [Id_SanPhamBienThe] int NULL,
        CONSTRAINT [PK_ChiTietHoaDons] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ChiTietHoaDons_HoaDons_Id_HoaDon] FOREIGN KEY ([Id_HoaDon]) REFERENCES [HoaDons] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ChiTietHoaDons_SanPhamBienThes_Id_SanPhamBienThe] FOREIGN KEY ([Id_SanPhamBienThe]) REFERENCES [SanPhamBienThes] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE INDEX [IX_AuthHistories_IdentityId] ON [AuthHistories] ([IdentityId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE INDEX [IX_ChiTietHoaDons_Id_HoaDon] ON [ChiTietHoaDons] ([Id_HoaDon]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE INDEX [IX_ChiTietHoaDons_Id_SanPhamBienThe] ON [ChiTietHoaDons] ([Id_SanPhamBienThe]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE INDEX [IX_HoaDons_Id_User] ON [HoaDons] ([Id_User]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE INDEX [IX_ImageSanPhams_IdSanPham] ON [ImageSanPhams] ([IdSanPham]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE INDEX [IX_JobSeekers_Id_Identity] ON [JobSeekers] ([Id_Identity]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE INDEX [IX_MauSacs_Id_Loai] ON [MauSacs] ([Id_Loai]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE INDEX [IX_SanPhamBienThes_Id_Mau] ON [SanPhamBienThes] ([Id_Mau]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE INDEX [IX_SanPhamBienThes_Id_SanPham] ON [SanPhamBienThes] ([Id_SanPham]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE INDEX [IX_SanPhamBienThes_SizeId] ON [SanPhamBienThes] ([SizeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE INDEX [IX_SanPhams_Id_Loai] ON [SanPhams] ([Id_Loai]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE INDEX [IX_SanPhams_Id_NhanHieu] ON [SanPhams] ([Id_NhanHieu]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    CREATE INDEX [IX_Sizes_Id_Loai] ON [Sizes] ([Id_Loai]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628015702_v1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210628015702_v1', N'5.0.4');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628115736_v2')
BEGIN
    ALTER TABLE [ImageSanPhams] DROP CONSTRAINT [FK_ImageSanPhams_SanPhams_IdSanPham];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628115736_v2')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ImageSanPhams]') AND [c].[name] = N'IdSanPham');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ImageSanPhams] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [ImageSanPhams] ALTER COLUMN [IdSanPham] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628115736_v2')
BEGIN
    ALTER TABLE [ImageSanPhams] ADD CONSTRAINT [FK_ImageSanPhams_SanPhams_IdSanPham] FOREIGN KEY ([IdSanPham]) REFERENCES [SanPhams] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628115736_v2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210628115736_v2', N'5.0.4');
END;
GO

COMMIT;
GO

