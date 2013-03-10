using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq;

using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.Application.Role;
using RestaurantWebReservation.Application.Service;
using RestaurantWebReservation.DataAccess;

namespace RestaurantWebReservation.Application.Role
{
    public class Manager : User
    {
        //public string name { get; set; }
        //public string pwd { get; set; }
        //public string mail { get; set; }

        public Manager() { }
        public Manager(string pName, string pPwd, string pmail)
        {
            name = pName;
            pwd = pPwd;
            mail = pmail;
        }
        //CustomService customService = new CustomService();
        //ManagerService managerService = new ManagerService();

		//Function: assign a table to the custoemr who come into restaurant without a reservation
		//Parameters:
		//    string pTableName: table name assigned to the customer walk in
		//    Reservation pR: reservation generated which belongs to this new customer
		//Remarks:
		//    change the TableState to BUSY, the table is specified by  pTableName
		//    set the ReservationState to BUSY of pR
        //$ 一个客人进来，没有提前预定的 table 从available->busy，reservation-》busy
        public void WalkInArrive(string pTableName, Reservation pR)
        {
            foreach (SysTable t in Restaurant.tableList)
            {
                if (t.name == pTableName)
                {
                    DataContextDataContext dc = new DataContextDataContext();
                    dc.insert_reservation(
                        (Guid?)pR.id,
                        pR.userFrom,
                        pR.customerName,
                        pR.phone,
                        (DateTime?)pR.arriveTime,
                        pR.tableName,
                        (int?)pR.seat,
                        (int?)pR.state);

                    t.SetReservation(pR); //so the table now maintain a reservation
                    t.ChageState(TableState.BUSY);
                    t.GetReservation().ChangeState(ReservationState.BUSY);
                }
                else
                { }
            }
        }

		//Function: invoked when a customer come with a reservation
		//Paramaters:
		//    string pTableName: the table name which is recorded on the reservation by this customer
		//Remarks:
		//    change TableState to BUSY, the table is specified by  pTableName
		//    change the ReservationState to BUSY, of the reservation on the table
        //$一个客人进来，有提前预定的 table从reserved->busy，
        public void ReservationArrive(string pTableName)
        {
            foreach (SysTable t in Restaurant.tableList)
            {
                if (t.name == pTableName)
                {
                    //no need to set Reservation to this table
                    //reservation is generated at the time when the table is reserved for it
                    //at the function Restaurant.GetAllTableWithStateAndCurrentReservation()
                    t.ChageState(TableState.BUSY);
                    t.GetReservation().ChangeState(ReservationState.BUSY);
                }
                else
                { }
            }
        }

		//Function: invoked when a customer finish meal
		//    change TableState to AVAILABLE, the table is specified by  pTableName
		//    change the ReservationState to FINISH, of the reservation in this table
        //$custoemr 结束用餐，table从busy-》available， resrvation-》finish
        public void FinishMeal(string pTableName)
        {
            foreach (SysTable t in Restaurant.tableList)
            {
                if (t.name == pTableName)
                {
                    t.GetReservation().ChangeState(ReservationState.FINISH);
                    t.SetReservation(null);
                    t.ChageState(TableState.AVAILABLE);
                }
                else
                { }
            }
        }

        //$就餐的时候，在相应的reservation里面把dish加进去
        public void AddDish(string pTableName, DishQuota pDishQuota)
        {
            foreach (SysTable t in Restaurant.tableList)
            {
                if (t.name == pTableName)
                {
                    t.GetReservation().AddDish(pDishQuota);
                }
                else
                {}
            }
        }

        //reservation is committed when the custom finish the meal
        //reservation state is updated and dishes is added to db
        //used by manager
        //private void FinishReservationWithDish(Reservation pR)
        //{
        //    DataContextDataContext dc = new DataContextDataContext();

        //    foreach (DishQuota dq in pR.dishQuotaList)
        //    {
        //        dc.insert_reservation_dish(dq.id, pR.id, dq.dishName, dq.quota, dq.note);
        //    }

        //    pR.ChangeState(ReservationState.FINISH);
        //}

		//Function: submit a new reservation for a customer
		//    invoked when a manager helps customer reserve a meal in restaurant
        public void CommitReservation(Reservation pR)
        {
            PublicService.CommitReservation(pR);
        }

        public void CancelReservation(Guid pId)
        {
            DataContextDataContext dc = new DataContextDataContext();
            dc.delete_reservation(pId);
        }

        public void ModifyReservation(Reservation pR)
        {
            PublicService.ModifyReservation(pR);
        }

