USE [GreatSavings]
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Product_Price]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Product_Price]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [DF_Product_Price]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Product_MaxTerm]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Product_MaxTerm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [DF_Product_MaxTerm]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Product_Searchable]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Product_Searchable]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [DF_Product_Searchable]
END


End
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchProducts]    Script Date: 04/05/2015 22:57:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SearchProducts]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SearchProducts]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 04/05/2015 22:57:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
DROP TABLE [dbo].[Product]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 04/05/2015 22:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
BEGIN
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
	[Searchable] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON
INSERT [dbo].[Product] ([Id], [Name], [Price], [Currency], [Hint], [Payable], [Description], [MaxTerm], [Term], [Position], [Searchable]) VALUES (1, N'Advertisement', 100.0000, N'RM ', N'Weekly', 1, N'Blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah  blah blah blah blah blah blah blah blah blah blah', 52, N'Week(s)', 5, 0)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Currency], [Hint], [Payable], [Description], [MaxTerm], [Term], [Position], [Searchable]) VALUES (2, N'Deals', 88.0000, N'RM ', N'Monthly', 1, N'Blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah  blah blah blah blah blah blah blah blah blah blah', 10, N'Entry', 2, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Currency], [Hint], [Payable], [Description], [MaxTerm], [Term], [Position], [Searchable]) VALUES (3, N'Directory Listing', 50.0000, N'RM ', N'Life Time', 1, N'Blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah  blah blah blah blah blah blah blah blah blah blah', 10, N'Entry', 1, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Currency], [Hint], [Payable], [Description], [MaxTerm], [Term], [Position], [Searchable]) VALUES (4, N'New Opening', 188.0000, N'RM ', N'Monthly', 1, N'Blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah  blah blah blah blah blah blah blah blah blah blah', 3, N'Month(s)', 3, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Currency], [Hint], [Payable], [Description], [MaxTerm], [Term], [Position], [Searchable]) VALUES (5, N'Recommendation', 100.0000, N'RM ', N'Weekly', 1, N'Blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah  blah blah blah blah blah blah blah blah blah blah', 10, N'Entry', 4, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Currency], [Hint], [Payable], [Description], [MaxTerm], [Term], [Position], [Searchable]) VALUES (6, N'Promotions', 0.0000, N'RM ', NULL, 0, NULL, 0, NULL, NULL, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Currency], [Hint], [Payable], [Description], [MaxTerm], [Term], [Position], [Searchable]) VALUES (7, N'Coupons', 0.0000, N'RM ', NULL, 0, NULL, 0, NULL, NULL, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Currency], [Hint], [Payable], [Description], [MaxTerm], [Term], [Position], [Searchable]) VALUES (8, N'Freebies', 0.0000, N'RM ', NULL, 0, NULL, 0, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
/****** Object:  StoredProcedure [dbo].[sp_SearchProducts]    Script Date: 04/05/2015 22:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SearchProducts]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =====================================================
-- Author:		Au, Kah Yin
-- Create date: 15 Mar 2015
-- Description:	Search products by product id, category, location, expiry date range
-- Test:  exec sp_SearchProducts 2, ''Food & Beverage'', ''Penang''
-- =====================================================
CREATE PROCEDURE [dbo].[sp_SearchProducts]
	-- Add the parameters for the stored procedure here
	@prProductId INT,
	@prBizCategory VARCHAR(50),
	@prLocation VARCHAR(30), 
	@prExpDaysRangeFrom INT = 0, 
	@prExpDaysRangeTo INT = 60
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @prProductId = 2   -- Deals
	BEGIN
		SELECT d.Id,
		d.Title,
		d.Image,
		CONVERT(VARCHAR(24), d.ExpiryDate , 113) AS ExpiryDate,
		dir.CompanyName,
		bi.BusIndustry
		FROM Deals d
		INNER JOIN Directory dir ON d.DirId = dir.DirId
		INNER JOIN BusinessIndustry bi ON bi.BusIndustryId = dir.BusIndustryId
		INNER JOIN Transactions tr on d.TransId = tr.TransId
		WHERE bi.BusIndustry = @prBizCategory
		AND dir.State = @prLocation
		AND tr.PymtReceived = 1
		AND DATEDIFF(d,GETDATE(), d.ExpiryDate) BETWEEN @prExpDaysRangeFrom  AND @prExpDaysRangeTo
		 
	END

	SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  Default [DF_Product_Price]    Script Date: 04/05/2015 22:57:51 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Product_Price]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Product_Price]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Price]  DEFAULT ((0)) FOR [Price]
END


End
GO
/****** Object:  Default [DF_Product_MaxTerm]    Script Date: 04/05/2015 22:57:51 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Product_MaxTerm]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Product_MaxTerm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_MaxTerm]  DEFAULT ((0)) FOR [MaxTerm]
END


End
GO
/****** Object:  Default [DF_Product_Searchable]    Script Date: 04/05/2015 22:57:51 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Product_Searchable]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Product_Searchable]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Searchable]  DEFAULT ((0)) FOR [Searchable]
END


End
GO
