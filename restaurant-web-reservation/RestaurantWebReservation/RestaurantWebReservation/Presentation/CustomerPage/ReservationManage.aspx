<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainCustomer.Master" AutoEventWireup="true" CodeBehind="ReservationManage.aspx.cs" Inherits="RestaurantWebReservation.Presentation.CustomerPage.ReservationManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
    </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetHistoryReservation" 
        TypeName="RestaurantWebReservation.Application.Role.Customer">
        </asp:ObjectDataSource>
    </div>
</asp:Content>