        //Function: modify the arrive time of the reservation
		//    invoked when the reservation becomes TIMEOUT and the manager helps to delay the available time for this reservation
        //$resrvation timeout后，manager可以给延时，状态从timeout到reserved 这个是后加的，设计的有问题，转换写死到数据库存储过程了
        public void ProlongReservation(Guid pId, DateTime pDateTime)
        {
            DataContextDataContext dc = new DataContextDataContext();
            dc.prolong_reservation(pId, pDateTime);
        }

		//Function: update the DeliveryState as DELIVERED in db, the delivery is is specified by pId
        //$delivey送出后，manager点一个按钮，undelivered-》deliveried
        public void SendDelivery(Guid pId)
        {
            DataContextDataContext dc = new DataContextDataContext();
            dc.update_state_delivery((Guid?)pId, (int?)DeliveryState.DELIVERED);
        }

		//Function: insert a news in db
        public void PublishNews(News pNews)
        {
            DataContextDataContext dc = new DataContextDataContext();
            dc.insert_news(pNews.id, pNews.title, pNews.content, (DateTime?)pNews.publishTime, pNews.aboutDish);
        }

		//Function: get all the reservation today
        static List<Reservation> GetReservationToday()
        {
            DateTime now = DateTime.Now;
            DateTime today = now.Date;
            return PublicService.GetReservationByDurationAndUser(today, now, "%");
        }

        static List<Delivery> GetDeliveryToday()
        {
            DateTime now = DateTime.Now;
            DateTime today = now.Date;
            return PublicService.GetDeliveryByDurationAndUser(today, now, "%");
        }

		//Function: get all the history reservations of a given customer
        public List<Reservation> GetHistoryReservationByUser(string pUserFrom)
        {
            return PublicService.GetHistoryReservation(pUserFrom);
        }

		//Function: get all the history deliverys of a given customer
        public List<Delivery> GetHistoryDeliveryByUser(string pUserFrom)
        {
            return PublicService.GetHistoryDelivery(pUserFrom);
        }

		//Function: search reservations by keyword
		//Remarks: if the keyword == null, return all the records
        public List<Reservation> SearchReservationMatch(string keyword)
        {
            List<Reservation> reservationList = new List<Reservation>();

            if (keyword == null)
            { keyword = "%"; }  //search all the records
            else
            { }
            DataContextDataContext dc = new DataContextDataContext();
            ISingleResult<search_current_reservation_by_keywordResult> rs = dc.search_current_reservation_by_keyword(keyword);
            foreach (search_current_reservation_by_keywordResult r in rs)
            {
                List<DishQuota> dishQuotaList = new List<DishQuota>();

                ISingleResult<get_dishquota_by_reservationResult> rs2 = dc.get_dishquota_by_reservation(r.id);
                foreach (get_dishquota_by_reservationResult r2 in rs2)
                {
                    double price = 0;
                    ISingleResult<get_dish_by_nameResult> rs3 = dc.get_dish_by_name(r2.dish_name);
                    foreach (get_dish_by_nameResult r3 in rs3)
                    {
                        price = (double)r3.price;
                    }

                    DishQuota tDishQuota = new DishQuota(r2.id, r2.dish_name, price, (int)r2.quato, r2.note);
                    dishQuotaList.Add(tDishQuota);
                }


                Reservation reservation = new Reservation(
                    r.id,
                    r.user_from,
                    r.customer_name,
                    r.phone,
                    (DateTime)r.arrive_time,
                    r.table_name,
                    (int)r.seat,
                    (ReservationType)r.type,
                    (ReservationState)r.state,
                    dishQuotaList);
                reservationList.Add(reservation);
            }
            return reservationList;
        }

        public List<Delivery> SearchDeliveryMatch(string keyword)
        {
            List<Delivery> deliveryList = new List<Delivery>();
            DataContextDataContext dc = new DataContextDataContext();

            ISingleResult<search_delivery_by_keywordResult> rs = dc.search_delivery_by_keyword(keyword);
            foreach (search_delivery_by_keywordResult r in rs)
            {
                List<DishQuota> dishQuotaLish = new List<DishQuota>();

                ISingleResult<get_dishquota_by_deliveryResult> rs2 = dc.get_dishquota_by_delivery(r.id);
                foreach (get_dishquota_by_deliveryResult r2 in rs2)
                {
                    double price = 0;
                    ISingleResult<get_dish_by_nameResult> rs3 = dc.get_dish_by_name(r2.dish_name);
                    foreach (get_dish_by_nameResult r3 in rs3)
                    {
                        price = (double)r3.price;
                    }

                    DishQuota dishQuota = new DishQuota(r2.id, r2.dish_name, price, (int)r2.quota, r2.note);
                    dishQuotaLish.Add(dishQuota);
                }

                Delivery delivery = new Delivery(
                    (Guid)r.id,
                    r.user_from,
                    r.customer_name,
                    r.phone,
                    r.address,
                    (DateTime)r.commit_time,
                    (DateTime)r.delivery_time,
                    (DeliveryState)r.state,
                    dishQuotaLish);

                deliveryList.Add(delivery);
            }
            return deliveryList;
        }

