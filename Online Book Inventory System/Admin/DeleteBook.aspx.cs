using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Online_Book_Inventory_System
{
    public partial class DeleteBook : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionManager.RedirectToLoginIfNotAdmin();
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Db.Book book = DatabaseAccess.Books.GetBookFromID(id);
                NameLabel.Text = "Are you sure you want to delete the book: " + book.Name + "?";
            }
        }
        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            SessionManager.RedirectToLoginIfNotLoggedIn();

            int id = Convert.ToInt32(Request.QueryString["id"]);
            DatabaseAccess.Books.DeleteBookByID(id);
            RedirectManager.ToAdminPage();
        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            RedirectManager.ToAdminPage();
        }
    }
}