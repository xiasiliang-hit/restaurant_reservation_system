create table Dish
(
	name nvarchar(50) primary key,
	description nvarchar(500),
	price float,
	pict_path nvarchar(500),
	popularity int
)

create table Tag
(
	name nvarchar(50) primary key,
	popularity int,
)

create table TagAndDish
(
	tag_name nvarchar(50),
	dish_name nvarchar(50),

	primary key (tag_name, dish_name),
	foreign key (tag_name) references Tag(name) on delete cascade,
	foreign key (dish_name) references Dish(name) on delete cascade
)


--table Dish store the dishes record in the restaurant, table Tag is store the tags related to the dish since a dish has some tags to specify it and different dishes may have the same tag, the relation is [n..n] and the relation should be stored as an extra table