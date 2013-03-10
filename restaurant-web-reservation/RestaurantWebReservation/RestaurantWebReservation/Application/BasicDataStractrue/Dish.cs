using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantWebReservation.Application.BasicDataStractrue
{
    public class Dish
    {
        public Dish() { }
        public Dish(string pName, string pDescription, double pPrice, string pPictPath, int pPopularity, List<Tag> pTagList, List<Comment> pCommentList)
        {
            name = pName;
            description = pDescription;
            price = pPrice;
            pictPath = pPictPath;
            popularity = pPopularity;
            tagList = pTagList;
            commentList = pCommentList;
        }

        public List<Comment> GetComment()
        {
            return commentList;
        }
        
        
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string pictPath { get; set; }
        public int popularity { get; set; }

        public List<Tag> tagList = new List<Tag>();
        public List<Comment> commentList = new List<Comment>();
    }
}