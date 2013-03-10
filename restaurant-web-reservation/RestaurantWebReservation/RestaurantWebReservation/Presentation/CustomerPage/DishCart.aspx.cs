using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using RestaurantWebReservation.Application.BasicDataStractrue;

namespace RestaurantWebReservation.Presentation.CustomerPage
{
    public partial class DishCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            List<DishQuota> dishQuotaList = new List<DishQuota>();

            foreach (GridViewRow r in GridView1.Rows)
            {
                //这个相当于购物车的内容了，这里还可以添加，删除东西
                string quotaStr = ((DropDownList)(r.Cells[5].FindControl("DropDownList1"))).SelectedItem.Text.ToString(); //吧数量取出来
                if (quotaStr == "0")
                { } //不用处理
                else
                {
                    string dishName = r.Cells[0].Text; //名字取出来
                    double price = Convert.ToDouble(r.Cells[2].Text.Substring(1));//价格
                    int quota = Convert.ToInt32(quotaStr);//数量的数据类型转换下

                    DishQuota dishQuota = new DishQuota(Guid.NewGuid(), dishName, price, quota, "");//实例化一个dish
                    dishQuotaList.Add(dishQuota);//放到list
                }
            }

            if (dishQuotaList.Count != 0)//list 有东西
            {
                if (Session["Delivery"] != null)  //delivery 在session已经有
                {
                    ((Delivery)Session["Delivery"]).dishQuotaList = dishQuotaList; //设置session里的delivery的list为刚刚设置的list
                }
                else
                {
                    Delivery delivery = new Delivery(); //new 一个delivery
                    delivery.dishQuotaList = dishQuotaList;

                    Session["Delivery"] = delivery;  //把new的放到sesion
                }
                Response.Redirect(ConfigurationManager.AppSettings["NewDelivery"]); //转到填写用户信息的页面
            }
            else
            {
                Response.Write("<Script>alert('no dishes is selected!')</script>"); //list空的，错误提示

            }
            
        }
    }
}