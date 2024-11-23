public static class Db
{
    public class Book
    {

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public string Author { get; private set; }
        public string Genre { get; private set; }
        public decimal Price { get; private set; }
        public int Pages { get; private set; }
        public Book(int id, string name, string description, string image, string author, string genre, decimal price, int pages)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            Author = author;
            Genre = genre;
            Price = price;
            Pages = pages;
        }
    }
    public class User
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public User(int id, string username, string email, string password, string role)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
            Role = role;
        }
    }
    public class ReadingList
    {
        public int Id { get; private set; }
        public int BookId { get; private set; }
        public int UserId { get; private set; }
        public ReadingList(int id, int bookId, int userId)
        {
            Id = id;
            BookId = bookId;
            UserId = userId;
        }
    }
}
