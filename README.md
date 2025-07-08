Step-by-Step Guide: Setting up your BooksMVC Application
Follow these steps carefully in Visual Studio to create and run your application.

1. Create a New ASP.NET Core Web Application
Open Visual Studio.

Click on "Create a new project".

In the "Create a new project" window, search for "ASP.NET Core Web App (Model-View-Controller)" (for C#) and click Next.

Configure your new project:

Project name: BooksMVC

Location: Choose a suitable location on your disk.

Solution name: BooksMVC (by default, it will be the same as the project name)

Click Next.

In the "Additional information" window:

Framework: Choose a recent .NET version (e.g., .NET 8.0 or .NET 7.0).

Authentication type: None (for this example).

Configure for HTTPS: Checked (recommended).

Enable Docker: Unchecked.

Use controllers (uncheck to use minimal APIs): Make sure this is checked.

Click Create.

2. Install NuGet Packages
Once the project is created, you need to install the necessary NuGet packages for Entity Framework Core and MySQL.

In Solution Explorer, right-click on your BooksMVC project.

Select "Manage NuGet Packages...".

Go to the "Browse" tab.

Search for and install the following packages:

Microsoft.EntityFrameworkCore.Design

Microsoft.EntityFrameworkCore.Tools

Pomelo.EntityFrameworkCore.MySql (This is the MySQL provider for EF Core)

For each package:

Select it from the search results.

Click Install.

Accept any license agreements.

3. Configure MySQL Database and Connection String
Before proceeding, ensure you have a MySQL server running (e.g., using XAMPP, WAMP, Docker, or a standalone MySQL installation).

Create a Database:

Open your MySQL client (e.g., MySQL Workbench, phpMyAdmin, or command line).

Execute the following SQL command to create a new database:

CREATE DATABASE BooksDB;

Note down your MySQL server details: server address (e.g., localhost), port (e.g., 3306), username (e.g., root), and password (if any).

Update appsettings.json:

In Solution Explorer, open the appsettings.json file in your BooksMVC project.

Add your MySQL connection string. Replace your_password with your actual MySQL root password (or the password for the user you're using).

(The content for appsettings.json will be provided in a separate code immersive.)

4. Create the BookModel
This model will represent your tbl_books table in the database and include validation rules.

In Solution Explorer, right-click on the Models folder in your BooksMVC project.

Select "Add" > "Class...".

Name the class BookModel.cs and click Add.

(The content for BookModel.cs will be provided in a separate code immersive.)

5. Create the ApplicationDbContext
This class will be the bridge between your application and the MySQL database using Entity Framework Core.

In Solution Explorer, right-click on your BooksMVC project (or create a new folder named Data for better organization).

Select "Add" > "Class...".

Name the class ApplicationDbContext.cs and click Add.

(The content for ApplicationDbContext.cs will be provided in a separate code immersive.)

6. Register DbContext in Program.cs
You need to tell your application how to use the ApplicationDbContext and where to find the connection string.

In Solution Explorer, open the Program.cs file.

Add the necessary using statements and the AddDbContext configuration.

(The updated content for Program.cs will be provided in a separate code immersive.)

7. Use Entity Framework Migrations
Migrations allow you to create and update your database schema based on your models.

Open Package Manager Console in Visual Studio: Go to Tools > NuGet Package Manager > Package Manager Console.

Ensure the "Default project" dropdown is set to BooksMVC.

Run the following commands in the Package Manager Console:

Add a migration: This command creates a new migration file that describes the changes to be applied to the database (in this case, creating the tbl_books table).

Add-Migration InitialCreate

(You can name InitialCreate anything descriptive, like CreateBooksTable.)

Update the database: This command applies the pending migrations to your MySQL database, creating the BooksDB database (if it doesn't exist) and the tbl_books table.

Update-Database

Verify in your MySQL client that BooksDB and tbl_books (with BookID, BookName, BookAuthor, BookPrice columns) have been created.

8. Create the BookController
This controller will handle the logic for adding and showing books.

In Solution Explorer, right-click on the Controllers folder in your BooksMVC project.

Select "Add" > "Controller...".

Choose "MVC Controller - Empty" and click Add.

Name the controller BookController.cs and click Add.

(The content for BookController.cs will be provided in a separate code immersive.)

9. Create the Views
Now, let's create the views for Index, AddBook, and ShowBooks.

Create Book Folder for Views:

In Solution Explorer, right-click on the Views folder.

Select "Add" > "New Folder".

Name the folder Book (this name must match your controller name, BookController, without the "Controller" suffix).

Create Index.cshtml:

Right-click on the newly created Views/Book folder.

Select "Add" > "View" > "Razor View - Empty".

Name it Index.cshtml and click Add.

(The content for Index.cshtml will be provided in a separate code immersive.)

Create AddBook.cshtml:

Right-click on the Views/Book folder.

Select "Add" > "View" > "Razor View - Empty".

Name it AddBook.cshtml and click Add.

(The content for AddBook.cshtml will be provided in a separate code immersive.)

Create ShowBooks.cshtml:

Right-click on the Views/Book folder.

Select "Add" > "View" > "Razor View - Empty".

Name it ShowBooks.cshtml and click Add.

(The content for ShowBooks.cshtml will be provided in a separate code immersive.)

10. Run the Application
Press F5 or click the "IIS Express" (or whatever server is configured) button in the Visual Studio toolbar to run your application.

Your browser should open to https://localhost:port/.

Navigate to https://localhost:port/Book (replace port with the actual port number, usually 7xxx or 5xxx). This will take you to the Index action of the BookController.

From there, you can use the links to "Add Book" and "Show Books".

Now, let's provide the code for each file.
