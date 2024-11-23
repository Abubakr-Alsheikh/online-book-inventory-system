using System.Web;

public class RedirectManager
{
    public static class PagesURL
    {
        public static string HomeURL {
            get {
                return "/";
            }
        }
        public static string BookDetailsURL {
            get {
                return "/BookDetails";
            }
        }
        public static string ReadingListURL {
            get {
                return "/ReadingList";
            }
        }
        public static string LoginURL {
            get {
                return "/Forms/Login";
            }
        }
        public static string SignupURL {
            get {
                return "/Forms/Signup";
            }
        }
        public static string AdminURL {
            get {
                return "/Admin/Admin";
            }
        }
        public static string AddBookURL {
            get {
                return "/Admin/AddBook";
            }
        }
        public static string EditBookURL {
            get {
                return "/Admin/EditBook";
            }
        }
        public static string DeleteBookURL {
            get {
                return "/Admin/DeleteBook";
            }
        }
    }
    public static void ToHomePage()
    {
        HttpContext.Current.Response.Redirect(PagesURL.HomeURL);
    }
    public static void ToLoginForm()
    {
        HttpContext.Current.Response.Redirect(PagesURL.LoginURL);
    }
    public static void ToSignupForm()
    {
        HttpContext.Current.Response.Redirect(PagesURL.SignupURL);
    }
    public static void ToAdminPage()
    {
        HttpContext.Current.Response.Redirect(PagesURL.AdminURL);
    }
}
