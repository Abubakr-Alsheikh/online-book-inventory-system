using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static Db;

public class DatabaseAccess
{
    public readonly static string _connectionString = ConfigurationManager.ConnectionStrings["OBIS"].ConnectionString;
    public static class ErrorMessages
    {
        public static string errorMessage = "";
        public static bool IsThereErrorMessage {
            get {
                return errorMessage != null;
            }
        }
    }
    private static void ExecuteNonQuery(string query, SqlParameter[] parameters)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (System.Exception ex)
        {
            ErrorMessages.errorMessage = ex.Message;
        }
    }
    public static class Books
    {
        private static List<Book> ExecuteBookQuery(string query, SqlParameter[] parameters = null)
        {
            List<Book> books = new List<Book>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Book book = new Book(
                                    reader.GetInt32(reader.GetOrdinal("Id")),
                                    reader.GetString(reader.GetOrdinal("Name")),
                                    reader.GetString(reader.GetOrdinal("Description")),
                                    reader.GetString(reader.GetOrdinal("Image")),
                                    reader.GetString(reader.GetOrdinal("Author")),
                                    reader.GetString(reader.GetOrdinal("Genre")),
                                    reader.GetDecimal(reader.GetOrdinal("Price")),
                                    reader.GetInt32(reader.GetOrdinal("Pages"))
                                );

                                books.Add(book);
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                ErrorMessages.errorMessage = ex.Message;
            }

            return books;
        }
        public static List<Book> GetBooks()
        {
            return ExecuteBookQuery("SELECT * FROM Books");
        }
        public static List<Book> GetBooks(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return new List<Book>();
            }

            SqlParameter[] parameters = { new SqlParameter("@search", "%" + search + "%") };
            return ExecuteBookQuery("SELECT * FROM Books WHERE Name LIKE @search", parameters);
        }
        public static List<Book> GetBooksFromUserID(int userId)
        {
            List<ReadingList> readingLists = ReadingLists.GetReadingLists(userId);
            List<int> bookIds = readingLists.Select(rl => rl.BookId).ToList();

            if (bookIds.Count > 0)
            {
                string ids = string.Join(",", bookIds);
                return ExecuteBookQuery($"SELECT * FROM Books WHERE Id IN ({ids})");
            }

            return new List<Book>();
        }
        public static Book GetBookFromID(int id)
        {
            SqlParameter[] parameters = { new SqlParameter("@id", id) };
            List<Book> books = ExecuteBookQuery("SELECT * FROM Books WHERE Id = @id", parameters);

            return books.Count > 0 ? books[0] : null;
        }
        public static void DeleteBookByID(int id)
        {
            SqlParameter[] parameters = { new SqlParameter("@id", id) };
            ExecuteNonQuery("DELETE FROM Books WHERE id = @id", parameters);
        }
        public static void UpdateBook(Book book)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@id", book.Id),
                new SqlParameter("@name", book.Name),
                new SqlParameter("@description", book.Description),
                new SqlParameter("@image", book.Image),
                new SqlParameter("@author", book.Author),
                new SqlParameter("@genre", book.Genre),
                new SqlParameter("@price", book.Price),
                new SqlParameter("@pages", book.Pages)
            };

            ExecuteNonQuery("UPDATE Books SET name = @name, description = @description, image = @image, author = @author, genre = @genre, price = @price, pages = @pages WHERE id = @id", parameters);
        }
        public static void AddBook(Book book)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@name", book.Name),
                new SqlParameter("@description", book.Description),
                new SqlParameter("@image", book.Image),
                new SqlParameter("@author", book.Author),
                new SqlParameter("@genre", book.Genre),
                new SqlParameter("@price", book.Price),
                new SqlParameter("@pages", book.Pages)
            };

            ExecuteNonQuery("INSERT INTO Books (name, description, image, author, genre, price, pages) VALUES (@name, @description, @image, @author, @genre, @price, @pages)", parameters);
        }

    }
    public class Users
    {
        private static User ExecuteUserQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User(
                                    reader.GetInt32(reader.GetOrdinal("Id")),
                                    reader.GetString(reader.GetOrdinal("Username")),
                                    reader.GetString(reader.GetOrdinal("Email")),
                                    reader.GetString(reader.GetOrdinal("Password")),
                                    reader.GetString(reader.GetOrdinal("Role"))
                                );
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                ErrorMessages.errorMessage = ex.Message;
            }
            return null;
        }
        public static User GetUser(string usernameOrEmail, string password)
        {
            SqlParameter[] parameters = { new SqlParameter("@UsernameOrEmail", usernameOrEmail), new SqlParameter("@Password", password) };
            return ExecuteUserQuery("SELECT * FROM Users WHERE (Username = @UsernameOrEmail OR Email = @UsernameOrEmail) AND Password = @Password", parameters);
        }
        public static User AddUser(string username, string email, string password, string role)
        {
            SqlParameter[] parameters = { new SqlParameter("@username", username),
                new SqlParameter("@email", email),
                new SqlParameter("@password", password),
                new SqlParameter("@role", role)};
            User user = ExecuteUserQuery("INSERT INTO Users (username, email, password, role) OUTPUT INSERTED.* VALUES (@username, @email, @password, @role);", parameters);

            if (user != null)
            {
                SessionManager.LoginUser(user.Id.ToString(), user.Username, role);
            }

            return user;
        }
        public static bool IsUsernameTaken(string username)
        {
            return IsFieldTaken("username", username);
        }
        public static bool IsEmailTaken(string email)
        {
            return IsFieldTaken("email", email);
        }
        private static bool IsFieldTaken(string field, string value)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM Users WHERE {field} = @{field}", conn))
                {
                    cmd.Parameters.AddWithValue($"@{field}", value);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private static void DeleteAllUsers()
        {
            ExecuteNonQuery("Delete from users",null);
        }
    }
    public static class ReadingLists
    {
        private static List<ReadingList> ExecuteReadingListQuery(string query, SqlParameter[] parameters = null)
        {
            List<ReadingList> readingLists = new List<ReadingList>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ReadingList readingList = new ReadingList(
                                    reader.GetInt32(reader.GetOrdinal("Id")),
                                    reader.GetInt32(reader.GetOrdinal("book_id")),
                                    reader.GetInt32(reader.GetOrdinal("user_id"))
                                );

                                readingLists.Add(readingList);
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                ErrorMessages.errorMessage = ex.Message;
            }

            return readingLists;
        }
        public static List<ReadingList> GetReadingLists(int userId)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@userId", userId) };
            return ExecuteReadingListQuery("SELECT * FROM ReadingList WHERE user_id = @userId", parameters);
        }
        public static void AddToReadingList(int bookId, int userId)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@bookId", bookId), new SqlParameter("@userId", userId) };
            ExecuteReadingListQuery("INSERT INTO ReadingList (book_id, user_id) VALUES (@bookId, @userId)", parameters);
        }
        public static void RemoveFromReadingList(int bookId, int userId)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@bookId", bookId), new SqlParameter("@userId", userId) };
            ExecuteReadingListQuery("DELETE FROM ReadingList WHERE book_id = @bookId AND user_id = @userId", parameters);
        }
        public static bool IsInReadingList(int bookId, int userId)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@bookId", bookId), new SqlParameter("@userId", userId) };
            var readingLists = ExecuteReadingListQuery("SELECT * FROM ReadingList WHERE book_id = @bookId AND user_id = @userId", parameters);

            return readingLists.Count > 0;
        }
    }
}