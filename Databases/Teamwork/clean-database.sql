merge into Product as pr
using (
	select pr.* from Product pr
	inner join Measure m on m.id = pr.measureId
	inner join Vendor v on v.id = pr.vendorId
	inner join Currency cur on cur.id = pr.currencyId
)as map
on map.id = pr.id
when matched then delete;

merge into Vendor v
using (
	select
		v.id as id, 
		t.id as town,
		vt.id as typeId,
		pr.vendorId as product
	from Vendor v
	left join Product pr on v.id = pr.vendorId
	left join Town t on t.id = v.town_Id
	left join VendorType vt on vt.id = v.vendorTypeId
)as map
on map.id = v.id 
and map.town = v.town_id
and map.typeId = v.vendorTypeId
when matched then delete;

merge into VendorType vt
using (select vt.* from VendorType vt left join Vendor v on vt.id = v.id) as a
on (vt.id = a.id)
When matched then delete;

merge into Town t
using (select t.* from Town t left join Vendor v on t.id = v.id)as map
on t.id = map.id
when matched then delete;

merge into Measure as m
using (select m.* from Measure m left join Product pr on m.id = pr.measureId)as map
on m.id  = map.id
when matched then delete;

merge into Currency c
using (select c.* from Currency c )as map
on map.id = c.id
when matched then delete;