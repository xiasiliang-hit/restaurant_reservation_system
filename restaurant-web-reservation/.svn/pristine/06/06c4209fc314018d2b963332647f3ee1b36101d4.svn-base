--
create proc is_valid_user
@name nvarchar(50),
@pwd nvarchar(50),
@is_valid bit output
as
declare @@pwd nvarchar(50)
begin
	select @@pwd = pwd from SysUser
	where name = @name

	if @pwd = @@pwd
	begin
		set @is_valid = 1
		select * from SysUser
		where name = @name
	end

	else
	begin
		set @is_valid = 0
	end
end
go

--
create proc insert_customer
@name nvarchar(50),
@pwd nvarchar(50),
@mail nvarchar(50)
as
begin
	insert into SysUser
	values(@name, @pwd, @mail, 1)
end
go

--
create proc insert_manager
@name nvarchar(50),
@pwd nvarchar(50),
@mail nvarchar(50)
as
begin
	insert into SysUser
	values(@name, @pwd, @mail, 2)
end
go

--
create proc update_user
@name nvarchar(50),
@pwd nvarchar(50),
@mail nvarchar(50)
as
begin
	update SysUser
	set pwd = @pwd, mail = @mail
	where name = @name
end
go

--
create proc delete_user
@name nvarchar(50)
as
begin
	delete from SysUser
	where name = @name
end
go

create proc is_registered
@name nvarchar(50),
@is_exist bit output
as
declare @@num int
begin
	select @@num = count (*)
	from SysUser
	where name = @name
	if @@num=1
	begin
		set @is_exist=1
	end

	else
	begin
		set @is_exist=0
	end
end
go
--
create proc insert_reservation
@id uniqueidentifier,
@user_from nvarchar(50),
@customer_name nvarchar(50),
@phone nvarchar(50),
@arrive_time datetime,
@table_name nvarchar(50),
@seat int,
--@type int
@state int
as
begin
	insert into Reservation
	values (@id, @user_from, @customer_name, @phone, @arrive_time, @table_name, @seat, 1, 1)
end
go

--
create proc delete_reservation
@id uniqueidentifier
as
begin
	delete from Reservation
 	where id = @id
end
go

--
create proc update_reservation
@id uniqueidentifier,
@user_from nvarchar(50),
@customer_name nvarchar(50),
@phone nvarchar(50),
@arrive_time datetime,
@table_name nvarchar(50),
@seat int,
@type int,
@state int
as
begin
	update Reservation
	set user_from = @user_from,
		customer_name = @customer_name,
		phone = @phone,
		arrive_time = @arrive_time,
		table_name = @table_name,
		seat = @seat,
		type = @type,
		state = @state
	where id = @id
end
go

create proc update_state_reservation
@id uniqueidentifier,
@state int
as
begin
	update reservation
	set  state = @state
	where id = @id
end
go

--
create proc insert_reservation_dish
@id uniqueidentifier,
@reservation_id uniqueidentifier,
@dish_name nvarchar(50),
@quato int,
@note nvarchar(500)
as
begin
	insert into ReservationDishQuota
	values(@id, @reservation_id, @dish_name, @quato, @note)
end
go

--
-- create proc delete_reservation_dish
-- @id uniqueidentifier,
-- as
-- begin
-- 	delete from ReservationDishQuota
-- 	where id = @id
-- end
-- go

create proc get_history_reservation_by_user
@user_from nvarchar(50)
as
begin
	select * from Reservation
	where user_from = @user_from and state = 0
end
go

--do not take into consideration the undealed timeout reservation
--the normal situation is the reseration out of time is either be deleted or modify to a later time

create proc select_unfinished_reservation_by_user
@user_from nvarchar(50)
as
begin
	select * from Reservation
	where user_from = @user_from and state >= 1
end
go

--
create proc insert_delivery
@id uniqueidentifier,
@user_from nvarchar(50),
@customer_name nvarchar(50),
@phone nvarchar(50),
@address nvarchar(500),
@commit_time datetime,
@delivery_time datetime
--@state int
as
begin
	insert into Delivery
	values (@id, @user_from, @customer_name, @phone, @address,@commit_time,@delivery_time,1)
