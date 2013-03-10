using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using RestaurantWebReservation.Application.Role;

namespace RestaurantWebReservation.Presentation.ManagerPage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Manager"] != null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["ManagerMain"]);
            }
            else
            { }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            User user = RestaurantWebReservation.Application.Role.User.Login(TextBoxName.Text, TextBoxPwd.Text);
            if (user != null)
            {
                Session["Manager"] = (Manager)user;
                Response.Redirect(ConfigurationManager.AppSettings["ManagerMain"]);
            }
            else
            {
                Response.Write("<Script>alert('name or password error')</script>");
            }
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {

        }
    }
}