<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainManager.Master" AutoEventWireup="true" CodeBehind="ManagerMain.aspx.cs" Inherits="RestaurantWebReservation.Presentation.ManagerPage.ManagerMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Button ID="ButtonTable" runat="server" Text="Restaurant" 
            onclick="ButtonTable_Click" />
        <asp:Button ID="ButtonReservation" runat="server" Text="Reservation and Delivery" 
        onclick="ButtonReservation_Click"/>

        <asp:MultiView ID="MultiViewMain" runat="server">
            <asp:View ID="ViewTable" runat="server">

            <div id = "divTable" runat = "server">
    <asp:GridView ID="GridViewTable" runat="server" 
        DataSourceID="ObjectDataSource4" AutoGenerateColumns="False" CellPadding="4" 
        ForeColor="#333333" GridLines="None" 
        onselectedindexchanged="GridViewTable_SelectedIndexChanged" 
        ondatabound="GridViewTable_DataBound" DataKeyNames="name">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="name" HeaderText="Table Name" 
                SortExpression="name" />
            <asp:BoundField DataField="seat" HeaderText="Seat" SortExpression="seat" />
            
            <asp:BoundField DataField="hide" />
            
            <asp:ImageField DataImageUrlField="hide" 
                DataImageUrlFormatString="~/Image/TableState/{0}.png" 
                HeaderText="Currrent State">
            </asp:ImageField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" 
        SelectMethod="GetTable" 
        TypeName="RestaurantWebReservation.Application.BasicDataStractrue.Restaurant"  >
    
    </asp:ObjectDataSource>
</div>

    <div id ="reservation" style="position: absolute; top: 180px; right: 380px">
    <asp:Label ID="Label2" runat="server" Text="Detail"></asp:Label>
    
    <asp:DetailsView ID="DetailsViewReservation" runat="server" 
        AutoGenerateRows="False" CellPadding="4" ForeColor="#333333" GridLines="None" 
        Height="50px" Width="125px">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
        <EditRowStyle BackColor="#2461BF" />
        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="customerName" HeaderText="customerName" 
                SortExpression="customerName" />
            <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
            <asp:BoundField DataField="arriveTime" HeaderText="arriveTime" 
                SortExpression="arriveTime" />
            <asp:BoundField DataField="tableName" HeaderText="tableName" 
                SortExpression="tableName" />
            <asp:BoundField DataField="seat" HeaderText="seat" SortExpression="seat" />
        </Fields>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
    </asp:DetailsView>

    <asp:ObjectDataSource ID="ObjectDataSourceReservation" runat="server" 
        onobjectcreating="ObjectDataSourceReservation_ObjectCreating" 
        SelectMethod="GetReservation" 
        TypeName="RestaurantWebReservation.Application.BasicDataStractrue.SysTable">
    </asp:ObjectDataSource>
    </div>

    <div id = "divDish" style="position: absolute; top: 180px; right: 160px">
    <asp:Label ID="Label3" runat="server" Text="Dishes for this customer"></asp:Label>
    <asp:GridView ID="GridViewDish" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" 
                Visible="False" />
            <asp:BoundField DataField="dishName" HeaderText="dishName" 
                SortExpression="dishName" />
            <asp:BoundField DataField="priceSingle" HeaderText="priceSingle" 
                SortExpression="priceSingle" Visible="False" />
            <asp:BoundField DataField="quota" HeaderText="quota" SortExpression="quota" />
            <asp:BoundField DataField="note" HeaderText="note" SortExpression="note" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSourceDish" runat="server" 
        onobjectcreating="ObjectDataSourceDish_ObjectCreating" 
        SelectMethod="GetDishQuota" 
        TypeName="RestaurantWebReservation.Application.BasicDataStractrue.Reservation">
    </asp:ObjectDataSource>
    <br />
</div>