end
go

create proc update_state_delivery
@id uniqueidentifier,
@state int
as
begin
	update delivery
	set state = @state
	where id = @id
end
go

--delete_delivery
--

--
create proc insert_delivery_dish
@id uniqueidentifier,
@delivery_id uniqueidentifier,
@dish_name nvarchar(50),
@quota int,
@note nvarchar(500)
as
begin
	insert into DeliveryDishQuota
	values (@id, @delivery_id, @dish_name, @quota, @note)
end
go
--
-- create proc delete_delivery_dish
-- @id
-- as
-- begin
-- 	delete from DeliveryDishQuota
-- 	where
-- end
create proc select_history_delivery_by_user
@user_from nvarchar(50)
as
begin
	select * from Delivery
	where user_from = @user_from and state = 0
end
go

create proc select_undelived_delivery_by_user
@user_from nvarchar(50)
as
begin
	select * from Delivery
	where user_from like @user_from and state = 1
	order by delivery_time
end
go

create proc insert_comment
@id uniqueidentifier,
@content nvarchar(500),
@about_dish nvarchar(50),
@user_from nvarchar(50)
as
begin
	insert into Comment
	values (@id, @content, @about_dish, @user_from)
end
go

create proc insert_walkin
@id uniqueidentifier,
@user_from nvarchar(50),
@customer_name nvarchar(50),
@phone nvarchar(50),
@arrive_time datetime,
@table_name nvarchar(50),
@seat int,
@type int
--@state
as
begin
	insert into Reservation
	values (@id, @user_from, @customer_name, @phone, @arrive_time, @table_name, @seat, 2, 2)
end
go

--
create proc select_all_history_reservation
as
begin
	select * from Reservation
	where state = 0
order by user_from
end
go

--
create proc select_all_history_delivery
as
begin
	select * from Delivery
	where state=0
	order by user_from
end
go

--
create proc update_delivery
@id uniqueidentifier
as
begin
	update Delivery
	set state = 0
	where id = @id
end
go

--
create proc search_current_reservation_by_keyword
@key nvarchar(50)
as
begin
	select * from Reservation
	where ((user_from like '%' + @key + '%') or
			(phone like '%' + @key + '%'))
			and
			state >= 1
end
go

create proc search_delivery_by_keyword
@key nvarchar(50)
as
begin
	select * from Delivery
	where ((user_from like '%' + @key + '%') or
			(phone like '%' + @key + '%'))
end
go

create proc select_all_table
as
begin
	select * from SysTable
end
go

create proc get_available_table
@time datetime
as
begin
	select * from SysTable
	where SysTable.name not in
	(select table_name from Reservation
	where state >= 1 and (convert(nvarchar, arrive_time, 112) = convert(nvarchar, @time, 112)) and
		not exists (select time from SysBusinessTime
					where (convert(nvarchar, SysBusinessTime.time, 108) between convert(nvarchar, Reservation.arrive_time, 108) and convert(nvarchar, @time, 108))
					 and
					convert(nvarchar, SysBusinessTime.time, 108) != convert(nvarchar, Reservation.arrive_time, 108) and convert(nvarchar, SysBusinessTime.time, 108) != convert(nvarchar, @time, 108)
					)
	)
end
go


--check RESERVED reservation to bound to its table
create proc get_reserved_tablenum_reservation
@time datetime
as
begin
	select * from Reservation
	where state =1 and (convert(nvarchar, arrive_time, 112) = convert(nvarchar, @time, 112)) and
		not exists (select time from SysBusinessTime
					where time between convert(nvarchar, Reservation.arrive_time, 108) and convert(nvarchar, @time, 108))
end
go

create proc select_reservation_by_duration_and_user
@time_begin datetime,
@time_end datetime,
@user_from nvarchar(50)
as
begin
	select * from Reservation
	where ((arrive_time between @time_begin and @time_end) and
			(user_from like @user_from))
