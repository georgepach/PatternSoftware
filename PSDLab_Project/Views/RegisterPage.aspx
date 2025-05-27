<%@ Page Title="Register" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="PSDLab_Project.Views.RegisterPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Register New Account</h1>
    <div>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>
    </div>
    <table>
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="Email:"></asp:Label></td>
            <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="Username:"></asp:Label></td>
            <td><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label></td>
            <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
         <tr>
            <td><asp:Label ID="Label4" runat="server" Text="Confirm Password:"></asp:Label></td>
            <td><asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label5" runat="server" Text="Gender:"></asp:Label></td>
            <td>
                <asp:RadioButtonList ID="rblGender" runat="server">
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="Label6" runat="server" Text="Date of Birth:"></asp:Label></td>
            <td><asp:TextBox ID="txtDOB" runat="server" TextMode="Date"></asp:TextBox></td>
            <%-- For browsers not supporting TextMode="Date", consider a Calendar control or JavaScript datepicker --%>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" /></td>
        </tr>
    </table>
</asp:Content>