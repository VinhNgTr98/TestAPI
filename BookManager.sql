USE [master]
GO
/****** Object:  Database [BookManager]    Script Date: 06/07/2025 2:49:30 AM ******/
CREATE DATABASE [BookManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MAY1\MSSQL\DATA\BookManager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MAY1\MSSQL\DATA\BookManager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BookManager] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookManager] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BookManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookManager] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BookManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookManager] SET RECOVERY FULL 
GO
ALTER DATABASE [BookManager] SET  MULTI_USER 
GO
ALTER DATABASE [BookManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookManager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookManager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookManager', N'ON'
GO
ALTER DATABASE [BookManager] SET QUERY_STORE = ON
GO
ALTER DATABASE [BookManager] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BookManager]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 06/07/2025 2:49:30 AM ******/
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
/****** Object:  Table [dbo].[Accounts]    Script Date: 06/07/2025 2:49:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 06/07/2025 2:49:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Author] [nvarchar](max) NOT NULL,
	[CreatedAt] [date] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250609003420_Init', N'9.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250609015130_init', N'9.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250629103914_Init', N'9.0.6')
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([UserId], [Username], [Password], [Email], [FullName], [PhoneNumber]) VALUES (1, N'user01', N'P@ssword1', N'user01@example.com', N'Nguy?n Van A', N'0912345678')
INSERT [dbo].[Accounts] ([UserId], [Username], [Password], [Email], [FullName], [PhoneNumber]) VALUES (2, N'admin01', N'Admin@123', N'admin@example.com', N'Tr?n Th? B', N'0987654321')
INSERT [dbo].[Accounts] ([UserId], [Username], [Password], [Email], [FullName], [PhoneNumber]) VALUES (3, N'guest01', N'Guest#321', N'guest01@example.com', N'Lê Van C', N'0933123123')
INSERT [dbo].[Accounts] ([UserId], [Username], [Password], [Email], [FullName], [PhoneNumber]) VALUES (4, N'kha', N'$2a$11$zXNKi8/0hsHE90Q.cUprHuchEmV9QnvBh7FFAn/GBL6m6g7fqHClS', N'string@gmail.com', N'string', N'0123456789')
INSERT [dbo].[Accounts] ([UserId], [Username], [Password], [Email], [FullName], [PhoneNumber]) VALUES (5, N'Vinh', N'$2a$11$hn5qzSDBHB.9f7TCBofqpe9op0qkKnHgeaUACcPmIh8Lhc7RfIJ7i', N'string@gmail.com', N'Vinh Nguyen', N'0123456789')
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'0ce2ff61-aed1-4cec-8350-038897ab3e90', N'The Silent Forest', N'Anna Lee', CAST(N'2023-01-15' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'f1a2381c-7962-42b2-a97d-06cfb2b8fdef', N'Glass Garden', N'David Ho', CAST(N'2023-07-12' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'bb4a39a1-0771-49ff-6ded-08dda6f8d74a', N'test', N'nhơn1', CAST(N'2025-06-01' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'2b0e1835-0759-47fb-6191-08dda6fae42b', N'test12', N'123', CAST(N'2025-06-09' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'be366634-4880-4085-99e2-145152e881b5', N'Painted Silence', N'Tuan Nguyen', CAST(N'2023-12-15' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'f840da12-7010-4320-8bcd-36d74b4da30a', N'Wings of Paper', N'Lien Ngo', CAST(N'2023-09-21' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'cf74c021-6fe7-4032-85ee-50803fe19ed0', N'Burnt Horizons', N'Kim Anh', CAST(N'2023-11-29' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'deb657d0-aaf3-4b36-b395-593dd1179639', N'A Path Forgotten', N'Henry Le', CAST(N'2023-06-18' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'e03696a3-0ea2-4c37-a29e-6b6e71418174', N'Lost in Mekong', N'Phuc Bui', CAST(N'2023-08-09' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'98f6f0e0-bfe2-4b79-aeb8-76b7384bf860', N'Shadows of Time', N'Mark Chen', CAST(N'2022-12-01' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'0ec723ac-b00d-4855-a1ba-779130dd00b9', N'Whispers of the Sea', N'Lana Vu', CAST(N'2024-02-20' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'a9f28199-26bb-45a7-adf2-7e6b3d95d8f9', N'Drifting Ashes', N'Nina Truong', CAST(N'2022-11-11' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'3479add7-7af1-4b11-86ff-7f2da249e983', N'Rainfall and Memory', N'Khoi Do', CAST(N'2023-10-03' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'2e3311b8-b844-4345-aed7-80a96e8cc9ef', N'Dust and Stars', N'James Dao', CAST(N'2023-05-05' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'cfd686e6-389b-4101-a101-8fba92e7a566', N'The Last Library', N'Tom Nguyen', CAST(N'2023-03-10' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'689bc588-83c6-4fd3-b872-9ed9e8363134', N'River of Fire', N'Julie Pham', CAST(N'2022-10-07' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'42cb939b-8531-46e4-84c1-af189cf18dd2', N'City of Bamboo', N'Minh Ha', CAST(N'2024-04-01' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'851a635b-3ff8-44cb-9b5d-b0f91e58aa63', N'Echoes in the Wind', N'Sarah Tran', CAST(N'2023-04-25' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'5a9d44e6-0c50-4970-98af-b3106eeac968', N'The Unseen Light', N'Bao Dinh', CAST(N'2024-03-22' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'3b58146c-4e30-4062-b9cf-b44d6165c9ec', N'Midnight Lanterns', N'Mai Linh', CAST(N'2024-01-01' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'8b9e70d4-8a19-49c4-bfa9-cd28b8a46e0f', N'Songs of the North', N'Thao Dang', CAST(N'2024-05-05' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Author], [CreatedAt]) VALUES (N'5fa882d1-6d8a-426d-a8fb-f730542db446', N'Chasing Autumn', N'Quang Le', CAST(N'2023-02-17' AS Date))
GO
USE [master]
GO
ALTER DATABASE [BookManager] SET  READ_WRITE 
GO
