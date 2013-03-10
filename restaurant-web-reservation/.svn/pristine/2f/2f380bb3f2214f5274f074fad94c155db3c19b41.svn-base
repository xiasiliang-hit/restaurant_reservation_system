<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainCustomer.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RestaurantWebReservation.Presentation.CustomerPage.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
    <table style="font-family: Verdana; font-size: 100%; background-color: #4b6c9e; color: #cfdbe6;" align="center" bgcolor="#CCFFCC" >
                <tr>
                    <td align="center" colspan="2" style="color: White; background-color: #6B696B; font-weight: bold;">
                        Register</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Name</asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" 
                            ErrorMessage="Input the name" ControlToValidate="UserName">*</asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" 
                            ErrorMessage="Name exists, choose another name" 
                            onservervalidate="CustomValidator1_ServerValidate" SetFocusOnError="True"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password</asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="Password" ErrorMessage="Input the password">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Password Confirm</asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="ConfirmPassword" ErrorMessage="confirm the password">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToCompare="ConfirmPassword" ControlToValidate="Password" 
                            Display="Dynamic" ErrorMessage="please confirm the password "></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">EMail</asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="Email" ErrorMessage="Input the EMail">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Enabled="False" />
                        &nbsp;
                    </td>
                    <td align="left">
                        &nbsp;
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="color: Red;">
        <asp:Button ID="ButtonRegiser" runat="server" onclick="ButtonRegiser_Click" 
            Text="Submit" />
                    </td>
                </tr>
            </table>
    </asp:Panel>

</asp:Content>