        public Dictionary<string, TableState> GetAllTableStateByTime(DateTime pDateTime)
        {
            Dictionary<string, TableState> tableStateDict = new Dictionary<string, TableState>();

            DataContextDataContext dc = new DataContextDataContext();
            ISingleResult<get_available_tableResult> rs = dc.get_available_table(pDateTime);
            foreach (get_available_tableResult r in rs)
            {
                tableStateDict.Add(r.name, TableState.AVAILABLE);
            }

            ISingleResult<get_reserved_tablename_and_reservationResult> rs2 = dc.get_reserved_tablename_and_reservation(pDateTime);
            foreach (get_reserved_tablename_and_reservationResult r2 in rs2)
            {
                tableStateDict.Add(r2.table_name, TableState.RESERVED);
            }

            return tableStateDict;
        }

        //ModifyNews()
        //DeleteNews()()


		//Function: get deliveries undelived of all cutomers from the db
        //$从数据库里读出没送出的delivery
        public List<Delivery> GetUnDelivedDelivery()
        {
            return PublicService.GetUndelivedDelivery("%");
        }

        //Function: Check deliveries and compare current time to delivery time of each delivery
        //  set certain deliveries as TIMEOUT
        //$掉存储过程把过期的delivery返回出来，存储过程也是比对当前时间和应该的delivery时间，这个和上面类似，只是更简单，从数据库直接找出来
        public List<Delivery> GetTimeOutDelivery()
        {
            List<Delivery> deliveryList = PublicService.GetUndelivedDelivery("%");
            List<Delivery> timeOutDelivery = new List<Delivery>();
            foreach (Delivery d in deliveryList )
            {
                if (d.deliveryTime < DateTime.Now) //TIMEOUT is left
                {
                    timeOutDelivery.Add(d);
                }
                else
                { }
            }
            return timeOutDelivery;
        }
        //public List<Delivery> GetTimeOutDelivery()
        //{
        //    List<Delivery> deliveryList = new List<Delivery>();

        //    DataContextDataContext dc = new DataContextDataContext();
        //    ISingleResult<select_timeout_deliveryResult> rs = dc.select_timeout_delivery();
        //    foreach (select_timeout_deliveryResult r in rs)
        //    {
        //        List<DishQuota> dishQuotaList = new List<DishQuota>();

        //        ISingleResult<get_dishquota_by_deliveryResult> rs2 = dc.get_dishquota_by_delivery(r.id);
        //        foreach (get_dishquota_by_deliveryResult r2 in rs2)
        //        {
        //            double price = 0;
        //            ISingleResult<get_dish_by_nameResult> rs3 = dc.get_dish_by_name(r2.dish_name);
        //            foreach (get_dish_by_nameResult r3 in rs3)
        //            {
        //                price = (double)r3.price;
        //            }

        //            DishQuota dishQuota = new DishQuota(r2.id, r2.dish_name, price, (int)r2.quota, r2.note);
        //            dishQuotaList.Add(dishQuota);
        //        }

        //        Delivery delivery = new Delivery(
        //            (Guid)r.id,
        //            r.user_from,
        //            r.customer_name,
        //            r.phone,
        //            r.address,
        //            (DateTime)r.commit_time,
        //            (DateTime)r.delivery_time,
        //            (DeliveryState)r.state,
        //            dishQuotaList);
        //        deliveryList.Add(delivery);
        //    }
        //    return deliveryList;
        //}

		//Function: get all the TIMEOUT reservations, by checking all the reserve time of each reservation
        //$获得TimeOut Reservation，CheckTableTimeOut事先写入的！！！
        public List<Reservation> GetTimeOutReservation()
        {
            List<Reservation> reservationList = new List<Reservation>();

            DataContextDataContext dc = new DataContextDataContext();
            ISingleResult<select_timeout_reservationResult> rs = dc.select_timeout_reservation();
            foreach (select_timeout_reservationResult r in rs)
            {
                List<DishQuota> dishQuotaList = new List<DishQuota>();


                //TIMEOUT reservations have no dishes
                ISingleResult<get_dishquota_by_reservationResult> rs2 = dc.get_dishquota_by_reservation(r.id);
                foreach (get_dishquota_by_reservationResult r2 in rs2)
                {
                    double price = 0;
                    ISingleResult<get_dish_by_nameResult> rs3 = dc.get_dish_by_name(r2.dish_name);
                    foreach (get_dish_by_nameResult r3 in rs3)
                    {
                        price = (double)r3.price;
                    }

                    DishQuota dishQuota = new DishQuota(r2.id, r2.dish_name, price, (int)r2.quato, r2.note);
                    dishQuotaList.Add(dishQuota);
                }


                Reservation reservation = new Reservation(
                    r.id,
                    r.user_from,
                    r.customer_name,
                    r.phone,
                    (DateTime)r.arrive_time,
                    r.table_name,
                    (int)r.seat,
                    (ReservationType)r.type,
                    (ReservationState)r.state,
                    dishQuotaList);
                reservationList.Add(reservation);
            }
            return reservationList;
        }


