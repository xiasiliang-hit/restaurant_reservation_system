<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainManager.Master" AutoEventWireup="true" CodeBehind="ManageTable.aspx.cs" Inherits="RestaurantWebReservation.Presentation.ManagerPage.ManageTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" 
        GridLines="None" onselectedindexchanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Key" HeaderText="Key" ReadOnly="True" 
                SortExpression="Key" />
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
        SelectMethod="GetAllTableStateByTime" 
        TypeName="RestaurantWebReservation.Application.Role.Manager">
        <SelectParameters>
            <asp:Parameter DefaultValue="DateTime.Now" Name="pDateTime" Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
