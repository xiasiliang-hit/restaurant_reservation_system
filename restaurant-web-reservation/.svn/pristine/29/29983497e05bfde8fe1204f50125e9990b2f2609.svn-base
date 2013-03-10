using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RestaurantWebReservation.Application.Role;
using RestaurantWebReservation.Application.BasicDataStractrue;

namespace RestaurantWebReservation.Presentation.ManagerPage
{
    public partial class AnalyzeHistoryDelivery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = ObjectDataSourceInit;
                GridView1.DataBind();

                GridView2.DataSource = ObjectDataSourceInit2;
                GridView2.DataBind();
            }
            else
            { }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (TextBoxKey.Text != "")
            {
                GridView1.DataSource = ObjectDataSource1;
                GridView1.DataBind();

                GridView2.DataSource = ObjectDataSource2;
                GridView2.DataBind();
            }
            else
            {
                GridView1.DataSource = ObjectDataSourceInit;
                GridView1.DataBind();

                GridView2.DataSource = ObjectDataSourceInit2;
                GridView2.DataBind();
            }
            
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxKey.Text = GridView1.SelectedRow.Cells[1].Text;
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxKey.Text = GridView2.SelectedRow.Cells[1].Text;
        }

        protected void ObjectDataSource3_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            
        }
    }
}