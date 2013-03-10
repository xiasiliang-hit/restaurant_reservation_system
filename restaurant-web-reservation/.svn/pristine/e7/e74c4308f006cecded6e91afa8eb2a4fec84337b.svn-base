using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestaurantWebReservation.Application.Role;

namespace RestaurantWebReservation.Presentation.ManagerPage
{
    public partial class AnalyzeDaily : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //吧统计数据绑定到表格
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            double priceTotal = 0;

            foreach (GridViewRow r in GridView1.Rows)
            {
                if (r.RowIndex != -1)
                {
                    priceTotal += Convert.ToDouble(r.Cells[4].Text);//求和，一天的销售总和
                }
                else
                { }
            }
            GridView1.FooterRow.Cells[0].ColumnSpan = 4;
            GridView1.FooterRow.Cells.RemoveAt(1);
            GridView1.FooterRow.Cells.RemoveAt(2);
            GridView1.FooterRow.Cells.RemoveAt(3);//合并单元格
            GridView1.FooterRow.Cells[0].Text = "Sum of Business Today: $" ;
            GridView1.FooterRow.Cells[1].Text = priceTotal.ToString();  //总和显示到表格下方
        }
    }
}