<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainManager.Master" AutoEventWireup="true" CodeBehind="AnalyzeDaily.aspx.cs" Inherits="RestaurantWebReservation.Presentation.ManagerPage.AnalyzeDaily" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div>
    <asp:Label ID="Label1" runat="server" 
        Text="Business Income according to dishes"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="ObjectDataSource1" CellPadding="4" ForeColor="#333333" 
        GridLines="None" ondatabound="GridView1_DataBound" ShowFooter="True">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="name" HeaderText="Dish" SortExpression="name" />
            <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
            <asp:BoundField DataField="reservationQuota" HeaderText="reservationQuota" 
                SortExpression="reservationQuota" />
            <asp:BoundField DataField="deliveryQuota" HeaderText="deliveryQuota" 
                SortExpression="deliveryQuota" />
            <asp:BoundField DataField="totalPrice" HeaderText="totalPrice" 
                SortExpression="totalPrice" />
            <asp:BoundField DataField="popularity" HeaderText="popularity" 
                SortExpression="popularity" />
            <asp:TemplateField></asp:TemplateField>
            <asp:BoundField DataField="description" HeaderText="description" 
                SortExpression="description" Visible="False" />
            <asp:BoundField DataField="pictPath" HeaderText="pictPath" 
                SortExpression="pictPath" Visible="False" />
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
        SelectMethod="GetDailyReport" 
        TypeName="RestaurantWebReservation.Application.Role.Manager">
    </asp:ObjectDataSource>
</div>
</asp:Content>
