<%@ Page Title="Home" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="PSDLab_Project.Views.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> <%-- Use MainContent or your verified ID --%>
    <h1>Our Collection</h1>
    <div style="display: grid; grid-template-columns: repeat(auto-fill, minmax(200px, 1fr)); gap: 20px;">
        <asp:Repeater ID="RepeaterJewels" runat="server">
            <ItemTemplate>
                <div style="border: 1px solid #ccc; padding: 15px; text-align: center;">
                    <%-- You might want to add an Image here later --%>
                    <h4><asp:Label ID="lblJewelName" runat="server" Text='<%# Eval("JewelName") %>'></asp:Label></h4>
                    <p>ID: <asp:Label ID="lblJewelID" runat="server" Text='<%# Eval("JewelID") %>'></asp:Label></p>
                    <p>Price: <asp:Label ID="lblJewelPrice" runat="server" Text='<%# Eval("JewelPrice", "{0:C}") %>'></asp:Label></p> <%-- {0:C} formats as currency --%>
                    <asp:HyperLink ID="hlViewDetails" runat="server" 
                                   NavigateUrl='<%# Eval("JewelID", "JewelDetail.aspx?id={0}") %>' 
                                   Text="View Details" 
                                   CssClass="button-class"> <%-- Add a CSS class for styling --%>
                    </asp:HyperLink>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblNoJewels" runat="server" Text="No jewels found." Visible='<%# RepeaterJewels.Items.Count == 0 %>'></asp:Label>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>