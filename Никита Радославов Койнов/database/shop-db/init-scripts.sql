create database shop_db;
use shop_db;

create table manufacturers (
	id 		int 		auto_increment,
    name 	varchar(70) not null,
    address varchar(70) not null,
    constraint pk_manufacturers primary key (id)
);

create table products (
	iban 			char(16),
    name 			varchar(30) 	not null,
    description 	varchar(256) 	not null,
    quantity 		int signed 		not null check(quantity > 0),
    price 			decimal(9, 2) 	not null,
    manufacturer_id int 			not null,
    constraint pk_products primary key (iban),
    constraint fk_products_manufacturers_id foreign key (manufacturer_id) references manufacturers (id) on update cascade on delete no action
);

create table orders (
	id 		int 			auto_increment,
    price 	decimal(9, 2)	not null,
    constraint pk_orders primary key (id)
);

create table products_orders (
	product_iban 	char(16),
    order_id 		int 		not null,
    quantity		int 		not null,
    constraint pk_products_orders primary key (product_iban, order_id),
    constraint fk_products_orders_products_iban foreign key (product_iban) references products (iban) on update cascade on delete no action,
    constraint fk_products_orders_orders_id foreign key (order_id) references orders (id) on update cascade on delete no action
);
