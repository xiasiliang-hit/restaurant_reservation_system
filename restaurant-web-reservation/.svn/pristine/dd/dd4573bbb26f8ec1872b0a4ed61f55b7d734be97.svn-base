create table SysAdmin
(
	name nvarchar(50) primary key,
	pwd nvarchar(50) not null,
	mail nvarchar(50)
)

--table information in the restaurant
create table SysTable
(
	id uniqueidentifier primary key,
	name nvarchar(50) unique,
	seat int,
	pict_path nvarchar(500),
	current_state int -- 0 == available, -- 1 == reserved, 2 == busy, 3 == timeout
)

--restaurant business time
create table SysBusinessTime
(
	keyword nvarchar(50) primary key,
	time datetime not null
)

create table SysUser
(
	name nvarchar(50) primary key,
	pwd nvarchar(50),
	mail nvarchar(50),
	type int --1 == customer, 2 == manager
)



