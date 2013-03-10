using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RestaurantWebReservation.DataAccess;

namespace RestaurantWebReservation.Application.BasicDataStractrue
{
    public class Comment
    {
        public Comment() { }
        public Comment(Guid pId, string pContent, string pAboutDish, string pUserFrom)
        {
            id = pId;
            content = pContent;
            aboutDish = pAboutDish;
            userFrom = pUserFrom;
        }

        public void Publish()
        {
            DataContextDataContext dc = new DataContextDataContext();
            dc.insert_comment(id, content, aboutDish, userFrom);
        }

        public Guid id { get; set; }
        public string content { get; set; }
        public string aboutDish { get; set; }
        public string userFrom { get; set; }
    }
}