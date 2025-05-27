<%@ Page Title="Jewel Details" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="JewelDetail.aspx.cs" Inherits="PSDLab_Project.Views.JewelDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> <%-- Use MainContent or your verified ID --%>
    <h1>Jewel Details</h1>
    <asp:Label ID="lblError" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>
    
    <asp:Panel ID="pnlDetails" runat="server">
        <table>
            <tr>
                <td><strong>Name:</strong></td>
                <td><asp:Label ID="lblName" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td><strong>Category:</strong></td>
                <td><asp:Label ID="lblCategory" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td><strong>Brand:</strong></td>
                <td><asp:Label ID="lblBrand" runat="server"></asp:Label></td>
            </tr>
             <tr>
                <td><strong>Country:</strong></td>
                <td><asp:Label ID="lblCountry" runat="server"></asp:Label></td>
            </tr>
             <tr>
                <td><strong>Class:</strong></td>
                <td><asp:Label ID="lblClass" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td><strong>Price:</strong></td>
                <td><asp:Label ID="lblPrice" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td><strong>Release Year:</strong></td>
                <td><asp:Label ID="lblYear" runat="server"></asp:Label></td>
            </tr>
        </table>
        
        <br />

        <%-- Customer Actions --%>
        <asp:PlaceHolder ID="phCustomerActions" runat="server" Visible="false">
            <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" OnClick="btnAddToCart_Click" />
        </asp:PlaceHolder>

        <%-- Admin Actions --%>
        <asp:PlaceHolder ID="phAdminActions" runat="server" Visible="false">
            <asp:Button ID="btnEdit" runat="server" Text="Edit Jewel" OnClick="btnEdit_Click" CausesValidation="false" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete Jewel" OnClick="btnDelete_Click" CausesValidation="false" 
                        OnClientClick="return confirm('Are you sure you want to delete this jewel?');" />
        </asp:PlaceHolder>

    </asp:Panel>
</asp:Content>