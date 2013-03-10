<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainAdmin.Master" AutoEventWireup="true" CodeBehind="DishAdd.aspx.cs" Inherits="RestaurantWebReservation.Presentation.AdminPage.DishAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
<table style="font-family: Verdana; font-size: 100%; background-color: #FFFFCC;" 
            align="center" bgcolor="#CCFFCC">
                <tr>
                    <td align="center" colspan="2" 
                        style="color: White; background-color: #800000; font-weight: bold;">
                        Add Dish 
                    </td>
                </tr>
                <tr>
                    <td align="right">
        <asp:Label ID="Label1" runat="server" Text="Dish name"></asp:Label>
                    </td>
                    <td align="left">
        <asp:TextBox ID="TextBox1" runat="server" style="width: 148px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="请输入用户名" ControlToValidate="TextBox1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
        <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
                    </td>
                    <td align="left">
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="TextBox2" ErrorMessage="密码不可为空">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
        <asp:Label ID="Label3" runat="server" Text="Price"></asp:Label>
                    </td>
                    <td align="left">
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="TextBox3" ErrorMessage="密码不可为空">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
        <asp:Label ID="Label4" runat="server" Text="Image"></asp:Label>
                    </td>
                    <td align="left">
        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="FileUpload1" ErrorMessage="请填写电子邮件">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
        <asp:Label ID="Label5" runat="server" Text="Tags:"></asp:Label>
                    </td>
                    <td align="left">
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="TextBox4" ErrorMessage="添加城市">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;</td>
                    <td align="left">
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="TextBox5" ErrorMessage="请添加学校">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToCompare="TextBox4" ControlToValidate="TextBox5" 
                            ErrorMessage="Tags should be different" Operator="NotEqual"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;</td>
                    <td align="left">
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ControlToValidate="TextBox6" ErrorMessage="添加昵称请">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" 
                            ControlToCompare="TextBox4" ControlToValidate="TextBox6" 
                            ErrorMessage="Tags should be different" Operator="NotEqual"></asp:CompareValidator>
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
        <asp:Button ID="ButtonSubmit" runat="server" onclick="Button1_Click" Text="Submit" 
                            style="height: 21px" />
        <asp:Label ID="SubmitInfoLabel" runat="server"></asp:Label>
    
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;
                    </td>
                    <td align="left">
                        &nbsp;
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
                        &nbsp;
                    </td>
                    <td align="left">
                        &nbsp;
                        </td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;
                    </td>
                    <td align="left">
                        &nbsp;
                        </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="color: Red;">
                        &nbsp;</td>
                </tr>
            </table>
</div>

</asp:Content>
