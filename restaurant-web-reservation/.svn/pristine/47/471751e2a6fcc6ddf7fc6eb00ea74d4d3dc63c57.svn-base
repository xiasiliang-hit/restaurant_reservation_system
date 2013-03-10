using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;

using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.Application.Role;
using RestaurantWebReservation.DataAccess;
namespace RestaurantWebReservation.Presentation.CustomerPage
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRegiser_Click(object sender, EventArgs e)
        { }

        //验证用户输入，并插入新用户到数据库
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string name = UserName.Text;
            string pwd = Password.Text;
            string mail = Email.Text;

            Customer customer = RestaurantWebReservation.Application.Role.User.Register(name, pwd, mail);

            if (customer != null) //注册成功，吧customer反倒sission
            {
                args.IsValid = true;
                Session["customer"] = customer;
                Response.Redirect(ConfigurationManager.AppSettings["CustomerMain"]);
            }
            else //error: name exist  //数据库用户已经存在，验证通不过，提示用户换个name
            {
                args.IsValid = false;
                this.SetFocus(UserName);
            }
        }
    }
}