use sys;

create database film_db;
use film_db;

create table films (
	id char(17) primary key,
    title varchar(60),
    premiere_date date,
    ticket_price decimal(7, 2) check (ticket_price > 0)
);

create table actors (
	id int primary key,
    full_name varchar(70),
    age tinyint check(age >= 7 AND age <= 100),
    years_experience tinyint unsigned null
);

create table films_actors (
	film_id char(17),
	actor_id int,
    constraint pk_films_actors primary key (film_id, actor_id),
    constraint fk_films_actors_films_id foreign key (film_id) references films(id),
    constraint fk_films_actors_actors_id foreign key (actor_id) references actors(id)
);

create table ticket_orders (
	id int primary key,
    film_id char(17),
    tickets_count int,
    order_price decimal(7, 2),
    constraint fk_ticket_orders_films_id foreign key (film_id) references films(id)
)
