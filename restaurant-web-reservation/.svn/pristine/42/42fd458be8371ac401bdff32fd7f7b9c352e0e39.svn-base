<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainManager.Master" AutoEventWireup="true" CodeBehind="AnalyzeHistoryDelivery.aspx.cs" Inherits="RestaurantWebReservation.Presentation.ManagerPage.AnalyzeHistoryDelivery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
    <asp:TextBox ID="TextBoxKey" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonSearch" runat="server" Text="Search" 
        onclick="ButtonSearch_Click" />
    <br />
    <br />
    <asp:Label ID="LabelDelivery" runat="server" Text="History of User"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Delivery history"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" 
        GridLines="None" DataKeyNames="id" AllowPaging="True" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" 
                Visible="False" />
            <asp:BoundField DataField="userFrom" HeaderText="userFrom" 
                SortExpression="userFrom" />
            <asp:BoundField DataField="customerName" HeaderText="customerName" 
                SortExpression="customerName" />
            <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
            <asp:BoundField DataField="address" HeaderText="address" 
                SortExpression="address" />
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
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetHistoryDeliveryByUser" 
        TypeName="RestaurantWebReservation.Application.Role.Manager" 
        >
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxKey" Name="pUserFrom" 
                PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSourceInit" runat="server" 
        SelectMethod="GetAllHistoryDelivery" 
        TypeName="RestaurantWebReservation.Application.Role.Manager">
    </asp:ObjectDataSource>
</div>

<div id="divDishDelivery" style="position: absolute; top: 250px; right: 160px">
    <asp:GridView ID="GridView3" runat="server" CellPadding="4" 
        DataSourceID="SqlDataSource3" ForeColor="#333333" GridLines="None" 
        AutoGenerateColumns="False" DataKeyNames="id">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" 
                SortExpression="id" Visible="False" />
            <asp:BoundField DataField="delivery_id" HeaderText="delivery_id" 
                SortExpression="delivery_id" Visible="False" />
            <asp:BoundField DataField="dish_name" HeaderText="dish_name" 
                SortExpression="dish_name" />
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
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:RestaurantWebReservationConnectionString %>" 
        SelectCommand="get_dishquota_by_delivery" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="id" 
                PropertyName="SelectedValue" DbType="Guid" />
        </SelectParameters>
    </asp:SqlDataSource>
</div>

<div "divReservation">
    <asp:Label ID="Label2" runat="server" Text="History Reservation"></asp:Label>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="id" onselectedindexchanged="GridView2_SelectedIndexChanged" 
        AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" 
        PageSize="5">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" 
                Visible="False" />
            <asp:BoundField DataField="userFrom" HeaderText="userFrom" 
                SortExpression="userFrom" />
            <asp:BoundField DataField="customerName" HeaderText="customerName" 
                SortExpression="customerName" />
            <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
            <asp:BoundField DataField="arriveTime" HeaderText="arriveTime" 
                SortExpression="arriveTime" />
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
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="GetHistoryReservationByUser" 
        TypeName="RestaurantWebReservation.Application.Role.Manager">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxKey" Name="pUserFrom" 
                PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSourceInit2" runat="server" 
        SelectMethod="GetAllHistoryReservation" 
        TypeName="RestaurantWebReservation.Application.Role.Manager">
    </asp:ObjectDataSource>
</div>
<div id = "divDishReservation" style="right: 160px; position: absolute; top: 500px">
    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="id" DataSourceID="SqlDataSource4" CellPadding="4" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" 
                SortExpression="id" Visible="False" />
            <asp:BoundField DataField="reservation_id" HeaderText="reservation_id" 
                SortExpression="reservation_id" Visible="False" />
            <asp:BoundField DataField="dish_name" HeaderText="dish_name" 
                SortExpression="dish_name" />
            <asp:BoundField DataField="quato" HeaderText="quato" SortExpression="quato" />
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
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
        ConnectionString="<%$ ConnectionStrings:RestaurantWebReservationConnectionString %>" 
        SelectCommand="get_dishquota_by_reservation" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView2" DbType="Guid" Name="id" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
</div>
</asp:Content>
