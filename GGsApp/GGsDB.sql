-- drop table products
-- drop table orders
-- drop table customers
-- drop table locations
-- drop table managers
-- drop table inventories
-- drop table productype
-- creating the type of product --
create table producttype
(
    id serial primary key,
    prodtype varchar(15)
);

-- creating inventories table --
create table inventories
(
    id serial primary key,
    city varchar(2) not null,
    state varchar(50) not null
);

-- creating managers table --
create table managers
(
    id serial primary key,
    firstname varchar(50) not null,
    lastname varchar(50) not null,
    email varchar(100) unique not null,
    age int not null
);

-- creating locations table --
create table locations
(
    id serial primary key,
    street varchar(50) not null,
    city varchar(50) not null,
    state varchar(2) not null,
    zipcode int not null
);

-- creating customers table --
create table customers
(
    id serial primary key,
    firstname varchar(50) not null,
    lastname varchar(50) not null,
    email varchar(100) unique not null,
    age integer not null,
    locationId int references locations (id)
);

-- creating orders table -- 
create table orders
(
    id serial primary key,
    customerId int references customers (id)
);

-- creating the products table --
create table products
(
    id serial primary key,
    cost NUMERIC(6, 2) not NULL,
    name varchar(64) not null,
    prodtype int REFERENCES producttype (id),
    inventoryId int references inventories (id),
    orderId int references orders (id)
);

-- inserting seed data --
insert into producttype (prodtype) VALUES
('Video game'),
('Game console');

insert into inventories (city, state) values 
('Oakland', 'CA'),
('San Francisco', 'CA'),
('Seattle', 'WA'),
('Miami', 'FL'),
('New York City', 'NY');

insert into managers (firstname, lastname, email, age) VALUES
('Jacob', 'Jennings', 'jacobjennings@gmail.com', 23);

insert into locations (street, city, state, zipcode) values 
('123 penny ln', 'Hayward', 'CA', 94541),
('221 cherry st', 'New York','NY', 65480),
('87865 Washington blvd', 'Philadelphia','PA', 32546),
('6546 Overtree ave', 'Alberquerque','NM', 98765);

insert into customers (firstname, lastname, email, age, locationId) values 
('Mark', 'Twain', 'mtwain@gmail.com', 100, 2),
('Josh', 'Vallinator', 'jvallinator@gmail.com', 35, 3),
('Maxine', 'Wong', 'mwong@gmail.com', 25, 1);

insert into orders (customerId) values 
(1),
(1),
(2),
(2),
(3),
(3);

insert into products (cost, name, prodtype, inventoryId, orderId) values
(59.99, 'Cyberpunk 2077', 1, 1, 1),
(400.00, 'PS5', 2, 1, 1),
(59.99, 'Call of Duty', 1, 1, 2),
(400.00, 'PC', 2, 2);




