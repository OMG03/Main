create database 11nikitakoynovDB;
use 11nikitakoynovDB;

create table locations (
	id int auto_increment,
    name varchar(30) not null,
    constraint pk_locations primary key (id)
);

create table companies (
	id int auto_increment,
    name varchar(30) not null,
    location_id int,
    constraint pk_companies primary key (id),
    constraint fk_companies_location_id foreign key (location_id)
    references locations (id)
);

create table resources (
	id int auto_increment,
    name varchar(30) not null,
    type varchar(30) not null,
    area int not null check (area > 0),
    price decimal(9, 2) not null check (price > 0),
    company_id int,
    constraint pk_resources primary key (id),
    constraint fk_resources_company_id foreign key (company_id)
    references companies (id)
);

insert into locations (name)
values ('Plovdiv'), 
	   ('Sofia'), 
       ('Burgar'), 
       ('Sliven'), 
       ('Svishtov'), 
       ('Mezdra');

insert into companies (name, location_id)
values ('Manu OOD', 1),
	   ('SLA EOOD', 1),
       ('MOL ET', 2),
       ('KKK OOD', 3),
       ('LOL ET', 3),
       ('MMMMM EOOD', 4),
       ('Horata BG OOD', 4),
       ('NaNo ET', 4),
       ('Purchi OOD', 5),
       ('SSC ET', 5),
       ('Pop EOOT', 5),
       ('Chani ET', 5),
       ('Zahari ET', 5),
       ('Komcho OOD', null);
       
insert into resources (name, type, area, price, company_id)
value ('resource 1', 'fossil', 45, 14654.23, 1),
	  ('resource 2', 'fuel', 3, 17552.41, 1),
	  ('resource 3', 'fossil', 8, 23654.23, 1),
	  ('resource 4', 'fossil', 22, 6532.75, 2),
	  ('resource 5', 'fossil', 25, 2365, 3),
	  ('resource 6', 'fuel', 233, 15436, 3),
	  ('resource 7', 'fuel', 4, 1323232, 4),
	  ('resource 8', 'fossil', 44, 15346.23, 4),
	  ('resource 9', 'fuel', 28, 4123, 5);

select 
	c.name as Company,
    l.name as Location
from companies as c
inner join locations as l
on c.location_id = l.id;

select 
	c.Name as Company,
	count(r.id) as Resources
from resources as r
right join companies as c
on r.company_id = c.id
group by c.id;

select r.Name as Resource, rr.MaxPrice from resources as r
join (select max(price) as MaxPrice 
	  from resources
	  having MaxPrice > 500000) as rr
on r.price = rr.MaxPrice;

select 
	c.Name as Company,
    round(avg(r.price), 2) as ResourcesAvgPrice
from companies as c
left join resources as r 
on c.id = r.company_id
group by c.id
having ResourcesAvgPrice < 500000
order by ResourcesAvgPrice desc;
