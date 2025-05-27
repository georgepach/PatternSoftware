<%@ Page Title="Login" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="PSDLab_Project.Views.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- Make sure 'head' matches your MasterPage's head placeholder ID --%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 
    <%-- *** CORRECTED to MainContent - VERIFY THIS ID *** --%>
    <h1>Login</h1>
    <div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" EnableViewState="false"></asp:Label>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>
    </div>
    <table>
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="Email:"></asp:Label></td>
            <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label></td>
            <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:CheckBox ID="chkRememberMe" runat="server" Text="Remember Me" /></td>
        </tr>
         <tr>
            <td></td>
            <td><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /></td>
        </tr>
         <tr>
            <td></td>
            <td>
                <asp:HyperLink ID="hlRegister" runat="server" NavigateUrl="~/Views/RegisterPage.aspx">Don't have an account? Register here.</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>