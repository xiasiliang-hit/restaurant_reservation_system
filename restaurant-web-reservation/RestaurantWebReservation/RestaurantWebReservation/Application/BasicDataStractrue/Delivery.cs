using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RestaurantWebReservation.DataAccess;

namespace RestaurantWebReservation.Application.BasicDataStractrue
{
    public class Delivery
    {
        public Delivery() { }
        public Delivery(Guid pId, string pUserFrom, string pCustomerName, string pPhone, string pAddress, DateTime pCommitTime, DateTime pDeliveryTime, DeliveryState pState, List<DishQuota> pDishQuotaList)
        {
            id = pId;
            userFrom = pUserFrom;
            customerName = pCustomerName;
            phone = pPhone;
            address = pAddress;
            commitTime = pCommitTime;
            deliveryTime = pDeliveryTime;

            state = pState;
            dishQuotaList = pDishQuotaList;
        }
        public void CompleteDelivery(Guid pId, string pUserFrom, string pCustomerName, string pPhone, string pAddress, DateTime pCommitTime, DateTime pDeliveryTime, DeliveryState pState)
        {
            id = pId;
            userFrom = pUserFrom;
            customerName = pCustomerName;
            phone = pPhone;
            address = pAddress;
            commitTime = pCommitTime;
            deliveryTime = pDeliveryTime;

            state = pState;
        }
        public void AddDish(DishQuota pDishQuota)
        {
            dishQuotaList.Add(pDishQuota);
        }

        public void DeleteDish(Guid pId)
        {
            foreach (DishQuota dq in dishQuotaList)
            {
                if (dq.id == pId)
                {
                    dishQuotaList.Remove(dq);
                }
                else
                { }
            }
        }

        public void ChangeState(DeliveryState pState)
        {
            state = pState;

            //~ synchronize to db, if need to maintain the state in db
            DataContextDataContext dc = new DataContextDataContext();
            dc.update_state_delivery(id, (int?)state);
        }

        public List<DishQuota> GetDishQuota()
        {
            return dishQuotaList;
        }


        public Guid id { get; set; }
        public string userFrom { get; set; }
        public string customerName { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime commitTime { get; set; }
        public DateTime deliveryTime { get; set; }
        public DeliveryState state = DeliveryState.UNDELIVERED;

        public List<DishQuota> dishQuotaList = new List<DishQuota>();

       
    }
}