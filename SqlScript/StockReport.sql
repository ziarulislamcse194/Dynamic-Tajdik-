USE [StockManagementDB]
GO

/****** Object:  View [dbo].[StockReport]    Script Date: 7/3/2019 6:55:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create view [dbo].[StockReport] as
select it.Id as ItemId,ItemName,co.CompanyName,ss.Quantity,ss.StockDate,ss.StockStatus from Stocks ss
join Items it
on ss.ItemID= it.Id
 join Companys co
on it.CompanyID=co.Id
 join Categorys ca
on it.CategoryID=ca.Id

GO


