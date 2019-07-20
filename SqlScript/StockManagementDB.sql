use [master]
go
--drop database StockManagementDB 
--go
create database StockManagementDB
go
use StockManagementDB


go
Create Table Users(
Id int identity(1,1) primary key,
UserName nvarchar(255),
[Password] nvarchar(255)
)
go
Create Table Companys(
Id int identity(1,1) primary key,
Name nvarchar(255)
)

go

Create Table Cetagorys(
Id int identity(1,1) primary key,
Name nvarchar(255)
)


go

Create Table Items(
Id int identity(1,1) primary key,
Name nvarchar(255),
ReOrderQuantity int,
CompanyID int references Companys(Id),
CetagoryID int references Cetagorys(Id)
)

go

Create Table Stocks(
Id int identity(1,1) primary key,
StockDate datetime,
StockStatus nvarchar(50),
Quantity int,
ItemID int references Items(Id),
CompanyID int references Companys(Id),
CetagoryID int references Cetagorys(Id)
)
