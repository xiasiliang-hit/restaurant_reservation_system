<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainManager.Master" AutoEventWireup="true" CodeBehind="AddDish.aspx.cs" Inherits="RestaurantWebReservation.Presentation.CustomerPage.AddDish" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div >
<div>
    <asp:Label ID="Label1" runat="server" Text="Add dish for customer"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="name" DataSourceID="SqlDataSource1" CellPadding="4" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="name" HeaderText="name" ReadOnly="True" 
                SortExpression="name" />
            <asp:BoundField DataField="description" HeaderText="description" 
                SortExpression="description" />
            <asp:BoundField DataField="price" DataFormatString="{0:c}" HeaderText="price" 
                SortExpression="price" />
            <asp:BoundField DataField="popularity" HeaderText="popularity" 
                SortExpression="popularity" />
            <asp:ImageField DataImageUrlField="pict_path">
            </asp:ImageField>
            <asp:TemplateField>
                <ItemTemplate>
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
                </ItemTemplate>
            </asp:TemplateField>
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:RestaurantWebReservationConnectionString %>" 
        SelectCommand="select_all_dish" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>

    <br />
    <asp:Button ID="ButtonSubmit" runat="server" onclick="ButtonSubmit_Click" 
                        Text="OK" />

<div>
    <asp:GridView ID="GridViewSelect" runat="server" style="margin-right: 0px">
    </asp:GridView>
</div>

</asp:Content>
