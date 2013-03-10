using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantWebReservation.Application.BasicDataStractrue
{
    public class DishQuota
    {
        public DishQuota() { }
        public DishQuota(Guid pId, string pDishName, double pPriceSingle, int pQuota, string pNote)
        {
            id = pId;
            dishName = pDishName;
            priceSingle = pPriceSingle;
            quota = pQuota;
            note = pNote;
        }

        public Guid id { get; set; }
        public string dishName { get; set; }
        public double priceSingle { get; set; }
        public int quota { get; set; }
        public string note { get; set; }
    }
}