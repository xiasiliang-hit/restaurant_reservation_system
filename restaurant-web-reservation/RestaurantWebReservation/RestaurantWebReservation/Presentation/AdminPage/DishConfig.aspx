﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainAdmin.Master" AutoEventWireup="true" CodeBehind="DishConfig.aspx.cs" Inherits="RestaurantWebReservation.Presentation.AdminPage.DishConfig" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateDeleteButton="True" 
            AutoGenerateEditButton="True" AutoGenerateSelectButton="True" 
            onrowediting="GridView1_RowEditing" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="name" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="name" HeaderText="name" ReadOnly="True" 
                    SortExpression="name" />
                <asp:BoundField DataField="description" HeaderText="description" 
                    SortExpression="description" />
                <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                <asp:BoundField DataField="popularity" HeaderText="popularity" 
                    SortExpression="popularity" />
                <asp:ImageField DataImageUrlField="pict_path">
                </asp:ImageField>
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:RestaurantWebReservationConnectionString %>" 
            DeleteCommand="delete_dish" DeleteCommandType="StoredProcedure" 
            SelectCommand="select_all_dish" SelectCommandType="StoredProcedure" 
            UpdateCommand="update_dish" UpdateCommandType="StoredProcedure">
            <DeleteParameters>
                <asp:Parameter Name="name" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="price" Type="Double" />
                <asp:Parameter Name="pict_path" Type="String" />
                <asp:Parameter Name="popularity" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="name" DataSourceID="SqlDataSource2" 
            ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="name" HeaderText="name" ReadOnly="True" 
                    SortExpression="name" />
                <asp:BoundField DataField="popularity" HeaderText="popularity" 
                    SortExpression="popularity" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:RestaurantWebReservationConnectionString %>" 
            SelectCommand="get_tag_by_dish" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="dish_name" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Button ID="ButtonAdd" runat="server" onclick="ButtonAdd_Click" 
            Text="Add new dish" />
        <br />
    </div>

    <div style="clip: rect(auto, 10px, auto, auto)">
    
    </div>    
</asp:content>