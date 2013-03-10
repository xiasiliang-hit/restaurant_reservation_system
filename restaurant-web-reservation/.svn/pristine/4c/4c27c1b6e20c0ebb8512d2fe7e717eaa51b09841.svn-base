using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace RestaurantWebReservation.Presentation.AdminPage
{
    public partial class AdminMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonTimeCongfig_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["TimeConfig"]);
           
        }

        protected void ButtonDishConfig_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["DishConfig"]);
        }

        protected void ButtonUserConfig_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["UserConfig"]);
        }

        protected void ButtonTableConfig_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["TableConfig"]);
        }
    }
}