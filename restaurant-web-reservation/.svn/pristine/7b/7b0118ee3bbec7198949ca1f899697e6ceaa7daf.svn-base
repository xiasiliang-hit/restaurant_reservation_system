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
    public partial class Bill : System.Web.UI.Page
    {
        string tableName = null;
        Manager manager = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Manager"] != null)
            {
                manager = (Manager)Session["Manager"];

            }
            else
            { }

            if (Request.QueryString["TableName"] != null)
            {
                tableName = Request.QueryString["TableName"];
            }
            else
            {
                Label1.Text = "no table is selected!";

            }
        }


        
        protected void ObjectDataSource1_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            foreach (SysTable t in Restaurant.tableList )
            {
                if (t.name == tableName)
                {
                    e.ObjectInstance =  t.GetReservation(); //从桌子name获得用户reservation信息
                    List<DishQuota> d = t.GetReservation().GetDishQuota();// 显示在表格头部
                    Label1.Text = "Table: " + tableName;
                    Label2.Text = "Customer: " + t.GetReservation().customerName;
                }
            }
        }

        
        //汇总用户总消费
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            double priceTotal = 0;

            if (GridView1.Rows.Count != 0)
            {
                foreach (GridViewRow r in GridView1.Rows)
                {
                    if (r.RowIndex != -1)
                    {
                        priceTotal += Convert.ToDouble(r.Cells[3].Text);
                    }
                    else
                    { }
                }

                GridView1.FooterRow.Cells[0].ColumnSpan = 3;
                GridView1.FooterRow.Cells.RemoveAt(1);
                GridView1.FooterRow.Cells.RemoveAt(2);
                GridView1.FooterRow.Cells[0].Text = "Total cost: $" + priceTotal.ToString();
            }
            else
            { }
        }

        //一种dish的小计 price*num，显示在一行尾
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                string itemTotal = (Convert.ToDouble(e.Row.Cells[1].Text) * Convert.ToInt32(e.Row.Cells[2].Text)).ToString();
                e.Row.Cells[3].Text = itemTotal;
            }
            else
            { }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            manager.FinishMeal(tableName);
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["ManagerMain"]);
        }


    }
}