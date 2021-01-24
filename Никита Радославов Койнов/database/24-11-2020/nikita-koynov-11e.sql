create database 11eNikitaKoynovDB;
use 11eNikitaKoynovDB;

create table manufacturers (
	id 		int 		auto_increment,
    name 	varchar(30) not null,
    constraint pk_manufacturers primary key (id)
);

create table products (
	id 				int             auto_increment,
    name 			varchar(30) 	not null,
    license 		varchar(30) 	not null,
    quantity 		int signed 		not null check(quantity > 0),
    price 			decimal(9, 2) 	not null check(price > 0),
    manufacturer_id int 			not null,
    constraint pk_products primary key (id),
    constraint fk_products_manufacturers_id foreign key (manufacturer_id) references manufacturers (id) on update cascade on delete no action
);

create table orders (
	id 			int 			auto_increment,
    price 		decimal(9, 2)	not null,
    order_date	datetime 		not null,
    constraint pk_orders primary key (id)
);

create table products_orders (
	product_id 	int,
    order_id 	int,
    quantity	int 	not null check(quantity > 0),
    constraint pk_products_orders primary key (product_id, order_id),
    constraint fk_products_orders_products_id foreign key (product_id) references products (id) on update cascade on delete no action,
    constraint fk_products_orders_orders_id foreign key (order_id) references orders (id) on update cascade on delete no action
);

insert into manufacturers (name)
values ('Oracle'), ('Mojang');

insert into products (name, license, quantity, price, manufacturer_id)
values 	('Minecraft', 'Unknown', 1000, 40, (select id from manufacturers where name = 'Mojang')),
		('MySql', 'Unknown', 100000, 120, (select id from manufacturers where name = 'Oracle')),
		('Banica s boza OS', 'MIT', 1, 3, (select id from manufacturers where name = 'Mojang')),
        ('Kiselo mlqko OS', 'Public', 13, 2, (select id from manufacturers where name = 'Oracle')),
        ('Salam kamchiq', 'Public', 24, 3, (select id from manufacturers where name = 'Oracle'));

insert into orders (price, order_date)
values 	(1200, '2020-11-24'),
		(50, '1980-03-15');
        
update products
set price = 0.8 * price
where quantity >= 20;

update products
set quantity = quantity + 5
where name like '%OS%' and quantity <= 5;

delete from products
where price < 20;

select * from products
order by quantity
limit 5;
