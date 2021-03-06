USE [master]
GO
/****** Object:  Database [TravelInn20190219]    Script Date: 22/02/2019 17:51:11 ******/
CREATE DATABASE [TravelInn20190219]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TravelInn20190219', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\TravelInn20190219.mdf' , SIZE = 7168KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TravelInn20190219_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\TravelInn20190219_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TravelInn20190219] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TravelInn20190219].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TravelInn20190219] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TravelInn20190219] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TravelInn20190219] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TravelInn20190219] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TravelInn20190219] SET ARITHABORT OFF 
GO
ALTER DATABASE [TravelInn20190219] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TravelInn20190219] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TravelInn20190219] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TravelInn20190219] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TravelInn20190219] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TravelInn20190219] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TravelInn20190219] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TravelInn20190219] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TravelInn20190219] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TravelInn20190219] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TravelInn20190219] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TravelInn20190219] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TravelInn20190219] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TravelInn20190219] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TravelInn20190219] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TravelInn20190219] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TravelInn20190219] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TravelInn20190219] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TravelInn20190219] SET  MULTI_USER 
GO
ALTER DATABASE [TravelInn20190219] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TravelInn20190219] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TravelInn20190219] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TravelInn20190219] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TravelInn20190219] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TravelInn20190219]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Banka]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banka](
	[Id] [int] NOT NULL,
	[Banka_Adi] [nvarchar](256) NOT NULL,
	[Telefon] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Adres] [nvarchar](255) NULL,
	[Uniqueidentifier] [nvarchar](50) NULL,
	[WhoInserted] [nvarchar](256) NULL,
	[WhoUpdated] [nvarchar](256) NULL,
	[WhoDeleted] [nvarchar](256) NULL,
	[WhenInserted] [datetime2](7) NULL,
	[WhenUpdated] [datetime2](7) NULL,
	[WhenDeleted] [datetime2](7) NULL,
 CONSTRAINT [PK_Banka] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cari]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cari](
	[Id] [int] NOT NULL,
	[Tarih] [smalldatetime] NULL,
	[Aciklama] [nvarchar](250) NOT NULL,
	[TL] [numeric](18, 2) NULL,
	[Euro] [numeric](18, 2) NULL,
	[Dollar] [numeric](18, 2) NULL,
	[FirmaId] [int] NOT NULL,
	[Uniqueidentifier] [nvarchar](50) NULL,
	[WhoInserted] [nvarchar](256) NULL,
	[WhoUpdated] [nvarchar](256) NULL,
	[WhoDeleted] [nvarchar](256) NULL,
	[WhenInserted] [datetime2](7) NULL,
	[WhenUpdated] [datetime2](7) NULL,
	[WhenDeleted] [datetime2](7) NULL,
	[VoucherNo] [nvarchar](50) NULL,
	[Pax] [nvarchar](50) NULL,
	[MusteriId] [int] NULL,
	[TurId] [int] NULL,
	[OtelId] [int] NULL,
	[SatisSorumlusu_Id] [int] NULL,
	[Confirmed] [bit] NOT NULL CONSTRAINT [DF_Cari_Confirmed]  DEFAULT ((0)),
 CONSTRAINT [PK_Odenecek] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CariConfirmations]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CariConfirmations](
	[Id] [int] NOT NULL,
	[CariId] [int] NOT NULL,
	[FilePath] [nvarchar](255) NULL,
	[Uniqueidentifier] [nvarchar](50) NULL,
	[WhenDeleted] [datetime2](7) NULL,
	[WhoInserted] [nvarchar](256) NULL,
	[WhoUpdated] [nvarchar](256) NULL,
	[WhoDeleted] [nvarchar](256) NULL,
	[WhenInserted] [datetime2](7) NULL,
	[WhenUpdated] [datetime2](7) NULL,
 CONSTRAINT [PK_CariConfirmations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CariLog]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CariLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tarih] [smalldatetime] NULL,
	[Aciklama] [nvarchar](250) NOT NULL,
	[TL] [numeric](18, 2) NULL,
	[Euro] [numeric](18, 2) NULL,
	[Dollar] [numeric](18, 2) NULL,
	[FirmaIsmi] [nvarchar](250) NOT NULL,
	[Uniqueidentifier] [nvarchar](50) NULL,
	[VoucherNo] [nvarchar](50) NULL,
	[Pax] [nvarchar](50) NULL,
	[MusteriAdi] [nvarchar](256) NULL,
	[TurAdi] [nvarchar](256) NULL,
	[OtelAdi] [nvarchar](256) NULL,
	[Who] [nvarchar](256) NULL,
	[When] [datetime2](7) NULL,
	[Action] [nvarchar](50) NULL,
	[SatisSorumlusu] [nvarchar](256) NULL,
 CONSTRAINT [PK_CariLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Firma]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Firma](
	[Id] [int] NOT NULL,
	[Ismi] [nvarchar](250) NOT NULL,
	[Adresi] [nvarchar](500) NULL,
	[Uniqueidentifier] [nvarchar](50) NULL,
	[WhoInserted] [nvarchar](256) NULL,
	[WhoUpdated] [nvarchar](256) NULL,
	[WhoDeleted] [nvarchar](256) NULL,
	[WhenInserted] [datetime2](7) NULL,
	[WhenUpdated] [datetime2](7) NULL,
	[WhenDeleted] [datetime2](7) NULL,
 CONSTRAINT [PK_Firma] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FirmaTemsilcisi]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FirmaTemsilcisi](
	[Id] [int] NOT NULL,
	[AdiSoyadi] [nvarchar](50) NOT NULL,
	[Telefon] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[FirmaId] [int] NOT NULL,
	[Uniqueidentifier] [nvarchar](50) NULL,
	[WhoInserted] [nvarchar](256) NULL,
	[WhoUpdated] [nvarchar](256) NULL,
	[WhoDeleted] [nvarchar](256) NULL,
	[WhenInserted] [datetime2](7) NULL,
	[WhenUpdated] [datetime2](7) NULL,
	[WhenDeleted] [datetime2](7) NULL,
 CONSTRAINT [PK_FirmaTemsilcisi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Log]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](50) NULL,
	[LogString] [nvarchar](2000) NULL,
	[TimeStamp] [datetime2](7) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Musteri]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteri](
	[Id] [int] NOT NULL,
	[Musteri_AdiSoyadi] [nvarchar](256) NOT NULL,
	[Telefon] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Adres] [nvarchar](255) NULL,
	[Uniqueidentifier] [nvarchar](50) NULL,
	[WhoInserted] [nvarchar](256) NULL,
	[WhoUpdated] [nvarchar](256) NULL,
	[WhoDeleted] [nvarchar](256) NULL,
	[WhenInserted] [datetime2](7) NULL,
	[WhenUpdated] [datetime2](7) NULL,
	[WhenDeleted] [datetime2](7) NULL,
	[Uyruk_Id] [int] NULL,
 CONSTRAINT [PK_Musteri] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Odeme]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Odeme](
	[Id] [int] NOT NULL,
	[Tarih] [smalldatetime] NULL,
	[Aciklama] [nvarchar](250) NOT NULL,
	[TL] [numeric](18, 2) NULL,
	[Euro] [numeric](18, 2) NULL,
	[Dollar] [numeric](18, 2) NULL,
	[FirmaId] [int] NOT NULL,
	[Uniqueidentifier] [nvarchar](50) NULL,
	[WhoInserted] [nvarchar](256) NULL,
	[WhoUpdated] [nvarchar](256) NULL,
	[WhoDeleted] [nvarchar](256) NULL,
	[WhenInserted] [datetime2](7) NULL,
	[WhenUpdated] [datetime2](7) NULL,
	[WhenDeleted] [datetime2](7) NULL,
	[Banka_Id] [int] NULL,
 CONSTRAINT [PK_Odenen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OdemeLog]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OdemeLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tarih] [smalldatetime] NULL,
	[Aciklama] [nvarchar](250) NOT NULL,
	[TL] [numeric](18, 2) NULL,
	[Euro] [numeric](18, 2) NULL,
	[Dollar] [numeric](18, 2) NULL,
	[FirmaIsmi] [nvarchar](250) NOT NULL,
	[Uniqueidentifier] [nvarchar](50) NULL,
	[Who] [nvarchar](256) NULL,
	[When] [datetime2](7) NULL,
	[Action] [nvarchar](50) NULL,
	[Banka] [nvarchar](256) NULL,
 CONSTRAINT [PK_OdemeLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Otel]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Otel](
	[Id] [int] NOT NULL,
	[Otel_Adi] [nvarchar](256) NOT NULL,
	[Telefon] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Adres] [nvarchar](255) NULL,
	[Uniqueidentifier] [nvarchar](50) NULL,
	[WhoInserted] [nvarchar](256) NULL,
	[WhoUpdated] [nvarchar](256) NULL,
	[WhoDeleted] [nvarchar](256) NULL,
	[WhenInserted] [datetime2](7) NULL,
	[WhenUpdated] [datetime2](7) NULL,
	[WhenDeleted] [datetime2](7) NULL,
 CONSTRAINT [PK_Otel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SatisSorumlusu]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatisSorumlusu](
	[Id] [int] NOT NULL,
	[Ismi] [nvarchar](256) NOT NULL,
	[Telefon] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Adres] [nvarchar](255) NULL,
	[Uniqueidentifier] [nvarchar](50) NULL,
	[WhoInserted] [nvarchar](256) NULL,
	[WhoUpdated] [nvarchar](256) NULL,
	[WhoDeleted] [nvarchar](256) NULL,
	[WhenInserted] [datetime2](7) NULL,
	[WhenUpdated] [datetime2](7) NULL,
	[WhenDeleted] [datetime2](7) NULL,
 CONSTRAINT [PK_SatisSorumlusu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tur]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tur](
	[Id] [int] NOT NULL,
	[Tur_Adi] [nvarchar](256) NOT NULL,
	[Telefon] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Adres] [nvarchar](255) NULL,
	[Uniqueidentifier] [nvarchar](50) NULL,
	[WhoInserted] [nvarchar](256) NULL,
	[WhoUpdated] [nvarchar](256) NULL,
	[WhoDeleted] [nvarchar](256) NULL,
	[WhenInserted] [datetime2](7) NULL,
	[WhenUpdated] [datetime2](7) NULL,
	[WhenDeleted] [datetime2](7) NULL,
 CONSTRAINT [PK_Tur] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Uyruk]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uyruk](
	[Id] [int] NOT NULL,
	[Uyrugu] [nvarchar](256) NOT NULL,
	[Uniqueidentifier] [nvarchar](50) NULL,
	[WhoInserted] [nvarchar](256) NULL,
	[WhoUpdated] [nvarchar](256) NULL,
	[WhoDeleted] [nvarchar](256) NULL,
	[WhenInserted] [datetime2](7) NULL,
	[WhenUpdated] [datetime2](7) NULL,
	[WhenDeleted] [datetime2](7) NULL,
 CONSTRAINT [PK_Uyruk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[View_CariOdemeExcel]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE View [dbo].[View_CariOdemeExcel]
AS

Select Distinct
	UnionId.Id, UnionId.FirmaId, f.Ismi as Firma, Cari.Tarih as CTarih, Cari.Aciklama as CAciklama, Cari.TL as CTL, Cari.Euro as CEuro, Cari.Dollar as CDollar, Cari.Musteri_AdiSoyadi as CMusteri_AdiSoyadi, Cari.Tur_Adi as CTur_Adi, Cari.Otel_Adi as COtel_Adi, Cari.SatisSorumlusu,
								 Odeme.Tarih as OTarih, Odeme.Aciklama as OAciklama, Odeme.TL as OTL, Odeme.Euro as OEuro, Odeme.Dollar as ODollar, Odeme.Banka_Adi
From 
	(
		Select 
			Id, FirmaId
		From 
			Cari c

		union all

		Select 
			Id, FirmaId
		From 
			Odeme o

	) UnionId

Left Outer Join 
	(
		Select 
			c.Id, FirmaId, Tarih, Aciklama, TL, Euro, Dollar, m.Musteri_AdiSoyadi, t.Tur_Adi, o.Otel_Adi, ss.Ismi as SatisSorumlusu
		From 
			Cari c
		Left Outer Join Musteri m on c.MusteriId = m.Id
		Left Outer Join Tur t on c.TurId = t.Id
		Left Outer Join Otel o on c.OtelId = o.Id
		Left Outer Join SatisSorumlusu ss on c.SatisSorumlusu_Id = ss.Id

	) Cari On UnionId.Id = Cari.Id and UnionId.FirmaId = Cari.FirmaId

Left Outer Join 
	(
		Select 
			o.Id, FirmaId, Tarih, Aciklama, TL, Euro, Dollar, b.Banka_Adi
		From 
			Odeme o
		Left Outer Join Banka b on o.Banka_Id = b.Id

	) Odeme On UnionId.Id = Odeme.Id and UnionId.FirmaId = Odeme.FirmaId

Inner Join Firma f on UnionId.FirmaId = f.Id






GO
/****** Object:  View [dbo].[View_FirmaBakiye]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_FirmaBakiye]
AS
SELECT     
	FirmaId, 
	Firma, 
	ISNULL(SUM(CTL), 0) AS Cari_TL,
	ISNULL(SUM(CEuro), 0) AS Cari_Euro, 
	ISNULL(SUM(CDollar), 0) AS Cari_Dollar, 
	ISNULL(SUM(OTL), 0) AS Odeme_TL, 
	ISNULL(SUM(OEuro), 0) AS Odeme_Euro, 
	ISNULL(SUM(ODollar), 0) AS Odeme_Dollar,
	ISNULL(SUM(CTL), 0) - ISNULL(SUM(OTL), 0) AS Bakiye_TL,
	ISNULL(SUM(CEuro), 0) - ISNULL(SUM(OEuro), 0) AS Bakiye_Euro, 
	ISNULL(SUM(CDollar), 0) - ISNULL(SUM(ODollar), 0) AS Bakiye_Dollar 
FROM
	dbo.View_CariOdemeExcel
GROUP BY FirmaId, Firma



GO
/****** Object:  View [dbo].[View_CariSearch]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE VIEW [dbo].[View_CariSearch]
AS
SELECT     dbo.Cari.Id, dbo.Firma.Id AS FirmaId, dbo.Firma.Ismi AS Firma, dbo.Cari.Tarih, dbo.Cari.Aciklama, dbo.SatisSorumlusu.Ismi AS Sorumlu, dbo.Cari.Dollar, dbo.Cari.Euro, dbo.Cari.TL, 
                      dbo.Cari.VoucherNo AS Vno, dbo.Cari.Pax, dbo.Musteri.Musteri_AdiSoyadi AS Musteri, dbo.Uyruk.Uyrugu, dbo.Tur.Tur_Adi AS Tur, dbo.Otel.Otel_Adi AS Otel
FROM         dbo.Uyruk RIGHT OUTER JOIN
                      dbo.Musteri ON dbo.Uyruk.Id = dbo.Musteri.Uyruk_Id RIGHT OUTER JOIN
                      dbo.Cari INNER JOIN
                      dbo.Firma ON dbo.Cari.FirmaId = dbo.Firma.Id ON dbo.Musteri.Id = dbo.Cari.MusteriId LEFT OUTER JOIN
                      dbo.Otel ON dbo.Cari.OtelId = dbo.Otel.Id LEFT OUTER JOIN
                      dbo.SatisSorumlusu ON dbo.Cari.SatisSorumlusu_Id = dbo.SatisSorumlusu.Id LEFT OUTER JOIN
                      dbo.Tur ON dbo.Cari.TurId = dbo.Tur.Id



GO
/****** Object:  View [dbo].[View_UyrukCariAdedi]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[View_UyrukCariAdedi]
AS
Select Uyruk.Id, Uyruk.Uyrugu, Uyruk.[Uniqueidentifier], Isnull(CAdet.CariAdedi, 0) as CariAdedi
From Uyruk
left outer join 
(
	Select m.Uyruk_Id, Count(c.MusteriId) as CariAdedi
	From Musteri m left outer join Cari c on m.Id = c.MusteriId
	Where m.Uyruk_Id is not null
	Group by m.Uyruk_Id
) CAdet on Uyruk.Id = CAdet.Uyruk_Id



GO
/****** Object:  View [dbo].[View_YaklasanKayitlar]    Script Date: 22/02/2019 17:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_YaklasanKayitlar]
AS 
SELECT    Cari.Id, Cari.Tarih, Firma.Ismi AS FirmaIsmi, Cari.Aciklama, isnull(SatisSorumlusu.Ismi, N'') AS Sorumlu, Cari.TL, Cari.Euro, Cari.Dollar, Cari.VoucherNo AS VN, Cari.Pax, 
                      isnull(Musteri.Musteri_AdiSoyadi, N'') AS Musteri, isnull(Uyruk.Uyrugu, N'') AS Uyrugu, isnull(Tur.Tur_Adi, N'') AS Tur, isnull(Otel.Otel_Adi, N'') AS Otel
FROM         Uyruk RIGHT OUTER JOIN
                      Musteri ON Uyruk.Id = Musteri.Uyruk_Id RIGHT OUTER JOIN
                      Cari INNER JOIN
                      Firma ON Cari.FirmaId = Firma.Id LEFT OUTER JOIN
                      SatisSorumlusu ON Cari.SatisSorumlusu_Id = SatisSorumlusu.Id ON Musteri.Id = Cari.MusteriId LEFT OUTER JOIN
                      Tur ON Cari.TurId = Tur.Id LEFT OUTER JOIN
                      Otel ON Cari.OtelId = Otel.Id

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 22/02/2019 17:51:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 22/02/2019 17:51:11 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 22/02/2019 17:51:11 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 22/02/2019 17:51:11 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 22/02/2019 17:51:11 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 22/02/2019 17:51:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CariConfirmations]    Script Date: 22/02/2019 17:51:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_CariConfirmations] ON [dbo].[CariConfirmations]
(
	[FilePath] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Firma]    Script Date: 22/02/2019 17:51:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Firma] ON [dbo].[Firma]
(
	[Ismi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Musteri]    Script Date: 22/02/2019 17:51:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Musteri] ON [dbo].[Musteri]
(
	[Musteri_AdiSoyadi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Otel]    Script Date: 22/02/2019 17:51:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Otel] ON [dbo].[Otel]
(
	[Otel_Adi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Tur]    Script Date: 22/02/2019 17:51:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tur] ON [dbo].[Tur]
(
	[Tur_Adi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Cari]  WITH CHECK ADD  CONSTRAINT [FK_Cari_Musteri] FOREIGN KEY([MusteriId])
REFERENCES [dbo].[Musteri] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Cari] CHECK CONSTRAINT [FK_Cari_Musteri]
GO
ALTER TABLE [dbo].[Cari]  WITH CHECK ADD  CONSTRAINT [FK_Cari_Otel] FOREIGN KEY([OtelId])
REFERENCES [dbo].[Otel] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Cari] CHECK CONSTRAINT [FK_Cari_Otel]
GO
ALTER TABLE [dbo].[Cari]  WITH CHECK ADD  CONSTRAINT [FK_Cari_SatisSorumlusu] FOREIGN KEY([SatisSorumlusu_Id])
REFERENCES [dbo].[SatisSorumlusu] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Cari] CHECK CONSTRAINT [FK_Cari_SatisSorumlusu]
GO
ALTER TABLE [dbo].[Cari]  WITH CHECK ADD  CONSTRAINT [FK_Cari_Tur] FOREIGN KEY([TurId])
REFERENCES [dbo].[Tur] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Cari] CHECK CONSTRAINT [FK_Cari_Tur]
GO
ALTER TABLE [dbo].[Cari]  WITH CHECK ADD  CONSTRAINT [FK_Odenecek_Firma] FOREIGN KEY([FirmaId])
REFERENCES [dbo].[Firma] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Cari] CHECK CONSTRAINT [FK_Odenecek_Firma]
GO
ALTER TABLE [dbo].[CariConfirmations]  WITH CHECK ADD  CONSTRAINT [FK_CariConfirmations_Cari] FOREIGN KEY([CariId])
REFERENCES [dbo].[Cari] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CariConfirmations] CHECK CONSTRAINT [FK_CariConfirmations_Cari]
GO
ALTER TABLE [dbo].[FirmaTemsilcisi]  WITH CHECK ADD  CONSTRAINT [FK_FirmaTemsilcisi_Firma] FOREIGN KEY([FirmaId])
REFERENCES [dbo].[Firma] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[FirmaTemsilcisi] CHECK CONSTRAINT [FK_FirmaTemsilcisi_Firma]
GO
ALTER TABLE [dbo].[Musteri]  WITH CHECK ADD  CONSTRAINT [FK_Musteri_Uyruk] FOREIGN KEY([Uyruk_Id])
REFERENCES [dbo].[Uyruk] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Musteri] CHECK CONSTRAINT [FK_Musteri_Uyruk]
GO
ALTER TABLE [dbo].[Odeme]  WITH CHECK ADD  CONSTRAINT [FK_Odeme_Banka] FOREIGN KEY([Banka_Id])
REFERENCES [dbo].[Banka] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Odeme] CHECK CONSTRAINT [FK_Odeme_Banka]
GO
ALTER TABLE [dbo].[Odeme]  WITH CHECK ADD  CONSTRAINT [FK_Odenen_Firma] FOREIGN KEY([FirmaId])
REFERENCES [dbo].[Firma] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Odeme] CHECK CONSTRAINT [FK_Odenen_Firma]
GO
USE [master]
GO
ALTER DATABASE [TravelInn20190219] SET  READ_WRITE 
GO
