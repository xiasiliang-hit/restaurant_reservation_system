using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq;

using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.Application.Role;
using RestaurantWebReservation.Application.Service;
using RestaurantWebReservation.DataAccess;

namespace RestaurantWebReservation.Application.Service
{
    public class CheckService
    {
        //Function: check all the AVAILABLE reservations in db, and find out in the span of current time which table is reserved
        //  set certain reservations and tables involed as RESERVED
        //Remarks: be involved periodically and automaticlly by a timer
        //  this is the begining of all the state transfer of tables and reservations in memory
        //$调用存储过程，查数据库里的reservation，比对现在时间和reservation预定时间的关系，确定哪些订单进入到reserved状态了
        public static void CheckTableReserved()
        {
            DataContextDataContext dc = new DataContextDataContext();

            //装数据库返回的数据集合
            ISingleResult<get_reserved_tablename_and_reservationResult> rs = dc.get_reserved_tablename_and_reservation(DateTime.Now);
            foreach (get_reserved_tablename_and_reservationResult r in rs)
            {
                //装reservation的很多dish
                List<DishQuota> dishQuotaList = new List<DishQuota>();

                //in fact no dish, if dishes is not allowed to order before custom comming
                //ISingleResult<get_dishquota_by_reservationResult> rs2 = dc.get_dishquota_by_reservation(r.id);
                //foreach (get_dishquota_by_reservationResult r2 in rs2)
                //{
                //    double price = 0;
                //    ISingleResult<get_dish_by_nameResult> rs3 = dc.get_dish_by_name(r2.dish_name);
                //    foreach (get_dish_by_nameResult r3 in rs3)
                //    {
                //        price = (double)r3.price;
                //    }

                //    DishQuota dishQuota = new DishQuota(r2.id, r2.dish_name, price, (int)r2.quato, r2.note);
                //    dishQuotaList.Add(dishQuota);
                //}

                //从数据集的一条记录组装一个reservation
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

                
                foreach (SysTable t in Restaurant.tableList)
                {
                    //如果内存中的table是还没被约定的，占用的，这条reservation预定的就是这张桌子，吧这张桌子预定到这张桌子
                    if (t.name == reservation.tableName && (t.state != TableState.BUSY && t.state != TableState.TIMEOUT))
                    {
                        t.SetReservation(reservation); //reservation 绑定到桌子
                        t.ChageState(TableState.RESERVED); //桌子状态reserved
                    }
                    else
                    { }
                }
            }
        }
        

        //Function: check tables and reservations to find out which is in TIMEOUT state
        //  by comparing current time and the reservation's arrive time in each RESERVED table
        //  identify them as TIMOUT
        //Remarks: in fact it can be realized by either searching db or check the reservations in tableList
        //  the TIMEOUT reservations can only be those maintained by the tables in RESERVED state,
        //  which is on the other hand caused by that reservation they are reserved for
        //  we check the tableList in memory directly
        //$查!!内存里!!的table 比对现在的时间 把过期的reserved订单从reserved-》timout，桌子也跟着变,然后这个状态写到数据库的，后面manager GetTimeOutReservation，才能get出来！！
        //reserved是之前上一个函数从！！！数据库！！！查出来的
        public static void CheckTableTimeOut()
        {
            foreach (SysTable t in Restaurant.tableList)
            {
                if (t.state == TableState.RESERVED && t.GetReservation().arriveTime < DateTime.Now)
                {
                    t.GetReservation().ChangeState(ReservationState.TIMEOUT);
                    t.ChageState(TableState.TIMEOUT);
                }
                else
                {}
            }
        }

        //public static void CheckDeliveryTimeOut()
        //{}
    }
}