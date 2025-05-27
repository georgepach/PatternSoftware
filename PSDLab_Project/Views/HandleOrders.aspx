<%@ Page Title="Handle Orders" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="HandleOrders.aspx.cs" Inherits="PSDLab_Project.Views.HandleOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> <%-- Use MainContent or your verified ID --%>
    <h1>Handle Unfinished Orders</h1>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" EnableViewState="false"></asp:Label>
    <asp:Label ID="lblError" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>

    <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="False" 
                  DataKeyNames="TransactionID" OnRowCommand="gvOrders_RowCommand" 
                  OnRowDataBound="gvOrders_RowDataBound" CssClass="orders-gridview">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
            <asp:BoundField DataField="UserID" HeaderText="User ID" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnConfirmPayment" runat="server" Text="Confirm Payment" CommandName="ConfirmPayment" CommandArgument='<%# Eval("TransactionID") %>' Visible="false" />
                    <asp:Button ID="btnShipPackage" runat="server" Text="Ship Package" CommandName="ShipPackage" CommandArgument='<%# Eval("TransactionID") %>' Visible="false" />
                    <asp:Label ID="lblWaiting" runat="server" Text="Waiting for user confirmation..." Visible="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
         <EmptyDataTemplate>
            There are no unfinished orders at the moment.
        </EmptyDataTemplate>
    </asp:GridView>

</asp:Content>