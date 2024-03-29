USE [StockManagementDB]
GO
/****** Object:  Table [dbo].[Categorys]    Script Date: 7/6/2019 4:03:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Companys]    Script Date: 7/6/2019 4:03:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Items]    Script Date: 7/6/2019 4:03:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](255) NULL,
	[ReOrderQuantity] [int] NULL,
	[CompanyID] [int] NULL,
	[CategoryID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stocks]    Script Date: 7/6/2019 4:03:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stocks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StockDate] [datetime] NULL,
	[Quantity] [int] NULL,
	[StockStatus] [nvarchar](50) NULL,
	[ItemID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/6/2019 4:03:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](255) NULL,
	[Password] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[CategoryView]    Script Date: 7/6/2019 4:03:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[CategoryView]  as
select distinct  it.CategoryId ,cm.CategoryName  from  [dbo].[Categorys] cm
join items it on it.CategoryID = cm.id
GO
/****** Object:  View [dbo].[CompanyView]    Script Date: 7/6/2019 4:03:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[CompanyView]  as
select distinct  it.CompanyId ,cm.CompanyName   from [dbo].[Companys] cm
join items it on it.CompanyID = cm.id
GO
/****** Object:  View [dbo].[GridView]    Script Date: 7/6/2019 4:03:36 PM ******/
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
/****** Object:  View [dbo].[ItemsView]    Script Date: 7/6/2019 4:03:36 PM ******/
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
/****** Object:  View [dbo].[StockReport]    Script Date: 7/6/2019 4:03:36 PM ******/
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
SET IDENTITY_INSERT [dbo].[Categorys] ON 

INSERT [dbo].[Categorys] ([Id], [CategoryName]) VALUES (1, N'Sationary')
INSERT [dbo].[Categorys] ([Id], [CategoryName]) VALUES (2, N'Cosmetics')
INSERT [dbo].[Categorys] ([Id], [CategoryName]) VALUES (3, N'Electronics')
INSERT [dbo].[Categorys] ([Id], [CategoryName]) VALUES (4, N'Books')
SET IDENTITY_INSERT [dbo].[Categorys] OFF
SET IDENTITY_INSERT [dbo].[Companys] ON 

INSERT [dbo].[Companys] ([Id], [CompanyName]) VALUES (1, N'Unilever')
INSERT [dbo].[Companys] ([Id], [CompanyName]) VALUES (2, N'RFL')
INSERT [dbo].[Companys] ([Id], [CompanyName]) VALUES (3, N'Walton')
SET IDENTITY_INSERT [dbo].[Companys] OFF
SET IDENTITY_INSERT [dbo].[Items] ON 

INSERT [dbo].[Items] ([Id], [ItemName], [ReOrderQuantity], [CompanyID], [CategoryID]) VALUES (1, N'Sampoo', 10, 1, 2)
INSERT [dbo].[Items] ([Id], [ItemName], [ReOrderQuantity], [CompanyID], [CategoryID]) VALUES (2, N'Laptop', 50, 1, 3)
INSERT [dbo].[Items] ([Id], [ItemName], [ReOrderQuantity], [CompanyID], [CategoryID]) VALUES (3, N'Television', 0, 3, 3)
INSERT [dbo].[Items] ([Id], [ItemName], [ReOrderQuantity], [CompanyID], [CategoryID]) VALUES (4, N'Chair', 5, 2, 1)
INSERT [dbo].[Items] ([Id], [ItemName], [ReOrderQuantity], [CompanyID], [CategoryID]) VALUES (5, N'Mobile', 100, 3, 3)
INSERT [dbo].[Items] ([Id], [ItemName], [ReOrderQuantity], [CompanyID], [CategoryID]) VALUES (6, N'Pencil', 100, 2, 4)
INSERT [dbo].[Items] ([Id], [ItemName], [ReOrderQuantity], [CompanyID], [CategoryID]) VALUES (7, N'Mobile', 150, 1, 3)
SET IDENTITY_INSERT [dbo].[Items] OFF
SET IDENTITY_INSERT [dbo].[Stocks] ON 

INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (1, CAST(0x0000AA7E00000000 AS DateTime), 200, N'StockIn', 1)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (2, CAST(0x0000AA7E00000000 AS DateTime), 20, N'StockIn', 4)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (3, CAST(0x0000AA7E00000000 AS DateTime), 400, N'Sold', 3)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (4, CAST(0x0000AA7E00000000 AS DateTime), 270, N'Damaged', 5)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (5, CAST(0x0000AA7E00000000 AS DateTime), 70, N'StockIn', 4)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (6, CAST(0x0000AA6100000000 AS DateTime), 100, N'Sold', 4)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (7, CAST(0x0000AA7E00000000 AS DateTime), 20, N'StockIn', 4)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (8, CAST(0x0000AA7F00000000 AS DateTime), 70, N'StockIn', 4)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (9, CAST(0x0000AA7A00000000 AS DateTime), 10, N'Sold', 6)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (10, CAST(0x0000AA7800000000 AS DateTime), 100, N'Damaged', 4)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (11, CAST(0x0000AA8000000000 AS DateTime), 0, N'StockIn', 6)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (12, CAST(0x0000AA8000000000 AS DateTime), 10, N'StockIn', 2)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (13, CAST(0x0000AA8000000000 AS DateTime), 100, N'StockIn', 1)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (14, CAST(0x0000AA8000000000 AS DateTime), 40, N'Sold', 1)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (15, CAST(0x0000AA8000000000 AS DateTime), 10, N'StockIn', 1)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (19, CAST(0x0000AA8000000000 AS DateTime), 50, N'StockIn', 1)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (20, CAST(0x0000AA8000000000 AS DateTime), 75, N'StockIn', 6)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (21, CAST(0x0000AA8000000000 AS DateTime), 80, N'Sold', 2)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (22, CAST(0x0000AA8100000000 AS DateTime), 80, N'StockIn', 3)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (23, CAST(0x0000AA8100000000 AS DateTime), 10, N'StockIn', 2)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (24, CAST(0x0000AA8100000000 AS DateTime), 60, N'StockIn', 2)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (25, CAST(0x0000AA8100000000 AS DateTime), 0, N'StockIn', 6)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (28, CAST(0x0000AA8200000000 AS DateTime), 40, N'StockIn', 1)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (29, CAST(0x0000AA8200000000 AS DateTime), 20, N'StockIn', 1)
INSERT [dbo].[Stocks] ([Id], [StockDate], [Quantity], [StockStatus], [ItemID]) VALUES (30, CAST(0x0000AA8200000000 AS DateTime), 10, N'StockIn', 1)
SET IDENTITY_INSERT [dbo].[Stocks] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [Password]) VALUES (1, N'Admin', N'Admin')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Items]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categorys] ([Id])
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Companys] ([Id])
GO
ALTER TABLE [dbo].[Stocks]  WITH CHECK ADD FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([Id])
GO
