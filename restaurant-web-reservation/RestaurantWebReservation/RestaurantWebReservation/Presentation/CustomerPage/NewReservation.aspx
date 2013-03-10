<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainCustomer.Master" AutoEventWireup="true" CodeBehind="NewReservation.aspx.cs" Inherits="RestaurantWebReservation.Presentation.CustomerPage.NewReservation" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id = "divReservation"  runat  = "server" 
    style="position: absolute; left: 160px; top: 180px; z-index: 0;" >
<table style="font-family: Verdana; font-size: 150%; background-color: #4b6c9e; color: #cfdbe6; z-index: inherit;" 
        align="center" bgcolor="#CCFFCC">
                <tr>
                    <td align="center" colspan="2" style="color: White; background-color: #6B696B; font-weight: bold;">
                        Information of a Reservation</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="UserNameLabel" runat="server">Customer Name</asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" 
                            ErrorMessage="input the recipient" ControlToValidate="TextBoxUserName" 
                            EnableClientScript="False">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="UserNameLabel0" runat="server">Ordered By</asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="UserNameLabel1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="EmailLabel0" runat="server">Phone</asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server" 
                            ErrorMessage="input the phone numer" ControlToValidate="TextBoxPhone" 
                            EnableClientScript="False">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label4" runat="server">Address</asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" 
                            ControlToValidate="TextBoxAddress" ErrorMessage="input address" 
                            EnableClientScript="False">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label8" runat="server">Arrive Date</asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBoxArriveDate" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="TextBoxArriveDate_CalendarExtender" runat="server" 
                            TargetControlID="TextBoxArriveDate" Format = "yyyy-MM-dd">
                        </cc1:CalendarExtender>
                        </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label7" runat="server">Arrive Time</asp:Label>
                    </td>
                    <td align="left">
                        <br />
                        <asp:DropDownList ID="DropDownListDuration" runat="server" 
                            DataSourceID="SqlDataSource2" DataTextField="keyword" DataValueField="keyword" 
                            onselectedindexchanged="DropDownListDuration_SelectedIndexChanged" 
                            AutoPostBack="True" ondatabound="DropDownListDuration_DataBound">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:RestaurantWebReservationConnectionString %>" 
                            SelectCommand="select_all_businesstime" SelectCommandType="StoredProcedure">
                        </asp:SqlDataSource>
                                <asp:DropDownList ID="DropDownListTime" runat="server" 
                            AutoPostBack="True">
                                </asp:DropDownList>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Table</td>
                    <td align="left">
                                <asp:DropDownList ID="DropDownListTableName" runat="server" 
                            AutoPostBack="True">
                                </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:RestaurantWebReservationConnectionString %>" 
                            SelectCommand="get_available_tablenum_reservation" 
                            SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TextBoxArriveDate" Name="time" 
                                    PropertyName="Text" Type="DateTime" />
                            </SelectParameters>
                        </asp:SqlDataSource>
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

            <div id = "divTable" 
    style="position: absolute; right: 160px; top: 180px;">
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:RestaurantWebReservationConnectionString %>" 
                    SelectCommand="get_table_by_name" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownListTableName" Name="name" 
                            PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource3" 
                            ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="name" HeaderText="Table Name " 
                                    SortExpression="name" />
                                <asp:BoundField DataField="seat" HeaderText="Seat" SortExpression="seat" />
                                <asp:ImageField DataImageUrlField="pict_path" HeaderText="Evironment">
                                </asp:ImageField>
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div  id = "divTableImage" 
        style="position: absolute; top: 500px; right: 100px">
            </div>
    
</asp:Content>
