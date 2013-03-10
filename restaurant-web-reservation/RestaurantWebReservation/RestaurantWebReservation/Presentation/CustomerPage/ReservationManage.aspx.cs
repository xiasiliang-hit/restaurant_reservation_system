using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RestaurantWebReservation.Application.Role;

namespace RestaurantWebReservation.Presentation.CustomerPage
{
    public partial class ReservationManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Customer"] != null)
            {
                GridView1.DataSource = ((Customer)Session["Customer"]).GetCurrentReservation(); ;

                GridView1.DataBind();
            }
            else
            { }
        }
    }
}