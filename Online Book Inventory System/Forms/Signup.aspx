<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Online_Book_Inventory_System.Signup" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center align-items-center my-5 h-100">
        <div class="form w-50 w-sm-75">
            <div class="text-center">
                <h2>Sign up</h2>
                <p class="text-secondary fs-5 mb-5">Enter your information to continue with us</p>
            </div>
            <div class="form-group">
                <label for="UsernameTextBox">Username:</label>
                <asp:TextBox ID="UsernameTextBox" runat="server" Placeholder="Enter your name..." CssClass="form-control border-primary rounded-pill" />
                <asp:RequiredFieldValidator ControlToValidate="UsernameTextBox" ErrorMessage="Username is required." runat="server" CssClass="text-danger" />
            </div>
            <br />
            <div class="form-group">
                <label for="EmailTextBox">Email:</label>
                <asp:TextBox ID="EmailTextBox" runat="server" Placeholder="Example@gmail.com..." CssClass="form-control border-primary rounded-pill"  />
                <asp:RequiredFieldValidator ControlToValidate="EmailTextBox" ErrorMessage="Email is required." runat="server" CssClass="text-danger" /><br />
                <asp:RegularExpressionValidator ControlToValidate="EmailTextBox" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Email is not valid." runat="server" CssClass="text-danger" />
            </div>

            <div class="form-group">
                <label for="PasswordTextBox">Password:</label>
                <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" Placeholder="password..." CssClass="form-control border-primary rounded-pill" />
                <asp:RequiredFieldValidator ControlToValidate="PasswordTextBox" ErrorMessage="Password is required." runat="server" CssClass="text-danger" /><br />
                <asp:RegularExpressionValidator ControlToValidate="PasswordTextBox" ValidationExpression=".{8,}" ErrorMessage="Password must be at least 8 characters long." runat="server" CssClass="text-danger" />
            </div>

            <div class="form-group">
                <label for="RoleDropDownList">Role(It's for testing):</label>
                <asp:DropDownList ID="RoleDropDownList" runat="server" CssClass="form-control border-primary rounded-pill">
                    <asp:ListItem Value="user">user</asp:ListItem>
                    <asp:ListItem Value="admin">admin</asp:ListItem>
                </asp:DropDownList>
            </div>

            <asp:Button ID="SignupButton" runat="server" Text="Sign Up" OnClick="SignupButton_Click" CssClass="btn btn-primary rounded-pill px-4 w-25 my-5" /><br />
            <asp:Label ID="ErrorMessageLabel" runat="server" ForeColor="Red" CssClass="invisible" />
        </div>
    </div>
</asp:Content>


