using System;
using System.IO;
using System.Web.UI;
using static Db;

namespace Online_Book_Inventory_System
{
    public partial class EditBook : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionManager.RedirectToLoginIfNotAdmin();
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);

                Book book = DatabaseAccess.Books.GetBookFromID(id);

                IdLabel.Text = book.Id.ToString();
                NameTextBox.Text = book.Name;
                DescriptionTextBox.Text = book.Description;
                BookImage.ImageUrl = book.Image;
                AuthorTextBox.Text = book.Author;
                GenreTextBox.Text = book.Genre;
                PriceTextBox.Text = book.Price.ToString();
                PagesTextBox.Text = book.Pages.ToString();
            }
        }
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                int id = Convert.ToInt32(IdLabel.Text);
                string imagePath = BookImage.ImageUrl.ToString();

                if (ImageFileUpload.HasFile)
                {
                    string fileName = Path.GetFileName(ImageFileUpload.PostedFile.FileName);
                    ImageFileUpload.PostedFile.SaveAs(Server.MapPath("~/images/") + fileName);
                    imagePath = "~/images/" + fileName;
                }

                var name = NameTextBox.Text;
                var description = DescriptionTextBox.Text;
                var author = AuthorTextBox.Text;
                var genre = GenreTextBox.Text;
                var price = Convert.ToDecimal(PriceTextBox.Text);
                var pages = Convert.ToInt32(PagesTextBox.Text);

                var book = new Book(id, name, description, imagePath, author, genre, price, pages);
                DatabaseAccess.Books.UpdateBook(book);
                RedirectManager.ToAdminPage();
            }
            else
            {
                ErrorMessageLabel.Text = "Please enter valid input.";
            }
        }

    }
}