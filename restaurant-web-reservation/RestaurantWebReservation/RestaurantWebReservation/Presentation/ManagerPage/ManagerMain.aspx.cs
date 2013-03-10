using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.Application.Role;
using RestaurantWebReservation.Application.Service;

namespace RestaurantWebReservation.Presentation.ManagerPage
{
    public partial class ManagerMain : System.Web.UI.Page
    {
        string tableName = null;
        Manager manager = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化table，dish信息
            Restaurant.InitAllDish();
            Restaurant.InitAllTable();
            CheckService.CheckTableReserved();
            CheckService.CheckTableTimeOut();

            //看是否登录，登录的manager，custoemr都会存session的
            if (Session["Manager"] != null)
            {
                manager = (Manager)Session["Manager"];
            }
            else
            {}

            //非post过来的请求，默认指定一个标签，下拉菜单初始化（选择timout resrvation延时时间的），
            if (!IsPostBack)
            {   
                MultiViewMain.SetActiveView(ViewTable);
                for (int i = 10; i <= 60; i+=10)
                {
                    DropDownListTime.Items.Add(i.ToString());
                }
            }
            else
            { }
        }

        protected void GridViewTimeOutReservation_DataBound(object sender, EventArgs e)
        {
            GridViewTimeOutReservation.SelectRow(0);
        }

        //dish和，reservation的表格也重新绑定，刷新
        //下面还会提到
        protected void GridViewTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTableMenu(); //把对饮的按钮刷新一次

            GridViewDish.DataSource = ObjectDataSourceDish;
            GridViewDish.DataBind();

