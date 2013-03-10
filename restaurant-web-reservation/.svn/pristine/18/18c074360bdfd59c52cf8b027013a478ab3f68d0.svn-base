using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using RestaurantWebReservation.Application.Role;
using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.Application.Service;

namespace RestaurantWebReservation.Presentation
{
    public partial class MainManager : System.Web.UI.MasterPage
    {
        Manager manager = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Manager"] == null)
            {
                ContentPlaceHolder1.Visible = false;
                divLogin.Visible = false;
                divMenu.Visible = false;
                this.ContentPlaceHolder1.Visible = false;
            }
            else
            {
                divNotLogin.Visible = false;

                manager = (Manager)Session["manager"];
                LabelHello.Text = "Hello " + manager.name;
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            User user = RestaurantWebReservation.Application.Role.User.Login(TextBoxName.Text, TextBoxPwd.Text);
            if (user != null)
            {
                Session["Manager"] = (Manager)user;
                Response.Redirect(Request.Url.ToString());
            }
            else
            {
                Response.Write("<Script>alert('name or password error')</script>");
            }
        }
    } 
}