<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainCustomer.Master" AutoEventWireup="true" CodeBehind="HistoryDelivery.aspx.cs" Inherits="RestaurantWebReservation.Presentation.CustomerPage.HistoryDelivery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Text="History Delivery"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" 
        GridLines="None" DataKeyNames="id">
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
        SelectMethod="GetHistoryDelivery" 
        TypeName="RestaurantWebReservation.Application.Role.Customer" 
        onobjectcreating="ObjectDataSource1_ObjectCreating">
    </asp:ObjectDataSource>
</div>

<div>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Coming Delivery"></asp:Label>
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataSourceID="ObjectDataSource2" ForeColor="#333333" 
        GridLines="None" DataKeyNames="id">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" 
                Visible="False" />
            <asp:BoundField DataField="userFrom" HeaderText="userFrom" 
                SortExpression="userFrom" Visible="False" />
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
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="GetUndelivedDelivery" 
        TypeName="RestaurantWebReservation.Application.Role.Customer" 
        onobjectcreating="ObjectDataSource2_ObjectCreating">
    </asp:ObjectDataSource>
</div>


<div id="divDish" style="position: absolute; top: 180px; right: 160px">
<div>
    <asp:GridView ID="GridView2" runat="server" CellPadding="4" 
        DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
        AutoGenerateColumns="False" DataKeyNames="id">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" 
                SortExpression="id" Visible="False" />
            <asp:BoundField DataField="delivery_id" HeaderText="delivery_id" 
                SortExpression="delivery_id" Visible="False" />
            <asp:BoundField DataField="dish_name" HeaderText="Dish" 
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:RestaurantWebReservationConnectionString %>" 
        SelectCommand="get_dishquota_by_delivery" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="id" 
                PropertyName="SelectedValue" DbType="Guid" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
</div>
<div >
    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource2" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" 
                SortExpression="id" Visible="False" />
            <asp:BoundField DataField="delivery_id" HeaderText="delivery_id" 
                SortExpression="delivery_id" Visible="False" />
            <asp:BoundField DataField="dish_name" HeaderText="Dish" 
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
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:RestaurantWebReservationConnectionString %>" 
        SelectCommand="get_dishquota_by_delivery" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView2" DbType="Guid" Name="id" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
</div>
</div>

</asp:Content>