            DetailsViewReservation.DataSource = ObjectDataSourceReservation;
            DetailsViewReservation.DataBind();
        }

        //$没有预定的客人进来，manager分配一个桌子给客人
        protected void ButtonWalkInCome_Click(object sender, EventArgs e)
        {
            tableName = GridViewTable.SelectedRow.Cells[1].Text;
            Response.Redirect(ConfigurationManager.AppSettings["WalkIn"] + "?TableName=" + tableName);
            
        }

        //$客人结束用餐，跳转到bill页面，通过url querystring把tablename传过去，bill里面才知道是那张桌子，什么客人
        protected void ButtonFinish_Click(object sender, EventArgs e)
        {
            tableName = GridViewTable.SelectedRow.Cells[1].Text;
            Response.Redirect(ConfigurationManager.AppSettings["Bill"] + "?TableName=" + tableName);
        }
        
        //$预定的客人到
        //这里的GridViewTable.SelectedRow.Cells[1].Text;是取出table的name，循环查所有的桌子，根据name找到对应的那张
        //下面的同理
        protected void ButtonReservationCome_Click(object sender, EventArgs e)
        {
            tableName = GridViewTable.SelectedRow.Cells[1].Text;
            foreach (SysTable t in Restaurant.tableList)
            {
                if (t.name == tableName)
                {
                    manager.ReservationArrive(t.name);
                    break;
                }
                else
                { }
            }
            GridViewTable.DataBind();
            //RefreshTableMenu();
        }

        //$选中一张桌子，往桌子上加菜
        protected void ButtonAddDish_Click(object sender, EventArgs e)
        {
            tableName = GridViewTable.SelectedRow.Cells[1].Text; //桌子的name
            Response.Redirect(ConfigurationManager.AppSettings["AddDish"] + "?TableName=" + tableName);
        }

        //$桌子timeout，为客人延时
        protected void ButtonLong_Click(object sender, EventArgs e)
        {
            string tableName = GridViewTimeOutReservation.SelectedRow.Cells[5].Text;
            Guid id = Guid.Parse(GridViewTimeOutReservation.SelectedValue.ToString());
            DateTime dateTime = Convert.ToDateTime( GridViewTimeOutReservation.SelectedRow.Cells[4].Text);
            dateTime = dateTime.AddMinutes(int.Parse(DropDownListTime.SelectedItem.Text));
            manager.ProlongReservation(id, dateTime);

            if (dateTime > DateTime.Now)
            {
                foreach (SysTable t in Restaurant.tableList)
                {
                    if (t.name == tableName)
                    {
                        t.GetReservation().ChangeState(ReservationState.RESRVED);
                        t.ChageState(TableState.RESERVED);
                    }
                }
            }

            GridViewTimeOutReservation.DataBind();
            GridViewTable.DataBind();
        }


        //选中一个delivery，取出id，设置为delivered
        protected void ButtonDelive_Click(object sender, EventArgs e)
        {
            if (GridViewUndelivedDelivery.SelectedIndex != -1  && GridViewTimeoutDelivery.SelectedIndex == -1)
            {
                Guid id = Guid.Parse(GridViewUndelivedDelivery.SelectedDataKey.Value.ToString());
            manager.SendDelivery(id);

            GridViewUndelivedDelivery.DataBind();
            }
            else if (GridViewUndelivedDelivery.SelectedIndex == -1 && GridViewTimeoutDelivery.SelectedIndex != -1)
            {
                Guid id = Guid.Parse(GridViewTimeoutDelivery.SelectedDataKey.Value.ToString());
                manager.SendDelivery(id);

                GridViewTimeoutDelivery.DataBind();
            }
            else
            { }

        }

        //选中table的时候，右边会列出table对应的reservation信息，所以右边表格的绑定是根据选中的桌子的
        //每次选的table，变的时候，要让右边的表格知道是哪个table
        protected void ObjectDataSourceReservation_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            tableName = GridViewTable.SelectedRow.Cells[1].Text;
            foreach (SysTable t in Restaurant.tableList)
            {
                if (t.name == tableName)
                {
                    e.ObjectInstance = t;
                    break;
                }
                else
                { }
            }
        }

        //同上，这个是dish信息的表格
        protected void ObjectDataSourceDish_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            tableName = GridViewTable.SelectedRow.Cells[1].Text;
            foreach (SysTable t in Restaurant.tableList)
            {
                if (t.name == tableName)
                {
                    e.ObjectInstance = t.GetReservation();
                    break;
                }
                else
                { }
            }
        }

        //每次都默认选中第一个桌子，防止没选中桌子就进行各种操作
        //比如adddish，没选中桌子的话，会出错的
        //SelectRow 都同理
        protected void GridViewTable_DataBound(object sender, EventArgs e)
        {
            if (GridViewTable.SelectedIndex == -1)
            {
                GridViewTable.SelectRow(0);
            }
            else
            { }
            RefreshTableMenu();
        }

        protected void GridViewUndelivedDelivery_DataBound(object sender, EventArgs e)
        {
            GridViewUndelivedDelivery.SelectRow(0);
        }

        //MultiView理解成两个标签切换吧，一个是桌子的信息，另一个是timout的reservation等的信息，在一个页面摆不下，切换了一下标签
        protected void ButtonTable_Click(object sender, EventArgs e)
        {
            MultiViewMain.SetActiveView(ViewTable);
            DetailsViewReservation.DataBind();
            GridViewDish.DataBind();
        }
        //一样，这个是切换到过期Reservation的那个标签
        protected void ButtonReservation_Click(object sender, EventArgs e)
        {
            MultiViewMain.SetActiveView(ViewReservation);

        }

        //这两个是因为两个表格中的只能选中一个，所以要把另一个写成-1
        protected void GridViewTimeoutDelivery_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewUndelivedDelivery.SelectedIndex = -1;
        }

        protected void GridViewUndelivedDelivery_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewTimeoutDelivery.SelectedIndex = -1;
        }

        //timeout的reservation，manager可以给取消
        protected void ButtonCancelReservation_Click(object sender, EventArgs e)
        {
            manager.CancelReservation(Guid.Parse(GridViewTimeOutReservation.SelectedValue.ToString()));
            
            string tableName = GridViewTimeOutReservation.SelectedRow.Cells[5].Text;
            foreach (SysTable t in Restaurant.tableList)
            {
                if (t.name == tableName)
                {
                    t.ChageState(TableState.AVAILABLE);
                }
                else
                { }
            }
            GridViewTimeOutReservation.DataBind();
        }

        //protected void ButtonCancel_Click(object sender, EventArgs e)
        //{
        //    tableName  = GridViewTable.SelectedValue.ToString();
        //    foreach (SysTable t in Restaurant.tableList)
        //    {
        //        if (t.name == tableName)
        //        {
        //            manager.CancelReservation(t.GetReservation().id);
        //            t.ChageState(TableState.AVAILABLE);
        //        }
        //        else
        //        { }
        //    }
        //}

        //根据选中的桌子状态，给出不同的按钮
        //比如busy应该显示add dish finish的按钮
        //reserverd应该显示，客人来了的按钮
        //也是通过切换MultiView标签实现的
        void RefreshTableMenu()
        {
            string tableStateStr = GridViewTable.SelectedRow.Cells[3].Text;
            switch (tableStateStr)
            {
                case ("AVAILABLE"):
                    MultiView1.ActiveViewIndex = 0;
                    break;

                case ("RESERVED"):
                    MultiView1.ActiveViewIndex = 1;
                    break;

                case ("BUSY"):
                    MultiView1.ActiveViewIndex = 2;
                    break;

                case ("TIMEOUT"):
                    MultiView1.ActiveViewIndex = 3;
                    break;
            }
        }


    }
}