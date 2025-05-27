<%@ Page Title="Add New Jewel" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddJewel.aspx.cs" Inherits="PSDLab_Project.Views.AddJewel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> <%-- Use MainContent or your verified ID --%>
    <h1>Add New Jewel</h1>
    <div>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>
    </div>
    <table>
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="Jewel Name:"></asp:Label></td>
            <td><asp:TextBox ID="txtJewelName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="Category:"></asp:Label></td>
            <td><asp:DropDownList ID="ddlCategory" runat="server" DataTextField="CategoryName" DataValueField="CategoryID"></asp:DropDownList></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label3" runat="server" Text="Brand:"></asp:Label></td>
            <td><asp:DropDownList ID="ddlBrand" runat="server" DataTextField="BrandName" DataValueField="BrandID"></asp:DropDownList></td>
        </tr>
         <tr>
            <td><asp:Label ID="Label4" runat="server" Text="Price:"></asp:Label></td>
            <td><asp:TextBox ID="txtPrice" runat="server" TextMode="Number" step="0.01"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label5" runat="server" Text="Release Year:"></asp:Label></td>
            <td><asp:TextBox ID="txtReleaseYear" runat="server" TextMode="Number"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnAddJewel" runat="server" Text="Add Jewel" OnClick="btnAddJewel_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" />
            </td>
        </tr>
    </table>
</asp:Content>