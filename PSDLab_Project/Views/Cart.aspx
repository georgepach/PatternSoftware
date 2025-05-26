<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="PSDLab_Project.Views.Cart" MasterPageFile="~/Views/MasterPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 600px; margin: auto;">
        <h2>My Cart</h2>

        <asp:Label ID="lblError" runat="server" ForeColor="Red" />

        <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" OnRowCommand="gvCart_RowCommand">
            <Columns>
                <asp:BoundField DataField="JewelName" HeaderText="Jewel" />
                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
                <asp:ButtonField Text="Remove" ButtonType="Button" CommandName="Remove" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>