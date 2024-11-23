using System.Web;

public static class SessionManager
{
    public static bool IsUserLoggedIn {
        get {
            return HttpContext.Current.Session["UserID"] != null;
        }
    }
    public static string GetUserRole {
        get {
            return HttpContext.Current.Session["role"] as string;
        }
    }
    public static bool IsUserAdmin {
        get {
            return IsUserLoggedIn && GetUserRole == "admin";
        }
    }
    public static int GetUserID {
        get {
            return int.Parse(HttpContext.Current.Session["UserID"].ToString());
        }
    }
    public static string GetUsername {
        get {
            return HttpContext.Current.Session["username"].ToString();
        }
    }
    public static void LoginUser(string userId, string username, string role)
    {
        HttpContext.Current.Session["UserID"] = userId;
        HttpContext.Current.Session["username"] = username;
        HttpContext.Current.Session["role"] = role;
    }
    public static void LogoutUser()
    {
        HttpContext.Current.Session.Clear();
        RedirectManager.ToHomePage();
    }
    public static void RedirectToLoginIfNotLoggedIn()
    {
        if (!IsUserLoggedIn)
        {
            RedirectManager.ToLoginForm();
        }
    }
    public static void RedirectToHomeIfLoggedIn()
    {
        if (IsUserLoggedIn)
        {
            RedirectManager.ToHomePage();
        }
    }
    public static void RedirectToLoginIfNotAdmin()
    {
        if (!IsUserAdmin)
        {
            RedirectManager.ToLoginForm();
        }
    }
}