<div id = "menu">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="ViewAvailable" runat="server">
            <div id = "divMenuAvailable" visible = "false">
                <asp:Button ID="ButtonWalkInCome" runat="server" Text="Customer Come" 
        onclick="ButtonWalkInCome_Click" />
            </div>
        </asp:View>
        <asp:View ID="ViewReserved" runat="server">
            <div id = "divMenuReserved" visible = "false">
                <asp:Button ID="ButtonReservationCome" runat="server" Text="Customer Come" 
        onclick="ButtonReservationCome_Click" />
            </div>
        </asp:View>
        <asp:View ID="ViewBusy" runat="server">
            <div id = "divMenuBusy" visible = "false">
                <asp:Button ID="ButtonAddDish" runat="server" Text="Add Dish" 
        onclick="ButtonAddDish_Click" />
                <asp:Button ID="ButtonFinish" runat="server" Text="Finish" 
        onclick="ButtonFinish_Click" Height="21px" />
            </div>
        </asp:View>
        <asp:View ID="ViewTimeOut" runat="server">
            <div id = "divMenuTimeOut" visible = "false">
                <asp:Button ID="ButtonProlong" runat="server" Text="Prolong Reservation" />
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel Reservation" />
            </div>
        </asp:View>
    </asp:MultiView>
    </div>
            </asp:View>



            <asp:View ID="ViewReservation" runat="server">
                <div id = "divTimeOutReservation">
        <asp:Label ID="LabelTimeOutReservation" runat="server" 
            Text="Time Out Reservation" ForeColor="Red"></asp:Label>
    <asp:GridView ID="GridViewTimeOutReservation" runat="server" 
        DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" CellPadding="4" 
            ForeColor="#333333" GridLines="None" DataKeyNames="id" 
            ondatabound="GridViewTimeOutReservation_DataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" 
                SortExpression="id" Visible="False" />
            <asp:BoundField DataField="userFrom" HeaderText="userFrom" 
                SortExpression="userFrom" Visible="False" />
            <asp:BoundField DataField="customerName" HeaderText="customerName" 
                SortExpression="customerName" />
            <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
            <asp:BoundField DataField="arriveTime" DataFormatString="{0:yyyy-MM-dd HH:mm}" 
                HeaderText="arriveTime" SortExpression="arriveTime" >
            <ControlStyle ForeColor="#FF6600" />
            </asp:BoundField>
            <asp:BoundField DataField="tableName" HeaderText="tableName" 
                SortExpression="tableName" />
            <asp:BoundField DataField="seat" HeaderText="seat" SortExpression="seat" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            DataObjectTypeName="System.Guid" DeleteMethod="CancelReservation" 
            SelectMethod="GetTimeOutReservation" 
            TypeName="RestaurantWebReservation.Application.Role.Manager">
        </asp:ObjectDataSource>
                                <asp:DropDownList ID="DropDownListTime" runat="server" 
                            AutoPostBack="True">
                                </asp:DropDownList>
                        &nbsp;<asp:Label ID="Label1" runat="server" Text="Minutes"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="ButtonLong" runat="server" Text="Prolong" 
            onclick="ButtonLong_Click" />
                    &nbsp;<asp:Button ID="ButtonCancelReservation" runat="server" 
                        onclick="ButtonCancelReservation_Click" Text="Cancel Reservation" />
                    <br />
</div>

<div id ="delivery" style="position: absolute; top: 190px; right: 150px">
<div id = "divTimeOutDelivery" >
    <asp:Label ID="LabelTimeoutDelievry" runat="server" Text="Time out Delivery" 
        ForeColor="Red"></asp:Label>
    <asp:GridView ID="GridViewTimeoutDelivery" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataSourceID="ObjectDataSource2" 
        ForeColor="#333333" GridLines="None" 
        onselectedindexchanged="GridViewTimeoutDelivery_SelectedIndexChanged" 
        DataKeyNames="id">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="customerName" HeaderText="customerName" 
                SortExpression="customerName" />
            <asp:BoundField DataField="phone" HeaderText="phone" 
                SortExpression="phone" />
            <asp:BoundField DataField="address" 
                HeaderText="address" SortExpression="address" />
            <asp:BoundField DataField="commitTime" DataFormatString="{0:yyyy-MM-dd hh:mm}" 
                HeaderText="commitTime" SortExpression="commitTime" />
            <asp:BoundField DataField="deliveryTime" DataFormatString="{0:yyyy-MM-dd hh:mm}" 
                HeaderText="deliveryTime" SortExpression="deliveryTime" >
            <ControlStyle Font-Overline="True" BackColor="Red" />
            </asp:BoundField>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        DataObjectTypeName="System.Guid" SelectMethod="GetTimeOutDelivery" 
        TypeName="RestaurantWebReservation.Application.Role.Manager" 
        UpdateMethod="SendDelivery"></asp:ObjectDataSource>
</div>

<div id = "divAvailableDelivery">
    <asp:Label ID="LabelUndelivedDelievry" runat="server" Text="Undelived Delievry"></asp:Label>
    <asp:GridView ID="GridViewUndelivedDelivery" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataSourceID="ObjectDataSource3" 
        ForeColor="#333333" GridLines="None" 
        ondatabound="GridViewUndelivedDelivery_DataBound" 
        onselectedindexchanged="GridViewUndelivedDelivery_SelectedIndexChanged" 
        DataKeyNames="id">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" 
                SortExpression="id" Visible="False" />
            <asp:BoundField DataField="userFrom" 
                HeaderText="userFrom" SortExpression="userFrom" Visible="False" />
            <asp:BoundField DataField="customerName" 
                HeaderText="customerName" SortExpression="customerName" />
            <asp:BoundField DataField="phone" 
                HeaderText="phone" SortExpression="phone" />
            <asp:BoundField DataField="address" 
                HeaderText="address" SortExpression="address" />
            <asp:BoundField DataField="commitTime" HeaderText="commitTime" 
                SortExpression="commitTime" />
            <asp:BoundField DataField="deliveryTime" HeaderText="deliveryTime" 
                SortExpression="deliveryTime" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
        SelectMethod="GetUnDelivedDelivery" 
        TypeName="RestaurantWebReservation.Application.Role.Manager">
    </asp:ObjectDataSource>
    <asp:Button ID="ButtonDelive" runat="server" Text="Delivy" 
        onclick="ButtonDelive_Click" />
</div>
</div>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
