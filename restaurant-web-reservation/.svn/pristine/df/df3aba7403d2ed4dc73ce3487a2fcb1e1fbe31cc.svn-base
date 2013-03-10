using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using RestaurantWebReservation.Application.Role;
using RestaurantWebReservation.Application.BasicDataStractrue;

namespace RestaurantWebReservation.Presentation
{
    public partial class MainCustomer : System.Web.UI.MasterPage
    {
        //public Customer customer = null;
        //public Delivery delivery = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Customer"] != null)
            {
                LabelWelcome.Text = "Welcome, " + ((Customer)Session["Customer"]).name ;
                FindControl("divNotLogin").Visible = false;
                FindControl("divLogin").Visible = true;
            }
            else
            { 
                FindControl("divNotLogin").Visible = true;
                FindControl("divLogin").Visible = false;
                
            }
            
        }

        

        protected void TextBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void HeadLoginView_ViewChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            User user = RestaurantWebReservation.Application.Role.User.Login(TextBoxName.Text, TextBoxPwd.Text);
            if (user != null)
            {
                Session["Customer"] = (Customer)user;
                Response.Redirect(Request.Url.ToString());
            }
            else
            {
                Response.Write("<Script>alert('name or password error')</script>");
            }
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["Register"]);
        }
    }
}