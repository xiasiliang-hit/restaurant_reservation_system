using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;

using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.Application.Role;

namespace RestaurantWebReservation.Presentation.AdminPage
{
    public partial class ManagerRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            admin = new Admin();
        }
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string name = UserName.Text;
            string pwd = Password.Text;
            string mail = Email.Text;

            Manager manager = admin.RegisterManager(name, pwd, mail);

            if (manager != null)
            {
                args.IsValid = true;
                Label1.Text = "Success to register new manager!";

                UserName.Text = "";
                Email.Text = "";
            }
            else //error: name exist
            {
                args.IsValid = false;
                Label1.Text = "fail to register manager!";
                this.SetFocus(UserName);
            }
        }

        protected void ButtonRegiser_Click(object sender, EventArgs e)
        {
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["UserConfig"]);
        }

        Admin admin = null;
    }
}