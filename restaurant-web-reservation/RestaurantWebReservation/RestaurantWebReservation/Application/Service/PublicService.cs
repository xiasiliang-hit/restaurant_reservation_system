using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq;

using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.Application.Service;
using RestaurantWebReservation.DataAccess;

namespace RestaurantWebReservation.Application.Service
{
    public class PublicService
    {
        public static void CommitReservation(Reservation pR)
        {
            DataContextDataContext dc = new DataContextDataContext();
            //$dc.ins
            dc.insert_reservation(
                (Guid?)pR.id,
                pR.userFrom,
                pR.customerName,
                pR.phone,
            (DateTime?)pR.arriveTime,
            pR.tableName,
            (int?)pR.seat,
            (int?)pR.state);
        }

        public static void ModifyReservation(Reservation pR)
        {
            DataContextDataContext dc = new DataContextDataContext();
            dc.update_reservation((Guid?)pR.id,
                pR.userFrom,
                pR.customerName,
                pR.phone,
                (DateTime?)pR.arriveTime,
                pR.tableName,
                (int?)pR.seat,
                (int?)pR.type,
                (int?)pR.state);
        }

        public static List<Reservation> GetHistoryReservation(string pUserFrom)
        {
            List<Reservation> reservationList = new List<Reservation>();

            DataContextDataContext dc = new DataContextDataContext();
            ISingleResult<get_history_reservation_by_userResult> rs = dc.get_history_reservation_by_user(pUserFrom);
            foreach (get_history_reservation_by_userResult r in rs)
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

        public static List<Reservation> GetUnfinishedReservation(string pUserFrom)
        {
            List<Reservation> reservatioList = new List<Reservation>();

            DataContextDataContext dc = new DataContextDataContext();
            ISingleResult<select_unfinished_reservation_by_userResult> rs = dc.select_unfinished_reservation_by_user(pUserFrom);
            foreach (select_unfinished_reservation_by_userResult r in rs)
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

                reservatioList.Add(reservation);
            }


            return reservatioList;
        }

        public static List<Reservation> GetReservationByDurationAndUser(DateTime pBeginTime, DateTime pEndTime, string pUserFrom)
        {
            List<Reservation> reservationList = new List<Reservation>();

            DataContextDataContext dc = new DataContextDataContext();
            ISingleResult<select_reservation_by_duration_and_userResult> rs = dc.select_reservation_by_duration_and_user((DateTime?)pBeginTime, (DateTime?)pEndTime, pUserFrom);
            foreach (select_reservation_by_duration_and_userResult r in rs)
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

        public static List<Delivery> GetHistoryDelivery(string pUserFrom)
        {
            List<Delivery> deliveryList = new List<Delivery>();
            DataContextDataContext dc = new DataContextDataContext();

            ISingleResult<select_history_delivery_by_userResult> rs = dc.select_history_delivery_by_user(pUserFrom);
            foreach (select_history_delivery_by_userResult r in rs)
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

        public static List<Delivery> GetUndelivedDelivery(string pUserFrom)
        {
            List<Delivery> deliveryList = new List<Delivery>();
            DataContextDataContext dc = new DataContextDataContext();

            ISingleResult<select_undelived_delivery_by_userResult> rs = dc.select_undelived_delivery_by_user(pUserFrom);
            foreach (select_undelived_delivery_by_userResult r in rs)
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

        public static List<Delivery> GetDeliveryByDurationAndUser(DateTime pBeginTime, DateTime pEndTime, string pUserFrom)
        {
            List<Delivery> deliveryList = new List<Delivery>();
            DataContextDataContext dc = new DataContextDataContext();

            ISingleResult<select_delivery_by_duration_and_userResult> rs = dc.select_delivery_by_duration_and_user(pBeginTime, pEndTime, pUserFrom);
            foreach (select_delivery_by_duration_and_userResult r in rs)
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

        public static Dictionary<string, DateTime> GetBusinessTime()
        {
            Dictionary<string, DateTime> dictionary = new Dictionary<string, DateTime>();
            DataContextDataContext dc = new DataContextDataContext();
            ISingleResult<select_all_businesstimeResult> rs = dc.select_all_businesstime();
            foreach (select_all_businesstimeResult r in rs)
            {
                dictionary.Add(r.keyword, r.time);
            }
            return dictionary;
        }

        public static List<News> GetNews()
        {
            List<News> newsList = new List<News>();
            DataContextDataContext dc = new DataContextDataContext();
            ISingleResult<select_all_newsResult> rs = dc.select_all_news();

            foreach (select_all_newsResult r in rs)
            {
                News news = new News((Guid)r.id, r.title, r.content, (DateTime)r.publish_time, r.about_dish);
                newsList.Add(news);
            }
            return newsList;
        }
    }
}