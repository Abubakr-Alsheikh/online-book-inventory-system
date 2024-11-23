using System;
using System.Web.UI;

namespace Online_Book_Inventory_System
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionManager.RedirectToHomeIfLoggedIn();
        }

        protected void SignupButton_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                string username = UsernameTextBox.Text;
                string email = EmailTextBox.Text;
                string password = PasswordTextBox.Text;

                if (username.Length > 50)
                {
                    ShowErrorLable();
                    ErrorMessageLabel.Text = "Your name is so long.";
                }
                if (password.Length < 8)
                {
                    ShowErrorLable();
                    ErrorMessageLabel.Text = "Password must be at least 8 characters long.";
                }
                else if (DatabaseAccess.Users.IsUsernameTaken(username))
                {
                    ShowErrorLable();
                    ErrorMessageLabel.Text = "Username is already in use. Please try again.";
                }
                else if (DatabaseAccess.Users.IsEmailTaken(email))
                {
                    ShowErrorLable();
                    ErrorMessageLabel.Text = "Email is already in use. Please try again.";
                }
                else
                {
                    // Username and email are not in use, proceed with storing in the database
                    string role = RoleDropDownList.Text; 
                    DatabaseAccess.Users.AddUser(username, email, password, role);

                    RedirectManager.ToHomePage();
                }
            }
            else
            {
                ShowErrorLable();
                ErrorMessageLabel.Text = "Please enter valid input.";
            }
        }

        private void ShowErrorLable()
        {
            ErrorMessageLabel.CssClass = "alert alert-danger visible p-1";
        }


    }
}
