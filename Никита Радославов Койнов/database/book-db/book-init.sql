use sys;

create database book_db;
use book_db;

create table books (
	isbn char(13) primary key,
    title varchar(70) not null,
    quantity int unsigned not null check(quantity > 0),
    price decimal(9, 2) not null
);

create table authors (
	id int primary key,
    full_name varchar(70) not null,
    age tinyint unsigned not null check(age >= 10 and age <= 130),
    years_experience tinyint unsigned null
);

create table books_authors (
	book_isbn char(13),
    author_id int,
    constraint pk_books_authors primary key (book_isbn, author_id),
    constraint fk_books_authors_books_isbn foreign key (book_isbn) references books(isbn),
    constraint fk_books_authors_authors_id foreign key (author_id) references authors(id)
);

create table book_orders (
	id int primary key,
    book_isbn char(13) not null,
    selled_count int unsigned not null,
    order_price decimal(9, 2) not null,
    constraint fk_book_orders_books_isbn foreign key (book_isbn) references books(isbn)
);
