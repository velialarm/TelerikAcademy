
-- add some Towns
insert into Town (name, country_id) values('Pleven',1);
insert into Town (name, country_id) values('Svishov',1);
insert into Town (name, country_id) values('Varna',1);
--add Address
insert into Address(address_text,town_id) values('Ulica neznaina',3);
insert into Address(address_text,town_id) values('Stopalka 23 ',4);
insert into Address(address_text,town_id) values('Kuklovishaman',5);

select * from Continent
select * from Country
select * from Town;
select * from Address;
select * from Person;

create view V_demo  as 
select 
	p.first_name as FirstName,
	p.last_name as LastName,
	a.address_text as Address,
	t.name as Town,
	c.name as Country,
	con.name as Continent 
from person p 
inner join address as a on a.id = p.address_id
inner join Town t on t.id = a.town_id
inner join Country c on c.id = t.country_id
inner join Continent con on con.id = c.continet_id
;
------------------------
select * from V_demo
