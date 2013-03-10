using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.Application.Role;

namespace RestaurantWebReservation.Presentation.AdminPage
{
    public partial class TableConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            admin = new Admin();
        }

        

        Admin admin = null;

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["TableAdd"]);
        }
    }
}