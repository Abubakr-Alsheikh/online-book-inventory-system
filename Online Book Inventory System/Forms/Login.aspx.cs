using System;
using System.Web.UI;

namespace Online_Book_Inventory_System
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionManager.RedirectToHomeIfLoggedIn();
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {

            Page.Validate();
            if (Page.IsValid)
            {
                var usernameOrEmail = usernameEmailTextBox.Text;
                var password = passwordTextBox.Text;

                Db.User user = DatabaseAccess.Users.GetUser(usernameOrEmail, password);

                if (user != null)
                {
                    SessionManager.LoginUser(user.Id.ToString(), user.Username, user.Role);
                    if (user.Role == "admin")
                    {
                        RedirectManager.ToAdminPage();
                    }
                    else
                    {
                        RedirectManager.ToHomePage();
                    }
                }
                else
                {
                    ErrorMessageLabel.CssClass = "alert alert-danger visible";
                    ErrorMessageLabel.Text = "Invalid username/email or password. Please try again.";
                }
            }
            else
            {
                ErrorMessageLabel.Text = "Please enter valid input.";
            }
        }
    }
}
