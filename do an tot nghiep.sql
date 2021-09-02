USE [db_datn_fake]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
	[DiaChi] [nvarchar](max) NULL,
	[SDT] [nvarchar](max) NULL,
	[ImagePath] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Quyen] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDons]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Soluong] [int] NOT NULL,
	[ThanhTien] [decimal](18, 2) NOT NULL,
	[Id_HoaDon] [int] NULL,
	[Id_SanPhamBienThe] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhapHangs]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhapHangs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SoluongNhap] [int] NOT NULL,
	[ThanhTienNhap] [decimal](18, 2) NOT NULL,
	[Id_PhieuNhapHang] [int] NULL,
	[Id_SanPhamBienThe] [int] NULL,
 CONSTRAINT [PK_ChiTietPhieuNhapHangs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDons]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NgayTao] [datetime2](7) NOT NULL,
	[GhiChu] [nvarchar](max) NULL,
	[TrangThai] [nvarchar](max) NULL,
	[LoaiThanhToan] [nvarchar](max) NULL,
	[DaLayTien] [nvarchar](max) NULL,
	[TongTien] [decimal](18, 2) NOT NULL,
	[Id_User] [nvarchar](450) NULL,
 CONSTRAINT [PK_HoaDons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageSanPhams]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageSanPhams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageName] [nvarchar](max) NULL,
	[IdSanPham] [int] NULL,
 CONSTRAINT [PK_ImageSanPhams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loais]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loais](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](max) NULL,
 CONSTRAINT [PK_Loais] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaGiamGias]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaGiamGias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NULL,
	[SoPhanTramGiam] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_MaGiamGias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MauSacs]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MauSacs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaMau] [nvarchar](max) NULL,
	[Id_Loai] [int] NULL,
 CONSTRAINT [PK_MauSacs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCaps]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCaps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](max) NOT NULL,
	[SDT] [nvarchar](max) NULL,
	[ThongTin] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](max) NULL,
 CONSTRAINT [PK_NhaCungCaps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanHieus]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanHieus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](max) NULL,
	[DateCreate] [datetime2](7) NULL,
 CONSTRAINT [PK_NhanHieus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotificationCheckouts]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotificationCheckouts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ThongBaoMaDonHang] [int] NOT NULL,
 CONSTRAINT [PK_NotificationCheckouts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](max) NULL,
	[TranType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhapHangs]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhapHangs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SoChungTu] [nvarchar](max) NULL,
	[NgayTao] [datetime2](7) NOT NULL,
	[TongTien] [decimal](18, 2) NOT NULL,
	[NguoiLapPhieu] [nvarchar](450) NULL,
	[GhiChu] [nvarchar](max) NULL,
	[Id_NhaCungCap] [int] NOT NULL,
 CONSTRAINT [PK_PhieuNhapHangs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPhamBienThes]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPhamBienThes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_SanPham] [int] NULL,
	[Id_Mau] [int] NULL,
	[SoLuongTon] [int] NOT NULL,
	[SizeId] [int] NULL,
 CONSTRAINT [PK_SanPhamBienThes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPhams]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPhams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
	[GiaBan] [decimal](18, 0) NULL,
	[GiaNhap] [decimal](18, 0) NULL,
	[KhuyenMai] [decimal](18, 0) NULL,
	[Tag] [nvarchar](max) NULL,
	[HuongDan] [nvarchar](max) NULL,
	[ThanhPhan] [nvarchar](max) NULL,
	[NgayCapNhat] [datetime2](7) NULL,
	[NgayTao] [datetime2](7) NULL,
	[TrangThaiSanPham] [nvarchar](max) NULL,
	[TrangThaiHoatDong] [bit] NULL,
	[GioiTinh] [int] NULL,
	[Id_NhanHieu] [int] NULL,
	[Id_Loai] [int] NULL,
	[Id_NhaCungCap] [int] NULL,
 CONSTRAINT [PK_SanPhams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sizes]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sizes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenSize] [nvarchar](max) NULL,
	[Id_Loai] [int] NULL,
 CONSTRAINT [PK_Sizes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserComments]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserComments](
	[IdAppUser] [nvarchar](450) NOT NULL,
	[IdSanPham] [int] NOT NULL,
	[TrangThaiHienThi] [bit] NOT NULL,
	[Content] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserComments] PRIMARY KEY CLUSTERED 
(
	[IdSanPham] ASC,
	[IdAppUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLikes]    Script Date: 02/09/2021 10:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLikes](
	[IdAppUser] [nvarchar](450) NOT NULL,
	[IdSanPham] [int] NOT NULL,
 CONSTRAINT [PK_UserLikes] PRIMARY KEY CLUSTERED 
(
	[IdSanPham] ASC,
	[IdAppUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210812034558_v1', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210812224522_v2', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210812230257_v3', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210812232130_v4', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210812234211_v5', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210813115757_v6', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210813120512_v7', N'5.0.4')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [DiaChi], [SDT], [ImagePath], [FirstName], [LastName], [Quyen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'AppUser', N'Bình Dương', N'0982232335', NULL, N'Tran ', N'Quy Vinh', N'Admin', N'vinh@gmail.com', N'VINH@GMAIL.COM', N'vinh@gmail.com', N'VINH@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEOID7rCcsfLuxKE3NdFdbtLmfYtTPwK0DV6HVuQWdb5/gpZTa5/HKsYmIt+IF97RdA==', N'JTSOPWIFADEKZR44H2P7TEK6ZTQACUMB', N'a5ec91a9-8653-400d-98d9-944fbfa72554', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [DiaChi], [SDT], [ImagePath], [FirstName], [LastName], [Quyen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'4f672e3d-1e94-4fa5-962e-6f7dff335cfe', N'AppUser', N'Bình Dương', N'0865245266', NULL, N'Tran', N'Chi Nhan', N'User', N'nhan@gmail.com', N'NHAN@GMAIL.COM', N'nhan@gmail.com', N'NHAN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEHuWJqGLqDyTb2bvaDgMrbhZaJGvGLXX5nSIHt5Ck/THT7wUTe7qh8kGKbVdmRyvzg==', N'3ADWWHI7I6KYWYX5C2U77HWX7WHVLFOB', N'741f13b9-9af9-460b-840b-2a6f30587a97', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [DiaChi], [SDT], [ImagePath], [FirstName], [LastName], [Quyen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'53cc4f58-ec9e-4bc7-96b4-c3cbe7aba309', N'AppUser', N'Quảng Ngãi', N'0965326303', NULL, N'Tran Duc', N'Hai', N'User', N'hai@gmail.com', N'HAI@GMAIL.COM', N'hai@gmail.com', N'HAI@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEBKxky3PXdXwyakA+dintIfzvY5iroSOt9kh7AMyKAEPjWpoNZzpTCPyLS0MuqDI8g==', N'VH25I4QWWAR4OAWISKTUS2RYNWVHRSTJ', N'631c9dc7-63d5-43d8-b103-73e4dda2ccf0', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [DiaChi], [SDT], [ImagePath], [FirstName], [LastName], [Quyen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'7af327e9-0019-46e4-be38-31d2a84d80ef', N'AppUser', N'Bến Tre', N'0965875332', NULL, N'Pham', N'Phuong Tuan', N'User', N'tuan@gmail.com', N'TUAN@GMAIL.COM', N'tuan@gmail.com', N'TUAN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEIdwzkTf9js+Ty/29WymgLqfgaqsZoe8skNJoFgy2bl0uGXrMXrk9autatrDGteIaA==', N'VHD5NH2SR32IKQAWSYHIQQK3ONOL57JS', N'41f84ce9-3fdb-42a5-9e94-c995b2c793ea', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [DiaChi], [SDT], [ImagePath], [FirstName], [LastName], [Quyen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ce18aa96-6af6-4fb3-a3a4-104fcbc0f91b', N'AppUser', N'Vũng Tàu', N'0865232564', NULL, N'Dinh Van', N'Dung', N'User', N'dung@gmail.com', N'DUNG@GMAIL.COM', N'dung@gmail.com', N'DUNG@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKjqes+6ZRBxwT4uNUziLI6TrSHSXy3wT3EbkCyGRCpafS+MNGnZgDvl/TgU3buUwg==', N'G6GGDOYQE2FCHRDQYYAOHU367OWL7DBZ', N'246ac420-b268-4126-bb60-454c0d96928d', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[ChiTietHoaDons] ON 

INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (1, 4, CAST(102800.00 AS Decimal(18, 2)), 1, 8)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (2, 5, CAST(256500.00 AS Decimal(18, 2)), 1, 10)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (3, 2, CAST(82200.00 AS Decimal(18, 2)), 1, 2)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (4, 1, CAST(41100.00 AS Decimal(18, 2)), 1, 15)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (5, 3, CAST(123300.00 AS Decimal(18, 2)), 2, 2)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (6, 3, CAST(153900.00 AS Decimal(18, 2)), 2, 1)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (7, 5, CAST(256500.00 AS Decimal(18, 2)), 2, 6)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (8, 1, CAST(41100.00 AS Decimal(18, 2)), 2, 15)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (9, 3, CAST(123300.00 AS Decimal(18, 2)), 3, 15)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (10, 3, CAST(153900.00 AS Decimal(18, 2)), 3, 10)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (11, 5, CAST(256500.00 AS Decimal(18, 2)), 3, 6)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (12, 1, CAST(25700.00 AS Decimal(18, 2)), 3, 9)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (13, 5, CAST(256500.00 AS Decimal(18, 2)), 4, 7)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (14, 2, CAST(51400.00 AS Decimal(18, 2)), 4, 11)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (15, 5, CAST(128500.00 AS Decimal(18, 2)), 4, 4)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (16, 1, CAST(51300.00 AS Decimal(18, 2)), 4, 1)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (17, 2, CAST(102600.00 AS Decimal(18, 2)), 5, 5)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (18, 2, CAST(102600.00 AS Decimal(18, 2)), 5, 16)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (19, 5, CAST(205500.00 AS Decimal(18, 2)), 5, 2)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe]) VALUES (20, 5, CAST(256500.00 AS Decimal(18, 2)), 5, 1)
SET IDENTITY_INSERT [dbo].[ChiTietHoaDons] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietPhieuNhapHangs] ON 

INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (1, 100, CAST(1570000.00 AS Decimal(18, 2)), 1, 31)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (2, 150, CAST(2355000.00 AS Decimal(18, 2)), 1, 21)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (3, 150, CAST(4665000.00 AS Decimal(18, 2)), 1, 21)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (4, 250, CAST(7775000.00 AS Decimal(18, 2)), 1, 30)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (5, 50, CAST(1555000.00 AS Decimal(18, 2)), 1, 30)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (6, 250, CAST(7775000.00 AS Decimal(18, 2)), 2, 39)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (7, 100, CAST(3110000.00 AS Decimal(18, 2)), 2, 10)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (8, 250, CAST(7775000.00 AS Decimal(18, 2)), 2, 39)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (9, 50, CAST(1555000.00 AS Decimal(18, 2)), 2, 39)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (10, 250, CAST(7775000.00 AS Decimal(18, 2)), 3, 29)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (11, 50, CAST(1555000.00 AS Decimal(18, 2)), 3, 13)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (12, 250, CAST(7775000.00 AS Decimal(18, 2)), 4, 35)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (13, 250, CAST(5325000.00 AS Decimal(18, 2)), 4, 12)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (14, 250, CAST(5325000.00 AS Decimal(18, 2)), 4, 25)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (15, 250, CAST(5325000.00 AS Decimal(18, 2)), 4, 43)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (16, 150, CAST(2355000.00 AS Decimal(18, 2)), 5, 4)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (17, 150, CAST(2355000.00 AS Decimal(18, 2)), 5, 9)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (18, 200, CAST(3140000.00 AS Decimal(18, 2)), 5, 42)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (19, 200, CAST(3140000.00 AS Decimal(18, 2)), 5, 26)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (20, 200, CAST(8040000.00 AS Decimal(18, 2)), 6, 5)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (21, 50, CAST(2010000.00 AS Decimal(18, 2)), 6, 16)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (22, 50, CAST(2010000.00 AS Decimal(18, 2)), 6, 19)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (23, 50, CAST(2010000.00 AS Decimal(18, 2)), 6, 6)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (24, 150, CAST(6750000.00 AS Decimal(18, 2)), 7, 37)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (25, 150, CAST(6750000.00 AS Decimal(18, 2)), 7, 37)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (26, 50, CAST(2250000.00 AS Decimal(18, 2)), 7, 37)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (27, 100, CAST(2130000.00 AS Decimal(18, 2)), 8, 36)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (28, 100, CAST(2130000.00 AS Decimal(18, 2)), 8, 22)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (29, 200, CAST(6220000.00 AS Decimal(18, 2)), 8, 22)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (30, 100, CAST(4500000.00 AS Decimal(18, 2)), 9, 37)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (31, 200, CAST(9000000.00 AS Decimal(18, 2)), 9, 37)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (32, 100, CAST(1570000.00 AS Decimal(18, 2)), 10, 34)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (33, 150, CAST(2355000.00 AS Decimal(18, 2)), 10, 34)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (1027, 150, CAST(2355000.00 AS Decimal(18, 2)), 1008, 34)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (1028, 50, CAST(785000.00 AS Decimal(18, 2)), 1008, 34)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (1029, 100, CAST(1570000.00 AS Decimal(18, 2)), 1009, 21)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (1030, 250, CAST(3925000.00 AS Decimal(18, 2)), 1009, 21)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (2027, 100, CAST(3110000.00 AS Decimal(18, 2)), 2009, 39)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (2028, 100, CAST(3110000.00 AS Decimal(18, 2)), 2009, 39)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (2029, 100, CAST(3110000.00 AS Decimal(18, 2)), 2009, 39)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (2030, 100, CAST(2130000.00 AS Decimal(18, 2)), 2010, 1)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (2031, 100, CAST(2130000.00 AS Decimal(18, 2)), 2010, 1)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (2032, 100, CAST(1570000.00 AS Decimal(18, 2)), 2011, 21)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (2033, 100, CAST(1570000.00 AS Decimal(18, 2)), 2011, 21)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (2034, 100, CAST(1570000.00 AS Decimal(18, 2)), 2011, 21)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (3027, 100, CAST(1570000.00 AS Decimal(18, 2)), 3008, 4)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (3028, 200, CAST(3140000.00 AS Decimal(18, 2)), 3008, 4)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (3029, 200, CAST(3140000.00 AS Decimal(18, 2)), 3008, 8)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (3030, 100, CAST(1570000.00 AS Decimal(18, 2)), 3009, 31)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (3031, 200, CAST(3140000.00 AS Decimal(18, 2)), 3009, 21)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (3032, 50, CAST(1555000.00 AS Decimal(18, 2)), 3009, 21)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (3033, 100, CAST(2130000.00 AS Decimal(18, 2)), 3010, 12)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (3034, 100, CAST(2130000.00 AS Decimal(18, 2)), 3010, 33)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (3035, 250, CAST(5325000.00 AS Decimal(18, 2)), 3010, 33)
SET IDENTITY_INSERT [dbo].[ChiTietPhieuNhapHangs] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDons] ON 

