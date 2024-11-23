## Online Book Inventory System

This project is a web-based book inventory management system that allows users to browse, search, and manage books online. It also includes an admin section for adding, updating, and deleting books.  This project was developed for educational purposes, demonstrating the practical application of web development skills using ASP.NET, C#, SQL Server, HTML, CSS, JavaScript, and Bootstrap.

**Features:**

* **User-friendly Interface:** Browse featured books, view details, search, and manage a personal reading list.
* **Admin Panel:** Secure access for administrators to manage the book inventory (add, update, delete).
* **Search Functionality:** Dynamic search results displayed on the same page without reloading.
* **User Authentication:** Secure login and signup with role-based authorization.
* **Database Integration:**  Utilizes SQL Server to store and retrieve book data, user information, and reading lists.
* **Responsive Design:** Adapts to different screen sizes for optimal viewing on various devices.

**Technologies Used:**

* ASP.NET with C#
* SQL Server
* HTML, CSS, JavaScript
* Bootstrap
* jQuery
* Visual Studio


**Project Structure:**

The project is structured with a master page (`site.master`) for consistent layout and navigation, and individual ASPX pages for different functionalities. A `DatabaseAccess` class handles database interactions, and a `SessionManager` class manages user sessions.  Key files include:

* `Default.aspx`: Homepage displaying featured books.
* `BookDetails.aspx`: Page displaying detailed information about a specific book.
* `SearchResults.aspx`: Handles search queries and returns results.
* `ReadingList.aspx`: Displays and manages the user's reading list.
* `Admin.aspx`:  Admin panel for managing books.
* `AddBook.aspx`: Page for adding new books.
* `EditBook.aspx`: Page for editing existing books.
* `DeleteBook.aspx`: Page for deleting books.
* `Login.aspx`: Login page for user authentication.
* `Signup.aspx`: Signup page for new users.
* `DatabaseAccess.cs`: Class for database interactions.
* `SessionManager.cs`: Class for managing user sessions.


**Setup and Installation:**

1. Clone the repository.
2. Open the project in Visual Studio.
3. Configure the database connection string in `Web.config`.
4. Build and run the project.



**Future Enhancements:**

* Implement encryption and input validation for enhanced security.
* Add features like book ratings, reviews, recommendations, and online payment options.
* Conduct user testing and gather feedback to improve UI/UX design.


**References:**

1. The website linke: [Home Page (bsite.net)](https://abubakralsheikh.bsite.net/) 
2. [Online Book Inventory System - Figma](https://www.figma.com/file/5IXMWyanmnBxRyuHpdCLds/Online-Book-Inventory-System?type=design&node-id=0-1&mode=design&t=xd56drJbEn6ViNyb-0)
3. How to Upload Your Asp.Net Project For Free At [FreeAspHosting | Tutorial4You](https://www.youtube.com/watch?v=R75QbUD5XLI)