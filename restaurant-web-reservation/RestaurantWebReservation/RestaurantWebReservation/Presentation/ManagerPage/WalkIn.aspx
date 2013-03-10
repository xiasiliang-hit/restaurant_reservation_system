<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainCustomer.Master" AutoEventWireup="true" CodeBehind="WalkIn.aspx.cs" Inherits="RestaurantWebReservation.Presentation.ManagerPage.WalkIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .style1
    {
        height: 6px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divReservation" runat="server" 
        style="position: absolute; left: 160px; top: 180px;">
        <table align="center" bgcolor="#CCFFCC" 
            style="font-family: Verdana; font-size: 150%; background-color: #4b6c9e; color: #cfdbe6;">
            <tr>
                <td align="center" colspan="2" 
                    style="color: White; background-color: #6B696B; font-weight: bold;">
                    Information of a Reservation</td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="UserNameLabel" runat="server">Customer Name</asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" 
                        ControlToValidate="TextBoxUserName" EnableClientScript="False" 
                        ErrorMessage="input the recipient">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="EmailLabel0" runat="server">Phone</asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server" 
                        ControlToValidate="TextBoxPhone" EnableClientScript="False" 
                        ErrorMessage="input the phone numer">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label4" runat="server">Address</asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" 
                        ControlToValidate="TextBoxAddress" EnableClientScript="False" 
                        ErrorMessage="input address">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label7" runat="server">Arrive Time</asp:Label>
                </td>
                <td align="left">
                    <calendarextender id="TextBoxArriveDate_CalendarExtender" runat="server" 
                        format="yyyy-MM-dd" targetcontrolid="TextBoxArriveDate">
                        </calendarextender>
                    <asp:Label ID="LabelTime" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    &nbsp;</td>
                <td align="left" class="style1">
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Table</td>
                <td align="left">
                    <asp:Label ID="LabelTable" runat="server" Text="Label"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Seat</td>
                <td align="left">
                    <asp:TextBox ID="TextBoxSeat" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;</td>
                <td align="left">
                    <asp:Button ID="ButtonSubmit" runat="server" onclick="ButtonSubmit_Click" 
                        Text="Button" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;</td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