end
go

create proc select_reservation_by_user
@user_from nvarchar(50)
as
begin
	select * from Reservation
	where user_from = @user_from
end
go

create proc get_dishquota_by_reservation
@id uniqueidentifier
as
begin
	select * from ReservationDishQuota
	where reservation_id =@id
end
go


create proc select_delivery_by_duration_and_user
@time_begin datetime,
@time_end datetime,
@user_from nvarchar(50)
as
begin
	select * from Delivery
	where ((delivery_time between @time_begin and @time_end) and
			(user_from like @user_from))
end
go

create proc select_delivery_by_user
@user_from nvarchar(50)
as
begin
	select * from Delivery
	where user_from = @user_from
end
go

create proc get_dishquota_by_delivery
@id uniqueidentifier
as
begin
	select * from DeliveryDishQuota
	where delivery_id  = @id
end
go



create proc insert_news
@id uniqueidentifier,
@title nvarchar(50),
@content nvarchar(500),
@publish_time datetime,
@about_dish nvarchar(50)
as
begin
	insert into News
	values (@id,@title,@content,@publish_time,@about_dish)
end
go

create proc update_news
@id uniqueidentifier,
@title nvarchar(50),
@content nvarchar(500),
@publish_time datetime,
@about_dish nvarchar(50)
as
begin
	update News
	set id = @id,
		title = @title,
		content = @content,
		publish_time = @publish_time,
		about_dish = @about_dish
	where id = @id
end
go

create proc delete_news
@id uniqueidentifier
as
begin
	delete from news
	where id = @id
end
go

create proc insert_dish
@name nvarchar(50),
@description nvarchar(500),
@price float,
@pict_path nvarchar(500),
@popularity int
as
begin
	insert into Dish
	values (@name,@description,@price,@pict_path,@popularity)
end
go

create proc update_tag
@name nvarchar(50)
as
declare @@num int
begin

	select @@num = count(*) from Tag
	where name = @name
	if @@num = 1
	begin
		update Tag
		set popularity = popularity + 1
		where name = @name
	end
	else
	begin
		insert into Tag
		values (@name, 0)
	end
end
go

create proc insert_taganddish
@tag_name nvarchar(50),
@dish_name nvarchar(50)
as
begin
	insert into TagAndDish
	values (@tag_name, @dish_name)
end
go

create proc update_dish
@name nvarchar(50),
@description nvarchar(500),
@price float,
@pict_path nvarchar(500),
@popularity int
as
begin
	update Dish
	set name = @name,
		description = @description,
		price = @price,
		pict_path = @pict_path,
		popularity = @popularity
	where name = @name
end
go

create proc delete_dish
@name nvarchar(50)
as
begin
	delete from dish
	where name = @name
end
go

create proc is_admin
@name nvarchar(50),
@pwd nvarchar(50),
@is_admin bit output
as
declare @@pwd nvarchar(50)
begin
	select @@pwd = pwd from SysAdmin
	where name = @name

	if @pwd = @@pwd
	begin
		set @is_admin = 1
		select * from SysAdmin
		where name = @name
	end

	else
	begin
		set @is_admin = 0
	end
end
go

create proc get_hot_dish
as
begin
	select * from Dish
	order by popularity desc
end
go

-- create proc get_favor_dish
-- @user_name
-- begin
-- 	select Dish.*
-- 	from SysUser as s, Reservation as r, ReservationDishQuota as rdq, Dish as d
-- 	where s.name = r.user_from and r.id = rqd.reservation_id and rdq.dish_name = d.name
-- 	where name in
-- end

create proc get_hot_tag
as
begin
	select * from Tag
	order by popularity desc
end
go

create proc get_tag_by_dish
@dish_name nvarchar(50)
as
begin
	select * from tag
	where name in (select tag_name from TagAndDish
					where dish_name = @dish_name)
end
go

create proc get_dish_by_tag
@tag_name nvarchar(50)
as
begin
	select * from Dish
	where name in
		(select dish_name from TagAndDish
		where tag_name = @tag_name)
