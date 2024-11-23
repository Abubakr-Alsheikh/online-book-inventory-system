﻿<%@ Page Title="Reading List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReadingList.aspx.cs" Inherits="Online_Book_Inventory_System.ReadingList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-primary text-opacity-50 my-5 fs-4">Welcome <%= SessionManager.GetUsername %></h2>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container mt-5">
                <h3 class="text-primary">Your book list</h3>
                <hr class="bg-primary border-primary rounded-pill opacity-75" style="height: 6px" />
                <div class="book-section row d-flex justify-content-between ">
                    <asp:Repeater ID="ReadingListBooks" runat="server">
                        <ItemTemplate>
                            <div class=" col-md-12 col-lg-4 card my-2 p-0" style="height: 300px; width: 420px">
                                <div class="d-flex p-0 h-100">
                                    <div class="col-6 h-100">
                                        <asp:Image DataField="Name" ImageUrl='<%# Eval("Image") %>' ID="BookImage" runat="server" CssClass="img-fluid rounded-start mw-100" Height="300" />
                                    </div>
                                    <div class="col-6 p-0 flex-fill m-100">
                                        <div class="card-body d-flex justify-content-between flex-column h-100 w-100">
                                            <div>
                                                <h5 class="card-title "><%# (Eval("Name").ToString().Count() < 14)?Eval("Name"):Eval("Name").ToString().Substring(0,14)+"..." %></h5>
                                                <p class="card-text fs-6 fw-light"><%# (Eval("Author").ToString().Count() < 14)? Eval("Author"): Eval("Author").ToString().Substring(0,14)+"..." %></p>
                                                <p class="card-text text-secondary">
                                                    Description:<br />
                                                    <%# (Eval("Description").ToString().Count() < 90)? Eval("Description"): Eval("Description").ToString().Substring(0,90)+"..." %>
                                                </p>
                                            </div>
                                            <p class="card-text p-0 w-100">
                                                <a href='<%# RedirectManager.PagesURL.BookDetailsURL %>?BookID=<%# Eval("Id") %>' class="btn btn-primary col-sm-8 col-12">Details</a>
                                                <asp:LinkButton ID="RemoveButton" runat="server" OnClick="RemoveBook" CommandArgument='<%# Bind("id") %>' CssClass="btn btn-danger  text-white col-sm-3 col-12">
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3" viewBox="0 0 16 16">
                                                        <path d="M6.5 1h3a.5.5 0 0 1 .5.5v1H6v-1a.5.5 0 0 1 .5-.5M11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 5 1.5v1H2.506a.58.58 0 0 0-.01 0H1.5a.5.5 0 0 0 0 1h.538l.853 10.66A2 2 0 0 0 4.885 16h6.23a2 2 0 0 0 1.994-1.84l.853-10.66h.538a.5.5 0 0 0 0-1h-.995a.59.59 0 0 0-.01 0zm1.958 1-.846 10.58a1 1 0 0 1-.997.92h-6.23a1 1 0 0 1-.997-.92L3.042 3.5zm-7.487 1a.5.5 0 0 1 .528.47l.5 8.5a.5.5 0 0 1-.998.06L5 5.03a.5.5 0 0 1 .47-.53Zm5.058 0a.5.5 0 0 1 .47.53l-.5 8.5a.5.5 0 1 1-.998-.06l.5-8.5a.5.5 0 0 1 .528-.47ZM8 4.5a.5.5 0 0 1 .5.5v8.5a.5.5 0 0 1-1 0V5a.5.5 0 0 1 .5-.5"/>
                                                    </svg>
                                                </asp:LinkButton>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ReadingListBooks" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>