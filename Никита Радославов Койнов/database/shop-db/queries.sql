insert into manufacturers (name, address)
values 	('Sahan ET', 'ul. Stolipinovo 11, Plovdiv, Bulgaria'),
		('Milka OOD', 'bul. Dondukov 3, Sofia, Bulgaria'),
        ('PeshoAuto EOOD', 'Trud, Bulgaria');
	
insert into products (iban, name, description, quantity, price, manufacturer_id)
values 	('odinsjodkj', 'Chuk', 'Chuka na Tor', 100, 20, (select id from manufacturers where name = 'Sahan ET' limit 1)),
		('odinssddkj', 'Bradva', 'Bradvata na Shrek', 23, 5, (select id from manufacturers where name = 'Sahan ET' limit 1)),
		('odassjodas', 'Bastun', 'Bastuna na Bai Tosho', 12, 10, (select id from manufacturers where name = 'Sahan ET' limit 1)),
		('akdojnaios', 'Mlqko', 'Mlqko ot nemski kravi', 2, 1200, (select id from manufacturers where name = 'Milka OOD' limit 1)),
        ('kokffffdsl', 'Mercedes Benz S63 AMG Coupe', 'Really cool car', 4, 450000, (select id from manufacturers where name = 'PeshoAuto EOOD' limit 1)),
        ('koksdfsffl', 'Mercedes Benz G63 AMG Brabus', 'Really cool car', 2, 500000, (select id from manufacturers where name = 'PeshoAuto EOOD' limit 1)),
        ('kaaaaffdsl', 'Mercedes Benz CLA250', 'Really cheap car', 1, 80000, (select id from manufacturers where name = 'PeshoAuto EOOD' limit 1));

insert into orders (price)
values (40), (80000), (2300);

insert into products_orders (product_iban, order_id, quantity)
values 	((select iban from products where name = 'Chuk' limit 1), 1, 2),
		((select iban from products where name = 'Mercedes Benz CLA250' limit 1), 2, 1),
        ((select iban from products where name = 'Bastun' limit 1), 2, 2),
        ((select iban from products where name = 'Bradva' limit 1), 3, 1),
        ((select iban from products where name = 'Mlqko' limit 1), 3, 2);

update products
set quantity = quantity + 10
where quantity <= 5;

update orders
set price = 0.95 * price
where price > 100;

delete from orders
where price < 20;

select * from orders
order by price desc;

select 
	p.name as 'Product Name',
    p.description as 'Product Description',
    p.quantity as 'Product Quantity',
    po.quantity as 'Ordered Quantity',
    o.price as 'Order Price'
from products as p
join products_orders as po on p.iban = po.product_iban
join orders as o on o.id = po.order_id
where o.price > 50 AND po.quantity > 2
order by p.name
limit 5;
