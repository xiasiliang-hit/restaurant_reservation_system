<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainCustomer.Master" AutoEventWireup="true" CodeBehind="HistoryReservation.aspx.cs" Inherits="RestaurantWebReservation.Presentation.CustomerPage.HistoryReservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="History Reservation"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="ObjectDataSource1" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AllowPaging="True" DataKeyNames="id" PageSize="5">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" 
                SortExpression="id" Visible="False" />
            <asp:BoundField DataField="userFrom" HeaderText="userFrom" 
                SortExpression="userFrom" Visible="False" />
            <asp:BoundField DataField="customerName" HeaderText="customerName" 
                SortExpression="customerName" />
            <asp:BoundField DataField="phone" HeaderText="phone" 
                SortExpression="phone" />
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
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetHistoryReservation" 
        TypeName="RestaurantWebReservation.Application.Role.Customer" 
        onobjectcreating="ObjectDataSource1_ObjectCreating">
    </asp:ObjectDataSource>
    <div>
    <div>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Comming Reservation"></asp:Label>
    <asp:GridView ID="GridView2" runat="server" CellPadding="4" 
            DataSourceID="ObjectDataSource2" ForeColor="#333333" GridLines="None" 
            AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" 
                SortExpression="id" Visible="False" />
            <asp:BoundField DataField="userFrom" HeaderText="userFrom" 
                SortExpression="userFrom" Visible="False" />
            <asp:BoundField DataField="customerName" HeaderText="customerName" 
                SortExpression="customerName" />
            <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
            <asp:BoundField DataField="arriveTime" HeaderText="arriveTime" 
                SortExpression="arriveTime" />
            <asp:BoundField DataField="tableName" HeaderText="tableName" 
                SortExpression="tableName" />
            <asp:BoundField DataField="seat" HeaderText="seat" SortExpression="seat" />
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
            onobjectcreating="ObjectDataSource2_ObjectCreating" 
            SelectMethod="GetCurrentReservation" 
            TypeName="RestaurantWebReservation.Application.Role.Customer">
        </asp:ObjectDataSource>
</div>
<div id = "divDish" style="position: absolute; top: 180px; right: 160px">
    <asp:GridView ID="GridViewDish" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" 
                SortExpression="id" Visible="False" />
            <asp:BoundField DataField="reservation_id" HeaderText="reservation_id" 
                SortExpression="reservation_id" Visible="False" />
            <asp:BoundField DataField="dish_name" HeaderText="Dish" 
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:RestaurantWebReservationConnectionString %>" 
        SelectCommand="get_dishquota_by_reservation" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" DbType="Guid" Name="id" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
</div>
</asp:Content>
