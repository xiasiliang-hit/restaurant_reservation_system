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
    public partial class PublishNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manager = new Manager();
        }

        //把news插入到数据库
        protected void ButtonPuslish_Click(object sender, EventArgs e)
        {
            Guid id = Guid.NewGuid();
            DateTime publishTime = new DateTime();
            publishTime = DateTime.Now;

            //实例化一个news
            News news = new News(id, TextBoxTitle.Text, TextBoxContent.Text, publishTime, DropDownListDish.SelectedItem.Text);


            manager.PublishNews(news);
            Response.Write("<Script>alert('news is published successfully')</Script>"); //
        }


        Manager manager = null;
    }
}