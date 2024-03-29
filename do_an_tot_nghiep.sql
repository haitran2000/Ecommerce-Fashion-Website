USE [db_datn_fake]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 15/11/2021 7:18:21 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 15/11/2021 7:18:21 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 15/11/2021 7:18:21 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 15/11/2021 7:18:21 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 15/11/2021 7:18:21 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 15/11/2021 7:18:21 PM ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 15/11/2021 7:18:21 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 15/11/2021 7:18:21 PM ******/
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
/****** Object:  Table [dbo].[AuthHistories]    Script Date: 15/11/2021 7:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthHistories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdentityId] [nvarchar](450) NULL,
 CONSTRAINT [PK_AuthHistories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 15/11/2021 7:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](max) NULL,
	[NoiDung] [nvarchar](max) NULL,
	[FkAppUser_NguoiThem] [nvarchar](450) NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calendar]    Script Date: 15/11/2021 7:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calendar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ToDo] [nvarchar](max) NULL,
	[IdUser] [nvarchar](450) NULL,
	[Time] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Calendar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 15/11/2021 7:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[CartID] [int] IDENTITY(1,1) NOT NULL,
	[Gia] [decimal](18, 2) NULL,
	[Mau] [nvarchar](max) NULL,
	[Size] [nvarchar](max) NULL,
	[UserID] [nvarchar](450) NULL,
	[SanPhamId] [int] NOT NULL,
	[Id_SanPhamBienThe] [int] NULL,
	[SoLuong] [int] NOT NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[CartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDons]    Script Date: 15/11/2021 7:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Soluong] [int] NOT NULL,
	[ThanhTien] [decimal](18, 2) NULL,
	[Id_HoaDon] [int] NULL,
	[Id_SanPhamBienThe] [int] NULL,
	[GiaBan] [decimal](18, 2) NULL,
	[Id_SanPham] [int] NULL,
	[Mau] [nvarchar](max) NULL,
	[Size] [nvarchar](max) NULL,
	[HoaDonId] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhapHangs]    Script Date: 15/11/2021 7:18:21 PM ******/
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
/****** Object:  Table [dbo].[HoaDons]    Script Date: 15/11/2021 7:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NgayTao] [datetime2](7) NOT NULL,
	[GhiChu] [nvarchar](max) NULL,
	[TrangThai] [int] NULL,
	[Xa] [nvarchar](max) NULL,
	[TongTien] [decimal](18, 2) NOT NULL,
	[Id_User] [nvarchar](450) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[Huyen] [nvarchar](max) NULL,
	[Tinh] [nvarchar](max) NULL,
 CONSTRAINT [PK_HoaDons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageBlogs]    Script Date: 15/11/2021 7:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageBlogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageName] [nvarchar](max) NULL,
	[FkBlogId] [int] NULL,
 CONSTRAINT [PK_ImageBlogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageSanPhams]    Script Date: 15/11/2021 7:18:21 PM ******/
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
/****** Object:  Table [dbo].[JobSeekers]    Script Date: 15/11/2021 7:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobSeekers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Identity] [nvarchar](450) NULL,
	[Location] [nvarchar](max) NULL,
 CONSTRAINT [PK_JobSeekers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loais]    Script Date: 15/11/2021 7:18:21 PM ******/
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
/****** Object:  Table [dbo].[MaGiamGias]    Script Date: 15/11/2021 7:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaGiamGias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NULL,
	[SoTienGiam] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_MaGiamGias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MauSacs]    Script Date: 15/11/2021 7:18:21 PM ******/
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
/****** Object:  Table [dbo].[NhaCungCaps]    Script Date: 15/11/2021 7:18:21 PM ******/
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
/****** Object:  Table [dbo].[NhanHieus]    Script Date: 15/11/2021 7:18:21 PM ******/
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
/****** Object:  Table [dbo].[NotificationCheckouts]    Script Date: 15/11/2021 7:18:21 PM ******/
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
/****** Object:  Table [dbo].[Notifications]    Script Date: 15/11/2021 7:18:21 PM ******/
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
/****** Object:  Table [dbo].[PhieuNhapHangs]    Script Date: 15/11/2021 7:18:21 PM ******/
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
/****** Object:  Table [dbo].[SanPhamBienThes]    Script Date: 15/11/2021 7:18:21 PM ******/
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
/****** Object:  Table [dbo].[SanPhams]    Script Date: 15/11/2021 7:18:21 PM ******/
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
	[NhanHieuId] [int] NULL,
 CONSTRAINT [PK_SanPhams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sizes]    Script Date: 15/11/2021 7:18:21 PM ******/
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
/****** Object:  Table [dbo].[UserChats]    Script Date: 15/11/2021 7:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserChats](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContentChat] [nvarchar](max) NULL,
	[TimeChat] [datetime2](7) NOT NULL,
	[IdUser] [nvarchar](450) NULL,
 CONSTRAINT [PK_UserChats] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserComments]    Script Date: 15/11/2021 7:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserComments](
	[IdSanPham] [int] NOT NULL,
	[Content] [nvarchar](max) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AppUserId] [nvarchar](450) NULL,
	[IdUser] [nvarchar](max) NULL,
	[NgayComment] [datetime2](7) NULL,
 CONSTRAINT [PK_UserComments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLikes]    Script Date: 15/11/2021 7:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLikes](
	[IdSanPham] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AppUserId] [nvarchar](450) NULL,
	[IdUser] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserLikes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210812034558_v1', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210812224522_v2', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210812230257_v3', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210812232130_v4', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210812234211_v5', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210813115757_v6', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210813120512_v7', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210913041500_v8', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210917092028_v9', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210917092109_v10', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211106174219_v11', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211109095746_v12', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211109100340_v13', N'5.0.4')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [DiaChi], [SDT], [ImagePath], [FirstName], [LastName], [Quyen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'1e85ffbf-126a-4192-8116-caa454ac393d', N'AppUser', N'Ấp 4 Bình Dương', N'0868420530', NULL, N'Admin', N'', N'Admin', N'admin@gmail.com', N'ADMIN@GMAIL.COM', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEIxwT6BtY5NLHjLJ3aBmpmvVWnHuDxf8knQBWDjoBWuYWPNgfq29Ripy343pP7U23w==', N'A4BXU34ZMNA62CHU43MB3I32QCVJHUCL', N'0f4e0f41-467a-4255-8443-cc07980336d9', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [DiaChi], [SDT], [ImagePath], [FirstName], [LastName], [Quyen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'37cb2728-7ab2-4a1f-9035-b4b68dbed8a4', N'AppUser', N'Quảng Ngãi', NULL, NULL, N'Nguyễn Văn', N'Qúy', N'Customer', N'hai21@gmail.com', N'HAI21@GMAIL.COM', N'hai21@gmail.com', N'HAI21@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEHdMhQKqILTLUCaDZK1XhIfW3eI3QWu0BoVoo0koBZDqAH+okQqr8sCkviQSWmlvPw==', N'MEXA3NZDCY6LJG6YB2G2JMPOQ3MFADUM', N'af977ed4-3560-406d-bb31-307b03d25a87', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [DiaChi], [SDT], [ImagePath], [FirstName], [LastName], [Quyen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'AppUser', N'Bình Dương', N'0982232335', NULL, N'Tran ', N'Quy Vinh', N'Admin', N'vinh@gmail.com', N'VINH@GMAIL.COM', N'vinh@gmail.com', N'VINH@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEOID7rCcsfLuxKE3NdFdbtLmfYtTPwK0DV6HVuQWdb5/gpZTa5/HKsYmIt+IF97RdA==', N'JTSOPWIFADEKZR44H2P7TEK6ZTQACUMB', N'a5ec91a9-8653-400d-98d9-944fbfa72554', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [DiaChi], [SDT], [ImagePath], [FirstName], [LastName], [Quyen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'4db69aa8-7300-4fce-b81b-f00ac6f13ab9', N'AppUser', N'97 Ung Van Khiem , Phuowng 25, Quan Binh Thanh', N'0935582597', NULL, N'Đoàn Văn', N'Bình', N'Customer', N'vinhnguyen1@gmail.com', N'VINHNGUYEN1@GMAIL.COM', N'vinhnguyen1@gmail.com', N'VINHNGUYEN1@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAELdTQbDII4eSZKB+YVa2jAyv90rtsmokwXSfbcSgbrUp9a1Ua2ZpvndFyLkLIdudnA==', N'PNKKTGCDNZ6YKGGHR6XOJS7BLME3JO7D', N'716b8ae4-20fa-4532-bcaf-1285705a175e', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [DiaChi], [SDT], [ImagePath], [FirstName], [LastName], [Quyen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'4f672e3d-1e94-4fa5-962e-6f7dff335cfe', N'AppUser', N'Bình Dương', N'0865245266', NULL, N'Tran', N'Chi Nhan', N'Customer', N'nhan@gmail.com', N'NHAN@GMAIL.COM', N'nhan@gmail.com', N'NHAN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEHuWJqGLqDyTb2bvaDgMrbhZaJGvGLXX5nSIHt5Ck/THT7wUTe7qh8kGKbVdmRyvzg==', N'3ADWWHI7I6KYWYX5C2U77HWX7WHVLFOB', N'741f13b9-9af9-460b-840b-2a6f30587a97', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [DiaChi], [SDT], [ImagePath], [FirstName], [LastName], [Quyen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'53cc4f58-ec9e-4bc7-96b4-c3cbe7aba309', N'AppUser', N'Quảng Ngãi', N'0965326303', NULL, N'Tran Duc', N'Hai', N'Customer', N'hai@gmail.com', N'HAI@GMAIL.COM', N'hai@gmail.com', N'HAI@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEBKxky3PXdXwyakA+dintIfzvY5iroSOt9kh7AMyKAEPjWpoNZzpTCPyLS0MuqDI8g==', N'VH25I4QWWAR4OAWISKTUS2RYNWVHRSTJ', N'631c9dc7-63d5-43d8-b103-73e4dda2ccf0', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [DiaChi], [SDT], [ImagePath], [FirstName], [LastName], [Quyen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'7af327e9-0019-46e4-be38-31d2a84d80ef', N'AppUser', N'Bến Tre', N'0965875332', NULL, N'Pham', N'Phuong Tuan', N'Customer', N'tuan@gmail.com', N'TUAN@GMAIL.COM', N'tuan@gmail.com', N'TUAN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEIdwzkTf9js+Ty/29WymgLqfgaqsZoe8skNJoFgy2bl0uGXrMXrk9autatrDGteIaA==', N'VHD5NH2SR32IKQAWSYHIQQK3ONOL57JS', N'41f84ce9-3fdb-42a5-9e94-c995b2c793ea', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [DiaChi], [SDT], [ImagePath], [FirstName], [LastName], [Quyen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9185bbf1-7002-4180-ba27-9cc772b3f0a1', N'AppUser', N'Bình Dương', N'01644732089', NULL, N'Phạm Thanh ', N'Tùng', N'Customer', N'haitran1@gmail.com', N'HAITRAN1@GMAIL.COM', N'haitran1@gmail.com', N'HAITRAN1@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEAks5qqkxitT8EbuQHN8PvL4LuF2azE19zF9e5PRtCplokPMrkcd3wAVIqXIsRiMCw==', N'MQIZTZQP2JOSPO442OIQJHO3CTVWB5YI', N'353f32bc-7aa0-4e62-90b9-2455608787c2', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [DiaChi], [SDT], [ImagePath], [FirstName], [LastName], [Quyen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b192ca14-3277-4f4e-8227-dfdd48b8b45e', N'AppUser', N'97 Ung Van Khiem , Phuowng 25, Quan Binh Thanh', N'8796542364', NULL, N'Nguyễn Thị', N'Linh', N'Customer', N'linhnguyen@gmail.com', N'LINHNGUYEN@GMAIL.COM', N'vinhnguyen@gmail.com', N'VINHNGUYEN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEObaHgCb1MmTybpiltzDxQxxCwn9Zwly2YwKAtgDHaehu8G2TDzN17/sA40M1cNFlA==', N'CF6FSSSSV5KOE25T5DI2I2SXD3IB4SR3', N'd38c7539-bf84-4f9e-adbc-041027e76090', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [DiaChi], [SDT], [ImagePath], [FirstName], [LastName], [Quyen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b96485ed-758c-464f-be93-ebff970a3a54', N'AppUser', N'Quảng Ngãi', N'856987023', NULL, N'Đặng ', N'Tuấn Anh', N'Customer', N'tuana@gmail.com', N'TUANA@GMAIL.COM', N'tuana@gmail.com', N'TUANA@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKguvMc1FOfNLzuiBjBkS+i/wF2BBi0zCYClXcpI+Yf+rfRcAkyYxGZ03X+1eY6mdA==', N'FJBYON4TO6JEE2LXNMBEKJRLQP4D3MP2', N'dafb3eab-6417-4d40-87fd-c6c534387387', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [DiaChi], [SDT], [ImagePath], [FirstName], [LastName], [Quyen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c9ca6e23-0da4-4628-bd93-6f2acb88a046', N'AppUser', N'Quảng Ngãi', N'568954236', NULL, N'Trần Trà', N'Mi', N'Customer', N'hai25@gmail.com', N'HAI25@GMAIL.COM', N'hai25@gmail.com', N'HAI25@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEMRhjsbx7V0NDcWusMG2HYIgwTVM8a2kF1xfMZpPCyAjswwgqzZ79DLQR0BRO6+1Qw==', N'EBTVVAF3OCR2I7DHGW2I3IDVUWSP4SFL', N'296cd94e-a838-41b1-97fc-143d8bb2b3bc', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [DiaChi], [SDT], [ImagePath], [FirstName], [LastName], [Quyen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ce18aa96-6af6-4fb3-a3a4-104fcbc0f91b', N'AppUser', N'Vũng Tàu', N'0865232564', NULL, N'Dinh Van', N'Dung', N'Customer', N'dung@gmail.com', N'DUNG@GMAIL.COM', N'dung@gmail.com', N'DUNG@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKjqes+6ZRBxwT4uNUziLI6TrSHSXy3wT3EbkCyGRCpafS+MNGnZgDvl/TgU3buUwg==', N'G6GGDOYQE2FCHRDQYYAOHU367OWL7DBZ', N'246ac420-b268-4126-bb60-454c0d96928d', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [DiaChi], [SDT], [ImagePath], [FirstName], [LastName], [Quyen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'f04b1d20-7e45-4124-986f-08d08232b0cb', N'AppUser', N'Quảng Ngãi', NULL, NULL, N'tran duc', N'hai', N'Customer', N'hai9@gmail.com', N'HAI9@GMAIL.COM', N'hai9@gmail.com', N'HAI9@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEHQVnLIke8yyZSV3dG38o8s9cPLr/e1f/qzcCiQ/8ysgoz1xf7kNRxb7k25K1q/4EA==', N'R7UXEBBD42ZRTD2DJRU6ZH4ZCBE4YAF2', N'e5bbd48f-118c-4b8b-8e0c-13d69fcd00fb', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[AuthHistories] ON 

INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (11, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (33, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (34, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (38, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (48, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (50, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (51, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (52, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (53, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (54, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (57, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (59, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (60, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (61, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (62, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (64, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (65, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (66, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (69, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (70, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (71, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (72, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (73, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (75, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (76, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (77, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (14, N'37cb2728-7ab2-4a1f-9035-b4b68dbed8a4')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (16, N'37cb2728-7ab2-4a1f-9035-b4b68dbed8a4')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (49, N'37cb2728-7ab2-4a1f-9035-b4b68dbed8a4')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (67, N'37cb2728-7ab2-4a1f-9035-b4b68dbed8a4')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (1, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (3, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (12, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (13, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (15, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (17, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (18, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (19, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (20, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (21, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (22, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (23, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (24, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (25, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (26, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (27, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (28, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (29, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (30, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (32, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (35, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (36, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (37, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (39, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (40, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (41, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (42, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (43, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (44, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (45, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (46, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (47, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (63, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (58, N'4db69aa8-7300-4fce-b81b-f00ac6f13ab9')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (2, N'9185bbf1-7002-4180-ba27-9cc772b3f0a1')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (4, N'9185bbf1-7002-4180-ba27-9cc772b3f0a1')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (5, N'9185bbf1-7002-4180-ba27-9cc772b3f0a1')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (6, N'9185bbf1-7002-4180-ba27-9cc772b3f0a1')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (7, N'9185bbf1-7002-4180-ba27-9cc772b3f0a1')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (8, N'9185bbf1-7002-4180-ba27-9cc772b3f0a1')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (9, N'9185bbf1-7002-4180-ba27-9cc772b3f0a1')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (10, N'9185bbf1-7002-4180-ba27-9cc772b3f0a1')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (56, N'b192ca14-3277-4f4e-8227-dfdd48b8b45e')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (55, N'b96485ed-758c-464f-be93-ebff970a3a54')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (68, N'c9ca6e23-0da4-4628-bd93-6f2acb88a046')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (74, N'c9ca6e23-0da4-4628-bd93-6f2acb88a046')
INSERT [dbo].[AuthHistories] ([Id], [IdentityId]) VALUES (31, N'f04b1d20-7e45-4124-986f-08d08232b0cb')
SET IDENTITY_INSERT [dbo].[AuthHistories] OFF
GO
SET IDENTITY_INSERT [dbo].[Blogs] ON 

INSERT [dbo].[Blogs] ([Id], [TieuDe], [NoiDung], [FkAppUser_NguoiThem]) VALUES (1, N'Điểm nhấn của bộ sưu tập Louis Vuitton Cruise 2022', N'<ul><li><a href="https://vnexpress.net/giai-tri">Giải trí</a></li><li><a href="https://vnexpress.net/giai-tri/thoi-trang">Thời trang</a></li></ul><p>Thứ năm, 11/11/2021, 15:30 (GMT+7)</p><h2><strong>Điểm nhấn của bộ sưu tập Louis Vuitton Cruise 2022</strong></h2><p>Bộ sưu tập Cruise 2022 của Louis Vuitton lăng xê màu sắc rực rỡ, họa tiết vũ trụ và các thiết kế lấy cảm hứng từ đồng phục diễu hành.</p><p>Lên kệ tại các cửa hàng Louis Vuitton vào tháng 11, bộ sưu tập Cruise 2022 được giới mộ điệu đánh giá cao chất liệu, kiểu dáng lẫn ý tưởng.</p><p><strong>Phong cách trẻ trung, thanh lịch</strong></p><p>Thoát khỏi chuẩn mực thời trang nghỉ dưỡng thông thường, loạt trang phục mùa 2022 mang hơi thở mới, đậm dấu ấn Space Age cùng loạt phom dáng lạ. Trong đó có váy bồng bềnh nhấn vào chi tiết cổ áo dây xích hay những thiết kế ứng dụng chất liệu bạc ánh kim bắt mắt.</p><p>Vogue và nhiều chuyên trang nhận xét bộ sưu tập kết hợp giữa phong cách trẻ trung, mới lạ nhưng vẫn giữ nét thanh lịch, sang trọng của nhà mốt Pháp.</p>', NULL)
INSERT [dbo].[Blogs] ([Id], [TieuDe], [NoiDung], [FkAppUser_NguoiThem]) VALUES (2, N'Thiết kế của Kim Kardashian thu một triệu USD trong một phút', N'<p>Bộ sưu tập của Kim Kardashian hợp tác Fendi thu về một triệu USD trong 60 giây đầu tiên mở bán online hôm 9/11.</p><p>Theo <i>TMZ</i>, con số đánh dấu kỷ lục doanh thu của thương hiệu Skims trong ba năm phát triển. Bộ sưu tập Skims x Fendi chủ yếu gồm váy áo, nội y và đồ bơi được may ôm sát cơ thể với giá từ 950 USD trở lên. Một số thiết kế đặc biệt được bán cao hơn, như quần legging 1.100 USD, cardigan 1.850 USD, áo khoác lông xù 2.950 USD.</p>', NULL)
INSERT [dbo].[Blogs] ([Id], [TieuDe], [NoiDung], [FkAppUser_NguoiThem]) VALUES (3, N'Đàm Thu Trang có 2 công thức cứ xài đi xài lại', N'<p>Cấp độ đơn giản nhất khi mix combo&nbsp;áo sơ mi&nbsp;+ quần dài của Đàm Thu Trang chính là ưu tiên áo và quần mang tông màu nhã nhặn. Cụ thể, chỉ đơn thuần là mix áo sơ mi trắng với quần jeans, bà xã Cường Đô La đã có ngay vẻ ngoài trẻ trung, tươi tắn và thanh lịch. Đổi gió đi một chút, Đàm Thu Trang sẽ kết hợp áo sơ mi kẻ sọc với <a href="https://tintuconline.com.vn/tags/quan-jeans-217333.vnn">quần jeans</a> trắng, vậy là trông nổi bật, xịn đẹp chẳng thua gì gái Hàn.</p>', NULL)
SET IDENTITY_INSERT [dbo].[Blogs] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietHoaDons] ON 

INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (1, 6, CAST(1542000.00 AS Decimal(18, 2)), 1, 4, CAST(257000.00 AS Decimal(18, 2)), 1, N'Đen', N'M', NULL)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (2, 11, CAST(2827000.00 AS Decimal(18, 2)), 1, 2, CAST(257000.00 AS Decimal(18, 2)), 1, N'Trắng', N'M', NULL)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (3, 6, CAST(3078000.00 AS Decimal(18, 2)), 2, 7, CAST(513000.00 AS Decimal(18, 2)), 2, N'Tím', N'L', NULL)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (4, 6, CAST(3078000.00 AS Decimal(18, 2)), 3, 7, CAST(513000.00 AS Decimal(18, 2)), 2, N'Tím', N'L', NULL)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (5, 250, CAST(128250000.00 AS Decimal(18, 2)), 4, 9, CAST(513000.00 AS Decimal(18, 2)), 4, N'Đen', N'L', NULL)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (6, 4, CAST(1028000.00 AS Decimal(18, 2)), 5, 5, CAST(257000.00 AS Decimal(18, 2)), 3, N'Đen', N'M', NULL)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (7, 5, CAST(2055000.00 AS Decimal(18, 2)), 5, 10, CAST(411000.00 AS Decimal(18, 2)), 5, N'Đỏ', N'M', NULL)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (8, 2, CAST(1500000.00 AS Decimal(18, 2)), 6, 14, CAST(750000.00 AS Decimal(18, 2)), 6, N'Tím', N'L', NULL)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (9, 2, CAST(1026000.00 AS Decimal(18, 2)), 7, 6, CAST(513000.00 AS Decimal(18, 2)), 2, N'Đen', N'M', NULL)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (10, 11, CAST(564300.00 AS Decimal(18, 2)), 8, 7, CAST(51300.00 AS Decimal(18, 2)), 2, N'Tím', N'L', NULL)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (11, 3, CAST(1539000.00 AS Decimal(18, 2)), 8, 6, CAST(513000.00 AS Decimal(18, 2)), 2, N'Đen', N'M', NULL)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (12, 5, CAST(3750000.00 AS Decimal(18, 2)), 9, 14, CAST(750000.00 AS Decimal(18, 2)), 6, N'Tím', N'L', NULL)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (13, 3, CAST(1233000.00 AS Decimal(18, 2)), 9, 18, CAST(411000.00 AS Decimal(18, 2)), 5, N'Vàng', N'M', NULL)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (14, 5, CAST(3010000.00 AS Decimal(18, 2)), 10, 25, CAST(602000.00 AS Decimal(18, 2)), 11, N'Trắng', N'L', NULL)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (15, 10, CAST(6020000.00 AS Decimal(18, 2)), 10, 26, CAST(602000.00 AS Decimal(18, 2)), 11, N'Đen', N'M', NULL)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (16, 7, CAST(2877000.00 AS Decimal(18, 2)), 11, 30, CAST(411000.00 AS Decimal(18, 2)), 13, N'Đen', N'M', NULL)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (17, 10, CAST(4110000.00 AS Decimal(18, 2)), 11, 32, CAST(411000.00 AS Decimal(18, 2)), 13, N'Trắng', N'S', NULL)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (18, 19, CAST(14250000.00 AS Decimal(18, 2)), 12, 14, CAST(750000.00 AS Decimal(18, 2)), 6, N'Tím', N'L', NULL)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (19, 15, CAST(3855000.00 AS Decimal(18, 2)), 12, 5, CAST(257000.00 AS Decimal(18, 2)), 3, N'Đen', N'M', NULL)
INSERT [dbo].[ChiTietHoaDons] ([Id], [Soluong], [ThanhTien], [Id_HoaDon], [Id_SanPhamBienThe], [GiaBan], [Id_SanPham], [Mau], [Size], [HoaDonId]) VALUES (20, 6, CAST(4500000.00 AS Decimal(18, 2)), 12, 23, CAST(750000.00 AS Decimal(18, 2)), 10, N'Tím', N'41', NULL)
SET IDENTITY_INSERT [dbo].[ChiTietHoaDons] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietPhieuNhapHangs] ON 

INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (1, 100, CAST(15700000.00 AS Decimal(18, 2)), 1, 1)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (2, 150, CAST(23550000.00 AS Decimal(18, 2)), 1, 2)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (3, 150, CAST(23550000.00 AS Decimal(18, 2)), 1, 3)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (4, 200, CAST(31400000.00 AS Decimal(18, 2)), 1, 4)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (5, 100, CAST(15700000.00 AS Decimal(18, 2)), 2, 1)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (6, 100, CAST(15700000.00 AS Decimal(18, 2)), 2, 2)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (7, 150, CAST(46650000.00 AS Decimal(18, 2)), 3, 1)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (8, 200, CAST(62200000.00 AS Decimal(18, 2)), 3, 7)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (9, 250, CAST(77750000.00 AS Decimal(18, 2)), 4, 8)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (10, 250, CAST(77750000.00 AS Decimal(18, 2)), 4, 9)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (11, 50, CAST(15550000.00 AS Decimal(18, 2)), 5, 10)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (12, 50, CAST(15550000.00 AS Decimal(18, 2)), 5, 10)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (13, 100, CAST(31100000.00 AS Decimal(18, 2)), 6, 6)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (14, 150, CAST(46650000.00 AS Decimal(18, 2)), 6, 7)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (15, 100, CAST(31100000.00 AS Decimal(18, 2)), 7, 15)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (16, 200, CAST(62200000.00 AS Decimal(18, 2)), 7, 9)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (17, 100, CAST(31100000.00 AS Decimal(18, 2)), 7, 8)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (18, 200, CAST(90000000.00 AS Decimal(18, 2)), 8, 13)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (19, 100, CAST(45000000.00 AS Decimal(18, 2)), 8, 12)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (20, 250, CAST(162500000.00 AS Decimal(18, 2)), 9, 14)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (21, 250, CAST(162500000.00 AS Decimal(18, 2)), 10, 16)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (22, 150, CAST(9750000.00 AS Decimal(18, 2)), 10, 17)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (23, 150, CAST(23550000.00 AS Decimal(18, 2)), 11, 5)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (24, 150, CAST(23550000.00 AS Decimal(18, 2)), 11, 20)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (25, 150, CAST(46650000.00 AS Decimal(18, 2)), 11, 19)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (26, 150, CAST(46650000.00 AS Decimal(18, 2)), 11, 10)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (27, 150, CAST(46650000.00 AS Decimal(18, 2)), 11, 18)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (28, 200, CAST(80400000.00 AS Decimal(18, 2)), 12, 21)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (29, 150, CAST(60300000.00 AS Decimal(18, 2)), 12, 22)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (30, 200, CAST(80400000.00 AS Decimal(18, 2)), 13, 23)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (31, 50, CAST(20100000.00 AS Decimal(18, 2)), 13, 24)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (32, 150, CAST(60300000.00 AS Decimal(18, 2)), 14, 25)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (33, 150, CAST(60300000.00 AS Decimal(18, 2)), 14, 26)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (34, 200, CAST(31400000.00 AS Decimal(18, 2)), 14, 2)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (35, 100, CAST(40200000.00 AS Decimal(18, 2)), 14, 2)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (36, 250, CAST(100500000.00 AS Decimal(18, 2)), 15, 25)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (37, 150, CAST(46650000.00 AS Decimal(18, 2)), 16, 27)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (38, 200, CAST(62200000.00 AS Decimal(18, 2)), 16, 28)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (39, 250, CAST(77750000.00 AS Decimal(18, 2)), 16, 29)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (40, 50, CAST(15550000.00 AS Decimal(18, 2)), 17, 31)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (41, 100, CAST(31100000.00 AS Decimal(18, 2)), 17, 30)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (42, 250, CAST(77750000.00 AS Decimal(18, 2)), 18, 32)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (43, 100, CAST(15700000.00 AS Decimal(18, 2)), 19, 5)
INSERT [dbo].[ChiTietPhieuNhapHangs] ([Id], [SoluongNhap], [ThanhTienNhap], [Id_PhieuNhapHang], [Id_SanPhamBienThe]) VALUES (44, 100, CAST(15700000.00 AS Decimal(18, 2)), 19, 20)
SET IDENTITY_INSERT [dbo].[ChiTietPhieuNhapHangs] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDons] ON 

INSERT [dbo].[HoaDons] ([Id], [NgayTao], [GhiChu], [TrangThai], [Xa], [TongTien], [Id_User], [DiaChi], [Huyen], [Tinh]) VALUES (1, CAST(N'2021-11-10T00:34:07.4891464' AS DateTime2), NULL, 2, NULL, CAST(4369000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'Bình Dương', NULL, NULL)
INSERT [dbo].[HoaDons] ([Id], [NgayTao], [GhiChu], [TrangThai], [Xa], [TongTien], [Id_User], [DiaChi], [Huyen], [Tinh]) VALUES (2, CAST(N'2021-11-10T00:42:02.1291024' AS DateTime2), NULL, 0, NULL, CAST(3078000.00 AS Decimal(18, 2)), N'37cb2728-7ab2-4a1f-9035-b4b68dbed8a4', N'TP - HCM', NULL, NULL)
INSERT [dbo].[HoaDons] ([Id], [NgayTao], [GhiChu], [TrangThai], [Xa], [TongTien], [Id_User], [DiaChi], [Huyen], [Tinh]) VALUES (3, CAST(N'2021-11-10T09:45:45.9897542' AS DateTime2), NULL, 0, NULL, CAST(3078000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', NULL, NULL, NULL)
INSERT [dbo].[HoaDons] ([Id], [NgayTao], [GhiChu], [TrangThai], [Xa], [TongTien], [Id_User], [DiaChi], [Huyen], [Tinh]) VALUES (4, CAST(N'2021-11-11T19:00:30.1405921' AS DateTime2), NULL, 2, NULL, CAST(128250000.00 AS Decimal(18, 2)), N'37cb2728-7ab2-4a1f-9035-b4b68dbed8a4', N'Quảng Ngãi', NULL, NULL)
INSERT [dbo].[HoaDons] ([Id], [NgayTao], [GhiChu], [TrangThai], [Xa], [TongTien], [Id_User], [DiaChi], [Huyen], [Tinh]) VALUES (5, CAST(N'2021-11-11T23:21:19.3003742' AS DateTime2), NULL, 0, NULL, CAST(3083000.00 AS Decimal(18, 2)), N'b96485ed-758c-464f-be93-ebff970a3a54', N'Quảng Ngãi', NULL, NULL)
INSERT [dbo].[HoaDons] ([Id], [NgayTao], [GhiChu], [TrangThai], [Xa], [TongTien], [Id_User], [DiaChi], [Huyen], [Tinh]) VALUES (6, CAST(N'2021-11-12T07:35:52.7501460' AS DateTime2), NULL, 0, N'Xã Thượng Nông', CAST(1500000.00 AS Decimal(18, 2)), N'b192ca14-3277-4f4e-8227-dfdd48b8b45e', N'97 Ung Van Khiem , Phuong 25 , Binh Thanh', N'Huyện Na Hang', N'Tỉnh Tuyên Quang')
INSERT [dbo].[HoaDons] ([Id], [NgayTao], [GhiChu], [TrangThai], [Xa], [TongTien], [Id_User], [DiaChi], [Huyen], [Tinh]) VALUES (7, CAST(N'2021-11-12T08:15:13.2138102' AS DateTime2), NULL, 1, N'Phường Đồng Xuân', CAST(1026000.00 AS Decimal(18, 2)), N'4db69aa8-7300-4fce-b81b-f00ac6f13ab9', N'97 Ung Văn kHiem', N'Quận Hoàn Kiếm', N'Thành phố Hà Nội')
INSERT [dbo].[HoaDons] ([Id], [NgayTao], [GhiChu], [TrangThai], [Xa], [TongTien], [Id_User], [DiaChi], [Huyen], [Tinh]) VALUES (8, CAST(N'2021-11-13T22:53:25.6320883' AS DateTime2), NULL, 0, NULL, CAST(7182000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Bình Dương', NULL, NULL)
INSERT [dbo].[HoaDons] ([Id], [NgayTao], [GhiChu], [TrangThai], [Xa], [TongTien], [Id_User], [DiaChi], [Huyen], [Tinh]) VALUES (9, CAST(N'2021-11-14T14:28:11.8749215' AS DateTime2), NULL, 0, NULL, CAST(4983000.00 AS Decimal(18, 2)), N'3f34da33-53bd-4c54-9735-66dea19d7af0', N'Bình Dương', NULL, NULL)
INSERT [dbo].[HoaDons] ([Id], [NgayTao], [GhiChu], [TrangThai], [Xa], [TongTien], [Id_User], [DiaChi], [Huyen], [Tinh]) VALUES (10, CAST(N'2021-11-14T14:40:03.8656155' AS DateTime2), NULL, 2, NULL, CAST(9030000.00 AS Decimal(18, 2)), N'c9ca6e23-0da4-4628-bd93-6f2acb88a046', N'Quảng Ngãi', NULL, NULL)
INSERT [dbo].[HoaDons] ([Id], [NgayTao], [GhiChu], [TrangThai], [Xa], [TongTien], [Id_User], [DiaChi], [Huyen], [Tinh]) VALUES (11, CAST(N'2021-11-14T16:10:58.9336819' AS DateTime2), NULL, 2, NULL, CAST(6862000.00 AS Decimal(18, 2)), N'c9ca6e23-0da4-4628-bd93-6f2acb88a046', N'Quảng Ngãi', NULL, NULL)
INSERT [dbo].[HoaDons] ([Id], [NgayTao], [GhiChu], [TrangThai], [Xa], [TongTien], [Id_User], [DiaChi], [Huyen], [Tinh]) VALUES (12, CAST(N'2021-11-15T19:13:30.2633428' AS DateTime2), NULL, 2, NULL, CAST(22605000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Ấp 4 Bình Dương', NULL, NULL)
SET IDENTITY_INSERT [dbo].[HoaDons] OFF
GO
SET IDENTITY_INSERT [dbo].[ImageBlogs] ON 

INSERT [dbo].[ImageBlogs] ([Id], [ImageName], [FkBlogId]) VALUES (1, N'Điểm nhấn của bộ sưu tập Louis Vuitton Cruise 20221.jpg', 1)
INSERT [dbo].[ImageBlogs] ([Id], [ImageName], [FkBlogId]) VALUES (2, N'Điểm nhấn của bộ sưu tập Louis Vuitton Cruise 20222.png', 1)
INSERT [dbo].[ImageBlogs] ([Id], [ImageName], [FkBlogId]) VALUES (3, N'Thiết kế của Kim Kardashian thu một triệu USD trong một phút3.jpg', 2)
INSERT [dbo].[ImageBlogs] ([Id], [ImageName], [FkBlogId]) VALUES (8, N'Đàm Thu Trang có 2 công thức cứ xài đi xài lại0.jpg', 3)
SET IDENTITY_INSERT [dbo].[ImageBlogs] OFF
GO
SET IDENTITY_INSERT [dbo].[ImageSanPhams] ON 

INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (1, N'Áo ba lỗ1.jfif', 1)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (2, N'Áo ba lỗ2.jfif', 1)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (3, N'Áo ba lỗ3.jfif', 1)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (9, N'Áo khoác bò 0.jpg', 2)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (10, N'Áo khoác bò 1.jpg', 2)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (11, N'Áo FEAER 11.jpg', 4)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (12, N'Áo FEAER 12.jpg', 4)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (13, N'Áo FEAER 13.jpg', 4)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (17, N'Áo thun HOTTREND17.jpg', 6)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (18, N'Áo thun HOTTREND18.jpg', 6)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (19, N'Áo thun HOTTREND19.jpg', 6)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (20, N'Giây lưng thắt lưng nam 20.jpg', 7)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (21, N'Giây lưng thắt lưng nam 21.jpg', 7)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (22, N'Giày thể thao nữ CV classic22.jpg', 8)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (23, N'Giày thể thao nữ CV classic23.jpg', 8)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (24, N'Giày thể thao nữ CV classic24.jpg', 8)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (25, N'Áo SIGNATURE0.jpg', 5)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (26, N'Áo SIGNATURE1.jpg', 5)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (27, N'Áo SIGNATURE2.jpg', 5)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (30, N'Đồng hồ Nữ Army0.jpg', 9)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (31, N'Đồng hồ Nữ Army1.jpg', 9)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (32, N'Giày AF1 trắng32.jpg', 10)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (33, N'Giày AF1 trắng33.jpg', 10)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (34, N'Giày AF1 trắng34.jpg', 10)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (35, N'Quần short0.jpg', 3)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (36, N'Quần short1.jpg', 3)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (37, N'Áo Thun Missout BUNNY&BEAR TEE37.jpg', 11)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (38, N'Áo Thun Missout BUNNY&BEAR TEE38.jpg', 11)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (39, N'Áo Thun Nam Thể Thao39.jpg', 12)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (40, N'Áo Thun Nam Thể Thao40.jpg', 12)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (41, N'Áo thun Highclub Basic Tee41.jfif', 13)
INSERT [dbo].[ImageSanPhams] ([Id], [ImageName], [IdSanPham]) VALUES (42, N'Áo thun Highclub Basic Tee42.jfif', 13)
SET IDENTITY_INSERT [dbo].[ImageSanPhams] OFF
GO
SET IDENTITY_INSERT [dbo].[JobSeekers] ON 

INSERT [dbo].[JobSeekers] ([Id], [Id_Identity], [Location]) VALUES (1, N'9185bbf1-7002-4180-ba27-9cc772b3f0a1', NULL)
INSERT [dbo].[JobSeekers] ([Id], [Id_Identity], [Location]) VALUES (2, N'37cb2728-7ab2-4a1f-9035-b4b68dbed8a4', NULL)
INSERT [dbo].[JobSeekers] ([Id], [Id_Identity], [Location]) VALUES (3, N'f04b1d20-7e45-4124-986f-08d08232b0cb', NULL)
INSERT [dbo].[JobSeekers] ([Id], [Id_Identity], [Location]) VALUES (4, N'b96485ed-758c-464f-be93-ebff970a3a54', NULL)
INSERT [dbo].[JobSeekers] ([Id], [Id_Identity], [Location]) VALUES (5, N'b192ca14-3277-4f4e-8227-dfdd48b8b45e', NULL)
INSERT [dbo].[JobSeekers] ([Id], [Id_Identity], [Location]) VALUES (6, N'4db69aa8-7300-4fce-b81b-f00ac6f13ab9', NULL)
INSERT [dbo].[JobSeekers] ([Id], [Id_Identity], [Location]) VALUES (7, N'c9ca6e23-0da4-4628-bd93-6f2acb88a046', NULL)
SET IDENTITY_INSERT [dbo].[JobSeekers] OFF
GO
SET IDENTITY_INSERT [dbo].[Loais] ON 

INSERT [dbo].[Loais] ([Id], [Ten]) VALUES (1, N'Áo')
INSERT [dbo].[Loais] ([Id], [Ten]) VALUES (2, N'Quần')
INSERT [dbo].[Loais] ([Id], [Ten]) VALUES (3, N'Đồng hồ')
INSERT [dbo].[Loais] ([Id], [Ten]) VALUES (4, N'Giây lưng')
INSERT [dbo].[Loais] ([Id], [Ten]) VALUES (5, N'Giày')
SET IDENTITY_INSERT [dbo].[Loais] OFF
GO
SET IDENTITY_INSERT [dbo].[MaGiamGias] ON 

INSERT [dbo].[MaGiamGias] ([Id], [Code], [SoTienGiam]) VALUES (1, N'K5L6P', CAST(100000.00 AS Decimal(18, 2)))
INSERT [dbo].[MaGiamGias] ([Id], [Code], [SoTienGiam]) VALUES (2, N'OWLVR', CAST(125000.00 AS Decimal(18, 2)))
INSERT [dbo].[MaGiamGias] ([Id], [Code], [SoTienGiam]) VALUES (3, N'KN2XD', CAST(125000.00 AS Decimal(18, 2)))
INSERT [dbo].[MaGiamGias] ([Id], [Code], [SoTienGiam]) VALUES (4, N'ZE0Y8', CAST(150000.00 AS Decimal(18, 2)))
INSERT [dbo].[MaGiamGias] ([Id], [Code], [SoTienGiam]) VALUES (5, N'PBO8D', CAST(150000.00 AS Decimal(18, 2)))
INSERT [dbo].[MaGiamGias] ([Id], [Code], [SoTienGiam]) VALUES (6, N'70NBT', CAST(125000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[MaGiamGias] OFF
GO
SET IDENTITY_INSERT [dbo].[MauSacs] ON 

INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (1, N'Đen', 1)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (2, N'Trắng', 1)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (3, N'Vàng', 1)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (4, N'Tím', 1)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (5, N'Đỏ', 1)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (6, N'Đen', 2)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (7, N'Trắng', 2)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (8, N'Vàng', 2)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (9, N'Tím ', 2)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (10, N'Đỏ', 2)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (11, N'Đen', 3)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (12, N'Trắng', 3)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (13, N'Vàng', 3)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (14, N'Tím', 3)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (15, N'Đỏ', 3)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (16, N'Đen', 4)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (17, N'Trắng', 4)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (18, N'Vàng', 4)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (19, N'Tím', 4)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (20, N'Đỏ', 4)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (21, N'Đen', 5)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (22, N'Trắng', 5)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (23, N'Vàng', 5)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (24, N'Tím', 5)
INSERT [dbo].[MauSacs] ([Id], [MaMau], [Id_Loai]) VALUES (25, N'Đỏ - giày', 5)
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

INSERT [dbo].[NotificationCheckouts] ([Id], [ThongBaoMaDonHang]) VALUES (1, 11)
INSERT [dbo].[NotificationCheckouts] ([Id], [ThongBaoMaDonHang]) VALUES (2, 12)
SET IDENTITY_INSERT [dbo].[NotificationCheckouts] OFF
GO
SET IDENTITY_INSERT [dbo].[Notifications] ON 

INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (1, N'Áo Thun Nam Thể Thao', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (2, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (3, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (4, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (5, N'Áo thun Highclub Basic Tee', N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (6, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (7, NULL, N'Add')
INSERT [dbo].[Notifications] ([Id], [TenSanPham], [TranType]) VALUES (8, NULL, N'Add')
SET IDENTITY_INSERT [dbo].[Notifications] OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuNhapHangs] ON 

INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (1, N'O3RS6X4', CAST(N'2021-11-09T22:11:24.0405196' AS DateTime2), CAST(9420000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Phiếu nhập hàng thành công', 1)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (2, N'798ZHYH', CAST(N'2021-11-09T23:06:46.3420637' AS DateTime2), CAST(3140000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'ok', 1)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (3, N'XFMQTBW', CAST(N'2021-11-10T00:41:16.0587498' AS DateTime2), CAST(10885000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Thành công', 1)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (4, N'F5GTY3C', CAST(N'2021-11-11T18:57:56.5666098' AS DateTime2), CAST(15550000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Nhập hàng ', 1)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (5, N'X8V7OS1', CAST(N'2021-11-11T22:30:57.1969211' AS DateTime2), CAST(3110000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Phiếu nhập', 2)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (6, N'VGRSBDR', CAST(N'2021-11-11T22:33:23.4345053' AS DateTime2), CAST(7775000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Tạo phiếu nhập', 1)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (7, N'LSQYMJQ', CAST(N'2021-11-11T22:38:16.3096363' AS DateTime2), CAST(12440000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Nhập ba sản phẩm', 1)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (8, N'381L3MI', CAST(N'2021-11-11T22:38:56.4611546' AS DateTime2), CAST(13500000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Nhập hai sản phẩm giây lưng', 10)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (9, N'W8WHR9S', CAST(N'2021-11-11T22:39:32.6102453' AS DateTime2), CAST(16250000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Nhập áo thun HOTTREND', 11)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (10, N'6K3XVWH', CAST(N'2021-11-11T22:43:25.6736572' AS DateTime2), CAST(26000000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Giày thể thao nữ CV Classic', 9)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (11, N'7LB3PT0', CAST(N'2021-11-11T22:58:09.3070610' AS DateTime2), CAST(187050000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Nhập 5 lô hàng', 2)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (12, N'PFVQCW3', CAST(N'2021-11-11T23:17:24.4668593' AS DateTime2), CAST(140700000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Nhập 2 lô đồng hồ', 9)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (13, N'OYEV8US', CAST(N'2021-11-12T08:09:01.7672520' AS DateTime2), CAST(100500000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Nhập hàng', 1)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (14, N'3JTFQST', CAST(N'2021-11-14T14:34:31.3049085' AS DateTime2), CAST(192200000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Tạo phiếu nhập', 1)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (15, N'MRYV2J1', CAST(N'2021-11-14T14:38:19.6210965' AS DateTime2), CAST(100500000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Nhập thêm sản phẩm', 1)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (16, N'0I1LE6K', CAST(N'2021-11-14T15:50:09.6479296' AS DateTime2), CAST(186600000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Nhập hàng', 1)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (17, N'48GH35M', CAST(N'2021-11-14T16:04:52.9571142' AS DateTime2), CAST(46650000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Nhập hàng', 1)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (18, N'UBVO1J2', CAST(N'2021-11-14T16:08:21.6110898' AS DateTime2), CAST(77750000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Nhập hàng', 1)
INSERT [dbo].[PhieuNhapHangs] ([Id], [SoChungTu], [NgayTao], [TongTien], [NguoiLapPhieu], [GhiChu], [Id_NhaCungCap]) VALUES (19, N'WWK15WU', CAST(N'2021-11-15T19:11:29.5798293' AS DateTime2), CAST(31400000.00 AS Decimal(18, 2)), N'1e85ffbf-126a-4192-8116-caa454ac393d', N'Nhập hàng', 2)
SET IDENTITY_INSERT [dbo].[PhieuNhapHangs] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPhamBienThes] ON 

INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (1, 1, 1, 350, 1)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (2, 1, 2, 539, 2)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (3, 1, 1, 150, 3)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (4, 1, 1, 194, 2)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (5, 3, 6, 231, 5)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (6, 2, 1, 95, 2)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (7, 2, 4, 327, 3)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (8, 4, 2, 350, 2)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (9, 4, 1, 200, 3)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (10, 5, 5, 245, 2)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (12, 7, 17, 100, 11)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (13, 7, 19, 200, 12)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (14, 6, 4, 224, 3)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (15, 4, 5, 100, 2)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (16, 8, 22, 250, 15)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (17, 8, 23, 150, 14)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (18, 5, 3, 147, 2)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (19, 5, 3, 150, 3)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (20, 3, 9, 250, 6)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (21, 9, 12, 200, 9)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (22, 9, 11, 150, 8)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (23, 10, 24, 194, 15)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (24, 10, 25, 50, 13)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (25, 11, 2, 395, 3)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (26, 11, 1, 140, 2)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (27, 12, 2, 150, 3)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (28, 12, 3, 200, 3)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (29, 12, 5, 250, 2)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (30, 13, 1, 93, 2)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (31, 13, 1, 50, 3)
INSERT [dbo].[SanPhamBienThes] ([Id], [Id_SanPham], [Id_Mau], [SoLuongTon], [SizeId]) VALUES (32, 13, 2, 240, 1)
SET IDENTITY_INSERT [dbo].[SanPhamBienThes] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPhams] ON 

INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap], [NhanHieuId]) VALUES (1, N'Áo ba lỗ', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', CAST(257000 AS Decimal(18, 0)), CAST(157000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Fashion', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', N'Vải Thun Lạnh co giãn 4 chiều, thoáng mát, mềm mịn mát mẻ, phù hợp với mọi hoạt động dã ngoại, thể thao, hay dạo phố.', NULL, CAST(N'2021-11-09T21:38:52.9363953' AS DateTime2), N'new', 1, 1, 1, 1, 1, NULL)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap], [NhanHieuId]) VALUES (2, N'Áo khoác bò ', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', CAST(513000 AS Decimal(18, 0)), CAST(311000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Fashion', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', N'Vải Thun Lạnh co giãn 4 chiều, thoáng mát, mềm mịn mát mẻ, phù hợp với mọi hoạt động dã ngoại, thể thao, hay dạo phố.', CAST(N'2021-11-10T00:40:02.3896104' AS DateTime2), CAST(N'2021-11-09T21:39:55.9277738' AS DateTime2), N'new', 1, 1, 3, 1, 1, NULL)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap], [NhanHieuId]) VALUES (3, N'Quần short', N'Mẫu quần tây đen công sở cạp lưng cao Form thoải mái, không quá ôm và quá đứng dáng đâu các nàng ạ, mặc lên vừa thoải mái vận động mà vẫn đứng dáng. Các nàng có thể mặc quần tây nữ công sở phối áo sơ mi mặc đi làm, đi chơi, học sinh mặc đi học đều xinh ạ.', CAST(257000 AS Decimal(18, 0)), CAST(157000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Fashion', N'Mẫu quần tây đen công sở cạp lưng cao Form thoải mái, không quá ôm và quá đứng dáng đâu các nàng ạ, mặc lên vừa thoải mái vận động mà vẫn đứng dáng. Các nàng có thể mặc quần tây nữ công sở phối áo sơ mi mặc đi làm, đi chơi, học sinh mặc đi học đều xinh ạ.', N'Kaki ', CAST(N'2021-11-13T22:44:58.6384960' AS DateTime2), CAST(N'2021-11-09T21:40:59.5410337' AS DateTime2), N'hot', 1, 1, 2, 2, 2, NULL)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap], [NhanHieuId]) VALUES (4, N'Áo FEAER ', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', CAST(513000 AS Decimal(18, 0)), CAST(311000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Fashion', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', N'Vải Thun Lạnh co giãn 4 chiều, thoáng mát, mềm mịn mát mẻ, phù hợp với mọi hoạt động dã ngoại, thể thao, hay dạo phố.', NULL, CAST(N'2021-11-11T18:52:07.0130236' AS DateTime2), N'new', 1, 1, 1, 1, 1, NULL)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap], [NhanHieuId]) VALUES (5, N'Áo SIGNATURE', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', CAST(411000 AS Decimal(18, 0)), CAST(311000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Features', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', N'Vải Thun Lạnh co giãn 4 chiều, thoáng mát, mềm mịn mát mẻ, phù hợp với mọi hoạt động dã ngoại, thể thao, hay dạo phố.', CAST(N'2021-11-11T22:44:33.8448732' AS DateTime2), CAST(N'2021-11-11T22:28:21.0652372' AS DateTime2), N'new', 1, 2, 8, 1, 2, NULL)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap], [NhanHieuId]) VALUES (6, N'Áo thun HOTTREND', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', CAST(750000 AS Decimal(18, 0)), CAST(650000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Features', N'Đối với một người đàn ông hiện đại thì vẻ bề ngoài rất quan trọng, ngoài những bộ suit lịch lãm thì phụ kiện đồng hồ cũng là điểm nhấn không thể thiếu trên cổ tay của họ. Vì thế một chiếc đồng hồ đẹp cho nam luôn là mục đích tìm kiếm của đa số đàn ông hiện nay.', N'Vải Thun Lạnh co giãn 4 chiều, thoáng mát, mềm mịn mát mẻ, phù hợp với mọi hoạt động dã ngoại, thể thao, hay dạo phố.', NULL, CAST(N'2021-11-11T22:34:49.2078582' AS DateTime2), N'new', 1, 2, 5, 1, 11, NULL)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap], [NhanHieuId]) VALUES (7, N'Giây lưng thắt lưng nam ', N'Mang đến hình ảnh là một người lịch lãm, nhưng không kém phần thanh lịch, thời trang giày nổi bật cùng dáng xỏ tiện lợi giúp bạn có thể sử dụng ở bất cứ đâu.', CAST(602000 AS Decimal(18, 0)), CAST(450000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Features', N'Mang đến hình ảnh là một người lịch lãm, nhưng không kém phần thanh lịch, thời trang giày nổi bật cùng dáng xỏ tiện lợi giúp bạn có thể sử dụng ở bất cứ đâu.', N'Kim loại', NULL, CAST(N'2021-11-11T22:36:12.3119814' AS DateTime2), N'hot', 1, 1, 7, 4, 10, NULL)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap], [NhanHieuId]) VALUES (8, N'Giày thể thao nữ CV classic', N'Mang đến hình ảnh là một người lịch lãm, nhưng không kém phần thanh lịch, thời trang giày nổi bật cùng dáng xỏ tiện lợi giúp bạn có thể sử dụng ở bất cứ đâu.', CAST(850000 AS Decimal(18, 0)), CAST(650000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Features', N'Mang đến hình ảnh là một người lịch lãm, nhưng không kém phần thanh lịch, thời trang giày nổi bật cùng dáng xỏ tiện lợi giúp bạn có thể sử dụng ở bất cứ đâu.', N'Thân giày thể thao chủ yếu sử dụng vật liệu mesh (lưới), da tự nhiên hoặc da nhân tạo. ', NULL, CAST(N'2021-11-11T22:41:17.4153591' AS DateTime2), N'new', 1, 2, 2, 5, 9, NULL)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap], [NhanHieuId]) VALUES (9, N'Đồng hồ Nữ Army', N'Đối với một người đàn ông hiện đại thì vẻ bề ngoài rất quan trọng, ngoài những bộ suit lịch lãm thì phụ kiện đồng hồ cũng là điểm nhấn không thể thiếu trên cổ tay của họ. Vì thế một chiếc đồng hồ đẹp cho nam luôn là mục đích tìm kiếm của đa số đàn ông hiện nay.', CAST(602000 AS Decimal(18, 0)), CAST(402000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Features', N'Đối với một người đàn ông hiện đại thì vẻ bề ngoài rất quan trọng, ngoài những bộ suit lịch lãm thì phụ kiện đồng hồ cũng là điểm nhấn không thể thiếu trên cổ tay của họ. Vì thế một chiếc đồng hồ đẹp cho nam luôn là mục đích tìm kiếm của đa số đàn ông hiện nay.', N'Thân giày thể thao chủ yếu sử dụng vật liệu mesh (lưới), da tự nhiên hoặc da nhân tạo. ', CAST(N'2021-11-11T23:15:24.1324537' AS DateTime2), CAST(N'2021-11-11T23:12:31.9111399' AS DateTime2), N'hot', 1, 2, 5, 3, 9, NULL)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap], [NhanHieuId]) VALUES (10, N'Giày AF1 trắng', N'Đối với một người đàn ông hiện đại thì vẻ bề ngoài rất quan trọng, ngoài những bộ suit lịch lãm thì phụ kiện đồng hồ cũng là điểm nhấn không thể thiếu trên cổ tay của họ. Vì thế một chiếc đồng hồ đẹp cho nam luôn là mục đích tìm kiếm của đa số đàn ông hiện nay.', CAST(750000 AS Decimal(18, 0)), CAST(402000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Features', N'Mẫu quần tây đen công sở cạp lưng cao Form thoải mái, không quá ôm và quá đứng dáng đâu các nàng ạ, mặc lên vừa thoải mái vận động mà vẫn đứng dáng. Các nàng có thể mặc quần tây nữ công sở phối áo sơ mi mặc đi làm, đi chơi, học sinh mặc đi học đều xinh ạ.', N'Thân giày thể thao chủ yếu sử dụng vật liệu mesh (lưới), da tự nhiên hoặc da nhân tạo. ', NULL, CAST(N'2021-11-12T08:07:06.8813790' AS DateTime2), N'new', 1, 1, 1, 5, 1, NULL)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap], [NhanHieuId]) VALUES (11, N'Áo Thun Missout BUNNY&BEAR TEE', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', CAST(602000 AS Decimal(18, 0)), CAST(402000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Features', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', N'Vải Thun Lạnh co giãn 4 chiều, thoáng mát, mềm mịn mát mẻ, phù hợp với mọi hoạt động dã ngoại, thể thao, hay dạo phố.', NULL, CAST(N'2021-11-14T14:32:32.1745966' AS DateTime2), N'new', 0, 2, 1, 1, 1, NULL)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap], [NhanHieuId]) VALUES (12, N'Áo Thun Nam Thể Thao', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', CAST(513000 AS Decimal(18, 0)), CAST(311000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Fashion', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', N'Vải Thun Lạnh co giãn 4 chiều, thoáng mát, mềm mịn mát mẻ, phù hợp với mọi hoạt động dã ngoại, thể thao, hay dạo phố.', NULL, CAST(N'2021-11-14T15:48:39.3330033' AS DateTime2), N'new', 1, 1, 1, 1, 1, NULL)
INSERT [dbo].[SanPhams] ([Id], [Ten], [MoTa], [GiaBan], [GiaNhap], [KhuyenMai], [Tag], [HuongDan], [ThanhPhan], [NgayCapNhat], [NgayTao], [TrangThaiSanPham], [TrangThaiHoatDong], [GioiTinh], [Id_NhanHieu], [Id_Loai], [Id_NhaCungCap], [NhanHieuId]) VALUES (13, N'Áo thun Highclub Basic Tee', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', CAST(411000 AS Decimal(18, 0)), CAST(311000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Fashion', N'Ngày này, áo thun tay lỡ Unisex form rộng đang ngày càng trở nên phổ biến và đa dạng với các mẫu thiết kế độc đáo bắt mắt, thậm chí còn bắt kịp nhiều trào lưu xu hướng đặc biệt là phong cách Hàn Quốc. 
    Do đó, việc tìm hiểu tất tần tật về áo thun tay lỡ nam/nữ là cần thiết giúp bạn luôn cập nhật những mẫu thiết kế mới nhất. Điều này sẽ giúp bạn có nhiều sự lựa chọn mới mẻ và đa dạng phong cách thời trang của bạn.', N'Vải Thun Lạnh co giãn 4 chiều, thoáng mát, mềm mịn mát mẻ, phù hợp với mọi hoạt động dã ngoại, thể thao, hay dạo phố.', NULL, CAST(N'2021-11-14T16:03:38.2505288' AS DateTime2), N'new', 1, 1, 1, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[SanPhams] OFF
GO
SET IDENTITY_INSERT [dbo].[Sizes] ON 

INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (1, N'S', 1)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (2, N'M', 1)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (3, N'L', 1)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (4, N'S', 2)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (5, N'M', 2)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (6, N'L', 2)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (7, N'Nhỏ', 3)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (8, N'Vừa', 3)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (9, N'Lớn', 3)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (10, N'Vòng eo 65 - 73 cm', 4)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (11, N'Vòng eo 73 - 80 cm', 4)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (12, N'Vòng eo 87 - 93 cm', 4)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (13, N'39', 5)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (14, N'40', 5)
INSERT [dbo].[Sizes] ([Id], [TenSize], [Id_Loai]) VALUES (15, N'41', 5)
SET IDENTITY_INSERT [dbo].[Sizes] OFF
GO
SET IDENTITY_INSERT [dbo].[UserComments] ON 

INSERT [dbo].[UserComments] ([IdSanPham], [Content], [Id], [AppUserId], [IdUser], [NgayComment]) VALUES (2, N'Sản phẩm rất tốt', 1, NULL, NULL, NULL)
INSERT [dbo].[UserComments] ([IdSanPham], [Content], [Id], [AppUserId], [IdUser], [NgayComment]) VALUES (4, N'Rất thoải mái', 2, NULL, NULL, NULL)
INSERT [dbo].[UserComments] ([IdSanPham], [Content], [Id], [AppUserId], [IdUser], [NgayComment]) VALUES (6, N'Shop cần nhập sản phẩm này về nhiều hơn', 3, NULL, NULL, NULL)
INSERT [dbo].[UserComments] ([IdSanPham], [Content], [Id], [AppUserId], [IdUser], [NgayComment]) VALUES (2, N'ok', 4, NULL, N'1e85ffbf-126a-4192-8116-caa454ac393d', CAST(N'2021-11-13T22:45:58.9003947' AS DateTime2))
INSERT [dbo].[UserComments] ([IdSanPham], [Content], [Id], [AppUserId], [IdUser], [NgayComment]) VALUES (2, N'rat ok
', 5, NULL, N'1e85ffbf-126a-4192-8116-caa454ac393d', CAST(N'2021-11-13T22:46:15.2823852' AS DateTime2))
SET IDENTITY_INSERT [dbo].[UserComments] OFF
GO
SET IDENTITY_INSERT [dbo].[UserLikes] ON 

INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (7, 1, NULL, N'53cc4f58-ec9e-4bc7-96b4-c3cbe7aba309')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (8, 2, NULL, N'53cc4f58-ec9e-4bc7-96b4-c3cbe7aba309')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (8, 3, NULL, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (3, 4, NULL, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (3, 5, NULL, N'b192ca14-3277-4f4e-8227-dfdd48b8b45e')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (2, 6, NULL, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (8, 7, NULL, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (6, 8, NULL, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (6, 9, NULL, N'c9ca6e23-0da4-4628-bd93-6f2acb88a046')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (1, 10, NULL, N'1e85ffbf-126a-4192-8116-caa454ac393d')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (1, 11, NULL, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (5, 12, NULL, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (6, 13, NULL, N'53cc4f58-ec9e-4bc7-96b4-c3cbe7aba309')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (7, 14, NULL, N'b192ca14-3277-4f4e-8227-dfdd48b8b45e')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (7, 15, NULL, N'ce18aa96-6af6-4fb3-a3a4-104fcbc0f91b')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (8, 16, NULL, N'ce18aa96-6af6-4fb3-a3a4-104fcbc0f91b')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (9, 17, NULL, N'b192ca14-3277-4f4e-8227-dfdd48b8b45e')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (5, 18, NULL, N'b192ca14-3277-4f4e-8227-dfdd48b8b45e')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (6, 19, NULL, N'c9ca6e23-0da4-4628-bd93-6f2acb88a046')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (1, 20, NULL, N'53cc4f58-ec9e-4bc7-96b4-c3cbe7aba309')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (7, 21, NULL, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (9, 22, NULL, N'c9ca6e23-0da4-4628-bd93-6f2acb88a046')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (3, 23, NULL, N'b192ca14-3277-4f4e-8227-dfdd48b8b45e')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (6, 24, NULL, N'f04b1d20-7e45-4124-986f-08d08232b0cb')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (12, 25, NULL, N'b192ca14-3277-4f4e-8227-dfdd48b8b45e')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (11, 26, NULL, N'7af327e9-0019-46e4-be38-31d2a84d80ef')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (10, 27, NULL, N'37cb2728-7ab2-4a1f-9035-b4b68dbed8a4')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (10, 28, NULL, N'b192ca14-3277-4f4e-8227-dfdd48b8b45e')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (6, 29, NULL, N'53cc4f58-ec9e-4bc7-96b4-c3cbe7aba309')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (8, 30, NULL, N'3f34da33-53bd-4c54-9735-66dea19d7af0')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (9, 31, NULL, N'4db69aa8-7300-4fce-b81b-f00ac6f13ab9')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (9, 32, NULL, N'b96485ed-758c-464f-be93-ebff970a3a54')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (8, 33, NULL, N'b96485ed-758c-464f-be93-ebff970a3a54')
INSERT [dbo].[UserLikes] ([IdSanPham], [Id], [AppUserId], [IdUser]) VALUES (5, 34, NULL, N'b192ca14-3277-4f4e-8227-dfdd48b8b45e')
SET IDENTITY_INSERT [dbo].[UserLikes] OFF
GO
ALTER TABLE [dbo].[Calendar] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Time]
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
ALTER TABLE [dbo].[AuthHistories]  WITH CHECK ADD  CONSTRAINT [FK_AuthHistories_AspNetUsers_IdentityId] FOREIGN KEY([IdentityId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AuthHistories] CHECK CONSTRAINT [FK_AuthHistories_AspNetUsers_IdentityId]
GO
ALTER TABLE [dbo].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_Blogs_AspNetUsers_FkAppUser_NguoiThem] FOREIGN KEY([FkAppUser_NguoiThem])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Blogs] CHECK CONSTRAINT [FK_Blogs_AspNetUsers_FkAppUser_NguoiThem]
GO
ALTER TABLE [dbo].[Calendar]  WITH CHECK ADD  CONSTRAINT [FK_Calendar_AspNetUsers_IdUser] FOREIGN KEY([IdUser])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Calendar] CHECK CONSTRAINT [FK_Calendar_AspNetUsers_IdUser]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_AspNetUsers_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_AspNetUsers_UserID]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_SanPhamBienThes_Id_SanPhamBienThe] FOREIGN KEY([Id_SanPhamBienThe])
REFERENCES [dbo].[SanPhamBienThes] ([Id])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_SanPhamBienThes_Id_SanPhamBienThe]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_SanPhams_SanPhamId] FOREIGN KEY([SanPhamId])
REFERENCES [dbo].[SanPhams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_SanPhams_SanPhamId]
GO
ALTER TABLE [dbo].[ChiTietHoaDons]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDons_SanPhamBienThes_Id_SanPhamBienThe] FOREIGN KEY([Id_SanPhamBienThe])
REFERENCES [dbo].[SanPhamBienThes] ([Id])
GO
ALTER TABLE [dbo].[ChiTietHoaDons] CHECK CONSTRAINT [FK_ChiTietHoaDons_SanPhamBienThes_Id_SanPhamBienThe]
GO
ALTER TABLE [dbo].[ChiTietHoaDons]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDons_SanPhams_Id_SanPham] FOREIGN KEY([Id_SanPham])
REFERENCES [dbo].[SanPhams] ([Id])
GO
ALTER TABLE [dbo].[ChiTietHoaDons] CHECK CONSTRAINT [FK_ChiTietHoaDons_SanPhams_Id_SanPham]
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
ALTER TABLE [dbo].[ImageBlogs]  WITH CHECK ADD  CONSTRAINT [FK_ImageBlogs_Blogs_FkBlogId] FOREIGN KEY([FkBlogId])
REFERENCES [dbo].[Blogs] ([Id])
GO
ALTER TABLE [dbo].[ImageBlogs] CHECK CONSTRAINT [FK_ImageBlogs_Blogs_FkBlogId]
GO
ALTER TABLE [dbo].[ImageSanPhams]  WITH CHECK ADD  CONSTRAINT [FK_ImageSanPhams_SanPhams_IdSanPham] FOREIGN KEY([IdSanPham])
REFERENCES [dbo].[SanPhams] ([Id])
GO
ALTER TABLE [dbo].[ImageSanPhams] CHECK CONSTRAINT [FK_ImageSanPhams_SanPhams_IdSanPham]
GO
ALTER TABLE [dbo].[JobSeekers]  WITH CHECK ADD  CONSTRAINT [FK_JobSeekers_AspNetUsers_Id_Identity] FOREIGN KEY([Id_Identity])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[JobSeekers] CHECK CONSTRAINT [FK_JobSeekers_AspNetUsers_Id_Identity]
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
ALTER TABLE [dbo].[SanPhams]  WITH CHECK ADD  CONSTRAINT [FK_SanPhams_NhanHieus_NhanHieuId] FOREIGN KEY([NhanHieuId])
REFERENCES [dbo].[NhanHieus] ([Id])
GO
ALTER TABLE [dbo].[SanPhams] CHECK CONSTRAINT [FK_SanPhams_NhanHieus_NhanHieuId]
GO
ALTER TABLE [dbo].[Sizes]  WITH CHECK ADD  CONSTRAINT [FK_Sizes_Loais_Id_Loai] FOREIGN KEY([Id_Loai])
REFERENCES [dbo].[Loais] ([Id])
GO
ALTER TABLE [dbo].[Sizes] CHECK CONSTRAINT [FK_Sizes_Loais_Id_Loai]
GO
ALTER TABLE [dbo].[UserChats]  WITH CHECK ADD  CONSTRAINT [FK_UserChats_AspNetUsers_IdUser] FOREIGN KEY([IdUser])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserChats] CHECK CONSTRAINT [FK_UserChats_AspNetUsers_IdUser]
GO
ALTER TABLE [dbo].[UserComments]  WITH CHECK ADD  CONSTRAINT [FK_UserComments_AspNetUsers_AppUserId] FOREIGN KEY([AppUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserComments] CHECK CONSTRAINT [FK_UserComments_AspNetUsers_AppUserId]
GO
ALTER TABLE [dbo].[UserLikes]  WITH CHECK ADD  CONSTRAINT [FK_UserLikes_AspNetUsers_AppUserId] FOREIGN KEY([AppUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserLikes] CHECK CONSTRAINT [FK_UserLikes_AspNetUsers_AppUserId]
GO
