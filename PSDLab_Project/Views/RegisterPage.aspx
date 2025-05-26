<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="RegisterPage.aspx.cs" 
    Inherits="PSDLab_Project.Views.RegisterPage" 
    MasterPageFile="~/Views/MasterPage.Master" 
%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="width: 350px; margin: auto;">
        <h2>Register</h2>

        <asp:Label ID="lblError" runat="server" ForeColor="Red" />

        <br />
        <asp:Label Text="Email" runat="server" />
        <asp:TextBox ID="txtEmail" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="txtEmail" ErrorMessage="* Required" runat="server" ForeColor="Red" Display="Dynamic" />
        <asp:RegularExpressionValidator ControlToValidate="txtEmail" ValidationExpression="\w+@\w+\.\w+" ErrorMessage="Invalid email format" runat="server" ForeColor="Red" Display="Dynamic" />

        <br />
        <asp:Label Text="Username" runat="server" />
        <asp:TextBox ID="txtUsername" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="txtUsername" ErrorMessage="* Required" runat="server" ForeColor="Red" Display="Dynamic" />
        <asp:CustomValidator ID="valUsernameLength" runat="server" ControlToValidate="txtUsername" OnServerValidate="ValidateUsernameLength" ErrorMessage="Username must be 3–25 characters" ForeColor="Red" Display="Dynamic" />

        <br />
        <asp:Label Text="Password" runat="server" />
        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="txtPassword" ErrorMessage="* Required" runat="server" ForeColor="Red" Display="Dynamic" />
        <asp:RegularExpressionValidator ControlToValidate="txtPassword" ValidationExpression="^[a-zA-Z0-9]{8,20}$" ErrorMessage="Password must be alphanumeric and 8–20 characters" runat="server" ForeColor="Red" Display="Dynamic" />

        <br />
        <asp:Label Text="Confirm Password" runat="server" />
        <asp:TextBox ID="txtConfirm" TextMode="Password" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="txtConfirm" ErrorMessage="* Required" runat="server" ForeColor="Red" Display="Dynamic" />
        <asp:CompareValidator ControlToCompare="txtPassword" ControlToValidate="txtConfirm" ErrorMessage="Passwords must match" runat="server" ForeColor="Red" Display="Dynamic" />

        <br />
        <asp:Label Text="Gender" runat="server" />
        <asp:RadioButtonList ID="rdoGender" runat="server">
            <asp:ListItem Text="Male" Value="Male" />
            <asp:ListItem Text="Female" Value="Female" />
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ControlToValidate="rdoGender" InitialValue="" ErrorMessage="* Select gender" runat="server" ForeColor="Red" Display="Dynamic" />

        <br />
        <asp:Label Text="Date of Birth" runat="server" />
        <asp:TextBox ID="txtDob" runat="server" TextMode="Date" />
        <asp:RequiredFieldValidator ControlToValidate="txtDob" ErrorMessage="* Required" runat="server" ForeColor="Red" Display="Dynamic" />
        <asp:CustomValidator ID="valDob" runat="server" ControlToValidate="txtDob" OnServerValidate="ValidateDob" ErrorMessage="Date must be before 01/01/2010" ForeColor="Red" Display="Dynamic" />

        <br /><br />
        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
    </div>
</asp:Content>