INSERT [dbo].[HoaDons] ([Id], [NgayTao], [GhiChu], [TrangThai], [LoaiThanhToan], [DaLayTien], [TongTien], [Id_User]) VALUES (1, CAST(N'2021-08-12T13:59:31.1618827' AS DateTime2), N'Giao hàng gọi trước 15p', N'Chờ xác nhận', N'Tiền mặt', N'Rồi', CAST(482600.00 AS Decimal(18, 2)), N'4f672e3d-1e94-4fa5-962e-6f7dff335cfe')
INSERT [dbo].[HoaDons] ([Id], [NgayTao], [GhiChu], [TrangThai], [LoaiThanhToan], [DaLayTien], [TongTien], [Id_User]) VALUES (2, CAST(N'2021-08-12T14:00:34.7401406' AS DateTime2), N'Giao hàng gọi trước 15p', N'Chờ xác nhận', N'Online', N'Rồi', CAST(574800.00 AS Decimal(18, 2)), N'4f672e3d-1e94-4fa5-962e-6f7dff335cfe')
INSERT [dbo].[HoaDons] ([Id], [NgayTao], [GhiChu], [TrangThai], [LoaiThanhToan], [DaLayTien], [TongTien], [Id_User]) VALUES (3, CAST(N'2021-08-12T14:01:54.2251812' AS DateTime2), N'Đứng ở đường lớn gọi ra lấy hàng', N'Chờ xác nhận', N'Tiền mặt', N'Rồi', CAST(559400.00 AS Decimal(18, 2)), N'7af327e9-0019-46e4-be38-31d2a84d80ef')
INSERT [dbo].[HoaDons] ([Id], [NgayTao], [GhiChu], [TrangThai], [LoaiThanhToan], [DaLayTien], [TongTien], [Id_User]) VALUES (4, CAST(N'2021-08-12T14:03:43.0181593' AS DateTime2), N'Đứng ở đường lớn gọi điện ra lấy hàng', N'Chờ xác nhận', N'Tiền mặt', N'Rồi', CAST(487700.00 AS Decimal(18, 2)), N'ce18aa96-6af6-4fb3-a3a4-104fcbc0f91b')
INSERT [dbo].[HoaDons] ([Id], [NgayTao], [GhiChu], [TrangThai], [LoaiThanhToan], [DaLayTien], [TongTien], [Id_User]) VALUES (5, CAST(N'2021-08-12T14:06:07.4153492' AS DateTime2), N'Đứng ở đường lớn gọi điện ra lấy hàng', N'Chờ xác nhận', N'Tiền mặt', N'Rồi', CAST(667200.00 AS Decimal(18, 2)), N'4f672e3d-1e94-4fa5-962e-6f7dff335cfe')
SET IDENTITY_INSERT [dbo].[HoaDons] OFF
GO
SET IDENTITY_INSERT [dbo].[ImageSanPhams] ON 

INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (1, N'Quần short1.jpg', 1)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (2, N'Quần short2.jpg', 1)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (6, N'Áo Thun Nam SADBOIZ0.jpg', 2)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (7, N'Áo Thun Nam SADBOIZ1.jpg', 2)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (8, N'Áo Thun Nam SADBOIZ2.jpg', 2)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (12, N'Giày AF1 trắng12.jpg', 4)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (13, N'Giày AF1 trắng13.jpg', 4)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (14, N'Áo khoác bò 14.jpg', 5)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (15, N'Áo khoác bò 15.jpg', 5)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (16, N'Áo khoác bò 16.jpg', 5)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (17, N'Đồng hồ Nữ Army17.jpg', 6)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (18, N'Đồng hồ Nữ Army18.jpg', 6)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (19, N'Đồng hồ Nữ Army19.jpg', 6)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (20, N'Áo Polo20.jpg', 7)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (21, N'Áo Polo21.jpg', 7)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (22, N'Áo Polo22.jpg', 7)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (25, N'Quần đùi0.jpg', 8)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (26, N'Quần đùi1.jpg', 8)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (27, N'Thắt Lưng Da Bò SÁP27.jpg', 9)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (28, N'Thắt Lưng Da Bò SÁP28.jpg', 9)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (29, N'Quần short29.jpg', 10)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (30, N'Quần short30.jpg', 10)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (31, N'Quần short31.jpg', 10)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (32, N'Áo Thun Nam Thể Thao32.jpg', 11)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (33, N'Áo Thun Nam Thể Thao33.jpg', 11)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (34, N'Áo thun Bad Habits ROCKER34.jpg', 12)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (35, N'Áo thun Bad Habits ROCKER35.jpg', 12)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (36, N'Đồng Hồ Nam Crnaira Japan C307936.jpg', 13)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (37, N'Đồng Hồ Nam Crnaira Japan C307937.jpg', 13)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (38, N'Đồng Hồ Nam Crnaira Japan C307938.jpg', 13)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (39, N'GIÀY NỮ AIR TRẮNG39.jpg', 14)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (40, N'GIÀY NỮ AIR TRẮNG40.jpg', 14)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (41, N'Đồng hồ WR unisex dây hơp kim CS141.jpg', 15)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (42, N'Đồng hồ WR unisex dây hơp kim CS142.jpg', 15)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (43, N'Đồng Hồ Nam Crnaira Japan C307943.jpg', 16)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (44, N'Đồng Hồ Nam Crnaira Japan C307944.jpg', 16)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (48, N'Áo sơ mi trơn big size LADOS 0.jpg', 18)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (49, N'Áo sơ mi trơn big size LADOS 1.jpg', 18)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (50, N'Áo Polo0.jpg', 3)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (51, N'Áo Polo1.jpg', 3)
SET IDENTITY_INSERT [dbo].[ImageSanPhams] OFF
GO
SET IDENTITY_INSERT [dbo].[Loais] ON 

INSERT [dbo].[Loais] ([Id], [Ten]) VALUES (1, N'Áo')
INSERT [dbo].[Loais] ([Id], [Ten]) VALUES (2, N'Quần')
INSERT [dbo].[Loais] ([Id], [Ten]) VALUES (3, N'Đồng hồ')
INSERT [dbo].[Loais] ([Id], [Ten]) VALUES (4, N'Phụ kiện')
INSERT [dbo].[Loais] ([Id], [Ten]) VALUES (5, N'Giày')
SET IDENTITY_INSERT [dbo].[Loais] OFF
GO
SET IDENTITY_INSERT [dbo].[MaGiamGias] ON 

