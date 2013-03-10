<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainManager.Master" AutoEventWireup="true" CodeBehind="PublishNews.aspx.cs" Inherits="RestaurantWebReservation.Presentation.ManagerPage.PublishNews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 411px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <table style="font-family: Verdana; font-size: 150%; background-color: #4b6c9e; color: #cfdbe6; width: 634px;" 
        align="left" bgcolor="#CCFFCC">
                <tr>
                    <td align="center" colspan="2" style="color: White; background-color: #6B696B; font-weight: bold;">
                        Information of a Delivery</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="UserNameLabel" runat="server">News Title</asp:Label>
                    </td>
                    <td align="left" class="style1">
                        <asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="UserNameLabel0" runat="server">Content</asp:Label>
                    </td>
                    <td align="left" class="style1">
                        <asp:TextBox ID="TextBoxContent" runat="server" TextMode="MultiLine" 
                            Height="88px" Width="410px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="EmailLabel0" runat="server" Visible="False">About Dish</asp:Label>
                    </td>
                    <td align="left" class="style1">
                        <asp:DropDownList ID="DropDownListDish" runat="server" 
                            DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="name">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:RestaurantWebReservationConnectionString %>" 
                            SelectCommand="select_all_dish" SelectCommandType="StoredProcedure">
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;</td>
                    <td align="left" class="style1">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;</td>
                    <td align="left" class="style1">
                        <asp:Button ID="ButtonPuslish" runat="server" onclick="ButtonPuslish_Click" 
                            Text="Publish" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="color: Red;">
                        &nbsp;</td>
                </tr>
            </table>
            </div>

</asp:Content>
