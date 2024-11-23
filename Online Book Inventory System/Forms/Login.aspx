<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Online_Book_Inventory_System.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center align-items-center my-5 h-100">
        <div class="form w-50 w-sm-75">
            <div class="text-center">
                <h2>Welcom Back</h2>
                <p class="text-secondary fs-5 mb-5">Enter your email and password</p>
            </div>
            <div class="form-group text-secondary">
                <asp:Label ID="usernameEmailLabel" runat="server" Text="Email / Username:" CssClass="control-label"></asp:Label>
                <asp:TextBox AutoCompleteType="Email" ID="usernameEmailTextBox" runat="server" CssClass="form-control border-primary rounded-pill" placeholder="Example@gmail.com..."></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="usernameEmailTextBox" ErrorMessage="Email or Username is required." runat="server" CssClass="text-danger" />
            </div>
            <br />

            <div class="form-group text-secondary">
                <asp:Label ID="passwordLabel" runat="server" Text="Password:" CssClass="control-label"></asp:Label>
                <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password" CssClass="form-control border-primary rounded-pill" placeholder="password..."></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="passwordTextBox" ErrorMessage="Password is required." runat="server" CssClass="text-danger" />
            </div>
            <br />
            
            <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="LoginButton_Click" CssClass="btn btn-primary rounded-pill px-4 w-25 mb-5 " />
            <br /><asp:Label ID="ErrorMessageLabel" runat="server" ForeColor="Red" CssClass="invisible" />  
        </div>
    </div>
    
</asp:Content>