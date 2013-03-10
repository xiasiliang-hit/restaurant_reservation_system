using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.Application.Role;


namespace RestaurantWebReservation.Presentation.CustomerPage
{
    public partial class AddDish : System.Web.UI.Page
    {
        string tableName = null;
        Manager manager = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            manager = (Manager)Session["Manager"];

            //从url里找到桌子name
            if (Request.QueryString["TableName"] != null) 
            {
                tableName = Request.QueryString["TableName"];
            }
            else
            {
                Label1.Text = "no table is selected";
                GridView1.Dispose();
            }
        }

        //把点的菜 记录下来到对应的table的reservation，传的是table name ，dish是记录到reservation的
        //然后跳转会manager主页
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow r in GridView1.Rows)
            {
                string quotaStr = ((DropDownList)(r.Cells[5].FindControl("DropDownList1"))).SelectedItem.Text.ToString();
                if (quotaStr == "0")
                { }
                else
                {
                    string dishName = r.Cells[0].Text;
                    double price = Convert.ToDouble(r.Cells[2].Text.Substring(1));
                    int quota = Convert.ToInt32(quotaStr);

                    DishQuota dishQuota = new DishQuota(Guid.NewGuid(), dishName, price, quota, "");
                    manager.AddDish(tableName, dishQuota);
                }
            }
            Response.Redirect(ConfigurationManager.AppSettings["ManagerMain"]);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }


    }
}