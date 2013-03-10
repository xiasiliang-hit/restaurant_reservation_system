using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RestaurantWebReservation.DataAccess;


namespace RestaurantWebReservation.Application.BasicDataStractrue
{
    public class Reservation
    {
        public Reservation() { }
        public Reservation(Guid pId, string pUserFrom, string pCustomerName, string pPhone, DateTime pArriveTime, string pTableName, int pSeat,
                            ReservationType pType, ReservationState pState, List<DishQuota> pDishQuotaList)
        {
            id = pId;
            userFrom = pUserFrom;
            customerName = pCustomerName;
            phone = pPhone;
            arriveTime = pArriveTime;
            tableName = pTableName;
            seat = pSeat;
            type = pType;
            state = pState;
            dishQuotaList = pDishQuotaList;
        }

        public Reservation(Guid pId, string pUserFrom, string pCustomerName, string pPhone, DateTime pArriveTime, string pTableName, int pSeat,
                            ReservationType pType, ReservationState pState)
        {
            id = pId;
            userFrom = pUserFrom;
            customerName = pCustomerName;
            phone = pPhone;
            arriveTime = pArriveTime;
            tableName = pTableName;
            seat = pSeat;
            type = pType;
            state = pState;
        }

        public void AddDish(DishQuota pDishQuota)
        {
            dishQuotaList.Add(pDishQuota);

            DataContextDataContext dc = new DataContextDataContext();
            dc.insert_reservation_dish(pDishQuota.id, id, pDishQuota.dishName, pDishQuota.quota,pDishQuota.note);
        }

        //public void DeleteDish(Guid pId)
        //{
        //    foreach (DishQuota dq in dishQuotaList)
        //    {
        //        if (dq.id == pId)
        //        {
        //            dishQuotaList.Remove(dq);
        //        }
        //        else
        //        { }
        //    }
        //}

        public void ChangeState(ReservationState pState)
        {
            state = pState;
            //~ synchronize to db, if need to maintain the state in db
            DataContextDataContext dc = new DataContextDataContext();
            dc.update_state_reservation(id, (int?)state);
        }

        public List<DishQuota> GetDishQuota()
        {
            return dishQuotaList;
        }

        public Guid id { get; set; }
        public string userFrom { get; set; }
        public string customerName { get; set; }
        public string phone { get; set; }
        public DateTime arriveTime { get; set; }
        public string tableName { get; set; }
        public int seat { get; set; }
        public ReservationType type { get; set; }
 
        public ReservationState state = ReservationState.RESRVED;
        public List<DishQuota> dishQuotaList = new List<DishQuota>();
    }
}