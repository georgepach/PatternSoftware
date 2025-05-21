<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="PSDLab_Project.Views.LoginPage" MasterPageFile="~/Views/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 300px; margin: auto;">
        <h2>Login</h2>

        <asp:Label ID="lblError" runat="server" ForeColor="Red" />

        <br />
        <asp:Label Text="Email" runat="server" />
        <asp:TextBox ID="txtEmail" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="txtEmail" ErrorMessage="* Required" runat="server" ForeColor="Red" Display="Dynamic" />

        <br />
        <asp:Label Text="Password" runat="server" />
        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="txtPassword" ErrorMessage="* Required" runat="server" ForeColor="Red" Display="Dynamic" />

        <br />
        <asp:CheckBox ID="chkRemember" Text="Remember Me" runat="server" />

        <br /><br />
        <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" />
    </div>
</asp:Content>
