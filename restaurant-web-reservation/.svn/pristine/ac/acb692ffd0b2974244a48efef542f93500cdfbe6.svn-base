using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestaurantWebReservation.Application.Role;
namespace RestaurantWebReservation.Presentation.ManagerPage
{
    public partial class NewReservation : System.Web.UI.Page
    {
        Manager manager = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Manager"] != null)
            {
                manager = (Manager)Session["Manager"];
                UserNameLabel1.Text = manager.name;
            }
            
            else
            {
                divReservation.Visible = false;
                Response.Write("<Script>alert('please login first')</script>");
            }

            if (!IsPostBack)
            {
                TextBoxArriveDate.Text = DateTime.Now.ToShortDateString();
                //DropDownListDuration.Items.Remove("start");
            }
            else
            { }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void DropDownListDuration_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}