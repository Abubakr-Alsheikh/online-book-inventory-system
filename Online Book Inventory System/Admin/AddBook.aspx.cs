using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Db;

namespace Online_Book_Inventory_System
{
    public partial class AddBook : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionManager.RedirectToLoginIfNotAdmin();
        }
        protected void AddButton_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                var name = NameTextBox.Text;
                var description = DescriptionTextBox.Text;
                var imagePath = ImageFileUpload.FileName; 

                if (ImageFileUpload.HasFile)
                {
                    string fileName = Path.GetFileName(ImageFileUpload.PostedFile.FileName);
                    ImageFileUpload.PostedFile.SaveAs(Server.MapPath("~/images/") + fileName);
                    imagePath = "~/images/" + fileName;
                }
                
                var author = AuthorTextBox.Text;
                var genre = GenreTextBox.Text;
                var price = Convert.ToDecimal(PriceTextBox.Text);
                var pages = Convert.ToInt32(PagesTextBox.Text);

                var book = new Book(0, name, description, imagePath, author, genre, price, pages);
                DatabaseAccess.Books.AddBook(book);
                RedirectManager.ToAdminPage();
            }
            else
            {
                // Input is not valid, show error message
                ErrorMessageLabel.Text = "Please enter valid input.";
            }
        }
    }
}