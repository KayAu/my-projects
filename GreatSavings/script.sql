USE [master]
GO
/****** Object:  Database [GreatSavings]    Script Date: 03/05/2015 13:45:23 ******/
CREATE DATABASE [GreatSavings] ON  PRIMARY 
( NAME = N'GreatSavings', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\GreatSavings.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GreatSavings_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\GreatSavings_log.ldf' , SIZE = 27648KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GreatSavings] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GreatSavings].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GreatSavings] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [GreatSavings] SET ANSI_NULLS OFF
GO
ALTER DATABASE [GreatSavings] SET ANSI_PADDING OFF
GO
ALTER DATABASE [GreatSavings] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [GreatSavings] SET ARITHABORT OFF
GO
ALTER DATABASE [GreatSavings] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [GreatSavings] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [GreatSavings] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [GreatSavings] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [GreatSavings] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [GreatSavings] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [GreatSavings] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [GreatSavings] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [GreatSavings] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [GreatSavings] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [GreatSavings] SET  DISABLE_BROKER
GO
ALTER DATABASE [GreatSavings] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [GreatSavings] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [GreatSavings] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [GreatSavings] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [GreatSavings] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [GreatSavings] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [GreatSavings] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [GreatSavings] SET  READ_WRITE
GO
ALTER DATABASE [GreatSavings] SET RECOVERY FULL
GO
ALTER DATABASE [GreatSavings] SET  MULTI_USER
GO
ALTER DATABASE [GreatSavings] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [GreatSavings] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'GreatSavings', N'ON'
GO
USE [GreatSavings]
GO
/****** Object:  User [sitecore]    Script Date: 03/05/2015 13:45:23 ******/
CREATE USER [sitecore] FOR LOGIN [sitecore] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [gsaving]    Script Date: 03/05/2015 13:45:23 ******/
CREATE USER [gsaving] FOR LOGIN [gsaving] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 03/05/2015 13:45:24 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[States]    Script Date: 03/05/2015 13:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[States](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [varchar](50) NULL,
	[StateCode] [char](3) NULL,
	[CountryCode] [char](2) NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 03/05/2015 13:45:24 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdvertisementType]    Script Date: 03/05/2015 13:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdvertisementType](
	[AdTypeId] [int] IDENTITY(1,1) NOT NULL,
	[AdName] [varchar](30) NOT NULL,
 CONSTRAINT [PK_AdvertisementType] PRIMARY KEY CLUSTERED 
(
	[AdTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 03/05/2015 13:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [smallmoney] NOT NULL,
	[Currency] [char](3) NOT NULL,
	[Hint] [varchar](20) NULL,
	[Payable] [bit] NOT NULL,
	[Description] [text] NULL,
	[MaxTerm] [int] NOT NULL,
	[Term] [varchar](20) NULL,
	[Position] [smallint] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PromotionsType]    Script Date: 03/05/2015 13:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PromotionsType](
	[PromotionsTypeId] [int] IDENTITY(1,1) NOT NULL,
	[PromotionsType] [varchar](30) NOT NULL,
 CONSTRAINT [PK_PromotionsType] PRIMARY KEY CLUSTERED 
(
	[PromotionsTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MerchantAccount]    Script Date: 03/05/2015 13:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MerchantAccount](
	[MerchantId] [int] NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_MerchantAccount_1] PRIMARY KEY CLUSTERED 
(
	[MerchantId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 03/05/2015 13:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Country](
	[CountryCode] [char](2) NOT NULL,
	[CountryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BusinessIndustry]    Script Date: 03/05/2015 13:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BusinessIndustry](
	[BusIndustryId] [int] IDENTITY(1,1) NOT NULL,
	[BusIndustry] [varchar](50) NOT NULL,
 CONSTRAINT [PK_BusinessIndustry] PRIMARY KEY CLUSTERED 
(
	[BusIndustryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 03/05/2015 13:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[ConfirmedEmail] [bit] NOT NULL,
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers] 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 03/05/2015 13:45:24 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles] 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles] 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 03/05/2015 13:45:24 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins] 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 03/05/2015 13:45:24 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims] 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Merchant]    Script Date: 03/05/2015 13:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Merchant](
	[MerchantId] [int] NOT NULL,
	[CompanyName] [varchar](100) NOT NULL,
	[StreetName] [varchar](80) NOT NULL,
	[Postcode] [int] NOT NULL,
	[State] [varchar](30) NOT NULL,
	[Country] [varchar](20) NOT NULL,
	[Website] [varchar](50) NULL,
	[OperateFrom] [varchar](10) NOT NULL,
	[OperateTo] [varchar](10) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NULL,
	[ContactNo] [varchar](20) NOT NULL,
	[BusIndustryId] [int] NOT NULL,
	[IsActivated] [bit] NULL,
	[CompanyImg] [image] NULL,
	[UserId] [nvarchar](128) NULL,
 CONSTRAINT [PK_Merchant] PRIMARY KEY CLUSTERED 
(
	[MerchantId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Promotions]    Script Date: 03/05/2015 13:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Promotions](
	[PromotionId] [int] IDENTITY(1,1) NOT NULL,
	[PromotionTypeId] [int] NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Desc] [varchar](250) NOT NULL,
	[ValidFrom] [varchar](20) NOT NULL,
	[ValidTo] [varchar](20) NOT NULL,
	[IsNationWide] [bit] NULL,
	[ImgThumbnail] [image] NOT NULL,
	[ImgDetailPage] [image] NOT NULL,
	[ImgPremiumAd] [image] NULL,
 CONSTRAINT [PK_Promotions] PRIMARY KEY CLUSTERED 
(
	[PromotionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateMerchant]    Script Date: 03/05/2015 13:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Au, Kah Yin
-- Create date: 03 Dec 2014
-- Description:	Create a new merchant account
-- =============================================
CREATE PROCEDURE [dbo].[sp_CreateMerchant]
	-- Add the parameters for the stored procedure here
	@prUserID NVARCHAR(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @lastMerchantId INT

	SELECT @lastMerchantId = MAX(MerchantId) FROM MerchantAccount

		IF ( @lastMerchantId IS NULL)
			SET @lastMerchantId = 100001
		ELSE
		  SET @lastMerchantId = @lastMerchantId +1

	SELECT @lastMerchantId

	INSERT INTO MerchantAccount
	SELECT @lastMerchantId, @prUserID

	RETURN @lastMerchantId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckEmailAlreadyExist]    Script Date: 03/05/2015 13:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Au, Kah Yin
-- Create date: 02 Feb 2015
-- Description:	Verify an email already exists
-- Test: exec sp_CheckEmailAlreadyExist 'kytest1@test.com'
-- =============================================
CREATE PROCEDURE [dbo].[sp_CheckEmailAlreadyExist]
	-- Add the parameters for the stored procedure here
	@prEmail VARCHAR(60)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @isExists INT = 0

	IF EXISTS (SELECT * FROM dbo.AspNetUsers  WHERE Email = @prEmail ) 
		SET @isExists = 1  
	
	SELECT @isExists

END
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 03/05/2015 13:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransId] [int] IDENTITY(1,1) NOT NULL,
	[TransCode] [varchar](20) NOT NULL,
	[MerchantId] [int] NOT NULL,
	[TotalPymt] [smallmoney] NOT NULL,
	[CreatedOn] [smalldatetime] NOT NULL,
	[PymtReceived] [bit] NOT NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[TransId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Directory]    Script Date: 03/05/2015 13:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Directory](
	[DirId] [varchar](10) NOT NULL,
	[CompanyName] [varchar](100) NOT NULL,
	[StreetName] [varchar](80) NOT NULL,
	[Postcode] [int] NOT NULL,
	[State] [varchar](30) NOT NULL,
	[Country] [varchar](20) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Website] [varchar](50) NULL,
	[OperateFrom] [varchar](10) NOT NULL,
	[OperateTo] [varchar](10) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[ContactNo] [varchar](20) NOT NULL,
	[BusIndustryId] [int] NOT NULL,
	[IsActivated] [bit] NULL,
	[CompanyImg] [image] NULL,
	[TransId] [int] NULL,
	[MerchantId] [int] NULL,
 CONSTRAINT [PK_Directory] PRIMARY KEY CLUSTERED 
