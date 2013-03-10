<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainAdmin.Master" AutoEventWireup="true" CodeBehind="TableConfig.aspx.cs" Inherits="RestaurantWebReservation.Presentation.AdminPage.TableConfig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" 
                    SortExpression="id" Visible="False" />
                <asp:BoundField DataField="name" HeaderText="Table Name" 
                    SortExpression="name" />
                <asp:BoundField DataField="seat" HeaderText="seat" SortExpression="seat" />
                <asp:BoundField DataField="pict_path" HeaderText="pict_path" 
                    SortExpression="pict_path" Visible="False" />
                <asp:ImageField DataImageUrlField="pict_path">
                </asp:ImageField>
                <asp:BoundField DataField="current_state" HeaderText="current_state" 
                    SortExpression="current_state" Visible="False" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:RestaurantWebReservationConnectionString %>" 
            SelectCommand="select_all_table" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
    
        <asp:Button ID="ButtonAdd" runat="server" onclick="ButtonAdd_Click" 
            Text="Add new table" />
    
    </div>
</asp:Content>
