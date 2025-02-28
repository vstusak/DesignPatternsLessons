--create table dbo.ProductTypes (
--	ProductTypeId tinyint not null,
--	Name varchar(20) not null,
--	IsActive bit not null,

--	constraint PK_ProductTypes primary key (ProductTypeId)
--)

select * from dbo.ProductTypes
go;

with ProductTypes(ProductTypeId, Name, IsActive)
as 
(
select 1, 'ChildToys', 1 union all
select 2, 'AdultToys', 1 union all
select 3, 'AnimalToys', 1 union all
select 4, 'AlienToys', 1
)
select ProductTypeId, Name, IsActive 
into #AllProductTypes
from ProductTypes;



drop table #AllProductTypes