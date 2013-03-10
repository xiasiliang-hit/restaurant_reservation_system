<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MainAdmin.Master" AutoEventWireup="true" CodeBehind="TimeConfig.aspx.cs" Inherits="RestaurantWebReservation.Presentation.AdminPage.TimeConfig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="keyword" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="keyword" HeaderText="Meal" ReadOnly="True" 
                    SortExpression="keyword" />
                <asp:BoundField DataField="time" HeaderText="End Time" SortExpression="time" 
                    DataFormatString="{0:HH:mm:ss}" ApplyFormatInEditMode="True" />
                <asp:CommandField ShowEditButton="True" />
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
            SelectCommand="select_all_businesstime" 
            SelectCommandType="StoredProcedure" UpdateCommand="update_business_time" 
            UpdateCommandType="StoredProcedure">
            <UpdateParameters>
                <asp:Parameter Name="keyword" Type="String" />
                <asp:Parameter Name="time" Type="DateTime" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    <div>
        
    
        
    </div>
</asp:Content>
