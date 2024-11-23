<%@ Page Title="Delete Book" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteBook.aspx.cs" Inherits="Online_Book_Inventory_System.DeleteBook" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row mt-5 align-items-start w-100 justify-content-center">
        <div class="form-group col-sm-6 col-8 flex-row">
            <h2 class="mb-4">Delete Book</h2>
            <asp:Label ID="NameLabel" runat="server" Text="Book Name" CssClass="text-secondary" class="col-6" />
            <div class="col-6 d-flex flex-row justify-content-evenly w-100 mt-4">
                <asp:Button ID="Button1" runat="server" Text="Confirm" OnClick="ConfirmButton_Click" CssClass="form-control btn btn-primary rounded-pill w-25" />
                <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="CancelButton_Click" CssClass="form-control border-primary text-primary rounded-pill w-25" />
            </div>
        </div>
    </div>
</asp:Content>