INSERT [dbo].[MaGiamGias] ([Id], [Code], [SoPhanTramGiam]) VALUES (1, N'HSFJA', CAST(19.00 AS Decimal(18, 2)))
INSERT [dbo].[MaGiamGias] ([Id], [Code], [SoPhanTramGiam]) VALUES (2, N'DKILG', CAST(13.00 AS Decimal(18, 2)))
INSERT [dbo].[MaGiamGias] ([Id], [Code], [SoPhanTramGiam]) VALUES (3, N'UOSPM', CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[MaGiamGias] ([Id], [Code], [SoPhanTramGiam]) VALUES (4, N'U0GIA', CAST(12.00 AS Decimal(18, 2)))
INSERT [dbo].[MaGiamGias] ([Id], [Code], [SoPhanTramGiam]) VALUES (5, N'IQEDN', CAST(17.00 AS Decimal(18, 2)))
INSERT [dbo].[MaGiamGias] ([Id], [Code], [SoPhanTramGiam]) VALUES (6, N'HVRYX', CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[MaGiamGias] ([Id], [Code], [SoPhanTramGiam]) VALUES (7, N'J8M2U', CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[MaGiamGias] ([Id], [Code], [SoPhanTramGiam]) VALUES (8, N'3B06S', CAST(3.00 AS Decimal(18, 2)))
INSERT [dbo].[MaGiamGias] ([Id], [Code], [SoPhanTramGiam]) VALUES (9, N'BYNIV', CAST(6.00 AS Decimal(18, 2)))
INSERT [dbo].[MaGiamGias] ([Id], [Code], [SoPhanTramGiam]) VALUES (10, N'HW9Z1', CAST(15.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[MaGiamGias] OFF
GO
SET IDENTITY_INSERT [dbo].[MauSacs] ON 

INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (1, N'xanh dương', 1)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (2, N'đỏ', 1)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (3, N'vàng', 2)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (4, N'trắng', 3)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (5, N'xanh dương', 3)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (6, N'trắng', 3)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (7, N'vàng', 2)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (8, N'đỏ', 2)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (9, N'vàng', 4)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (10, N'trắng', 3)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (11, N'trắng', 5)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (12, N'vàng', 4)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (13, N'trắng', 1)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (14, N'đỏ', 1)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (15, N'đen', 1)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (16, N'vàng', 3)
SET IDENTITY_INSERT [dbo].[MauSacs] OFF
GO
SET IDENTITY_INSERT [dbo].[NhaCungCaps] ON 

INSERT [dbo].[NhaCungCaps] ([Id], [Ten], [SDT], [ThongTin], [DiaChi]) VALUES (1, N'Công Ty Cổ Phần May Phú Thịnh - Nhà Bè', N'(028) 38650561', N'Chuyên cung cấp quần áo giày dép các loại, rất hân hạnh được phục vụ quý khách', N'13A, Tống Văn Trân, Phường 5, Quận 11 Tp. Hồ Chí Minh (TPHCM)')
INSERT [dbo].[NhaCungCaps] ([Id], [Ten], [SDT], [ThongTin], [DiaChi]) VALUES (2, N'An Dương - Công Ty TNHH Thương Mại Thời Trang An Dương', N'(024) 36415898', N'	Chuyên cung cấp quần áo giày dép các loại, rất hân hạnh được phục vụ quý khách', N'Phòng 106, C4 Khu Đô Thị Mới Đại Kim,Q. Hoàng Mai, Hà Nội')
INSERT [dbo].[NhaCungCaps] ([Id], [Ten], [SDT], [ThongTin], [DiaChi]) VALUES (3, N'Công Ty CP Đầu Tư K&G Việt Nam', N'(024) 37880111', N'	Chuyên cung cấp quần áo giày dép các loại, rất hân hạnh được phục vụ quý khách', N'Tầng 11, Khối A, Tòa nhà Sông Đà, Đ. Phạm Hùng, P. Mỹ Đình 1, Q. Nam Từ Liêm, Hà Nội')
INSERT [dbo].[NhaCungCaps] ([Id], [Ten], [SDT], [ThongTin], [DiaChi]) VALUES (4, N'Công Ty TNHH May Trần Trúc', N'(028) 38752526', N'	Chuyên cung cấp quần áo giày dép các loại, rất hân hạnh được phục vụ quý khách', N'292 - 294 Nguyễn Văn Luông, P. 12, Q. 6, Tp. Hồ Chí Minh')
INSERT [dbo].[NhaCungCaps] ([Id], [Ten], [SDT], [ThongTin], [DiaChi]) VALUES (5, N'Công Ty TNHH Thương Mại Dịch Vụ Delta Vina', N'0909324068', N'	Chuyên cung cấp quần áo giày dép các loại, rất hân hạnh được phục vụ quý khách', N'2/28/3 Đường TMT12, P. Trung Mỹ Tây, Q. 12, Tp. Hồ Chí Minh (TPHCM)')
INSERT [dbo].[NhaCungCaps] ([Id], [Ten], [SDT], [ThongTin], [DiaChi]) VALUES (6, N'Xưởng Dáng Ngọc', N'0948246556', N'	Chuyên cung cấp quần áo giày dép các loại, rất hân hạnh được phục vụ quý khách', N'29 Mai Văn Vĩnh, P. Tân Quý, Q. 7, Tp. Hồ Chí Minh (TPHCM)')
INSERT [dbo].[NhaCungCaps] ([Id], [Ten], [SDT], [ThongTin], [DiaChi]) VALUES (7, N'May Gia Hồi - Công Ty TNHH Gia Hồi', N'(028) 38106981', N'	Chuyên cung cấp quần áo giày dép các loại, rất hân hạnh được phục vụ quý khách', N'20/41 Hồ Đắc Di, P. Tây Thạnh, Q. Tân Phú, Tp. Hồ Chí Minh (TPHCM)')
INSERT [dbo].[NhaCungCaps] ([Id], [Ten], [SDT], [ThongTin], [DiaChi]) VALUES (8, N'Công ty may mặc Hải Châu', N'028 963 654', N'Chuyên cung cấp hàng quần áo', N'205 Bình Thạnh TP-HCM')
INSERT [dbo].[NhaCungCaps] ([Id], [Ten], [SDT], [ThongTin], [DiaChi]) VALUES (9, N'Xưởng May Bình Dương', N'028 975 563', N'Chuyên may quần áo', N'206 Lê Lợi Thị Xã Thuận An Tỉnh Bình Dương')
INSERT [dbo].[NhaCungCaps] ([Id], [Ten], [SDT], [ThongTin], [DiaChi]) VALUES (10, N'Công ty TNHH một thành viên Đồng Nai Một', N'0987 635 236', N'Chuyên cung cấp giày đép', N'189 QL51 Đồng Nai')
INSERT [dbo].[NhaCungCaps] ([Id], [Ten], [SDT], [ThongTin], [DiaChi]) VALUES (11, N'Công ty UI', N'028 789 546', N'	Chuyên cung cấp quần áo giày dép các loại, rất hân hạnh được phục vụ quý khách', N'36 Nguyễn Thị Minh Khai Bình Dương')
SET IDENTITY_INSERT [dbo].[NhaCungCaps] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanHieus] ON 

INSERT [dbo].[NhanHieus] ([Id], [Ten], [DateCreate]) VALUES (1, N'ZERO', CAST(N'2021-08-12T12:54:04.2387953' AS DateTime2))
INSERT [dbo].[NhanHieus] ([Id], [Ten], [DateCreate]) VALUES (2, N'Nelly', CAST(N'2021-08-12T12:54:12.2748796' AS DateTime2))
INSERT [dbo].[NhanHieus] ([Id], [Ten], [DateCreate]) VALUES (3, N'Gucci', CAST(N'2021-08-12T12:54:20.3139413' AS DateTime2))
INSERT [dbo].[NhanHieus] ([Id], [Ten], [DateCreate]) VALUES (4, N'Yody', CAST(N'2021-08-12T12:54:26.2602799' AS DateTime2))
INSERT [dbo].[NhanHieus] ([Id], [Ten], [DateCreate]) VALUES (5, N'WIND', CAST(N'2021-08-12T12:54:32.6632051' AS DateTime2))
INSERT [dbo].[NhanHieus] ([Id], [Ten], [DateCreate]) VALUES (6, N'5S', CAST(N'2021-08-12T12:54:39.1983749' AS DateTime2))
INSERT [dbo].[NhanHieus] ([Id], [Ten], [DateCreate]) VALUES (7, N'MADE LEN', CAST(N'2021-08-12T12:54:46.0194193' AS DateTime2))
INSERT [dbo].[NhanHieus] ([Id], [Ten], [DateCreate]) VALUES (8, N'HLF', CAST(N'2021-08-12T12:54:52.0588264' AS DateTime2))
INSERT [dbo].[NhanHieus] ([Id], [Ten], [DateCreate]) VALUES (9, N'CV', CAST(N'2021-08-12T13:03:45.3909943' AS DateTime2))
SET IDENTITY_INSERT [dbo].[NhanHieus] OFF
GO
SET IDENTITY_INSERT [dbo].[NotificationCheckouts] ON 

INSERT [dbo].[NotificationCheckouts] ([Id], [ThongBaoMaDonHang]) VALUES (1, 1)
INSERT [dbo].[NotificationCheckouts] ([Id], [ThongBaoMaDonHang]) VALUES (2, 2)
INSERT [dbo].[NotificationCheckouts] ([Id], [ThongBaoMaDonHang]) VALUES (3, 3)
INSERT [dbo].[NotificationCheckouts] ([Id], [ThongBaoMaDonHang]) VALUES (4, 4)
INSERT [dbo].[NotificationCheckouts] ([Id], [ThongBaoMaDonHang]) VALUES (5, 5)
SET IDENTITY_INSERT [dbo].[NotificationCheckouts] OFF
GO
SET IDENTITY_INSERT [dbo].[Notifications] ON 

INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (1, N'Áo', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (2, N'Quần', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (3, N'Đồng hồ', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (4, N'Phụ kiện', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (5, N'ZERO', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (6, N'Nelly', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (7, N'Gucci', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (8, N'Yody', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (9, N'WIND', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (10, N'5S', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (11, N'MADE LEN', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (12, N'HLF', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (13, N'Quần short', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (14, N'Áo Thun Nam SADBOIZ', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (15, N'Áo Thun Nam SADBOIZ', N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (16, N'Áo Polo', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (17, N'Giày', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (18, N'CV', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (19, N'Giày AF1 trắng', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (20, N'Áo khoác bò ', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (21, N'Đồng hồ Nữ Army', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (22, N'Áo Polo', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (23, N'Quần đùi', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (24, N'Quần đùi', N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (25, N'Thắt Lưng Da Bò SÁP', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (26, N'Quần short', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (27, N'Áo Thun Nam Thể Thao', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (28, N'Áo thun Bad Habits ROCKER', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (29, N'Đồng Hồ Nam Crnaira Japan C3079', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (30, N'GIÀY NỮ AIR TRẮNG', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (31, N'xanh dương', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (32, N'đỏ', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (33, N'vàng', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (34, N'trắng', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (35, N'xanh dương', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (36, N'trắng', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (37, N'vàng', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (38, N'đỏ', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (39, N'vàng', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (40, N'trắng', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (41, N'trắng', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (42, N'XL', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (43, N'XL', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (44, N'L', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (45, N'40', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (46, N'41', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (47, N'L', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (48, N'XL', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (49, N'L', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (50, N'XL', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (51, N'39', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (52, N'M', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (53, N'XL', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (54, N'XL', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (55, N'XL', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (56, N'vàng', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (57, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (58, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (59, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (60, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (61, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (62, N'Đồng hồ WR unisex dây hơp kim CS1', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (63, N'trắng', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (64, N'đỏ', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (65, N'đen', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (66, N'vàng', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (67, N'vàng', N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (68, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (69, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (70, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (71, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (72, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (73, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (74, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (75, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (76, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (77, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (78, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (79, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (80, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (81, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (82, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (83, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (84, N'Đồng Hồ Nam Crnaira Japan C3079', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (85, N'Áo khoác bò ', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (86, N'Áo sơ mi trơn big size LADOS ', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (87, N'Áo sơ mi trơn big size LADOS ', N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (88, N'Áo Polo', N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (89, N'Áo khoác bò ', N'Delete')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (90, N'39', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (91, N'41', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (92, N'40', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (93, N'38', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (94, NULL, N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (95, NULL, N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (96, NULL, N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (97, NULL, N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (98, NULL, N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (100, NULL, N'Edit')
GO
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (101, NULL, N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (102, NULL, N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (103, NULL, N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (104, NULL, N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (105, NULL, N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (106, NULL, N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (107, NULL, N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (108, NULL, N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (109, N'Giày dsadas', N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (110, N'Giày', N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (111, N'SFC', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (112, N'XL', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (117, N'Test', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (118, N'Test', N'Delete')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (119, N'SFC', N'Delete')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (120, NULL, N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (121, NULL, N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (122, NULL, N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (123, NULL, N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (124, NULL, N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (125, NULL, N'Edit')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (1088, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (2088, NULL, N'Add')
SET IDENTITY_INSERT [dbo].[Notifications] OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuNhapHangs] ON 

INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (1, N'KEE8HR7', CAST(N'2021-08-15T10:37:21.6120205' AS DateTime2), CAST(17920000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'Ship nhanh lên nhá', 5)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (2, N'A6LU7MO', CAST(N'2021-08-15T10:41:12.8526874' AS DateTime2), CAST(20215000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'Ship nhanh lên', 4)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (3, N'DALP1BS', CAST(N'2021-08-15T10:42:30.6565610' AS DateTime2), CAST(9330000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'Ship nhanh lên', 4)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (4, N'DIQ3LW0', CAST(N'2021-08-15T20:33:22.1796752' AS DateTime2), CAST(23750000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'Ship nhanh lên', 1)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (5, N'CN2KURY', CAST(N'2021-08-15T20:37:58.1245067' AS DateTime2), CAST(10990000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'Ship nhanh lên', 2)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (6, N'BVXV88F', CAST(N'2021-08-15T20:48:34.6089493' AS DateTime2), CAST(14070000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'Ship nhanh lên', 9)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (7, N'YXQAB3Q', CAST(N'2021-08-15T20:52:11.5211382' AS DateTime2), CAST(15750000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'Ship nhanh lên', 10)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (8, N'TR0NB8R', CAST(N'2021-08-16T17:55:33.3810812' AS DateTime2), CAST(10480000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'Ship nhanh lên', 3)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (9, N'I23FMJ4', CAST(N'2021-08-16T17:56:48.3604372' AS DateTime2), CAST(13500000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'Ship nhanh lên', 10)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (10, N'3Z4OXH1', CAST(N'2021-08-16T20:27:34.0753244' AS DateTime2), CAST(3925000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'Ship nhanh !!!', 8)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (1008, N'7373Z56', CAST(N'2021-08-18T10:31:39.6440273' AS DateTime2), CAST(3140000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'ship nhanh lên', 8)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (1009, N'NMVFK49', CAST(N'2021-08-18T10:35:21.7983044' AS DateTime2), CAST(5495000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'ship nhanh lên', 5)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (2008, N'AD3Z6NZ', CAST(N'2021-08-22T09:04:23.0061013' AS DateTime2), CAST(6220000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'dasdsadsa', 1)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (2009, N'2X46PSG', CAST(N'2021-08-22T09:04:55.7042370' AS DateTime2), CAST(9330000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'dssadsa', 4)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (2010, N'LH65AV9', CAST(N'2021-08-22T09:26:37.8539090' AS DateTime2), CAST(4260000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'fdsfds', 1)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (2011, N'EOVFAKK', CAST(N'2021-08-22T09:27:43.1038992' AS DateTime2), CAST(4710000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'dsadsa', 5)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (3008, N'FC7YEUF', CAST(N'2021-08-24T18:02:18.5934452' AS DateTime2), CAST(7850000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'Ship aaaaaaaa', 2)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (3009, N'3LVRMR7', CAST(N'2021-08-24T19:19:40.0838136' AS DateTime2), CAST(6265000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'ship', 5)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (3010, N'1DGOOPF', CAST(N'2021-08-25T17:00:08.3655549' AS DateTime2), CAST(9585000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'Ship nhanh lên', 1)
SET IDENTITY_INSERT [dbo].[PhieuNhapHangs] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPhamBienThes] ON 

INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (1, 1, 7, 200, 11)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (2, 4, 11, 0, 17)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (3, 1, 9, 0, 1)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (4, 2, 3, 450, 3)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (5, 6, 4, 200, 2)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (6, 6, 3, 50, 3)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (7, 3, 5, 0, 3)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (8, 2, 4, 200, 2)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (9, 2, 6, 150, 3)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (10, 5, 5, 100, 3)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (11, 2, 5, 0, 1)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (12, 1, 7, 350, 2)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (13, 15, 7, 50, 2)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (14, 4, 5, 0, 2)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (15, 14, 6, 0, 2)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (16, 6, 5, 50, 7)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (17, 3, 5, 0, 5)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (18, 3, 9, 0, 5)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (19, 6, 2, 50, 4)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (20, 4, 6, 0, 1)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (21, 13, 1, 1200, 12)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (22, 8, 1, 300, 11)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (23, 8, 5, 0, 12)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (25, 1, 2, 250, 11)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (26, 2, 2, 200, 11)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (28, 16, 7, 0, 12)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (29, 15, 9, 250, 5)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (30, 14, 7, 300, 9)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (31, 13, 8, 200, 9)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (32, 12, 9, 0, 6)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (33, 1, 3, 350, 9)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (34, 10, 8, 450, 6)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (35, 9, 12, 250, 13)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (36, 14, 11, 100, 17)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (37, 7, 6, 650, 6)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (38, 6, 6, 0, 6)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (39, 5, 15, 850, 6)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (40, 4, 10, 0, 9)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (41, 3, 10, 0, 10)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (42, 2, 9, 200, 9)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (43, 6, 6, 250, 18)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (44, 5, 1, 0, 6)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (1044, 3, 2, 0, 14)
SET IDENTITY_INSERT [dbo].[SanPhamBienThes] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPhams] ON 

INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap]) VALUES (1, N'Quần short', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', CAST(41100 AS Decimal(18, 0)), CAST(21300 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Fashion', N'Đối với một người đàn ông hiện đại thì vẻ bề ngoài rất quan trọng, ngoài những bộ suit lịch lãm thì phụ kiện đồng hồ cũng là điểm nhấn không thể thiếu trên cổ tay của họ. Vì thế một chiếc đồng hồ đẹp cho nam luôn là mục đích tìm kiếm của đa số đàn ông hiện nay.', N'Vải Thun Lạnh co giãn 4 chiều, thoáng mát, mềm mịn mát mẻ, phù hợp với mọi hoạt động dã ngoại, thể thao, hay dạo phố.', NULL, CAST(N'2021-08-12T12:56:14.4115611' AS DateTime2), N'thuong', 1, 1, 5, 2, 1)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap]) VALUES (2, N'Áo Thun Nam SADBOIZ', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', CAST(25700 AS Decimal(18, 0)), CAST(15700 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Fashion', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', N'Vải Thun Lạnh co giãn 4 chiều, thoáng mát, mềm mịn mát mẻ, phù hợp với mọi hoạt động dã ngoại, thể thao, hay dạo phố.', CAST(N'2021-08-12T12:58:13.4029597' AS DateTime2), CAST(N'2021-08-12T12:57:16.2634773' AS DateTime2), N'new', 1, 1, 2, 1, 2)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap]) VALUES (3, N'Áo Polo', N'Đối với một người đàn ông hiện đại thì vẻ bề ngoài rất quan trọng, ngoài những bộ suit lịch lãm thì phụ kiện đồng hồ cũng là điểm nhấn không thể thiếu trên cổ tay của họ. Vì thế một chiếc đồng hồ đẹp cho nam luôn là mục đích tìm kiếm của đa số đàn ông hiện nay.', CAST(51300 AS Decimal(18, 0)), CAST(31100 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Features', N'Đối với một người đàn ông hiện đại thì vẻ bề ngoài rất quan trọng, ngoài những bộ suit lịch lãm thì phụ kiện đồng hồ cũng là điểm nhấn không thể thiếu trên cổ tay của họ. Vì thế một chiếc đồng hồ đẹp cho nam luôn là mục đích tìm kiếm của đa số đàn ông hiện nay.', N'Vải Thun Lạnh co giãn 4 chiều, thoáng mát, mềm mịn mát mẻ, phù hợp với mọi hoạt động dã ngoại, thể thao, hay dạo phố.', CAST(N'2021-08-16T17:58:38.3497666' AS DateTime2), CAST(N'2021-08-12T12:59:04.6463289' AS DateTime2), N'hot', 1, 1, 4, 1, 3)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap]) VALUES (4, N'Giày AF1 trắng', N'Mang đến hình ảnh là một người lịch lãm, nhưng không kém phần thanh lịch, thời trang giày nổi bật cùng dáng xỏ tiện lợi giúp bạn có thể sử dụng ở bất cứ đâu.', CAST(41100 AS Decimal(18, 0)), CAST(21300 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Fashion', N'Mẫu quần tây đen công sở cạp lưng cao Form thoải mái, không quá ôm và quá đứng dáng đâu các nàng ạ, mặc lên vừa thoải mái vận động mà vẫn đứng dáng. Các nàng có thể mặc quần tây nữ công sở phối áo sơ mi mặc đi làm, đi chơi, học sinh mặc đi học đều xinh ạ.', N'Thân giày thể thao chủ yếu sử dụng vật liệu mesh (lưới), da tự nhiên hoặc da nhân tạo. ', NULL, CAST(N'2021-08-12T13:04:30.8796285' AS DateTime2), N'new', 1, 1, 8, 1, 4)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap]) VALUES (5, N'Áo khoác bò ', N'Mẫu quần tây đen công sở cạp lưng cao Form thoải mái, không quá ôm và quá đứng dáng đâu các nàng ạ, mặc lên vừa thoải mái vận động mà vẫn đứng dáng. Các nàng có thể mặc quần tây nữ công sở phối áo sơ mi mặc đi làm, đi chơi, học sinh mặc đi học đều xinh ạ.', CAST(51300 AS Decimal(18, 0)), CAST(31100 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Fashion', N'Đối với một người đàn ông hiện đại thì vẻ bề ngoài rất quan trọng, ngoài những bộ suit lịch lãm thì phụ kiện đồng hồ cũng là điểm nhấn không thể thiếu trên cổ tay của họ. Vì thế một chiếc đồng hồ đẹp cho nam luôn là mục đích tìm kiếm của đa số đàn ông hiện nay.', N'Vải Thun Lạnh co giãn 4 chiều, thoáng mát, mềm mịn mát mẻ, phù hợp với mọi hoạt động dã ngoại, thể thao, hay dạo phố.', NULL, CAST(N'2021-08-12T13:05:03.6877124' AS DateTime2), N'hot', 1, 1, 1, 1, 4)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap]) VALUES (6, N'Đồng hồ Nữ Army', N'Đối với một người đàn ông hiện đại thì vẻ bề ngoài rất quan trọng, ngoài những bộ suit lịch lãm thì phụ kiện đồng hồ cũng là điểm nhấn không thể thiếu trên cổ tay của họ. Vì thế một chiếc đồng hồ đẹp cho nam luôn là mục đích tìm kiếm của đa số đàn ông hiện nay.', CAST(51300 AS Decimal(18, 0)), CAST(40200 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Fashion', N'Mang đến hình ảnh là một người lịch lãm, nhưng không kém phần thanh lịch, thời trang giày nổi bật cùng dáng xỏ tiện lợi giúp bạn có thể sử dụng ở bất cứ đâu.', N'Kim loại', NULL, CAST(N'2021-08-12T13:09:32.0415359' AS DateTime2), N'hot', 1, 2, 6, 3, 9)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap]) VALUES (7, N'Áo Polo', N'Mẫu quần tây đen công sở cạp lưng cao Form thoải mái, không quá ôm và quá đứng dáng đâu các nàng ạ, mặc lên vừa thoải mái vận động mà vẫn đứng dáng. Các nàng có thể mặc quần tây nữ công sở phối áo sơ mi mặc đi làm, đi chơi, học sinh mặc đi học đều xinh ạ.', CAST(65000 AS Decimal(18, 0)), CAST(45000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Features', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', N'Thân giày thể thao chủ yếu sử dụng vật liệu mesh (lưới), da tự nhiên hoặc da nhân tạo. ', NULL, CAST(N'2021-08-12T13:10:07.9218113' AS DateTime2), N'hot', 1, 2, 3, 1, 10)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap]) VALUES (8, N'Quần đùi', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', CAST(41100 AS Decimal(18, 0)), CAST(21300 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Fashion', N'Mẫu quần tây đen công sở cạp lưng cao Form thoải mái, không quá ôm và quá đứng dáng đâu các nàng ạ, mặc lên vừa thoải mái vận động mà vẫn đứng dáng. Các nàng có thể mặc quần tây nữ công sở phối áo sơ mi mặc đi làm, đi chơi, học sinh mặc đi học đều xinh ạ.', N'Vải Thun Lạnh co giãn 4 chiều, thoáng mát, mềm mịn mát mẻ, phù hợp với mọi hoạt động dã ngoại, thể thao, hay dạo phố.', CAST(N'2021-08-12T13:13:47.4260597' AS DateTime2), CAST(N'2021-08-12T13:10:51.3667411' AS DateTime2), N'new', 1, 2, 2, 2, 3)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap]) VALUES (9, N'Thắt Lưng Da Bò SÁP', N'Mẫu quần tây đen công sở cạp lưng cao Form thoải mái, không quá ôm và quá đứng dáng đâu các nàng ạ, mặc lên vừa thoải mái vận động mà vẫn đứng dáng. Các nàng có thể mặc quần tây nữ công sở phối áo sơ mi mặc đi làm, đi chơi, học sinh mặc đi học đều xinh ạ.', CAST(51300 AS Decimal(18, 0)), CAST(31100 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Features', N'Mẫu quần tây đen công sở cạp lưng cao Form thoải mái, không quá ôm và quá đứng dáng đâu các nàng ạ, mặc lên vừa thoải mái vận động mà vẫn đứng dáng. Các nàng có thể mặc quần tây nữ công sở phối áo sơ mi mặc đi làm, đi chơi, học sinh mặc đi học đều xinh ạ.', N'Thân giày thể thao chủ yếu sử dụng vật liệu mesh (lưới), da tự nhiên hoặc da nhân tạo. ', NULL, CAST(N'2021-08-12T13:14:22.6892976' AS DateTime2), N'new', 1, 1, 4, 4, 1)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap]) VALUES (10, N'Quần short', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', CAST(25700 AS Decimal(18, 0)), CAST(15700 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Fashion', N'Mẫu quần tây đen công sở cạp lưng cao Form thoải mái, không quá ôm và quá đứng dáng đâu các nàng ạ, mặc lên vừa thoải mái vận động mà vẫn đứng dáng. Các nàng có thể mặc quần tây nữ công sở phối áo sơ mi mặc đi làm, đi chơi, học sinh mặc đi học đều xinh ạ.', N'Vải Thun Lạnh co giãn 4 chiều, thoáng mát, mềm mịn mát mẻ, phù hợp với mọi hoạt động dã ngoại, thể thao, hay dạo phố.', NULL, CAST(N'2021-08-12T13:15:25.2460935' AS DateTime2), N'thuong', 1, 2, 2, 2, 8)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap]) VALUES (11, N'Áo Thun Nam Thể Thao', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', CAST(51300 AS Decimal(18, 0)), CAST(31100 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Features', N'Mẫu quần tây đen công sở cạp lưng cao Form thoải mái, không quá ôm và quá đứng dáng đâu các nàng ạ, mặc lên vừa thoải mái vận động mà vẫn đứng dáng. Các nàng có thể mặc quần tây nữ công sở phối áo sơ mi mặc đi làm, đi chơi, học sinh mặc đi học đều xinh ạ.', N'Thân giày thể thao chủ yếu sử dụng vật liệu mesh (lưới), da tự nhiên hoặc da nhân tạo. ', NULL, CAST(N'2021-08-12T13:16:44.4216173' AS DateTime2), N'new', 1, 1, 8, 1, 3)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap]) VALUES (12, N'Áo thun Bad Habits ROCKER', N'Đối với một người đàn ông hiện đại thì vẻ bề ngoài rất quan trọng, ngoài những bộ suit lịch lãm thì phụ kiện đồng hồ cũng là điểm nhấn không thể thiếu trên cổ tay của họ. Vì thế một chiếc đồng hồ đẹp cho nam luôn là mục đích tìm kiếm của đa số đàn ông hiện nay.', CAST(51300 AS Decimal(18, 0)), CAST(31100 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Features', N'Mẫu quần tây đen công sở cạp lưng cao Form thoải mái, không quá ôm và quá đứng dáng đâu các nàng ạ, mặc lên vừa thoải mái vận động mà vẫn đứng dáng. Các nàng có thể mặc quần tây nữ công sở phối áo sơ mi mặc đi làm, đi chơi, học sinh mặc đi học đều xinh ạ.', N'Kaki ', NULL, CAST(N'2021-08-12T13:17:23.7605477' AS DateTime2), N'hot', 1, 1, 1, 1, 6)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap]) VALUES (13, N'Đồng Hồ Nam Crnaira Japan C3079', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', CAST(41100 AS Decimal(18, 0)), CAST(15700 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Fashion', N'Mang đến hình ảnh là một người lịch lãm, nhưng không kém phần thanh lịch, thời trang giày nổi bật cùng dáng xỏ tiện lợi giúp bạn có thể sử dụng ở bất cứ đâu.', N'Kim loại', NULL, CAST(N'2021-08-12T13:18:03.4354188' AS DateTime2), N'hot', 1, 1, 8, 2, 5)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap]) VALUES (14, N'GIÀY NỮ AIR TRẮNG', N'Đối với một người đàn ông hiện đại thì vẻ bề ngoài rất quan trọng, ngoài những bộ suit lịch lãm thì phụ kiện đồng hồ cũng là điểm nhấn không thể thiếu trên cổ tay của họ. Vì thế một chiếc đồng hồ đẹp cho nam luôn là mục đích tìm kiếm của đa số đàn ông hiện nay.', CAST(41100 AS Decimal(18, 0)), CAST(31100 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Features', N'Mang đến hình ảnh là một người lịch lãm, nhưng không kém phần thanh lịch, thời trang giày nổi bật cùng dáng xỏ tiện lợi giúp bạn có thể sử dụng ở bất cứ đâu.', N'Thân giày thể thao chủ yếu sử dụng vật liệu mesh (lưới), da tự nhiên hoặc da nhân tạo. ', NULL, CAST(N'2021-08-12T13:18:47.4222884' AS DateTime2), N'hot', 1, 2, 9, 2, 5)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap]) VALUES (15, N'Đồng hồ WR unisex dây hơp kim CS1', N'Mẫu quần tây đen công sở cạp lưng cao Form thoải mái, không quá ôm và quá đứng dáng đâu các nàng ạ, mặc lên vừa thoải mái vận động mà vẫn đứng dáng. Các nàng có thể mặc quần tây nữ công sở phối áo sơ mi mặc đi làm, đi chơi, học sinh mặc đi học đều xinh ạ.', CAST(51300 AS Decimal(18, 0)), CAST(31100 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Fashion', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', N'Kim loại', NULL, CAST(N'2021-08-12T13:30:24.8745398' AS DateTime2), N'thuong', 1, 1, 2, 3, 4)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap]) VALUES (16, N'Đồng Hồ Nam Crnaira Japan C3079', N'Mẫu quần tây đen công sở cạp lưng cao Form thoải mái, không quá ôm và quá đứng dáng đâu các nàng ạ, mặc lên vừa thoải mái vận động mà vẫn đứng dáng. Các nàng có thể mặc quần tây nữ công sở phối áo sơ mi mặc đi làm, đi chơi, học sinh mặc đi học đều xinh ạ.', CAST(32500 AS Decimal(18, 0)), CAST(15700 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Fashion', N'Đối với một người đàn ông hiện đại thì vẻ bề ngoài rất quan trọng, ngoài những bộ suit lịch lãm thì phụ kiện đồng hồ cũng là điểm nhấn không thể thiếu trên cổ tay của họ. Vì thế một chiếc đồng hồ đẹp cho nam luôn là mục đích tìm kiếm của đa số đàn ông hiện nay.', N'Thân giày thể thao chủ yếu sử dụng vật liệu mesh (lưới), da tự nhiên hoặc da nhân tạo. ', NULL, CAST(N'2021-08-13T11:19:14.0539820' AS DateTime2), N'hot', 1, 1, 3, 1, 7)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap]) VALUES (18, N'Áo sơ mi trơn big size LADOS ', N'Mẫu quần tây đen công sở cạp lưng cao Form thoải mái, không quá ôm và quá đứng dáng đâu các nàng ạ, mặc lên vừa thoải mái vận động mà vẫn đứng dáng. Các nàng có thể mặc quần tây nữ công sở phối áo sơ mi mặc đi làm, đi chơi, học sinh mặc đi học đều xinh ạ.', CAST(41100 AS Decimal(18, 0)), CAST(15700 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Features', N'Mẫu quần tây đen công sở cạp lưng cao Form thoải mái, không quá ôm và quá đứng dáng đâu các nàng ạ, mặc lên vừa thoải mái vận động mà vẫn đứng dáng. Các nàng có thể mặc quần tây nữ công sở phối áo sơ mi mặc đi làm, đi chơi, học sinh mặc đi học đều xinh ạ.', N'Kaki ', CAST(N'2021-08-15T21:35:55.7260913' AS DateTime2), CAST(N'2021-08-15T21:34:20.9595198' AS DateTime2), N'hot', 0, 2, 2, 1, 4)
SET IDENTITY_INSERT [dbo].[SanPhams] OFF
GO
SET IDENTITY_INSERT [dbo].[Sizes] ON 

INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (1, N'XL', 2)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (2, N'XL', 3)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (3, N'L', 1)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (4, N'40', 3)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (5, N'41', 3)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (6, N'L', 1)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (7, N'XL', 2)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (8, N'L', 2)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (9, N'XL', 2)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (10, N'39', 5)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (11, N'M', 2)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (12, N'XL', 2)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (13, N'XL', 4)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (14, N'XL', 1)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (15, N'39', 5)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (16, N'41', 5)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (17, N'40', 5)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (18, N'38', 3)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (19, N'XL', 4)
SET IDENTITY_INSERT [dbo].[Sizes] OFF
GO
INSERT [dbo].[UserComments] ([IdAppUser], [IdSanPham], [TrangThaiHienThi], [Content]) VALUES (N'3f34da33-53bd-4c54-9735-66dea19d7af0', 2, 1, N'Sản phẩm rất tốt')
INSERT [dbo].[UserComments] ([IdAppUser], [IdSanPham], [TrangThaiHienThi], [Content]) VALUES (N'3f34da33-53bd-4c54-9735-66dea19d7af0', 4, 1, N'Rất thoải mái')
INSERT [dbo].[UserComments] ([IdAppUser], [IdSanPham], [TrangThaiHienThi], [Content]) VALUES (N'7af327e9-0019-46e4-be38-31d2a84d80ef', 6, 1, N'Shop cần nhập sản phẩm này về nhiều hơn')
GO
INSERT [dbo].[UserLikes] ([IdAppUser], [IdSanPham]) VALUES (N'3f34da33-53bd-4c54-9735-66dea19d7af0', 8)
INSERT [dbo].[UserLikes] ([IdAppUser], [IdSanPham]) VALUES (N'7af327e9-0019-46e4-be38-31d2a84d80ef', 7)
INSERT [dbo].[UserLikes] ([IdAppUser], [IdSanPham]) VALUES (N'7af327e9-0019-46e4-be38-31d2a84d80ef', 8)
GO
ALTER TABLE [dbo].[PhieuNhapHangs] ADD  DEFAULT ((0)) FOR [Id_NhaCungCap]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[ChiTietHoaDons]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDons_HoaDons_Id_HoaDon] FOREIGN KEY([Id_HoaDon])
REFERENCES [dbo].[HoaDons] ([Id])
GO
ALTER TABLE [dbo].[ChiTietHoaDons] CHECK CONSTRAINT [FK_ChiTietHoaDons_HoaDons_Id_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDons]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDons_SanPhamBienThes_Id_SanPhamBienThe] FOREIGN KEY([Id_SanPhamBienThe])
REFERENCES [dbo].[SanPhamBienThes] ([Id])
GO
ALTER TABLE [dbo].[ChiTietHoaDons] CHECK CONSTRAINT [FK_ChiTietHoaDons_SanPhamBienThes_Id_SanPhamBienThe]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhapHangs]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhapHangs_PhieuNhapHangs_Id_PhieuNhapHang] FOREIGN KEY([Id_PhieuNhapHang])
REFERENCES [dbo].[PhieuNhapHangs] ([Id])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhapHangs] CHECK CONSTRAINT [FK_ChiTietPhieuNhapHangs_PhieuNhapHangs_Id_PhieuNhapHang]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhapHangs]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhapHangs_SanPhamBienThes_Id_SanPhamBienThe] FOREIGN KEY([Id_SanPhamBienThe])
REFERENCES [dbo].[SanPhamBienThes] ([Id])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhapHangs] CHECK CONSTRAINT [FK_ChiTietPhieuNhapHangs_SanPhamBienThes_Id_SanPhamBienThe]
GO
ALTER TABLE [dbo].[HoaDons]  WITH CHECK ADD  CONSTRAINT [FK_HoaDons_AspNetUsers_Id_User] FOREIGN KEY([Id_User])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[HoaDons] CHECK CONSTRAINT [FK_HoaDons_AspNetUsers_Id_User]
GO
ALTER TABLE [dbo].[ImageSanPhams]  WITH CHECK ADD  CONSTRAINT [FK_ImageSanPhams_SanPhams_IdSanPham] FOREIGN KEY([IdSanPham])
REFERENCES [dbo].[SanPhams] ([Id])
GO
ALTER TABLE [dbo].[ImageSanPhams] CHECK CONSTRAINT [FK_ImageSanPhams_SanPhams_IdSanPham]
GO
ALTER TABLE [dbo].[MauSacs]  WITH CHECK ADD  CONSTRAINT [FK_MauSacs_Loais_Id_Loai] FOREIGN KEY([Id_Loai])
REFERENCES [dbo].[Loais] ([Id])
GO
ALTER TABLE [dbo].[MauSacs] CHECK CONSTRAINT [FK_MauSacs_Loais_Id_Loai]
GO
ALTER TABLE [dbo].[PhieuNhapHangs]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhapHangs_AspNetUsers_NguoiLapPhieu] FOREIGN KEY([NguoiLapPhieu])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[PhieuNhapHangs] CHECK CONSTRAINT [FK_PhieuNhapHangs_AspNetUsers_NguoiLapPhieu]
GO
ALTER TABLE [dbo].[PhieuNhapHangs]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhapHangs_NhaCungCaps_Id_NhaCungCap] FOREIGN KEY([Id_NhaCungCap])
REFERENCES [dbo].[NhaCungCaps] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhieuNhapHangs] CHECK CONSTRAINT [FK_PhieuNhapHangs_NhaCungCaps_Id_NhaCungCap]
GO
ALTER TABLE [dbo].[SanPhamBienThes]  WITH CHECK ADD  CONSTRAINT [FK_SanPhamBienThes_MauSacs_Id_Mau] FOREIGN KEY([Id_Mau])
REFERENCES [dbo].[MauSacs] ([Id])
GO
ALTER TABLE [dbo].[SanPhamBienThes] CHECK CONSTRAINT [FK_SanPhamBienThes_MauSacs_Id_Mau]
GO
ALTER TABLE [dbo].[SanPhamBienThes]  WITH CHECK ADD  CONSTRAINT [FK_SanPhamBienThes_SanPhams_Id_SanPham] FOREIGN KEY([Id_SanPham])
REFERENCES [dbo].[SanPhams] ([Id])
GO
ALTER TABLE [dbo].[SanPhamBienThes] CHECK CONSTRAINT [FK_SanPhamBienThes_SanPhams_Id_SanPham]
GO
ALTER TABLE [dbo].[SanPhamBienThes]  WITH CHECK ADD  CONSTRAINT [FK_SanPhamBienThes_Sizes_SizeId] FOREIGN KEY([SizeId])
REFERENCES [dbo].[Sizes] ([Id])
GO
ALTER TABLE [dbo].[SanPhamBienThes] CHECK CONSTRAINT [FK_SanPhamBienThes_Sizes_SizeId]
GO
ALTER TABLE [dbo].[SanPhams]  WITH CHECK ADD  CONSTRAINT [FK_SanPhams_Loais_Id_Loai] FOREIGN KEY([Id_Loai])
REFERENCES [dbo].[Loais] ([Id])
GO
ALTER TABLE [dbo].[SanPhams] CHECK CONSTRAINT [FK_SanPhams_Loais_Id_Loai]
GO
ALTER TABLE [dbo].[SanPhams]  WITH CHECK ADD  CONSTRAINT [FK_SanPhams_NhaCungCaps_Id_NhaCungCap] FOREIGN KEY([Id_NhaCungCap])
REFERENCES [dbo].[NhaCungCaps] ([Id])
GO
ALTER TABLE [dbo].[SanPhams] CHECK CONSTRAINT [FK_SanPhams_NhaCungCaps_Id_NhaCungCap]
GO
ALTER TABLE [dbo].[SanPhams]  WITH CHECK ADD  CONSTRAINT [FK_SanPhams_NhanHieus_Id_NhanHieu] FOREIGN KEY([Id_NhanHieu])
REFERENCES [dbo].[NhanHieus] ([Id])
GO
ALTER TABLE [dbo].[SanPhams] CHECK CONSTRAINT [FK_SanPhams_NhanHieus_Id_NhanHieu]
GO
ALTER TABLE [dbo].[Sizes]  WITH CHECK ADD  CONSTRAINT [FK_Sizes_Loais_Id_Loai] FOREIGN KEY([Id_Loai])
REFERENCES [dbo].[Loais] ([Id])
GO
ALTER TABLE [dbo].[Sizes] CHECK CONSTRAINT [FK_Sizes_Loais_Id_Loai]
GO
ALTER TABLE [dbo].[UserComments]  WITH CHECK ADD  CONSTRAINT [FK_UserComments_AspNetUsers_IdAppUser] FOREIGN KEY([IdAppUser])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserComments] CHECK CONSTRAINT [FK_UserComments_AspNetUsers_IdAppUser]
GO
ALTER TABLE [dbo].[UserComments]  WITH CHECK ADD  CONSTRAINT [FK_UserComments_SanPhams_IdSanPham] FOREIGN KEY([IdSanPham])
REFERENCES [dbo].[SanPhams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserComments] CHECK CONSTRAINT [FK_UserComments_SanPhams_IdSanPham]
GO
ALTER TABLE [dbo].[UserLikes]  WITH CHECK ADD  CONSTRAINT [FK_UserLikes_AspNetUsers_IdAppUser] FOREIGN KEY([IdAppUser])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLikes] CHECK CONSTRAINT [FK_UserLikes_AspNetUsers_IdAppUser]
GO
ALTER TABLE [dbo].[UserLikes]  WITH CHECK ADD  CONSTRAINT [FK_UserLikes_SanPhams_IdSanPham] FOREIGN KEY([IdSanPham])
REFERENCES [dbo].[SanPhams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLikes] CHECK CONSTRAINT [FK_UserLikes_SanPhams_IdSanPham]
GO
