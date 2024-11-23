<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Online_Book_Inventory_System._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="min-vh-75 d-flex flex-row justify-content-between align-items-center flex-md-row flex-column-reverse ">
        <div class="col-md-6 col-sm-12">
            <h1 class="text-primary mb-4 fs-1">Online Book Inventory System</h1>
            <h2 class="text-primary text-opacity-50 mb-5 fs-4">Manage your books online with ease and convenience</h2>
            <p class="text-secondary fs-5">
                Whether you are a bookstore, a library, a collector, or a book lover,
                our online book inventory system can help you organize, track, and sell your books online. You can create your own book catalog,
                browse and search books by various criteria.
            </p>
            <a class="nav-link btn btn-primary w-25 w-50 text-white p-2 mt-4 rounded-pill mb-5" runat="server" href='<%# RedirectManager.PagesURL.SignupURL %>'>Sign up for free!</a>
        </div>
        <div class="col-md-6 col-sm-12 mw-50 flex-fill">
            <img alt="Books thats referce to online book" src="/HomePage.png" class="mw-100 mh-100" />
        </div>
    </div>
    <div class="container mt-5">
        <h3 class="text-primary">Featured Books</h3>
        <hr class="bg-primary border-primary rounded-pill opacity-75" style="height:6px" />
        <div class="row justify-content-start align-items-center gap-3">
            <asp:Repeater ID="BooksSection" runat="server">
                <ItemTemplate>
                    <div class=" col-md-12 col-lg-4 card my-2 p-0" style="height:300px;width:420px">
                        <div class="d-flex p-0 h-100" >
                            <div class="col-6 h-100">
                                <asp:Image ImageUrl='<%# Eval("Image") %>' ID="BookImage" runat="server" CssClass="img-fluid rounded-start mw-100" Height="300"  />
                            </div>
                            <div class="col-6 p-0 flex-fill m-100">
                                <div class="card-body d-flex justify-content-between flex-column h-100 w-100">
                                    <div>
                                        <h5 class="card-title "><%# (Eval("Name").ToString().Count() < 14)?Eval("Name"):Eval("Name").ToString().Substring(0,14)+"..." %></h5>
                                        <p class="card-text fs-6 fw-light"><%# (Eval("Author").ToString().Count() < 14)? Eval("Author"): Eval("Author").ToString().Substring(0,14)+"..." %></p>
                                        <p class="card-text text-secondary">Description:<br /><%# (Eval("Description").ToString().Count() < 90)? Eval("Description"): Eval("Description").ToString().Substring(0,90)+"..." %></p>
                                    </div>
                                    <p class="card-text"><a href='<%# RedirectManager.PagesURL.BookDetailsURL %>?BookID=<%# Eval("Id") %>' class="btn btn-primary w-100">View Details</a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
