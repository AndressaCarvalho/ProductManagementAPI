USE [master]
GO
/****** Object:  Database [productmanagement]    Script Date: 31/12/2022 18:15:03 ******/
CREATE DATABASE [productmanagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'productmanagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\productmanagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'productmanagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\productmanagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [productmanagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [productmanagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [productmanagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [productmanagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [productmanagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [productmanagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [productmanagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [productmanagement] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [productmanagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [productmanagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [productmanagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [productmanagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [productmanagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [productmanagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [productmanagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [productmanagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [productmanagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [productmanagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [productmanagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [productmanagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [productmanagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [productmanagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [productmanagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [productmanagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [productmanagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [productmanagement] SET  MULTI_USER 
GO
ALTER DATABASE [productmanagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [productmanagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [productmanagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [productmanagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [productmanagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [productmanagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [productmanagement] SET QUERY_STORE = OFF
GO
USE [productmanagement]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 31/12/2022 18:15:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[Status] [bit] NULL,
	[ManufacturingDate] [datetime] NOT NULL,
	[ExpirationDate] [datetime] NULL,
	[Provider_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provider]    Script Date: 31/12/2022 18:15:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provider](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[Cnpj] [varchar](18) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Description], [Status], [ManufacturingDate], [ExpirationDate], [Provider_Id]) VALUES (1, N'Car glass.', 1, CAST(N'2022-12-30T14:16:40.680' AS DateTime), NULL, 1)
INSERT [dbo].[Product] ([Id], [Description], [Status], [ManufacturingDate], [ExpirationDate], [Provider_Id]) VALUES (2, N'Car steering wheel.', 0, CAST(N'2022-12-30T22:34:08.807' AS DateTime), NULL, 1)
INSERT [dbo].[Product] ([Id], [Description], [Status], [ManufacturingDate], [ExpirationDate], [Provider_Id]) VALUES (3, N'Car windshield.', 1, CAST(N'2022-12-31T20:43:14.440' AS DateTime), CAST(N'2027-12-31T20:43:14.440' AS DateTime), 3)
INSERT [dbo].[Product] ([Id], [Description], [Status], [ManufacturingDate], [ExpirationDate], [Provider_Id]) VALUES (4, N'Car tire.', 1, CAST(N'2022-12-31T19:36:46.133' AS DateTime), CAST(N'2025-12-31T19:36:46.133' AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Provider] ON 

INSERT [dbo].[Provider] ([Id], [Description], [Cnpj]) VALUES (1, N'The General Motors Company is an American multinational automotive manufacturing company.', N'59275792001636')
INSERT [dbo].[Provider] ([Id], [Description], [Cnpj]) VALUES (2, N'Ford Motor Company is an American multinational automobile manufacturer headquartered in Dearborn.', N'03470727001283')
INSERT [dbo].[Provider] ([Id], [Description], [Cnpj]) VALUES (3, N'FIAT is one of the brands of Stellantis, one of the largest car manufacturers in the world, with headquarters in the city of Turin, northern Italy.', N'16701716000156')
SET IDENTITY_INSERT [dbo].[Provider] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Provider__A299CC922F4210A1]    Script Date: 31/12/2022 18:15:03 ******/
ALTER TABLE [dbo].[Provider] ADD UNIQUE NONCLUSTERED 
(
	[Cnpj] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([Provider_Id])
REFERENCES [dbo].[Provider] ([Id])
GO
USE [master]
GO
ALTER DATABASE [productmanagement] SET  READ_WRITE 
GO
