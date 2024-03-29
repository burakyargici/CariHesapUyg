USE [master]
GO
/****** Object:  Database [CariHesap]    Script Date: 9/18/2019 14:26:13 ******/
CREATE DATABASE [CariHesap]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CariHesap', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CariHesap.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CariHesap_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CariHesap_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CariHesap] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CariHesap].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CariHesap] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CariHesap] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CariHesap] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CariHesap] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CariHesap] SET ARITHABORT OFF 
GO
ALTER DATABASE [CariHesap] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CariHesap] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CariHesap] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CariHesap] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CariHesap] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CariHesap] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CariHesap] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CariHesap] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CariHesap] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CariHesap] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CariHesap] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CariHesap] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CariHesap] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CariHesap] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CariHesap] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CariHesap] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CariHesap] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CariHesap] SET RECOVERY FULL 
GO
ALTER DATABASE [CariHesap] SET  MULTI_USER 
GO
ALTER DATABASE [CariHesap] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CariHesap] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CariHesap] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CariHesap] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CariHesap] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CariHesap', N'ON'
GO
ALTER DATABASE [CariHesap] SET QUERY_STORE = OFF
GO
USE [CariHesap]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 9/18/2019 14:26:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[categoryId] [int] NOT NULL,
	[categoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[categoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 9/18/2019 14:26:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[customerId] [int] NOT NULL,
	[customerName] [nvarchar](50) NOT NULL,
	[customerSurname] [nvarchar](50) NOT NULL,
	[customerPhone] [nvarchar](50) NOT NULL,
	[customerAddress] [nvarchar](50) NOT NULL,
	[userId] [int] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[customerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 9/18/2019 14:26:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[productId] [int] NOT NULL,
	[productName] [nvarchar](50) NOT NULL,
	[categoryId] [int] NOT NULL,
	[buyPrice] [int] NOT NULL,
	[sellPrice] [int] NOT NULL,
	[stockCount] [int] NOT NULL,
	[description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[productId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleDapertment]    Script Date: 9/18/2019 14:26:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleDapertment](
	[salesId] [int] NOT NULL,
	[productId] [int] NOT NULL,
	[sellDate] [datetime] NOT NULL,
	[customerId] [int] NOT NULL,
 CONSTRAINT [PK_SaleDapertment] PRIMARY KEY CLUSTERED 
(
	[salesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/18/2019 14:26:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userId] [int] NOT NULL,
	[userName] [nvarchar](50) NOT NULL,
	[userPassword] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Users] FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([userId])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Users]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([categoryId])
REFERENCES [dbo].[Categories] ([categoryId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[SaleDapertment]  WITH CHECK ADD  CONSTRAINT [FK_SaleDapertment_Customers] FOREIGN KEY([customerId])
REFERENCES [dbo].[Customers] ([customerId])
GO
ALTER TABLE [dbo].[SaleDapertment] CHECK CONSTRAINT [FK_SaleDapertment_Customers]
GO
ALTER TABLE [dbo].[SaleDapertment]  WITH CHECK ADD  CONSTRAINT [FK_SaleDapertment_Products] FOREIGN KEY([productId])
REFERENCES [dbo].[Products] ([productId])
GO
ALTER TABLE [dbo].[SaleDapertment] CHECK CONSTRAINT [FK_SaleDapertment_Products]
GO
USE [master]
GO
ALTER DATABASE [CariHesap] SET  READ_WRITE 
GO
