<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainCustomer.Master" AutoEventWireup="true" CodeBehind="NewDelivery.aspx.cs" Inherits="RestaurantWebReservation.Presentation.CustomerPage.NewDelivery" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id = "divDelivery" style="position: absolute; top: 180px; right: 150px;">
    <table style="font-family: Verdana; font-size: 150%; background-color: #4b6c9e; color: #cfdbe6;" 
        align="center" bgcolor="#CCFFCC">
        <tr>
            <td align="center" colspan="2" style="color: White; background-color: #6B696B; font-weight: bold;">
                        Fill the
                        Information of Delivery</td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="UserNameLabel" runat="server">Recipient</asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="请输入用户名" ControlToValidate="TextBoxUserName" 
                    EnableClientScript="False">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="UserNameLabel0" runat="server">Ordered By</asp:Label>
            </td>
            <td align="left">
                <asp:Label ID="LabelCustomerName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="EmailLabel0" runat="server">Phone</asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ErrorMessage="请输入手机号" ControlToValidate="TextBoxPhone" 
                    EnableClientScript="False">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label4" runat="server">Address</asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="TextBoxAddress" ErrorMessage="添加城市" 
                    EnableClientScript="False">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label8" runat="server">Delivery Date</asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxDate" runat="server" 
                    ontextchanged="TextBoxDate_TextChanged"></asp:TextBox>
 <!--               <cc1:CalendarExtender ID="TextBoxDate_CalendarExtender" runat="server" 
                            TargetControlID="TextBoxDate" Format = "yyyy-MM-dd">
                </cc1:CalendarExtender> -->
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                            ControlToValidate="TextBoxDate" ErrorMessage="添加城市" 
                    EnableClientScript="False">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label7" runat="server">Delivery Time</asp:Label>
            </td>
            <td align="left">
                <asp:Label ID="LabelTime" runat="server"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownListHour" runat="server" 
                    onselectedindexchanged="DropDownListHour_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownListMinute" runat="server" 
                    onselectedindexchanged="DropDownListMinute_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
                <br />
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
                            Text="Submit" />
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
<div id = "divDish" runat = "server" style="position: absolute; top: 180px; left: 150px">
    <asp:Label ID="LabelCart" runat="server" ForeColor="#333333" 
        Text="Dishes in your cart"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" 
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" 
        ondatabound="GridView1_DataBound" onrowdatabound="GridView1_RowDataBound" 
        ShowFooter="True">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="dishName" HeaderText="dishName" 
                SortExpression="dishName" />
            <asp:BoundField DataField="priceSingle" HeaderText="priceSingle" 
                SortExpression="priceSingle" />
            <asp:BoundField DataField="quota" HeaderText="quota" SortExpression="quota" />

            <asp:BoundField DataField="note" HeaderText="Total" SortExpression="note" />
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
        SelectMethod="GetDishQuota" 
        
        TypeName="RestaurantWebReservation.Application.BasicDataStractrue.Delivery" 
        onobjectcreating="ObjectDataSource1_ObjectCreating">
    </asp:ObjectDataSource>
    <br />
    <asp:Label ID="LabelError" runat="server" 
        Text="No dishes is in your shopping cart" Visible="False"></asp:Label>
</div>
</asp:Content>
