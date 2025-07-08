using Microsoft.AspNetCore.Mvc;
using BooksMVC.Models; // Import your models namespace
using BooksMVC.Data;   // Import your DbContext namespace
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Required for async operations like ToListAsync()

namespace BooksMVC.Controllers
{
    public class BookController : Controller
    {
        // Private field to hold the database context.
        private readonly ApplicationDbContext _context;

        // Constructor for dependency injection.
        // The DbContext is injected by the ASP.NET Core DI container.
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Book/Index
        // This action displays the main page with links to Add Book and Show Books.
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Book/AddBook
        // This action displays the form for adding a new book.
        public IActionResult AddBook()
        {
            return View();
        }

        // POST: /Book/AddBook
        // This action handles the form submission for adding a new book.
        [HttpPost]
        [ValidateAntiForgeryToken] // Protects against Cross-Site Request Forgery attacks.
        public async Task<IActionResult> AddBook(BookModel book)
        {
            // Check if the submitted model is valid based on data annotations.
            if (ModelState.IsValid)
            {
                try
                {
                    // Add the new book to the DbSet.
                    _context.Books.Add(book);
                    // Save changes to the database. This will also populate the BookID
                    // property of the 'book' object with the auto-generated ID.
                    await _context.SaveChangesAsync();

                    // Set a success message and the auto-generated BookID in TempData.
                    // TempData is used to pass data between actions and is cleared after a single request.
                    TempData["SuccessMessage"] = "Book added successfully!";
                    TempData["BookId"] = book.BookID; // Display the auto-generated ID

                    // Redirect to the AddBook GET action to show the success message and clear the form.
                    return RedirectToAction(nameof(AddBook));
                }
                catch (Exception ex)
                {
                    // Log the exception (e.g., using ILogger) for debugging.
                    // For simplicity, we'll just add a model error here.
                    ModelState.AddModelError("", "An error occurred while saving the book: " + ex.Message);
                }
            }

            // If ModelState is not valid or an error occurred, return the view with the current model
            // to display validation errors.
            return View(book);
        }

        // GET: /Book/ShowBooks
        // This action retrieves all books from the database and displays them.
        public async Task<IActionResult> ShowBooks()
        {
            // Retrieve all books asynchronously from the database.
            var books = await _context.Books.ToListAsync();
            // Pass the list of books to the view.
            return View(books);
        }
    }
}
