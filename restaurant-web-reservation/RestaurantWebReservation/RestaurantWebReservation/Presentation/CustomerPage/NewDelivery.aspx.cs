using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

using RestaurantWebReservation.Presentation;
using RestaurantWebReservation.Application.Role;
using RestaurantWebReservation.Application.BasicDataStractrue;

namespace RestaurantWebReservation.Presentation.CustomerPage
{
    public partial class NewDelivery : System.Web.UI.Page
    {
        Customer customer = null;
        Delivery delivery = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Customer"] != null)
            {
                customer = (Customer)Session["Customer"];
                LabelCustomerName.Text = customer.name;
            }
            else
            {
                Response.Write("<Script>alert('please login first')</script>");
            }
            if (Session["Delivery"] != null)
            {
                delivery = (Delivery)Session["Delivery"];
                if (delivery.dishQuotaList.Count == 0)
                {
                    GridView1.Dispose();
                    LabelCart.Text = "No dishes is in your shopping cart";
                }
                else
                { }
            }
            else
            {
                GridView1.Dispose();
                LabelCart.Text = "No dishes is in your shopping cart";
            }//error


            //初始化时间选择的下拉菜单
            if (!IsPostBack)
            {
                //init conponent
                int hourNow = DateTime.Now.Hour;
                TextBoxDate.Text = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;


                for (int i = 6; i <= 20; i++)
                {
                    string hour = i.ToString();
                    DropDownListHour.Items.Add(hour);
                }

                for (int j = 0; j <= 6; j += 1)
                {
                    DropDownListMinute.Items.Add(j.ToString() + "0");
                }

                
                LabelTime.Text = DropDownListHour.SelectedItem.Text + ":" + DropDownListMinute.SelectedItem.Text;
            }
            else
            { }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (Session["Delivery"] != null && Session["Customer"] != null)
            {
                //List<DishQuota> dishQuotaList = ((Delivery)Session["Delivery"]).dishQuotaList;
                DateTime deliveryTime = new DateTime();
                deliveryTime = Convert.ToDateTime(TextBoxDate.Text + " " + LabelTime.Text);
                DateTime now = DateTime.Now;
                //now = DateTime.Now;

                //delivery是session里面取出来的，加上这个页面上的信息，插入到数据库
                //Delivery delivery = new Delivery(
                delivery.CompleteDelivery(
                    Guid.NewGuid(),
                    customer.name,
                    TextBoxUserName.Text,
                    TextBoxPhone.Text,
                    TextBoxAddress.Text,
                    now,
                    deliveryTime,
                    DeliveryState.UNDELIVERED
                    //dishQuotaList
                   );
                customer.CommitDelivery(delivery);

                Response.Write("<Script>alert('succeed to submit, we will send the dishes on time!')</script>");
                Response.Redirect(ConfigurationManager.AppSettings["CustomerMain"]); //跳转主页
            }
            else
            { } //error
            //((MainCustomer)Master).customer.CommitDelivery(((MainCustomer)Master).delivery);
        }

        //小时和分钟的选择引起 显示变化，LabelTime要把小时，分值一起显示出来
        protected void DropDownListHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelTime.Text = DropDownListHour.SelectedItem.Text + ":" + DropDownListMinute.SelectedItem.Text;

        }

        protected void DropDownListMinute_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelTime.Text = DropDownListHour.SelectedItem.Text + ":" + DropDownListMinute.SelectedItem.Text;
        }

        //页面左边的dish表格，绑定到当前的这个session的delivery，显示
        protected void ObjectDataSource1_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            e.ObjectInstance = delivery;
        }

        //行小计
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

        //总价，并显示
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            double priceTotal = 0;

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

        //日期变化，吧具体时间复原
        protected void TextBoxDate_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxDate.Text == DateTime.Now.Date.ToString())
            {
                DropDownListHour.Items.Clear();
                for (int i = 8; i <= 20; i++)
                {
                    DropDownListHour.Items.Add(i.ToString());
                }
            }
            else 
            { }
        }
        
    }
}