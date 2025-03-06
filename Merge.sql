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
select 1, 'ChildToys', 0 union all
select 2, 'AdultToys', 1 union all
select 3, 'AnimalToys', 1 union all
select 4, 'AlienToys', 1
)
select ProductTypeId, Name, IsActive 
into #AllProductTypes
from ProductTypes;

merge LTG.dbo.ProductTypes pt
using #AllProductTypes apt
on pt.ProductTypeId = apt.ProductTypeId
when matched 
	then update set pt.Name = apt.Name,
					pt.IsActive = apt.IsActive
when not matched
	then insert (ProductTypeId, Name, IsActive)
	values (apt.ProductTypeId, apt.Name, apt.IsActive)
when not matched by source
	then delete;

select * from dbo.ProductTypes

drop table #AllProductTypes