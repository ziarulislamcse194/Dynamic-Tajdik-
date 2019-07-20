use [master]
go
--drop database StockManagementDB 
--go
create database StockManagementDB
go
use StockManagementDB

--drop all previous table then create, If you have have problem to delete then delete stock first , then item then category and company

go
Create Table Users(
Id int identity(1,1) primary key,
UserName nvarchar(255),
[Password] nvarchar(255)
)
go



drop table Stocks
drop table Items
drop table Companys
drop table Categorys

Create Table Companys(
Id int identity(1,1) primary key,
CompanyName nvarchar(255)
)

go

Create Table Categorys(
Id int identity(1,1) primary key,
CategoryName nvarchar(255)
)


go

Create Table Items(
Id int identity(1,1) primary key,
ItemName nvarchar(255),
ReOrderQuantity int,
Quantity int,
CompanyID int references Companys(Id),
CategoryID int references Categorys(Id)
)

go

Create Table Stocks(
Id int identity(1,1) primary key,
StockDate datetime,
StockStatus nvarchar(50),
ItemID int references Items(Id)
)


create view ItemsView 
as
select it.Id, it.ItemName , it.ReOrderQuantity ,it.Quantity ,it.CompanyId ,cm.CompanyName ,it.CategoryId ,ctg.CategoryName  from Companys cm
inner join items it on it.CompanyID = cm.id
inner join Categorys ctg on ctg.Id = it.CategoryID