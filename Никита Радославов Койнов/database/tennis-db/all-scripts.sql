create database tennis_db;
use tennis_db;

create table countries (
	id int auto_increment,
    name varchar(30) not null,
    constraint pk_countries primary key (id)
);

create table manufacturers (
	id int auto_increment,
    name varchar(30) not null,
    country_id int null,
    constraint pk_manufacturers primary key (id),
	constraint fk_manufacturers_countries_country_id foreign key (country_id)
    references countries (id)
);

create table items (
	id int auto_increment,
    name varchar(30) not null,
    type varchar(30) not null,
    qunatity int not null check (quantity > 0),
    price decimal(9, 2) not null check (price > 0),
    manufacturer_id int null,
    constraint pk_items primary key (id),
    constraint fk_items_manufacturers_manufacturer_id foreign key (manufacturer_id) 
    references manufacturers (id)
);

insert into countries (name)
values ('Bulgaria'), ('USA'), ('China'); 

insert into manufacturers (name, country_id)
values ('Khan Zu', 3),
	   ('Shai Hu', 3),
	   ('Mana Zzu', 3),
       ('Pu Shan', 3),
       ('Ma Du', 3),
       ('Kaz San', 3),
	   ('Bg Racket', 1),
	   ('Bg Tennis', 1),
	   ('Selling Rackets', 2),
	   ('Some Big Company', 2),
       ('Sports for America', 2),
       ('Great again', 2),
       ('Edin priqtel', null),
       ('Shano', null);
       
insert into items (name, type, qunatity, price, manufacturer_id)
values ('Racket BG', 'For playing', '100', '23', 1),
	   ('T-Shirt BG', 'For playing', '33', '64', 1),
       ('Pants BG', 'For playing', '23', '4', 1),
       ('Shoes BG', 'For playing', '676', '223', 1),
       ('Blades BG', 'For playing', '4', '2', 1),
       ('Rubbers BG', 'For playing', '3434', '56', 1),
       ('Balls BG', 'For playing', '22223', '5', 1),
       ('Racket USA', 'For playing', '100', '23', 2),
	   ('T-Shirt USA', 'For playing', '33', '34', 2),
       ('Pants USA', 'For playing', '23', '30', 2),
       ('Shoes USA', 'For playing', '676', '323', 2),
       ('Blades USA', 'For playing', '4', '6', 2),
       ('Rubbers USA', 'For playing', '3434', '66', 2),
       ('Balls USA', 'For playing', '22223', '6', 2),
       ('Racket CH', 'For playing', '100', '13', 3),
	   ('T-Shirt CH', 'For playing', '33', '44', 3),
       ('Pants CH', 'For playing', '23', '2', 3),
       ('Shoes CH', 'For playing', '676', '33', 3),
       ('Blades CH', 'For playing', '4', '4', 3),
       ('Rubbers Shano', 'For playing', '3444', '56', 4),
       ('Balls Eedin priqtel', 'For playing', '22423', '5', 5),
       ('T-Shirt Ne znam', 'For playing', '22423', '5', null),
       ('T-Shirt Ne znam 2', 'For playing', '22423', '5', null);
       
select m.name as Manufaturer, c.name as Country
from countries as c
inner join manufacturers as m
on c.id = m.country_id;

select i.name as Item, m.name as Manufacturer
from items as i
left join manufacturers as m
on i.manufacturer_id = m.id;

select round(avg(price), 2) as 'Average Price' from items
having avg(price) > 10;

select c.name as Country, count(m.id) as Manufacturers
from manufacturers as m
join countries as c
on m.country_id = c.id
group by c.name
having Manufacturers > 3
order by Manufacturers desc;
       