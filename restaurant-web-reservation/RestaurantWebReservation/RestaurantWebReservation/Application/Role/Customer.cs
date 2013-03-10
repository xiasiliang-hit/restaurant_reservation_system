using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq;

using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.Application.Role;
using RestaurantWebReservation.Application.Service;
using RestaurantWebReservation.DataAccess;


namespace RestaurantWebReservation.Application.Role
{
    public class Customer : User
    {
        //public string name { get; set; }
        //public string pwd { get; set; }
        //public string mail { get; set; }

        public Customer() { }

        public Customer(string pName, string pPwd, string pmail)
        {
            name = pName;
            pwd = pPwd;
            mail = pmail;
        }

        //CustomService customService = new CustomService();



        //Function: submit a reservation without dishes, used when a custom reserve a table in the restaurant
        public void CommitReservation(Reservation pR)
        {
            PublicService.CommitReservation(pR);
        }

        //public void CancelReservation(Guid pId)
        //{

        //}

        public void ModifyReservation(Reservation pR)
        {
            PublicService.ModifyReservation(pR);
        }

        //~should be a function if custom is allowed to add dish by his own when having meal
        //  or when commit a reservation
        //public void AddDishToReservation(Reservation pReservation, DishQuota pDishQuota)
        //{
        //    pReservation.AddDish(pDishQuota);
        //}

        //public void DeleteDishFromReservation(Reservation pReservation, Guid pDishQuotaId)
        //{
        //    pReservation.DeleteDish(pDishQuotaId);
        //}

        //Return: all reservations of his own
        public List<Reservation> GetHistoryReservation()
        {
            return PublicService.GetHistoryReservation(name);
        }

        //his own
        public List<Reservation> GetCurrentReservation()
        {
            return PublicService.GetUnfinishedReservation(name);
        }
        public  List<Delivery> GetHistoryDelivery()
        {
            return PublicService.GetHistoryDelivery(name);
        }

        public  List<Delivery> GetUndelivedDelivery()
        {
            return PublicService.GetUndelivedDelivery(name);
        }


        //when a Delivery is committed, the dishes in the delivery is commiteed to db at one time
        public void CommitDelivery(Delivery pD)
        {
            DataContextDataContext dc = new DataContextDataContext();
            dc.insert_delivery(
                (Guid?)pD.id,
                pD.userFrom,
                pD.customerName,
                pD.phone,
                pD.address,
                (DateTime?)pD.commitTime,
                (DateTime?)pD.deliveryTime
                );

            foreach (DishQuota dq in pD.dishQuotaList)
            {
                dc.insert_delivery_dish((Guid?)dq.id, pD.id, dq.dishName, (int?)dq.quota, dq.note);
            }
        }

        //AddDishToDelivery(){}
        //DeleteDishFromDelivery(dish, rid){}
        //public void PublishComment(Comment pC){}
        //读数据库，根据popularity高低吧推荐dish返回出来
        //这个popularity在任何用户在主页点击某一个dish到DishDetail.aspx页面是会更新的
        public List<Dish> GetRecommendedDish()
        {
            List<Dish> dishList = new List<Dish>();

            DataContextDataContext dc = new DataContextDataContext();
            ISingleResult<get_hot_dishResult> rs = dc.get_hot_dish();
            foreach (get_hot_dishResult r in rs)
            {
                List<Tag> tagList = new List<Tag>();
                ISingleResult<get_tag_by_dishResult> rs2 = dc.get_tag_by_dish(r.name);
                foreach (get_tag_by_dishResult r2 in rs2)
                {
                    Tag tag = new Tag(r2.name, (int)r2.popularity);
                    tagList.Add(tag);
                }

                List<Comment> commentList = new List<Comment>();

                ISingleResult<get_comment_by_dishResult> rs3 = dc.get_comment_by_dish(r.name);
                foreach (get_comment_by_dishResult r3 in rs3)
                {
                    Comment comment = new Comment(r3.id, r3.content, r3.about_dish, r3.user_from);
                    commentList.Add(comment);
                }
                Dish dish = new Dish(r.name,
                    r.description,
                    (double)r.price,
                    r.pict_path,
                    (int)r.popularity,
                    tagList,
                    commentList);

            }
            return dishList;
        }

        public static List<Tag> GetHotTag()
        {
            List<Tag> tagList = new List<Tag>();

            DataContextDataContext dc = new DataContextDataContext();
            ISingleResult<get_hot_tagResult> rs2 = dc.get_hot_tag();
            foreach (get_hot_tagResult r2 in rs2)
            {
                Tag tag = new Tag(r2.name, (int)r2.popularity);
                tagList.Add(tag);
            }
            return tagList;
        }

        public Dish GetDishByName(string pDishName)
        {
            Dish dish = null;

            DataContextDataContext dc = new DataContextDataContext();
            ISingleResult<get_dish_by_nameResult> rs = dc.get_dish_by_name(pDishName);

            foreach (get_dish_by_nameResult r in rs)
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
                    Comment comment = new Comment(r3.id, r3.content, r3.about_dish, r3.user_from);
                    commentList.Add(comment);

                }

                dish = new Dish(
                    r.name,
                    r.description,
                    (double)r.price,
                    r.pict_path,
                    (int)r.popularity,
                    tagList,
                    commentList);
            }
            return dish;
        }

        public static List<News> GetNews()
        {
             return PublicService.GetNews();
        }


        public Dictionary<string, DateTime> GetBusinessTime()
        {
            return PublicService.GetBusinessTime();
        }

        public List<string> GetAvailableTableName(DateTime pDateTime)
        {
            List<string> tableNameList = new List<string>();
            DataContextDataContext dc = new DataContextDataContext();
            ISingleResult<get_available_tableResult> rs = dc.get_available_table(pDateTime);

            foreach (get_available_tableResult r in rs)
            {

                tableNameList.Add(r.name);
            }
            return tableNameList;
        }

        public void PublishComment(Comment pC)
        {

            DataContextDataContext dc = new DataContextDataContext();
            dc.insert_comment(pC.id,pC.content,pC.aboutDish,pC.userFrom);
        }

		public List<Dish> SearchDishByKeyword(string pKeyword)
		{
            List<Dish> dishList = new List<Dish>();
            DataContextDataContext dc = new DataContextDataContext();

            ISingleResult<search_dish_by_keywordResult> rs = dc.search_dish_by_keyword(pKeyword);
            foreach (search_dish_by_keywordResult r in rs)
            {
                List<Tag> tagList = new List<Tag>();
                ISingleResult<get_tag_by_dishResult> rs2 = dc.get_tag_by_dish(r.name);
                foreach (get_tag_by_dishResult r2 in rs2)
                {
                    Tag tag = new Tag(r2.name, (int)r2.popularity);
                    tagList.Add(tag);
                }

                List<Comment> commentList = new List<Comment>();

                ISingleResult<get_comment_by_dishResult> rs3 = dc.get_comment_by_dish(r.name);
                foreach (get_comment_by_dishResult r3 in rs3)
                {
                    Comment comment = new Comment(r3.id, r3.content, r3.about_dish, r3.user_from);
                    commentList.Add(comment);
                }
                Dish dish = new Dish(r.name,
                    r.description,
                    (double)r.price,
                    r.pict_path,
                    (int)r.popularity,
                    tagList,
                    commentList);
                dishList.Add(dish);

            }
            return dishList;
		}
    }
}