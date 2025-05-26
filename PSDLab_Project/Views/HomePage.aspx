<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="PSDLab_Project.Views.HomePage" MasterPageFile="~/Views/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 80%; margin: auto;">
        <h2>All Jewels</h2>

        <asp:Repeater ID="rptJewels" runat="server" OnItemCommand="rptJewels_ItemCommand">
            <HeaderTemplate>
                <table border="1" cellpadding="5" cellspacing="0" width="100%">
                    <tr style="background-color: #f0f0f0;">
                        <th>Name</th>
                        <th>Brand</th>
                        <th>Category</th>
                        <th>Price</th>
                        <th>Action</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("JewelName") %></td>
                    <td><%# Eval("Brand.BrandName") %></td>
                    <td><%# Eval("Category.CategoryName") %></td>
                    <td><%# Eval("Price", "{0:C}") %></td>
                    <td>
                        <asp:Button ID="btnView" runat="server" Text="View Details"
                            CommandArgument='<%# Eval("JewelID") %>' CommandName="view" />

                        <asp:Button ID="btnAdd" runat="server" Text="Add to Cart"
                            CommandArgument='<%# Eval("JewelID") %>' CommandName="add"
                            Visible='<%# IsCustomer %>' />

                        <asp:Button ID="btnEdit" runat="server" Text="Edit"
                            CommandArgument='<%# Eval("JewelID") %>' CommandName="edit"
                            Visible='<%# IsAdmin %>' />

                        <asp:Button ID="btnDelete" runat="server" Text="Delete"
                            CommandArgument='<%# Eval("JewelID") %>' CommandName="delete"
                            Visible='<%# IsAdmin %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
