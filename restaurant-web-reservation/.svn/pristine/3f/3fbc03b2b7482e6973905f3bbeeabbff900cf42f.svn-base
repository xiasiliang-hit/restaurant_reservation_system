using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantWebReservation.Application.BasicDataStractrue
{
    public class DishReort : Dish
    {
        public DishReort(Dish pDish)
        {
            name = pDish.name;
            price = pDish.price;
            popularity = pDish.popularity;

            description = "";
            pictPath = "";
            tagList = null;
            commentList = null;
        }

        public int reservationQuota { get; set; }
        public int deliveryQuota { get; set; }
        public double totalPrice { get; set; }
    }
}