        public static List<Reservation> GetAllHistoryReservation()
        {
            List<Reservation> reservationList = new List<Reservation>();

            DataContextDataContext dc = new DataContextDataContext();
            ISingleResult<select_all_history_reservationResult> rs = dc.select_all_history_reservation();
            foreach (select_all_history_reservationResult r in rs)
            {
                List<DishQuota> dishQuotaList = new List<DishQuota>();

                ISingleResult<get_dishquota_by_reservationResult> rs2 = dc.get_dishquota_by_reservation(r.id);
                foreach (get_dishquota_by_reservationResult r2 in rs2)
                {
                    double price = 0;
                    ISingleResult<get_dish_by_nameResult> rs3 = dc.get_dish_by_name(r2.dish_name);
                    foreach (get_dish_by_nameResult r3 in rs3)
                    {
                        price = (double)r3.price;
                    }

                    DishQuota dishQuota = new DishQuota(r2.id, r2.dish_name, price, (int)r2.quato, r2.note);
                    dishQuotaList.Add(dishQuota);
                }


                Reservation reservation = new Reservation(
                    r.id,
                    r.user_from,
                    r.customer_name,
                    r.phone,
                    (DateTime)r.arrive_time,
                    r.table_name,
                    (int)r.seat,
                    (ReservationType)r.type,
                    (ReservationState)r.state,
                    dishQuotaList);
                reservationList.Add(reservation);
            }


            return reservationList;
        }

        public static List<Delivery> GetAllHistoryDelivery()
        {
            List<Delivery> deliveryList = new List<Delivery>();
            DataContextDataContext dc = new DataContextDataContext();

            ISingleResult<select_all_history_deliveryResult> rs = dc.select_all_history_delivery();
            foreach (select_all_history_deliveryResult r in rs)
            {
                List<DishQuota> dishQuotaLish = new List<DishQuota>();

                ISingleResult<get_dishquota_by_deliveryResult> rs2 = dc.get_dishquota_by_delivery(r.id);
                foreach (get_dishquota_by_deliveryResult r2 in rs2)
                {
                    double price = 0;
                    ISingleResult<get_dish_by_nameResult> rs3 = dc.get_dish_by_name(r2.dish_name);
                    foreach (get_dish_by_nameResult r3 in rs3)
                    {
                        price = (double)r3.price;
                    }

                    DishQuota dishQuota = new DishQuota(r2.id, r2.dish_name, price, (int)r2.quota, r2.note);
                    dishQuotaLish.Add(dishQuota);
                }

                Delivery delivery = new Delivery(
                    (Guid)r.id,
                    r.user_from,
                    r.customer_name,
                    r.phone,
                    r.address,
                    (DateTime)r.commit_time,
                    (DateTime)r.delivery_time,
                    (DeliveryState)r.state,
                    dishQuotaLish);

                deliveryList.Add(delivery);
            }

            return deliveryList;
        }

		//Function: get daily income report, by calculating sum of each dishes
        //$当天的卖出dish，按照dish分类统计销售金额，就是一个表格，菜名，reservaion里的销售额，delivery里的销售额
        public static List<DishReort> GetDailyReport()
        {
            List<DishReort> report = new List<DishReort>();

            List<Reservation> reservationList = GetReservationToday();
            List<Delivery> deliveryList = GetDeliveryToday();

            foreach (Dish dish in Restaurant.dishList)
            {
                DishReort dr = new DishReort(dish);
                foreach (Reservation reservation in reservationList)
                {
                    foreach (DishQuota dishQuota in reservation.dishQuotaList)
                    {
                        if (dishQuota.dishName == dish.name)
                        {
                            dr.reservationQuota += dishQuota.quota;
                        }
                        else
                        { }
                    }

                    dr.totalPrice += dr.price * dr.reservationQuota;
                }


                foreach (Delivery delivery in deliveryList)
                {
                    foreach (DishQuota dishQuota in delivery.dishQuotaList)
                    {
                        if (dishQuota.dishName == dish.name)
                        {
                            dr.deliveryQuota += dishQuota.quota;
                        }
                        else
                        { }
                    }
                    dr.totalPrice += dr.price * dr.deliveryQuota;
                }

                report.Add(dr);
            }
            return report;
        }
    }
}