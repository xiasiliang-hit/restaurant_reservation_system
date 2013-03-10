using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.Application.Role;

namespace RestaurantWebReservation.Presentation.CustomerPage
{
    public partial class NewReservation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //$判断是否custoemr登录了
            if (Session["Customer"] == null)
            {
                divReservation.Visible = false;
                Response.Write("<Script>alert('please login first')</script>");

                //RequiredFieldValidatorName.Enabled = false;
                //RequiredFieldValidatorPhone.Enabled = false;
                //RequiredFieldValidatorAddress.Enabled = false;
            }
            else
            {
                customer = (Customer)Session["Customer"];
                UserNameLabel1.Text = customer.name;
            }

            if (!IsPostBack)
            {
                TextBoxArriveDate.Text = DateTime.Now.ToShortDateString();
                //DropDownListDuration.Items.Remove(DropDownListDuration.Items.FindByText("start"));
            }
        }
        
        //new 一个 resrvation， 把页面上信息填充进来，提交resrvation
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            Guid id = Guid.NewGuid();
            //DateTime arriveTime = new DateTime();
            DateTime arriveTime = Convert.ToDateTime(TextBoxArriveDate.Text + " " + DropDownListTime.Text);

            Reservation reservation = new Reservation(
                id,
                customer.name,
                TextBoxUserName.Text,
                TextBoxPhone.Text,
                arriveTime,
                DropDownListTableName.SelectedItem.Text,
                Convert.ToInt32(TextBoxSeat.Text),
                ReservationType.Reservation, ReservationState.RESRVED);

            customer.CommitReservation(reservation);

            Response.Write("<Script>alert('Your reservation is recorded by system, please be on time!')</script>");
        }

        //那一餐的下来菜单选中项变的时候，其他的也要变，可供选择的有效的桌子就变了
        //还有具体时间，比如选早饭，具体时间在8：00-1：00，晚饭具体时间就变成19:00-21：00
        protected void DropDownListDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime tempBegin = new DateTime();
            DateTime tempEnd = new DateTime();
            string durationStr = DropDownListDuration.SelectedItem.Text;
            Dictionary<string, DateTime> dict = new Dictionary<string, DateTime>();
            dict =  customer.GetBusinessTime();
            tempEnd = dict[durationStr]; 

            //init hours available
            DropDownListTime.Items.Clear();  //清空原来的选择项

            //把对应的时间填上去供选择
            foreach (KeyValuePair<string, DateTime> p in dict)
            {
                if (p.Value < tempEnd)
                {
                    tempBegin = p.Value;
                }

                else if (p.Value == tempEnd)
                {
                    int hourBegin = tempBegin.Hour;
                    int hourEnd = tempEnd.Hour;

                    for (int i = hourBegin + 1; i <= hourEnd; i++)
                    {
                        string hourStr = i.ToString() + ":00:00";
                        DropDownListTime.Items.Add(hourStr);
                    }

                    break;
                }
                else
                { }
            }

            //获得有效的桌子，并填到下拉菜单里面
            //first time in this duration
            //not the exact, when customer choose the exact, do not change again
            DateTime targetDurationStandTime = new DateTime();
            targetDurationStandTime = Convert.ToDateTime(TextBoxArriveDate.Text + " " + DropDownListTime.SelectedItem.Text);

            DropDownListTableName.Items.Clear();
            List<string> availableTableNameList = new List<string>();
            availableTableNameList = customer.GetAvailableTableName(targetDurationStandTime);

            foreach (string s in availableTableNameList)
            {
                DropDownListTableName.Items.Add(s);
            }

            if (DropDownListTableName.Items.Count == 0)
            {
                DropDownListTableName.Items.Add("No table available");
            }
            //DropDownListTableName.DataSource = availableTableNameList;
            //DropDownListTableName.DataBind();
        }

        Customer customer = null;

        protected void DropDownListDuration_DataBound(object sender, EventArgs e)
        {
            //ListItem i = new ListItem();
            //i = DropDownListDuration.Items.FindByText("start");
            //DropDownListDuration.Items.Remove(i);
        }




    }
}