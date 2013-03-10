using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestaurantWebReservation.Application.Role;
namespace RestaurantWebReservation.Presentation.CustomerPage
{
    public partial class HistoryReservation : System.Web.UI.Page
    {
        Customer customer = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Customer"] != null)
            {
                customer = (Customer)Session["Customer"];
            }
            else
            {
                Response.Write("<Script>alert('Please login first!')</script>");
            }
        }

        protected void ObjectDataSource1_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            e.ObjectInstance = customer;
        }

        protected void ObjectDataSource2_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            e.ObjectInstance = customer;
        }




    }
}