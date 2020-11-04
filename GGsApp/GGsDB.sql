-- drop table carts cascade;
-- drop table cartitem cascade;
-- drop table inventoryitem cascade;
-- drop table lineitem cascade;
-- drop table location cascade;
-- drop table orders cascade;
-- drop table users cascade;
-- drop table videogame cascade;

create table VideoGames (
    id serial primary key,
    name varchar(50),
    cost NUMERIC(6, 2),
    platform varchar(6),
    esrb varchar(3)
);

create table Locations (
    id serial primary key,
    street varchar(50),
    city varchar(50),
    state varchar(50),
    zipcode varchar(50)
);

create table Users (
    id serial primary key,
    name varchar(50),
    email varchar(50),
    locationId int references Locations,
    type varchar(50)
);

create table Carts(
    id serial primary key,
    userId int references users
);

create table CartItems (
    id serial primary key,
    cartId int references Carts,
    videoGameId int references VideoGames,
    quantity int not null
);

create table InventoryItems (
    id serial primary key,
    videoGameId int references VideoGames,
    locationId int references Locations,
    quantity INT not null
);

create table Orders (
    id serial primary key,
    userId int REFERENCES Users,
    locationId int references Locations,
    orderDate TIMESTAMP,
    totalCost NUMERIC(8, 2) not null
);

create table LineItems (
    id serial primary key,
    orderId int references Orders,
    videoGameId int references VideoGames,
    quantity int not null
);

insert into VideoGames (name, cost, platform, esrb) VALUES
('Cyberpunk 2077', 59.99, 'PC', 'M'),
('Call of Duty', 59.99, 'PS5', 'M'),
('Among Us', 4.99, 'PC', 'E'),
('Assassins Creed', 59.99, 'XBOX', 'M'),
('NBA 2K21', 59.99, 'PS5', 'E');

insert into Locations (street, city, state, zipcode) VALUES
('721 Market St.', 'San Francisco', 'CA', '94108'),
('6841 Broadway Blvd.', 'Oakland', 'CA', '94512'),
('87467 Random Ave.', 'Seattle', 'WA', '89741'),
('7645 Pine Rd', 'Miami', 'FL', '65476'),
('84643 5th Ave.', 'New York', 'NY', '24654');

insert into Users (name, email, locationId, type) VALUES
('Maxine', 'mwong@gmail.com', 1, 'Customer'),
('Josh', 'jvalli@gmail.com', 2, 'Customer'),
('Justin', 'jpon@gmail.com', 5, 'Customer'),
('Ellie', 'emac@gmail.com', 3, 'Customer'),
('Jacob', 'jjennings@gmail.com', 4, 'Manager');

insert into inventoryitems (videogameid, locationid, quantity) VALUES
(1, 1, 5),
(1, 2, 4),
(1, 3, 10),
(1, 4, 7),
(1, 5, 2),
(2, 1, 2),
(2, 2, 10),
(2, 3, 10),
(2, 4, 54),
(2, 5, 2),
(3, 1, 45),
(3, 2, 6),
(3, 3, 10),
(3, 4, 43),
(3, 5, 9),
(4, 1, 5),
(4, 2, 4),
(4, 3, 10),
(5, 4, 7),
(5, 5, 2);