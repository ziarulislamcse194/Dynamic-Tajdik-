USE [StockManagementDB]
GO

/****** Object:  View [dbo].[ItemsView]    Script Date: 7/3/2019 6:55:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


  create view [dbo].[ItemsView] 
as
select it.Id, it.ItemName , it.ReOrderQuantity ,it.CompanyId ,cm.CompanyName ,it.CategoryId ,ctg.CategoryName  from [dbo].[Companys] cm
inner join items it on it.CompanyID = cm.id
inner join Categorys ctg on ctg.Id = it.CategoryID
GO


