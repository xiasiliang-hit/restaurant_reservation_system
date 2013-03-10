<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainManager.Master" AutoEventWireup="true" CodeBehind="Bill.aspx.cs" Inherits="RestaurantWebReservation.Presentation.ManagerPage.Bill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
<asp:Label ID="Label2" runat="server"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" 
            GridLines="None" ondatabound="GridView1_DataBound" 
            onrowdatabound="GridView1_RowDataBound" ShowFooter="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="dishName" HeaderText="dishName" 
                    SortExpression="dishName" />
                <asp:BoundField DataField="priceSingle" HeaderText="priceSingle" 
                    SortExpression="priceSingle" />
                <asp:BoundField DataField="quota" HeaderText="quota" SortExpression="quota" />
                <asp:BoundField DataField="note" HeaderText="Total" SortExpression="note" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <br />
                    </ItemTemplate>
                    <FooterTemplate>
                        <br />
                    </FooterTemplate>
                </asp:TemplateField>
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
            onobjectcreating="ObjectDataSource1_ObjectCreating" SelectMethod="GetDishQuota" 
            TypeName="RestaurantWebReservation.Application.BasicDataStractrue.Reservation">
        </asp:ObjectDataSource>
        <asp:Button ID="ButtonSubmit" runat="server" Text="Back To Restaurant" 
            onclick="ButtonSubmit_Click" />
    </div>
</asp:Content>
