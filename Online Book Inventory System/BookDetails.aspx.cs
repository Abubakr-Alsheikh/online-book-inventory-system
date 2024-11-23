using System;
using System.Web.UI;
using static Db;

namespace Online_Book_Inventory_System
{
    public partial class BookDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["BookID"] == null)
            {
                RedirectManager.ToHomePage();
                return;
            }
            if (!IsPostBack)
            {
                int bookId = int.Parse(Request.QueryString["BookID"]);
                Book book = DatabaseAccess.Books.GetBookFromID(bookId);

                UpdateBookDetails(book);
                UpdateReadingListButtons(bookId);
            }
        }
        private void UpdateReadingList(bool addToReadingList, string message)
        {
            SessionManager.RedirectToLoginIfNotLoggedIn();

            int bookId = int.Parse(Request.QueryString["BookID"]);
            int userId = int.Parse(Session["UserID"].ToString());

            if (addToReadingList)
            {
                DatabaseAccess.ReadingLists.AddToReadingList(bookId, userId);
            }
            else
            {
                DatabaseAccess.ReadingLists.RemoveFromReadingList(bookId, userId);
            }
            lblMessage.CssClass = "alert alert-success visible";
            lblMessage.Text = message;
            UpdateReadingListButtons(bookId);
        }
        protected void AddToReadingList(object sender, EventArgs e)
        {
            UpdateReadingList(true, "Book added to reading list!");
        }

        protected void RemoveFromReadingList(object sender, EventArgs e)
        {
            UpdateReadingList(false, "Book removed from reading list!");
        }

        private void UpdateBookDetails(Book book)
        {
            BookImage.Src = book.Image;
            BookName.InnerText = book.Name;
            BookAuthor.InnerText = book.Author;
            BookGenre.InnerText = book.Genre;
            BookPrice.InnerText = book.Price.ToString() + "$";
            BookPages.InnerText = book.Pages.ToString();
            BookDescription.InnerText = book.Description;
        }

        private void UpdateReadingListButtons(int bookId)
        {
            if (SessionManager.IsUserLoggedIn)
            {
                bool isInReadingList = DatabaseAccess.ReadingLists.IsInReadingList(bookId, SessionManager.GetUserID);

                addToReadingList.Visible = !isInReadingList;
                removeFromReadingList.Visible = isInReadingList;
            }
            else
            {
                addToReadingList.Visible = false;
                removeFromReadingList.Visible = false;
            }
        }
    }
}