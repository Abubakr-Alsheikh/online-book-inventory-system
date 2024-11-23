using System;
using System.Web.UI.WebControls;

namespace Online_Book_Inventory_System
{
    public partial class ReadingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionManager.RedirectToLoginIfNotLoggedIn();

            if (!IsPostBack)
            {
                 BindGrid();
            }
        }

        private void BindGrid()
        {
            int userId = Convert.ToInt32(SessionManager.GetUserID);

            ReadingListBooks.DataSource = DatabaseAccess.Books.GetBooksFromUserID(userId);
            ReadingListBooks.DataBind();
        }

        protected void RemoveBook(object sender, EventArgs e)
        {
            SessionManager.RedirectToLoginIfNotLoggedIn();

            int bookId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            int userId = Convert.ToInt32(SessionManager.GetUserID);
            DatabaseAccess.ReadingLists.RemoveFromReadingList(bookId, userId);
            BindGrid();
        }
    }
}

