<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainManager.Master" AutoEventWireup="true" CodeBehind="ManageReservation.aspx.cs" Inherits="RestaurantWebReservation.Presentation.ManagerPage.ManageReservation" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:TextBox ID="TextBoxKey" runat="server"></asp:TextBox>
    <cc1:AutoCompleteExtender ID="TextBoxKey_AutoCompleteExtender" runat="server" 
        TargetControlID="TextBoxKey" ServiceMethod="SearchUnfinishedReservationAutoComplete" 
                            ServicePath="~/Application/Service/AutoCompleteWebService.asmx">
    </cc1:AutoCompleteExtender>
    <asp:Button ID="ButtonSearch" runat="server" Text="Search" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" 
        GridLines="None" DataKeyNames="id">
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
            <asp:CommandField ShowEditButton="True" />
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
        SelectMethod="SearchReservationMatch" 
        TypeName="RestaurantWebReservation.Application.Role.Manager">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxKey" Name="keyword" PropertyName="Text" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>

<div id = "divDishReservation" style="right: 160px; position: absolute; top: 180px">
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
            <asp:CommandField ShowEditButton="True" />
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
            <asp:ControlParameter ControlID="GridView1" DbType="Guid" Name="id" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
</div>

</asp:Content>
