using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using RestaurantWebReservation.DataAccess;
namespace RestaurantWebReservation.Application.BasicDataStractrue
{
    public class News
    {
        public News() { }
        public News(Guid pId, string pTitle, string pContent, DateTime pPublishTime, string pAboutDish)
        {
            id = pId;
            title = pTitle;
            content = pContent;
            publishTime = pPublishTime;
            aboutDish = pAboutDish;

            DataContextDataContext dc = new DataContextDataContext();
            ISingleResult<get_dish_by_nameResult> rs2 = dc.get_dish_by_name(aboutDish);
            foreach (get_dish_by_nameResult r2 in rs2)
            {
                pictPath = r2.pict_path;
            }
        }

        public Guid id {get; set;}
        public string title{get; set;}
        public string content { get; set; }
        public DateTime publishTime { get; set; }
        public string aboutDish { get; set; }
        public string pictPath { get; set; }
    }
}