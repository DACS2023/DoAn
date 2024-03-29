USE [master]
GO
/****** Object:  Database [QL_HoiThao]    Script Date: 07/05/2023 10:15:16 ******/
CREATE DATABASE [QL_HoiThao]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_HoiThao', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QL_HoiThao.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QL_HoiThao_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QL_HoiThao_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QL_HoiThao] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_HoiThao].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_HoiThao] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QL_HoiThao] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QL_HoiThao] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QL_HoiThao] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QL_HoiThao] SET ARITHABORT OFF 
GO
ALTER DATABASE [QL_HoiThao] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QL_HoiThao] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QL_HoiThao] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QL_HoiThao] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QL_HoiThao] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QL_HoiThao] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QL_HoiThao] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QL_HoiThao] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QL_HoiThao] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QL_HoiThao] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QL_HoiThao] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QL_HoiThao] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QL_HoiThao] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QL_HoiThao] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QL_HoiThao] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QL_HoiThao] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [QL_HoiThao] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QL_HoiThao] SET RECOVERY FULL 
GO
ALTER DATABASE [QL_HoiThao] SET  MULTI_USER 
GO
ALTER DATABASE [QL_HoiThao] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QL_HoiThao] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QL_HoiThao] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QL_HoiThao] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QL_HoiThao] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QL_HoiThao] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QL_HoiThao', N'ON'
GO
ALTER DATABASE [QL_HoiThao] SET QUERY_STORE = ON
GO
ALTER DATABASE [QL_HoiThao] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QL_HoiThao]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 07/05/2023 10:15:16 ******/
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
/****** Object:  Table [dbo].[giaiDaus]    Script Date: 07/05/2023 10:15:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[giaiDaus](
	[IdgiaiDau] [int] IDENTITY(1,1) NOT NULL,
	[TenGiaiDau] [nvarchar](100) NOT NULL,
	[IdloaiGiaiDau] [int] NOT NULL,
	[NgayBatDau] [date] NOT NULL,
	[NgayKetThuc] [date] NOT NULL,
	[NoiDung] [nvarchar](max) NOT NULL,
	[TrangThai] [bit] NOT NULL,
 CONSTRAINT [PK_giaiDaus] PRIMARY KEY CLUSTERED 
(
	[IdgiaiDau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loaiGiaiDaus]    Script Date: 07/05/2023 10:15:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loaiGiaiDaus](
	[IdloaiGiaiDau] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](100) NOT NULL,
	[TrangThai] [bit] NOT NULL,
	[GiaiDauIdgiaiDau] [int] NULL,
 CONSTRAINT [PK_loaiGiaiDaus] PRIMARY KEY CLUSTERED 
(
	[IdloaiGiaiDau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleClaims]    Script Date: 07/05/2023 10:15:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 07/05/2023 10:15:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 07/05/2023 10:15:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 07/05/2023 10:15:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 07/05/2023 10:15:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 07/05/2023 10:15:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Gender] [nvarchar](max) NOT NULL,
	[Birthday] [date] NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
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
	[User] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 07/05/2023 10:15:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230506160157_reset', N'7.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230506184241_update_user', N'7.0.5')
GO
SET IDENTITY_INSERT [dbo].[giaiDaus] ON 

INSERT [dbo].[giaiDaus] ([IdgiaiDau], [TenGiaiDau], [IdloaiGiaiDau], [NgayBatDau], [NgayKetThuc], [NoiDung], [TrangThai]) VALUES (1, N'Ao làng 123', 1, CAST(N'0001-01-01' AS Date), CAST(N'0001-01-01' AS Date), N'as', 1)
SET IDENTITY_INSERT [dbo].[giaiDaus] OFF
GO
SET IDENTITY_INSERT [dbo].[loaiGiaiDaus] ON 

INSERT [dbo].[loaiGiaiDaus] ([IdloaiGiaiDau], [TenLoai], [TrangThai], [GiaiDauIdgiaiDau]) VALUES (1, N'Liên Minh', 1, NULL)
INSERT [dbo].[loaiGiaiDaus] ([IdloaiGiaiDau], [TenLoai], [TrangThai], [GiaiDauIdgiaiDau]) VALUES (2, N'Bóng đá', 1, NULL)
INSERT [dbo].[loaiGiaiDaus] ([IdloaiGiaiDau], [TenLoai], [TrangThai], [GiaiDauIdgiaiDau]) VALUES (3, N'Pubg', 1, NULL)
SET IDENTITY_INSERT [dbo].[loaiGiaiDaus] OFF
GO
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'14db2ffe-c3cd-4e19-a8e5-b2e7e9319616', N'Edit', N'EDIT', NULL)
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'9c4d0cf4-9974-4637-ade0-bbb37c92abea', N'Admin', N'ADMIN', NULL)
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'4f7dab60-ec19-47e1-8918-7a23375728df', N'9c4d0cf4-9974-4637-ade0-bbb37c92abea')
GO
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Gender], [Birthday], [Address], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [User]) VALUES (N'2e838a2d-6355-475d-b066-238c7364a8d5', N'Huỳnh', N'Tuấn', N'Male', CAST(N'0001-01-01' AS Date), N'HCM', N'123@gmail.com', N'123@GMAIL.COM', N'123@gmail.com', N'123@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAELd5jg7lX0zvDf3bgghbwi+jaxpiRgxLn/bUzU0J+ZTksGIicSzPxPdP2TO1AGST8Q==', N'UTSF26URZQ6DG3RKN6ATBFKGRCWOHZDC', N'831fedec-09c2-45fd-b7b3-796a5a1dc4f7', NULL, 0, 0, NULL, 1, 0, N'tuanconghuynh.biz')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Gender], [Birthday], [Address], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [User]) VALUES (N'4f7dab60-ec19-47e1-8918-7a23375728df', N'Admin', N'1', N'Female', CAST(N'0001-01-01' AS Date), N'Tuan', N'Admin@gmail.com', N'ADMIN@GMAIL.COM', N'Admin@gmail.com', N'ADMIN@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEPEfS3cEBefwHzceXXUaY7f+mxNevLqd9hvkFfz36fZp1Dr+SJYC/QnWV77U8ge/cQ==', N'QHWWVF5VHSM7ASMCYWH3YKMCV6YNPA4Z', N'40b6c78d-afd9-4eab-820e-14bedecb03c7', NULL, 0, 0, NULL, 1, 0, N'tuantest')
GO
/****** Object:  Index [IX_loaiGiaiDaus_GiaiDauIdgiaiDau]    Script Date: 07/05/2023 10:15:17 ******/
CREATE NONCLUSTERED INDEX [IX_loaiGiaiDaus_GiaiDauIdgiaiDau] ON [dbo].[loaiGiaiDaus]
(
	[GiaiDauIdgiaiDau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleClaims_RoleId]    Script Date: 07/05/2023 10:15:17 ******/
CREATE NONCLUSTERED INDEX [IX_RoleClaims_RoleId] ON [dbo].[RoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 07/05/2023 10:15:17 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[Roles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserClaims_UserId]    Script Date: 07/05/2023 10:15:17 ******/
CREATE NONCLUSTERED INDEX [IX_UserClaims_UserId] ON [dbo].[UserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserLogins_UserId]    Script Date: 07/05/2023 10:15:17 ******/
CREATE NONCLUSTERED INDEX [IX_UserLogins_UserId] ON [dbo].[UserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserRoles_RoleId]    Script Date: 07/05/2023 10:15:17 ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_RoleId] ON [dbo].[UserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 07/05/2023 10:15:17 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[Users]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 07/05/2023 10:15:17 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[Users]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (N'') FOR [User]
GO
ALTER TABLE [dbo].[loaiGiaiDaus]  WITH CHECK ADD  CONSTRAINT [FK_loaiGiaiDaus_giaiDaus_GiaiDauIdgiaiDau] FOREIGN KEY([GiaiDauIdgiaiDau])
REFERENCES [dbo].[giaiDaus] ([IdgiaiDau])
GO
ALTER TABLE [dbo].[loaiGiaiDaus] CHECK CONSTRAINT [FK_loaiGiaiDaus_giaiDaus_GiaiDauIdgiaiDau]
GO
ALTER TABLE [dbo].[RoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_RoleClaims_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleClaims] CHECK CONSTRAINT [FK_RoleClaims_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaims] CHECK CONSTRAINT [FK_UserClaims_Users_UserId]
GO
ALTER TABLE [dbo].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_Users_UserId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [dbo].[UserTokens]  WITH CHECK ADD  CONSTRAINT [FK_UserTokens_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserTokens] CHECK CONSTRAINT [FK_UserTokens_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [QL_HoiThao] SET  READ_WRITE 
GO
