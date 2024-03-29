USE [master]
GO
/****** Object:  Database [GurpreetVideoSystem]    Script Date: 9/24/2019 2:37:43 PM ******/
CREATE DATABASE [GurpreetVideoSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GurpreetVideoSystem_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\GurpreetVideoSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GurpreetVideoSystem_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\GurpreetVideoSystem.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GurpreetVideoSystem] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GurpreetVideoSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GurpreetVideoSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GurpreetVideoSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GurpreetVideoSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GurpreetVideoSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GurpreetVideoSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [GurpreetVideoSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GurpreetVideoSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GurpreetVideoSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GurpreetVideoSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GurpreetVideoSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GurpreetVideoSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GurpreetVideoSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GurpreetVideoSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GurpreetVideoSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GurpreetVideoSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GurpreetVideoSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GurpreetVideoSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GurpreetVideoSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GurpreetVideoSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GurpreetVideoSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GurpreetVideoSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GurpreetVideoSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GurpreetVideoSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GurpreetVideoSystem] SET  MULTI_USER 
GO
ALTER DATABASE [GurpreetVideoSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GurpreetVideoSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GurpreetVideoSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GurpreetVideoSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GurpreetVideoSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GurpreetVideoSystem] SET QUERY_STORE = OFF
GO
USE [GurpreetVideoSystem]
GO
/****** Object:  Table [dbo].[customerData]    Script Date: 9/24/2019 2:37:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customerData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstname] [varchar](50) NULL,
	[lastname] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[address] [varchar](50) NULL,
 CONSTRAINT [PK_customerData] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rentData]    Script Date: 9/24/2019 2:37:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rentData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customerId] [int] NULL,
	[MovieId] [int] NULL,
	[dateofIssue] [varchar](50) NULL,
	[dateofReturn] [varchar](50) NULL,
 CONSTRAINT [PK_rentData] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[videoData]    Script Date: 9/24/2019 2:37:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[videoData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NULL,
	[ratting] [varchar](50) NULL,
	[year] [varchar](50) NULL,
	[copies] [varchar](50) NULL,
	[cost] [varchar](50) NULL,
	[plot] [varchar](50) NULL,
	[genre] [varchar](50) NULL,
 CONSTRAINT [PK_videoData] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [GurpreetVideoSystem] SET  READ_WRITE 
GO