end
go

create proc login_autocomplete
@key nvarchar(50)
as
begin
	select name from SysUser
	where name like @key + '%'
end
go

create proc search_reservation_autocomplete
@key nvarchar(50)
as
begin
	select customer_name from Reservation
	where customer_name like @key + '%'
	union
	select phone from Reservation
	where phone like @key + '%'
-- 	union
-- 	select user_from from Reservation
-- 	where user_from like @key + '%'
end
go

create proc search_delivery_autocomplete
@key nvarchar(50)
as
begin
	select customer_name from Reservation
	where customer_name like @key + '%'
	union
	select phone from Reservation
	where phone like @key + '%'
end
go

-- create proc get_timeout_reservation
-- as
-- declare @@time datetime
-- begin
-- 	set @@time = getdate()
-- 	select * from Reservation
-- 	where convert(nvarchar, arrive_time, 112) = convert(nvarchar, @@time, 112) and
-- 		convert(nvarchar, Reservation.arrive_time, 108) < convert(nvarchar, @@time, 108)
-- end
-- go

create proc update_state_table
@id uniqueidentifier,
@state int
as
begin
	update Systable
	set current_state = @state
	where id = @id
end
go


--
create proc get_current_reservation_by_table
@table_name nvarchar(50)
as
begin
	select * from Reservation
	where table_name = @table_name and (state = 1 or state = 2)
end
go



create proc select_timeout_delivery
as
begin
	select * from Delivery
	where state = 2
end
go

create proc select_timeout_reservation
as
begin
	select * from Reservation
	where state = 3
end
go

create proc select_all_dish
as
begin
	select * from Dish
end
go

create proc truncate_business_time
as
begin
	truncate table SysBusinessTime
end
go

create proc update_business_time
@keyword nvarchar(50),
@time datetime
as
begin
	update SysBusinessTime
	set keyword = @keyword,
	time = @time
	where keyword = @keyword
end
go

create proc insert_business_time
@keyword nvarchar(50),
@time datetime
as
begin
	insert into SysBusinessTime
	values (@keyword, @time)
end
go

create proc get_comment_by_dish
@dish_name nvarchar(50)
as
begin
	select * from Comment
	where about_dish = @dish_name
end
go


----0316
create proc select_all_businesstime
as
begin
	select * from SysBusinessTime
	order by time asc
end
go

create proc delete_comment
@id uniqueidentifier
as
begin
	delete from Comment
	where id = @id
end
go

create proc select_all_manager
as
begin
	select * from SysUser
	where type = 2
end
go

create proc search_customer
@name nvarchar(50)
as
begin

		select * from SysUser
		where name like ('%' + @name + '%') and type = 1

end
go

create proc get_dish_by_name
@name nvarchar(50)
as
begin
select * from Dish
where name = @name
end
go

create proc select_all_news
as
begin
	select * from news
end
go

create proc get_table_by_id
@id uniqueidentifier
as
begin
select * from SysTable
where id = @id
end
go

create proc insert_table
@id uniqueidentifier,
@name varchar(50),
@seat int,
@pict_path nvarchar(500),
@current_state int
as
begin
	insert into Systable
	values (@id, @name, @seat, @pict_path, @current_state)
end
go

create proc update_dish_popularity
@name nvarchar(50)
as
begin
	update Dish
	set popularity = popularity+1
	where name = @name
end
go
--¶àÓàµÄ
create proc get_table_by_name
@name nvarchar(50)
as
begin
select * from SysTable
where name = @name
end
go

create proc get_reservation_by_id
@id uniqueidentifier
as
begin
	select * from reservation
	where id = @id
end
go

create proc prolong_reservation
@id uniqueidentifier,
@arrive_time datetime
as
begin
	update Reservation
	set arrive_time = @arrive_time
	where id = @id
end
end
go

create proc search_dish_by_keyword
@keyword nvarchar(50)
as
begin
	select * from dish
	where (name like ('%' + @keyword + '%')) or (description like ('%' + @keyword + '%'))
	order by popularity
end
go