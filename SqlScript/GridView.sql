USE [StockManagementDB]
GO

/****** Object:  View [dbo].[GridView]    Script Date: 7/6/2019 1:03:04 AM ******/
DROP VIEW [dbo].[GridView]
GO

/****** Object:  View [dbo].[GridView]    Script Date: 7/6/2019 1:03:04 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






create view [dbo].[GridView]
as
select ss.Id as StockId , ss.ItemID,it.CompanyID,it.CategoryID, it.[ItemName],ss.Quantity,ss.StockDate,ss.StockStatus from [dbo].[Stocks] ss
join [dbo].[Items] it
on it.Id=ss.ItemID





GO


