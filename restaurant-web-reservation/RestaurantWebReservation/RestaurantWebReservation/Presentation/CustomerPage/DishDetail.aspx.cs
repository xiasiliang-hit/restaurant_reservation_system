using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.Linq;
using System.Configuration;
using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.Application.Role;
using RestaurantWebReservation.DataAccess;

namespace RestaurantWebReservation.Presentation.CustomerPage
{
    public partial class DishDetail : System.Web.UI.Page
    {
        string dishName = "Hamburger";
        Dish dish = null;
        Customer customer = null;
        Delivery delivery = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            customer = new Customer();

            if (Session["Delivery"] != null)
            {
                delivery = (Delivery)Session["Delivery"];
            }
            else
            {
                delivery = new Delivery();
            }

            if (Request.QueryString["DishName"] != null)
            {
                dishName = Request.QueryString["DishName"];
                dish = customer.GetDishByName(dishName);
            }
            else
            {//defalut dish
                dish = customer.GetDishByName(dishName);
            }

            ImageDish.ImageUrl = dish.pictPath;

            LabelTag1.Text = dish.tagList.ElementAt(0).name;
            LabelTag2.Text = dish.tagList.ElementAt(1).name;
            LabelTag3.Text = dish.tagList.ElementAt(0).name;
        }
        

        protected void ButtonBuy_Click(object sender, EventArgs e)
        {
        }

        
        //商品加到购物车
        protected void ImageButtonBuy_Click(object sender, ImageClickEventArgs e)
        {
            string str = ((DropDownList)DetailsView1.Rows[5].Cells[1].FindControl("DropDownList1")).SelectedItem.Text;//取出dish名字
            int quota = Convert.ToInt32(str); //数量，类型转下
            DishQuota dishQuota = new DishQuota(Guid.NewGuid(), dish.name, dish.price, quota, "");
            delivery.AddDish(dishQuota);//把new的dish放到session里 的delivery ，相当于加入购物车了
            Session["Delivery"] = delivery; //delivery  放到session

            Response.Write("<Script>alert('Dish is added to your shopping cart')</script>");//提示用户，加入成功

        }

        protected void ObjectDataSourceDish_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            e.ObjectInstance = customer;
        }

        protected void ObjectDataSource2_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            e.ObjectInstance = dish;
        }

        protected void ButtonAddComment_Click(object sender, EventArgs e)
        {
            if (TextBoxComment.Visible == false)
            {
                if (Session["Customer"] != null)
                {
                    TextBoxComment.Visible = true;
                    ButtonAddComment.Text = "Publish Comment";
                }
                else
                {
                    Response.Write("<Script>alert('login first to add comment')</script>");

                }   
            }
            else
            {
                customer = (Customer)Session["Customer"];
                string str = TextBoxComment.Text;
                Comment comment = new Comment(Guid.NewGuid(), str, dish.name, customer.name);
                customer.PublishComment(comment);

                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["DishDetail"] + "?DishName=" + dish.name );
                //TextBoxComment.Visible = false;
                //ButtonAddComment.Text = "Add comment";
            }
        }


    }
}