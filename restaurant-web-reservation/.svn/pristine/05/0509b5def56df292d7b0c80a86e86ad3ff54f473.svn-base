
--Reservation to reserve a table
create table Reservation
(
	id uniqueidentifier primary key,
	user_from nvarchar(50),
	customer_name nvarchar(50),
	phone nvarchar(50),
	arrive_time datetime,
	table_name nvarchar(50),
	seat int,
	type int, -- 1 == reservation, 2 == walkin
state int, -- 1 == reserved, 2 == busy, 3 == timeout, 0 == finish

	foreign key (user_from) references SysUser(name) on delete set null,
	foreign key (table_name) references SysTable(name) on delete set null on update cascade
)

--basic information of Customer for a delivery
create table Delivery
(
	id uniqueidentifier primary key,
	user_from nvarchar(50),
	customer_name nvarchar(50),
	phone nvarchar(50),
	address nvarchar(500),
	commit_time datetime,
	delivery_time datetime,
state int, --1 == undelived, 2 == timeout, 0 == delived
	foreign key (user_from) references SysUser(name) on delete set null
)

--dihses and quota in a reservation
create table ReservationDishQuota
(
	id uniqueidentifier primary key,
	reservation_id uniqueidentifier,
	dish_name nvarchar(50),
	quato int,
	note nvarchar(500),

	--total float
	--primary key (dish_name, reservation_id),
	foreign key (reservation_id) references Reservation(id) on delete cascade,
	foreign key (dish_name) references Dish(name) on delete cascade
)

--dihses and quota in a delivery
create table DeliveryDishQuota
(
	id uniqueidentifier primary key,
	delivery_id uniqueidentifier,
	dish_name nvarchar(50),
	quota int,
	note nvarchar(500),
	--total float

	foreign key (delivery_id) references Delivery(id) on delete cascade,
	foreign key (dish_name) references Dish(name) on delete cascade
)

--restaurant news
create table News
(
	id uniqueidentifier primary key,
	title nvarchar(50),
	content nvarchar(500),
	publish_time datetime,
	about_dish nvarchar(50),

	foreign key (about_dish) references Dish(name)
)

--comment of dish from customer
create table Comment
(
	id uniqueidentifier primary key,
	content nvarchar(500),
	about_dish nvarchar(50),
	user_from nvarchar(50),

	foreign key (about_dish) references Dish(name) on delete cascade,
	foreign key (user_from) references SysUser(name) on delete set null
)
-- create table UserHistory
-- (
--
-- )


