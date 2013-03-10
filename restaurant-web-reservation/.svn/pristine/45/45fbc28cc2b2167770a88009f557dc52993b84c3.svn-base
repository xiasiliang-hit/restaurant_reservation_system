<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RestaurantWebReservation.Presentation.ManagerPage.Login" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


p
{
    margin-bottom: 10px;
    line-height: 1.6em;
}


    .header
{
    position: relative;
    margin: 0px;
    padding: 0px;
    background: #4b6c9e;
    width: 100%;
}

.title
{
    display: block;
    float: left;
    text-align: left;
    width: auto;
}

.header h1
{
    font-weight: 700;
    margin: 0px;
    padding: 0px 0px 0px 20px;
    color: #f9f9f9;
    border: none;
    line-height: 2em;
    font-size: 2em;
}

h1
{
    font-size: 1.6em;
    padding-bottom: 0px;
    margin-bottom: 0px;
}

h1, h2, h3, h4, h5, h6
{
    font-size: 1.5em;
    color: #666666;
    font-variant: small-caps;
    text-transform: none;
    font-weight: 200;
    margin-bottom: 0px;
}

.loginDisplay
{
    font-size: 1.1em;
    display: block;
    text-align: right;
    padding: 10px;
    color: White;
}

.clear
{
    clear: both;
}

a:link, a:visited
{
    color: #034af3;
}

div.menu
{
    padding: 4px 0px 4px 8px;
}

div.menu ul
{
    list-style: none;
    margin: 0px;
    padding: 0px;
    width: auto;
}

.page
{
    width: 960px;
    background-color: #fff;
    margin: 20px auto 0px auto;
    border: 1px solid #496077;
}

.main
{
    padding: 0px 12px;
    margin: 12px 8px 8px 8px;
    min-height: 420px;
}

.footer
{
    color: #4e5766;
    padding: 8px 0px 0px 0px;
    margin: 0px auto;
    text-align: center;
    line-height: normal;
}


    </style>
</head>
<body runat="server">
    <form id="Form1" runat="server">
    <div class="page">
        <div class="header">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
            <div class="title">
                <h1>
                    My Restaurant
                </h1>
            </div>
            <div class="loginDisplay">
                <div id="divNotLogin" runat = "server" >
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="TextBoxName_AutoCompleteExtender0" runat="server" 
                            TargetControlID="TextBoxName" ServiceMethod="LoginAutoCommplete" 
                            ServicePath="~/Application/Service/AutoCompleteWebService.asmx">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:TextBox ID="TextBoxPwd" runat="server" 
                    style="margin-top: 0px; margin-bottom: 0px;"></asp:TextBox>
                    
                <p>
                    <asp:Button ID="ButtonLogin" runat="server" onclick="ButtonLogin_Click" 
                        Text="Manager Login" />
                    
                </p>
                </div>
            <div id="divLogin" runat="server">
                    <asp:Label ID="LabelWelcome" runat="server">Manager Profile</asp:Label>
                    <br />
                    <br />
                    <br />
                    <br />
            </div>
        </div>
            <div class="clear hideSkiplink">
            <table style="width:100%;">
                    <tr>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </div>

        </div>
        <div class="main">
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="footer">
        
    </div>
    </form>
</body>
</html>
