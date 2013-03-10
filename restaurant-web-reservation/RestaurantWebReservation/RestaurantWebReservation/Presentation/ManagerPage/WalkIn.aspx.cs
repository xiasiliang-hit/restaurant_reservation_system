using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.Application.Role;
namespace RestaurantWebReservation.Presentation.ManagerPage
{
    public partial class WalkIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Manager"] != null)
            {
                manager = (Manager)Session["Manager"];
            }
            else
            {
                divReservation.Visible = false;
            }//error


            if (Request.QueryString["tableName"] != null)
            {
                tableName = Request.QueryString["tableName"].ToString();
            }
            else 
            {
                Response.Write("<Script>alert('no table is selected ')</script>");
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["ManagerMain"]);
            }

            if (!IsPostBack)
            {
                LabelTable.Text = tableName;
                LabelTime.Text = DateTime.Now.ToString();
            }
        }

        //没有预定的人直接用餐，提交信息
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation(
                Guid.NewGuid(),
                manager.name,
                TextBoxUserName.Text,
                TextBoxPhone.Text,
                Convert.ToDateTime(LabelTime.Text),
                tableName,
                Convert.ToInt32(TextBoxSeat.Text),
                ReservationType.WalkIn,
                ReservationState.BUSY);

            manager.WalkInArrive(tableName, reservation); //转换桌子状态

            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["ManagerMain"]);  //跳转回manager主页
        }

        Manager manager = null;
        string tableName = null;
    }
}