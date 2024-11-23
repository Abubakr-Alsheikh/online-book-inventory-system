using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Book_Inventory_System
{
    public partial class Admin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionManager.RedirectToLoginIfNotAdmin();
            if (!IsPostBack)
            {

                Books.DataSource = DatabaseAccess.Books.GetBooks();
                Books.DataBind();
            }
        }
        protected void DeletePage(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Response.Redirect(RedirectManager.PagesURL.DeleteBookURL + "?id=" + id);
        }
        protected void EditPage(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Response.Redirect(RedirectManager.PagesURL.EditBookURL + "?id=" + id);
        }
    }
}