using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq;

using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.Application.Role;
using RestaurantWebReservation.Application.Service;
using RestaurantWebReservation.DataAccess;

namespace RestaurantWebReservation.Application.BasicDataStractrue
{
    public class Restaurant
    {
        //all the tables in the restaurant
        public static List<SysTable> tableList = new List<SysTable>();
        
        //all the dishes in the restaurant
        public static List<Dish> dishList = new List<Dish>();
        //List<Reservation> timeoutReservationList = new List<Reservation>();
        //List<Delivery> timeoutDelivery = new List<Delivery>();

        //Function: initiate the all the dishes, by query the configure information in db
        //从数据库吧dish信息读出来，dish是Admin通过adddish加的
        public static void InitAllDish()
        {
            dishList = new List<Dish>();

            DataContextDataContext dc = new DataContextDataContext();
            ISingleResult<select_all_dishResult> rs = dc.select_all_dish();
            foreach (select_all_dishResult r in rs)
            {
                
                List<Tag> tagList = new List<Tag>();
                List<Comment> commentList = new List<Comment>();


                ISingleResult<get_tag_by_dishResult> rs2 = dc.get_tag_by_dish(r.name);
                foreach (get_tag_by_dishResult r2 in rs2)
                {
                    Tag tag = new Tag(r2.name, (int)r2.popularity);
                    tagList.Add(tag);
                }

                ISingleResult<get_comment_by_dishResult> rs3 = dc.get_comment_by_dish(r.name);
                foreach (get_comment_by_dishResult r3 in rs3)
                {
                    Comment comment = new Comment(r3.id,r3.content,r3.about_dish,r3.user_from);
                    commentList.Add(comment);
                    
                }

                Dish dish = new Dish(
                    r.name,
                    r.description,
                    (double)r.price,
                    r.pict_path,
                    (int)r.popularity,
                    tagList,
                    commentList);
                dishList.Add(dish);
            }
        }

        //Function: initiate all the tables with states, by querying the db
        ////从数据库把桌子信息读出来，带着当前的状态
        public static void InitAllTable()
        {
            tableList = new List<SysTable>();

            DataContextDataContext dc = new DataContextDataContext();
            ISingleResult<select_all_tableResult> rs = dc.select_all_table();
            foreach (select_all_tableResult r in rs)
            {
                Reservation reservation = null;

                ISingleResult<get_current_reservation_by_tableResult> rs2 = dc.get_current_reservation_by_table(r.name);
                foreach (get_current_reservation_by_tableResult r2 in rs2)
                {
                    List<DishQuota> dishQuotaList = new List<DishQuota>(); 

                    ISingleResult<get_dishquota_by_reservationResult> rs3 = dc.get_dishquota_by_reservation(r2.id);
                    foreach (get_dishquota_by_reservationResult r3 in rs3)
                    {
                        double price = 0;
                        ISingleResult<get_dish_by_nameResult> rs4 = dc.get_dish_by_name(r3.dish_name);
                        foreach (get_dish_by_nameResult r4 in rs4)
                        {
                            price = (double)r4.price;
                        }

                        DishQuota dishQuota = new DishQuota((Guid)r3.id, r3.dish_name, price, (int)r3.quato, r3.note);
                        dishQuotaList.Add(dishQuota);
                    }

                    reservation = new Reservation(
                    r2.id,
                    r2.user_from, 
                    r2.customer_name,
                    r2.phone,
                    (DateTime)r2.arrive_time,
                    r2.table_name,
                    (int)r2.seat,
                    (ReservationType)r2.type,
                    (ReservationState)r2.state,
                    dishQuotaList);
                }

                //only one reservation is bound to a table in a certain time
                //  in exact this foreach loop, not outside
                SysTable table = new SysTable(
                (Guid)r.id,
                r.name,
                (int)r.seat,
                r.pict_path,
                (TableState)r.current_state
                );
                table.SetReservation(reservation);
                tableList.Add(table);
            }
        }

        //even time bind to tableList, it init again
        //对外把所有table信息返回出来
        public static List<SysTable> GetTable()
        {
            InitAllTable();
            return tableList;
        }
    }
}