using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.Application.Role;
namespace RestaurantWebReservation.Presentation.AdminPage
{
    public partial class DishAdd : System.Web.UI.Page
    {
        Admin admin = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            admin = new Admin();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool fileTypeOk = false;
            string fileExtension = "";
            string virtualPath = System.Configuration.ConfigurationManager.AppSettings["ImageDish"];
            string path = Server.MapPath(virtualPath);
            
            if (this.FileUpload1.HasFile)
            {
                
                fileExtension = System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower();
                string[] allowExtension = { ".gif", ".png", ".jpeg", ".jpg" };
                foreach (string extension in allowExtension)
                {
                    if (fileExtension.Trim() == extension)
                    {
                        fileTypeOk = true;
                    }
                }
            }
            if (fileTypeOk)
            {
                try
                {
                    List<Tag> tagList = new List<Tag>();

                    Tag t1 = new Tag();
                    t1.name = TextBox4.Text;

                    Tag t2 = new Tag();
                    t2.name = TextBox5.Text;

                    Tag t3 = new Tag();
                    t3.name = TextBox6.Text;

                    tagList.Add(t1);
                    tagList.Add(t2);
                    tagList.Add(t3);

                    List<Comment> commentList = new List<Comment>();

                    string pictVirtualPath = virtualPath + TextBox1.Text + fileExtension;
                    Dish dish = new Dish(TextBox1.Text, TextBox2.Text, Convert.ToDouble(TextBox3.Text), pictVirtualPath, 0, tagList, commentList);

                    this.FileUpload1.SaveAs(path + dish.name.ToString() + fileExtension);
                    bool isSucceed = admin.AddDish(dish);

                    if (isSucceed)
                    {
                        this.SubmitInfoLabel.Text = "succeed to add the dish";
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        TextBox3.Text = "";
                        TextBox4.Text = "";
                        TextBox5.Text = "";
                        TextBox6.Text = "";
                    }
                    else
                    {
                        SubmitInfoLabel.Text = "fail, the dish name exists";
                    }
                }
                catch (Exception ee)
                {
                    SubmitInfoLabel.Text = "fail check the format of the image！";
                }
            }
            //没有选择文件或者文件格式不正确
            else
            {
                this.SubmitInfoLabel.Text = "fail no image is avalable, or format is not allowed！";
            }
            this.SubmitInfoLabel.Visible = true;
        }
        
    }
}