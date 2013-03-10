<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainCustomer.Master" AutoEventWireup="true" CodeBehind="CustomerMain.aspx.cs" Inherits="RestaurantWebReservation.Presentation.CustomerPage.CustomerMain" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div id = "divDish" runat = "server" 
        style="position: absolute; top: 180px; left: 160px" >
        <asp:TextBox ID="TextBoxKeyword" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonSearch" runat="server" Text="Search" 
            onclick="ButtonSearch_Click" />
       <asp:Button ID="ButtonHotDish" runat="server" Text="Hot Dish" 
            onclick="ButtonHotDish_Click" />
        <asp:GridView ID="GridViewDish" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="name" 
            ForeColor="#333333" GridLines="None"  
            Height="130px" onselectedindexchanged="GridViewDish_SelectedIndexChanged" 
            AllowPaging="True" PageSize="3">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:ImageField DataImageUrlField="pict_path">
                </asp:ImageField>
                <asp:BoundField DataField="name" HeaderText="Dish" ReadOnly="True" 
                    SortExpression="name" />
                <asp:BoundField DataField="description" HeaderText="description" 
                    SortExpression="description" Visible="False" />
                <asp:BoundField DataField="price" HeaderText="Price" SortExpression="price" />
                <asp:BoundField DataField="pict_path" HeaderText="pict_path" 
                    SortExpression="pict_path" Visible="False" />
                <asp:BoundField DataField="popularity" HeaderText="Popularity" 
                    SortExpression="popularity" />
                <asp:ButtonField ButtonType="Image" ImageUrl="~/Image/Sys/hot.png" />
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
        <asp:SqlDataSource ID="SqlDataSourceHotDish" runat="server" 
            ConnectionString="<%$ ConnectionStrings:RestaurantWebReservationConnectionString %>" 
            SelectCommand="get_hot_dish" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceTagDish" runat="server" 
            ConnectionString="<%$ ConnectionStrings:RestaurantWebReservationConnectionString %>" 
            SelectCommand="get_dish_by_tag" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridViewTag" Name="tag_name" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceKeyword" runat="server" 
            ConnectionString="<%$ ConnectionStrings:RestaurantWebReservationConnectionString %>" 
            SelectCommand="search_dish_by_keyword" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxKeyword" Name="keyword" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
   
    <div id = "divTag" runat = "server" 
        style="position: absolute; top: 180px; right: 160px" >
        <asp:Label ID="Label2" runat="server" Text="Hot Tags"></asp:Label>
        
        <asp:GridView ID="GridViewTag" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="ObjectDataSourceTag" 
            ForeColor="#333333" GridLines="None" DataKeyNames="name"
            onselectedindexchanged="GridViewTag_SelectedIndexChanged" 
            AllowPaging="True" PageSize="5" Width="280px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Tag" SortExpression="name" />
                <asp:BoundField DataField="popularity" HeaderText="Popularity" 
                    SortExpression="popularity" />
                <asp:ButtonField ButtonType="Image" ImageUrl="~/Image/Sys/pop.png" />
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
        
        <asp:ObjectDataSource ID="ObjectDataSourceTag" runat="server" 
            SelectMethod="GetHotTag" 
            TypeName="RestaurantWebReservation.Application.Role.Customer">
        </asp:ObjectDataSource>
        </div>

        <div id = "divNews" runat = "server" 
        style="position: absolute; top: 420px; right: 160px">
            <asp:Label ID="Label3" runat="server" Text="Restaurant News "></asp:Label>

        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSourceNews" CellPadding="4" ForeColor="#333333" 
                GridLines="None" AllowPaging="True" PageSize="1" Width="280px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" 
                    Visible="False" />
                <asp:BoundField DataField="title" HeaderText="News" SortExpression="title" >
                <ControlStyle Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="content" 
                    SortExpression="content" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="publishTime" HeaderText="Publish Time" 
                    SortExpression="publishTime" >
                <ControlStyle Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="aboutDish" HeaderText="aboutDish" 
                    SortExpression="aboutDish" Visible="False" />
                <asp:BoundField DataField="pictPath" HeaderText="pictPath" 
                    SortExpression="pictPath" Visible="False" />
                <asp:ImageField>
                </asp:ImageField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" Height="110px" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSourceNews" runat="server" 
            SelectMethod="GetNews" 
            TypeName="RestaurantWebReservation.Application.Role.Customer" 
            onselecting="ObjectDataSourceTag_Selecting">
        </asp:ObjectDataSource>
    </div>
</asp:Content>
