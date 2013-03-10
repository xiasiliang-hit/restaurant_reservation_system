<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainCustomer.Master" AutoEventWireup="true" CodeBehind="DishDetail.aspx.cs" Inherits="RestaurantWebReservation.Presentation.CustomerPage.DishDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #Select1
        {
            width: 90px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id = "divImage">
    <asp:Image ID="ImageDish" runat="server" Height="150px" Width="200px" /> 
</div>
<div style="position: absolute; top: 180px; left: 600px">
            <table align="center" bgcolor="#DEE8F5" 
                style="font-family: Verdana; font-size: 150%; background-color: #DEE8F5; color: #333333;">
                <tr>
                    <td align="center" colspan="2" 
                        style="color: White; background-color: #6B696B; font-weight: bold;">
                        TAGS</td>
                </tr>
                <tr>
                    <td align="right">
        
            <asp:Label ID="LabelTag1" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td align="left">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
            <asp:Label ID="LabelTag2" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td align="left">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
            <asp:Label ID="LabelTag3" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                </tr>
            </table>
            </div>

<div id = "divInfo" style="position: absolute; top: 180px; left: 370px;">
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        CellPadding="4" DataSourceID="ObjectDataSourceDish" ForeColor="#333333" 
        GridLines="None" Height="50px" Width="125px">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
        <EditRowStyle BackColor="#2461BF" />
        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
        <Fields>
            <asp:ImageField DataImageUrlField="pictPath" Visible="False">
            </asp:ImageField>
            <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
            <asp:BoundField DataField="description" HeaderText="Description" 
                SortExpression="description" />
            <asp:BoundField DataField="price" DataFormatString="{0:c}" HeaderText="Price" 
                SortExpression="price" />
            <asp:BoundField DataField="pictPath" HeaderText="pictPath" 
                SortExpression="pictPath" Visible="False" />
            <asp:BoundField DataField="popularity" HeaderText="Popularity" 
                SortExpression="popularity" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text="BUY "></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ImageButton ID="ImageButtonBuy" runat="server" 
                        ImageUrl="~/Image/Sys/add_to_cart.gif" onclick="ImageButtonBuy_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Fields>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
    </asp:DetailsView>
    <asp:ObjectDataSource ID="ObjectDataSourceDish" runat="server" 
        onobjectcreating="ObjectDataSourceDish_ObjectCreating" 
        SelectMethod="GetDishByName" 
        TypeName="RestaurantWebReservation.Application.Role.Customer">
        <SelectParameters>
            <asp:QueryStringParameter Name="pDishName" QueryStringField="DishName" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>
<div id = "divComment" style="position: absolute; right: 160px; top: 180px">
    <asp:GridView ID="GridViewComment" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataSourceID="ObjectDataSource2" ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" 
                Visible="False" />
            <asp:BoundField DataField="content" HeaderText="Others' comments" 
                SortExpression="content" />
            <asp:BoundField DataField="aboutDish" HeaderText="aboutDish" 
                SortExpression="aboutDish" Visible="False" />
            <asp:BoundField DataField="userFrom" HeaderText="From" 
                SortExpression="userFrom" />
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
        onobjectcreating="ObjectDataSource2_ObjectCreating" SelectMethod="GetComment" 
        TypeName="RestaurantWebReservation.Application.BasicDataStractrue.Dish">
    </asp:ObjectDataSource>
    <asp:Button ID="ButtonAddComment" runat="server" Text="Add comment" 
        Height="21px" onclick="ButtonAddComment_Click" />
    <br />
    <div id ="addComment"> 
        <asp:TextBox ID="TextBoxComment" runat="server" Height="41px" 
            TextMode="MultiLine" Width="159px" Visible="False"></asp:TextBox>
    </div>
</div>
</asp:Content>
