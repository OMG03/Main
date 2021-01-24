create database 11jangelvalkovDB;
use 11jangelvalkovDB;

create table manufacturers (
	id 		int 		auto_increment,
    name 	varchar(30) not null,
    constraint pk_manufacturers primary key (id)
);

create table hardware_components (
	iban 			char(17),
    name 			varchar(30) 	not null,
    type 			varchar(30) 	not null,
    quantity 		int signed 		not null check(quantity > 0),
    price 			decimal(9, 2) 	not null,
    manufacturer_id int 			not null,
    constraint pk_hardware_components primary key (iban),
    constraint fk_hardware_components_manufacturers_id foreign key (manufacturer_id) references manufacturers (id) on update cascade on delete no action
);

create table orders (
	id 		int 			auto_increment,
    price 	decimal(9, 2)	not null,
    order_date	datetime		not null,
    constraint pk_orders primary key (id)
);

create table hardware_components_orders (
	product_iban 	char(16),
    order_id 		int 		not null,
    quantity		int 		not null,
    constraint pk_hardware_components_orders primary key (product_iban, order_id),
    constraint fk_hardware_components_orders_hardware_components_iban foreign key (product_iban) references hardware_components (iban) on update cascade on delete no action,
    constraint fk_hardware_components_orders_orders_id foreign key (order_id) references orders (id) on update cascade on delete no action
);