(
	[DirId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Recommendations]    Script Date: 03/05/2015 13:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Recommendations](
	[RecomId] [int] IDENTITY(1,1) NOT NULL,
	[TransId] [int] NOT NULL,
	[DirId] [varchar](10) NULL,
	[Description] [text] NOT NULL,
	[ExpiryDate] [smalldatetime] NULL,
	[IsActive] [bit] NULL,
	[Image1] [image] NOT NULL,
	[Image2] [image] NOT NULL,
	[Image3] [image] NULL,
	[Image4] [image] NULL,
	[Image5] [image] NULL,
	[Image6] [image] NULL,
 CONSTRAINT [PK_Recommendations] PRIMARY KEY CLUSTERED 
(
	[RecomId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NewOpening]    Script Date: 03/05/2015 13:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NewOpening](
	[NewOpenId] [int] IDENTITY(1,1) NOT NULL,
	[TransId] [int] NOT NULL,
	[DirId] [varchar](10) NULL,
	[Description] [text] NOT NULL,
	[ExpiryDate] [smalldatetime] NULL,
	[IsActive] [bit] NOT NULL,
	[Image] [image] NOT NULL,
 CONSTRAINT [PK_NewOpening] PRIMARY KEY CLUSTERED 
(
	[NewOpenId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Advertisement]    Script Date: 03/05/2015 13:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Advertisement](
	[AdId] [int] IDENTITY(1,1) NOT NULL,
	[TransId] [int] NOT NULL,
	[DirId] [varchar](10) NULL,
	[ExpiryDate] [smalldatetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Image] [image] NULL,
	[AdTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Advertisement] PRIMARY KEY CLUSTERED 
(
	[AdId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Deals]    Script Date: 03/05/2015 13:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Deals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransId] [int] NOT NULL,
	[DirId] [varchar](10) NULL,
	[Title] [varchar](150) NOT NULL,
	[Description] [varchar](850) NOT NULL,
	[ExpiryDate] [smalldatetime] NOT NULL,
	[TermsAndCondition] [text] NOT NULL,
	[Image] [image] NOT NULL,
	[IsActivated] [bit] NOT NULL,
 CONSTRAINT [PK_Deals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_Product_Price]    Script Date: 03/05/2015 13:45:24 ******/
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Price]  DEFAULT ((0)) FOR [Price]
GO
/****** Object:  Default [DF_Product_MaxTerm]    Script Date: 03/05/2015 13:45:24 ******/
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_MaxTerm]  DEFAULT ((0)) FOR [MaxTerm]
GO
/****** Object:  Default [DF_Promotions_IsNationWide]    Script Date: 03/05/2015 13:45:24 ******/
ALTER TABLE [dbo].[Promotions] ADD  CONSTRAINT [DF_Promotions_IsNationWide]  DEFAULT ((0)) FOR [IsNationWide]
GO
/****** Object:  Default [DF_Transaction_CreatedOn]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_Transaction_CreatedOn]  DEFAULT (CONVERT([smalldatetime],getdate(),(0))) FOR [CreatedOn]
GO
/****** Object:  Default [DF_Transaction_PymtReceived]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_Transaction_PymtReceived]  DEFAULT ((0)) FOR [PymtReceived]
GO
/****** Object:  Default [DF_Directory_IsActivated]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Directory] ADD  CONSTRAINT [DF_Directory_IsActivated]  DEFAULT ((0)) FOR [IsActivated]
GO
/****** Object:  Default [DF_Recommendations_IsActive]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Recommendations] ADD  CONSTRAINT [DF_Recommendations_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
/****** Object:  Default [DF_NewOpening_IsActive]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[NewOpening] ADD  CONSTRAINT [DF_NewOpening_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
/****** Object:  Default [DF_Advertisement_IsActive]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Advertisement] ADD  CONSTRAINT [DF_Advertisement_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
/****** Object:  Default [DF_Deals_IsActivated]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Deals] ADD  CONSTRAINT [DF_Deals_IsActivated]  DEFAULT ((0)) FOR [IsActivated]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]    Script Date: 03/05/2015 13:45:24 ******/
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]    Script Date: 03/05/2015 13:45:24 ******/
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]    Script Date: 03/05/2015 13:45:24 ******/
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]    Script Date: 03/05/2015 13:45:24 ******/
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
/****** Object:  ForeignKey [FK_Merchant_BusinessIndustry]    Script Date: 03/05/2015 13:45:24 ******/
ALTER TABLE [dbo].[Merchant]  WITH CHECK ADD  CONSTRAINT [FK_Merchant_BusinessIndustry] FOREIGN KEY([BusIndustryId])
REFERENCES [dbo].[BusinessIndustry] ([BusIndustryId])
GO
ALTER TABLE [dbo].[Merchant] CHECK CONSTRAINT [FK_Merchant_BusinessIndustry]
GO
/****** Object:  ForeignKey [FK_Promotions_PromotionsType]    Script Date: 03/05/2015 13:45:24 ******/
ALTER TABLE [dbo].[Promotions]  WITH CHECK ADD  CONSTRAINT [FK_Promotions_PromotionsType] FOREIGN KEY([PromotionTypeId])
REFERENCES [dbo].[PromotionsType] ([PromotionsTypeId])
GO
ALTER TABLE [dbo].[Promotions] CHECK CONSTRAINT [FK_Promotions_PromotionsType]
GO
/****** Object:  ForeignKey [FK_Transactions_Merchant]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Merchant] FOREIGN KEY([MerchantId])
REFERENCES [dbo].[Merchant] ([MerchantId])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Merchant]
GO
/****** Object:  ForeignKey [FK_Transactions_Transactions]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Transactions] FOREIGN KEY([TransId])
REFERENCES [dbo].[Transactions] ([TransId])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Transactions]
GO
/****** Object:  ForeignKey [FK_Directory_BusinessIndustry]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Directory]  WITH CHECK ADD  CONSTRAINT [FK_Directory_BusinessIndustry] FOREIGN KEY([BusIndustryId])
REFERENCES [dbo].[BusinessIndustry] ([BusIndustryId])
GO
ALTER TABLE [dbo].[Directory] CHECK CONSTRAINT [FK_Directory_BusinessIndustry]
GO
/****** Object:  ForeignKey [FK_Directory_Directory]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Directory]  WITH CHECK ADD  CONSTRAINT [FK_Directory_Directory] FOREIGN KEY([DirId])
REFERENCES [dbo].[Directory] ([DirId])
GO
ALTER TABLE [dbo].[Directory] CHECK CONSTRAINT [FK_Directory_Directory]
GO
/****** Object:  ForeignKey [FK_Directory_Transaction]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Directory]  WITH CHECK ADD  CONSTRAINT [FK_Directory_Transaction] FOREIGN KEY([TransId])
REFERENCES [dbo].[Transactions] ([TransId])
GO
ALTER TABLE [dbo].[Directory] CHECK CONSTRAINT [FK_Directory_Transaction]
GO
/****** Object:  ForeignKey [FK_Recommendations_Directory]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Recommendations]  WITH CHECK ADD  CONSTRAINT [FK_Recommendations_Directory] FOREIGN KEY([DirId])
REFERENCES [dbo].[Directory] ([DirId])
GO
ALTER TABLE [dbo].[Recommendations] CHECK CONSTRAINT [FK_Recommendations_Directory]
GO
/****** Object:  ForeignKey [FK_Recommendations_Recommendations]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Recommendations]  WITH CHECK ADD  CONSTRAINT [FK_Recommendations_Recommendations] FOREIGN KEY([RecomId])
REFERENCES [dbo].[Recommendations] ([RecomId])
GO
ALTER TABLE [dbo].[Recommendations] CHECK CONSTRAINT [FK_Recommendations_Recommendations]
GO
/****** Object:  ForeignKey [FK_Recommendations_Transaction]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Recommendations]  WITH CHECK ADD  CONSTRAINT [FK_Recommendations_Transaction] FOREIGN KEY([TransId])
REFERENCES [dbo].[Transactions] ([TransId])
GO
ALTER TABLE [dbo].[Recommendations] CHECK CONSTRAINT [FK_Recommendations_Transaction]
GO
/****** Object:  ForeignKey [FK_NewOpening_Directory]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[NewOpening]  WITH CHECK ADD  CONSTRAINT [FK_NewOpening_Directory] FOREIGN KEY([DirId])
REFERENCES [dbo].[Directory] ([DirId])
GO
ALTER TABLE [dbo].[NewOpening] CHECK CONSTRAINT [FK_NewOpening_Directory]
GO
/****** Object:  ForeignKey [FK_NewOpening_Transaction]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[NewOpening]  WITH CHECK ADD  CONSTRAINT [FK_NewOpening_Transaction] FOREIGN KEY([TransId])
REFERENCES [dbo].[Transactions] ([TransId])
GO
ALTER TABLE [dbo].[NewOpening] CHECK CONSTRAINT [FK_NewOpening_Transaction]
GO
/****** Object:  ForeignKey [FK_Advertisement_Advertisement]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Advertisement]  WITH CHECK ADD  CONSTRAINT [FK_Advertisement_Advertisement] FOREIGN KEY([TransId])
REFERENCES [dbo].[Transactions] ([TransId])
GO
ALTER TABLE [dbo].[Advertisement] CHECK CONSTRAINT [FK_Advertisement_Advertisement]
GO
/****** Object:  ForeignKey [FK_Advertisement_Advertisement1]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Advertisement]  WITH CHECK ADD  CONSTRAINT [FK_Advertisement_Advertisement1] FOREIGN KEY([AdId])
REFERENCES [dbo].[Advertisement] ([AdId])
GO
ALTER TABLE [dbo].[Advertisement] CHECK CONSTRAINT [FK_Advertisement_Advertisement1]
GO
/****** Object:  ForeignKey [FK_Advertisement_AdvertisementType]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Advertisement]  WITH CHECK ADD  CONSTRAINT [FK_Advertisement_AdvertisementType] FOREIGN KEY([AdId])
REFERENCES [dbo].[AdvertisementType] ([AdTypeId])
GO
ALTER TABLE [dbo].[Advertisement] CHECK CONSTRAINT [FK_Advertisement_AdvertisementType]
GO
/****** Object:  ForeignKey [FK_Advertisement_Directory]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Advertisement]  WITH CHECK ADD  CONSTRAINT [FK_Advertisement_Directory] FOREIGN KEY([DirId])
REFERENCES [dbo].[Directory] ([DirId])
GO
ALTER TABLE [dbo].[Advertisement] CHECK CONSTRAINT [FK_Advertisement_Directory]
GO
/****** Object:  ForeignKey [FK_Deals_Deals]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Deals]  WITH CHECK ADD  CONSTRAINT [FK_Deals_Deals] FOREIGN KEY([Id])
REFERENCES [dbo].[Deals] ([Id])
GO
ALTER TABLE [dbo].[Deals] CHECK CONSTRAINT [FK_Deals_Deals]
GO
/****** Object:  ForeignKey [FK_Deals_Directory]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Deals]  WITH CHECK ADD  CONSTRAINT [FK_Deals_Directory] FOREIGN KEY([DirId])
REFERENCES [dbo].[Directory] ([DirId])
GO
ALTER TABLE [dbo].[Deals] CHECK CONSTRAINT [FK_Deals_Directory]
GO
/****** Object:  ForeignKey [FK_Deals_Transactions]    Script Date: 03/05/2015 13:45:25 ******/
ALTER TABLE [dbo].[Deals]  WITH CHECK ADD  CONSTRAINT [FK_Deals_Transactions] FOREIGN KEY([TransId])
REFERENCES [dbo].[Transactions] ([TransId])
GO
ALTER TABLE [dbo].[Deals] CHECK CONSTRAINT [FK_Deals_Transactions]
GO
