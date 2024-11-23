<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="Online_Book_Inventory_System.BookDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row min-vh-100 mt-5 align-items-start">
        <div class="col-lg-6 h-100 d-flex position-relative align-items-center" style="max-width:600px" >
            <img src="" id="BookImage" runat="server" class="img-fluid h-100 w-100 rounded-5" style="max-width:550px" >
            <div class="vr position-absolute end-0 h-100 bg-primary rounded-pill d-lg-block d-none opacity-50" style="width:5px; right:-5px"></div>
        </div>
        <div class="col-lg-6 d-flex flex-fill justify-content-between flex-column">
            <div class="h-100">
                <h2><strong>Title:</strong> <span id="BookName" runat="server"></span></h2>
                <p><strong>Author:</strong> <span id="BookAuthor" runat="server"></span></p>
                <p><strong>Genre:</strong> <span id="BookGenre" runat="server"></span></p>
                <p><strong>Price:</strong> <span id="BookPrice" runat="server"></span></p>
                <p><strong>Pages:</strong> <span id="BookPages" runat="server"></span></p>
                <p><strong>Description:</strong> <span id="BookDescription" runat="server"></span></p>
            </div>
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton CssClass="nav-link btn btn-primary w-25 w-50 text-white p-2 mt-5 rounded-pill mb-5" ID="addToReadingList" runat="server" OnClick="AddToReadingList" Text="Add to Reading List"  />
                        <asp:LinkButton CssClass="nav-link btn btn-primary w-25 w-50 text-white p-2 mt-5 rounded-pill mb-5" ID="removeFromReadingList" runat="server" OnClick="RemoveFromReadingList" Text="Remove from Reading List"  />
                        <asp:Label CssClass="alert alert-success invisible w-100" ID="lblMessage" runat="server" Text="" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%  if (!(SessionManager.IsUserLoggedIn) ){%>
                        <a runat="server" href="<%# RedirectManager.PagesURL.LoginURL %>" class="nav-link btn btn-primary w-25 w-50 text-white p-2 mt-4 rounded-pill mb-5">Log in to make your reading list</a>
                <% } %>
            </div>
        </div>
    </div>
</asp:Content>
