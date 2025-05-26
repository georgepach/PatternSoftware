<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddJewel.aspx.cs" Inherits="PSDLab_Project.Views.AddJewel" MasterPageFile="~/Views/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 400px; margin: auto;">
        <h2>Add Jewel</h2>

        <asp:Label ID="lblError" runat="server" ForeColor="Red" />

        <asp:Label Text="Jewel Name:" runat="server" /><br />
        <asp:TextBox ID="txtName" runat="server" /><br />

        <asp:Label Text="Brand:" runat="server" /><br />
        <asp:DropDownList ID="ddlBrand" runat="server" /><br />

        <asp:Label Text="Category:" runat="server" /><br />
        <asp:DropDownList ID="ddlCategory" runat="server" /><br />

        <asp:Label Text="Price:" runat="server" /><br />
        <asp:TextBox ID="txtPrice" runat="server" /><br />

        <asp:Label Text="Release Year:" runat="server" /><br />
        <asp:TextBox ID="txtYear" runat="server" /><br /><br />

        <asp:Button ID="btnAdd" runat="server" Text="Add Jewel" OnClick="btnAdd_Click" />
    </div>
</asp:Content>