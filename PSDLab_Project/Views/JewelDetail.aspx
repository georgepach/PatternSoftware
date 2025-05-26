<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JewelDetail.aspx.cs" Inherits="PSDLab_Project.Views.JewelDetail" MasterPageFile="~/Views/MasterPage.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="width: 400px; margin: auto;">
        <h2>Jewel Details</h2>

        <asp:Label ID="lblError" runat="server" ForeColor="Red" />

        <table style="width: 100%;">
            <tr>
                <td><strong>Name:</strong></td>
                <td><asp:Label ID="lblName" runat="server" /></td>
            </tr>
            <tr>
                <td><strong>Brand:</strong></td>
                <td><asp:Label ID="lblBrand" runat="server" /></td>
            </tr>
            <tr>
                <td><strong>Class:</strong></td>
                <td><asp:Label ID="lblClass" runat="server" /></td>
            </tr>
            <tr>
                <td><strong>Category:</strong></td>
                <td><asp:Label ID="lblCategory" runat="server" /></td>
            </tr>
            <tr>
                <td><strong>Price:</strong></td>
                <td><asp:Label ID="lblPrice" runat="server" /></td>
            </tr>
            <tr>
                <td><strong>Release Year:</strong></td>
                <td><asp:Label ID="lblYear" runat="server" /></td>
            </tr>
        </table>

        <br />
        <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" OnClick="btnAddToCart_Click" Visible="false" />
        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" Visible="false" />
    </div>
</asp:Content>
