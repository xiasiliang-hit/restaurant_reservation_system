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
    public partial class TableAdd : System.Web.UI.Page
    {
        Admin admin = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            admin = new Admin();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
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
                    Guid id = Guid.NewGuid();
                    string name = TextBoxName.Text;
                    int seat = Convert.ToInt32(TextBoxSeat.Text);
                    string pictVirtualPath = virtualPath + name.ToString() + fileExtension;


                    SysTable table = new SysTable(
                        id,
                        name,
                        seat,
                        pictVirtualPath,
                        TableState.AVAILABLE);


                    this.FileUpload1.SaveAs(path + table.name.ToString() + fileExtension);
                    bool isSucceed = admin.AddTable(table);

                    if (isSucceed)
                    {
                        SubmitInfoLabel.Text = "succeed to add the dish";
                        //TextBox.Text = "";
                        //TextBox2.Text = "";
                        //TextBox3.Text = "";
                        //TextBox4.Text = "";
                        //TextBox5.Text = "";
                        //TextBox6.Text = "";
                    }
                    else
                    {
                        SubmitInfoLabel.Text = "fail, the table name exists";
                    }
                }
                catch (Exception ee)
                {
                    this.SubmitInfoLabel.Text = "fail check the format of the image！";
                }
            }
            //no file is updated or format error
            else
            {
                this.SubmitInfoLabel.Text = "fail no image is avalable, or format is not allowed！";
            }
            this.SubmitInfoLabel.Visible = true;
        }
    }
}