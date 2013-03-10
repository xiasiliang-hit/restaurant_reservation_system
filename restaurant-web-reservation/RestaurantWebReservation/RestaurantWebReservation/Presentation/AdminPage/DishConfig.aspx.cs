using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;
using RestaurantWebReservation.DataAccess;

using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.Application.Role;

namespace RestaurantWebReservation.Presentation.AdminPage
{
    public partial class DishConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            admin = new Admin();
            
            Restaurant.InitAllDish();
            foreach (Dish d in Restaurant.dishList)
            {
                //TextBox dishNameTB = new TextBox();
                //dishNameTB.ID = "textBoxName" + i;
                //dishNameTB.Text = d.name;

                //TextBox textBoxDes = new TextBox();
                //textBoxDes.ID = "textBoxDes" + i;
                //textBoxDes.Text = 

                //TextBox textBoxPrice= new TextBox();
                //textBoxPrice.ID = "textBoxPrice" + i;
            }

            //GridView1.DataSource = Restaurant.dishList;
            //GridView1.DataBind();
        }

        


        //protected void GridView1_RowEditing(Object sender, GridViewEditEventArgs e)
        //{
 
        //}

        

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(Object sender, EventArgs e)
        {
            //GridViewRow row = GridView1.SelectedRow;
            //Page.RouteData["nameTemp"]= row.Cells[0].Text;
        }

        Admin admin = null;

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["DishAdd"]);
        }
        
    }

     
}