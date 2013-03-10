using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.Application.Role;
using RestaurantWebReservation.DataAccess;

namespace RestaurantWebReservation.Presentation.CustomerPage
{
    public partial class CustomerMain : System.Web.UI.Page
    {
        Customer customer = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            customer = new Customer();

            if (!IsPostBack)
            {
                GridViewDish.DataSource = SqlDataSourceHotDish;
                GridViewDish.DataBind();
            }

            
        }

        //tag popular+1 重新绑定datasource，页面的推荐dish变成与点击tag相关的dish，还在原来位置
        protected void GridViewTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewTag.SelectedRow;
            string name = row.Cells[0].Text;
            dc.update_tag_pupularity_or_insert(name);
            
            GridViewDish.DataSource = SqlDataSourceTagDish;
            GridViewDish.DataBind();
        }
        



        

        protected void ButtonHotDish_Click(object sender, EventArgs e)
        {

            GridViewDish.DataSource = SqlDataSourceHotDish;
            GridViewDish.DataBind();
        }

        //$dish的popularity在这里+1,跳转到dishdetail页面
        protected void GridViewDish_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dishName = GridViewDish.SelectedDataKey.Value.ToString();
            dc.update_dish_popularity(dishName);
            Response.Redirect(ConfigurationManager.AppSettings["DishDetail"] + "?DishName=" + GridViewDish.SelectedValue);
        }

        protected void ObjectDataSourceTag_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        //$把search的结果数据库绑定到 GridViewDish，就是返回search的结果
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            GridViewDish.DataSource = SqlDataSourceKeyword;
            GridViewDish.DataBind();
        }

        DataContextDataContext dc = new DataContextDataContext();
    }
}