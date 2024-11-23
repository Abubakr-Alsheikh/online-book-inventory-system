<%@ Page Title="Add Book" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="Online_Book_Inventory_System.AddBook" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="mt-5">Add Book</h2>
    <div class="row min-vh-100 mt-5 align-items-start">
        <div class="h-100 d-flex position-relative w-100 flex-lg-row flex-column">
            <div class="col-lg-6 d-flex position-relative align-items-start">
                <asp:Image ID="BookImage" runat="server" CssClass="w-100 pe-lg-2 rounded-5" />
                <div class="vr position-absolute end-0 h-100 bg-primary rounded-pill d-lg-block d-none opacity-50" style="width: 5px; right: -5px !important;"></div>
            </div>
            <div class="col-lg-6 d-flex flex-fill justify-content-between flex-column ps-3 text-secondary ">
                <div class="form-group">
                    <label for="NameTextBox">Title</label>
                    <asp:TextBox ID="NameTextBox" runat="server" CssClass="form-control border-primary rounded-pill" Placeholder="e.g. The lord of the rings..." />
                    <asp:RequiredFieldValidator ControlToValidate="NameTextBox" ErrorMessage="Name is required." runat="server" CssClass="text-danger" />
                </div>

                <div class="form-group">
                    <label for="AuthorTextBox">Author</label>
                    <asp:TextBox ID="AuthorTextBox" runat="server" CssClass="form-control border-primary rounded-pill" Placeholder="e.g. J. R. R. Tolkien..." />
                    <asp:RequiredFieldValidator ControlToValidate="AuthorTextBox" ErrorMessage="Author is required." runat="server" CssClass="text-danger" />
                </div>

                <div class="form-group">
                    <label for="DescriptionTextBox">Description</label>
                    <asp:TextBox ID="DescriptionTextBox" runat="server" CssClass="form-control border-primary rounded-4" Placeholder="the saga of a group of sometimes reluctant heroes who set forth to save their world from consummate evil..." TextMode="MultiLine" Style="min-height: 250px; resize: none" />
                    <asp:RequiredFieldValidator ControlToValidate="DescriptionTextBox" ErrorMessage="Description is required." runat="server" CssClass="text-danger" />
                </div>

                <div class="form-group">
                    <label for="ImageFileUpload">Image</label>
                    <asp:FileUpload ID="ImageFileUpload" runat="server" CssClass="form-control border-primary rounded-pill-file" onchange="previewImage(event)" accept="image/*" />
                    <asp:RequiredFieldValidator ID="ImageFileUploadValidator" ControlToValidate="ImageFileUpload" ErrorMessage="Please upload an image." runat="server" InitialValue="" CssClass="text-danger" />
                </div>

                <div class="row">
                    <div class="col-4">
                        <label for="GenreTextBox">Genre</label>
                        <asp:TextBox ID="GenreTextBox" runat="server" CssClass="form-control border-primary rounded-pill" Placeholder="e.g. Fantasy" />
                        <asp:RequiredFieldValidator ControlToValidate="GenreTextBox" ErrorMessage="Genre is required." runat="server" CssClass="text-danger" />
                    </div>

                    <div class="col-4">
                        <label for="PriceTextBox">Price</label>
                        <asp:TextBox ID="PriceTextBox" runat="server" CssClass="form-control border-primary rounded-pill" Placeholder="e.g. 100$" />
                        <asp:RequiredFieldValidator ControlToValidate="PriceTextBox" ErrorMessage="Price is required." runat="server" CssClass="text-danger" /><br />
                        <asp:CompareValidator ControlToValidate="PriceTextBox" Operator="DataTypeCheck" Type="Currency" ErrorMessage="Price must be a valid number." runat="server" CssClass="text-danger" />
                    </div>

                    <div class="col-4">
                        <label for="PagesTextBox">Pages</label>
                        <asp:TextBox ID="PagesTextBox" runat="server" CssClass="form-control border-primary rounded-pill" Placeholder="e.g. 300" />
                        <asp:RequiredFieldValidator ControlToValidate="PagesTextBox" ErrorMessage="Number of pages is required." runat="server" CssClass="text-danger" /><br />
                        <asp:CompareValidator ControlToValidate="PagesTextBox" Operator="DataTypeCheck" Type="Integer" ErrorMessage="Number of pages must be a valid integer." runat="server" CssClass="text-danger" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Button ID="AddButton" runat="server" CssClass="btn btn-primary rounded-pill px-4 w-25 mb-5" Text="Add" OnClick="AddButton_Click" />
                </div>
                <asp:Label ID="ErrorMessageLabel" runat="server" CssClass="text-danger" />
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function previewImage(event) {
            var reader = new FileReader();
            reader.onload = function () {
                var output = document.getElementById('<%= BookImage.ClientID %>');
                output.src = reader.result;
            };
            reader.readAsDataURL(event.target.files[0]);
        }
    </script>


</asp:Content>
