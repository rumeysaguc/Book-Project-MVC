using BookProject.Context;
using BookProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookProject.Controllers
{
    public class BookController : Controller
    {
		private readonly ApplicationDbContext context;
		public BookController(ApplicationDbContext context)
		{
			this.context = context;
		}
        public string Index()
        {
            return "swrfefer";
        }

        public async Task<ActionResult> BookList()
        {
			IQueryable<BookModel> books = from i in context.Books orderby i.Id select i;
			List<BookModel> result = await books.ToListAsync();
			
			//System.Data.SqlClient.SqlConnection sqlConnection1 =
			//new System.Data.SqlClient.SqlConnection("DefaultConnection");

			//System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
			//cmd.CommandType = System.Data.CommandType.Text;
			//cmd.CommandText = "INSERT Books (Id, Title, Description, Author, Publisher, PublishTime) VALUES (1, 'Dublörün Dilemması', 'TEST','Murat Menteş', 'April', '2010-01-01 12:00')";
			//cmd.Connection = sqlConnection1;

			//sqlConnection1.Open();
			//cmd.ExecuteNonQuery();
			//sqlConnection1.Close();
			return View(result);
        }
		[HttpPost]
		public IActionResult CreateBook(BookModel model)
		{
			context.Books.Add(model);
			context.SaveChanges();
			ViewBag.messages = "Create new Book!";
			return RedirectToAction("Index", "Home");
		}
		public int id;
		[HttpPost]
		public IActionResult DeleteBook()
		{
			
			try
			{
				if (Int32.TryParse(Request.Form["ID"], out id))
				{
					BookModel book = context.Books.Where(i => i.Id == id).First();
					context.Books.Remove(book);
					context.SaveChanges();
					TempData["SuccessMessage"] = "Deleted record!";
					return RedirectToAction("BookList", "Book");
				}
				else
				{
					TempData["MESSAGE"] = id;
					return RedirectToAction("Index", "Home");
				}


			}

			catch (Exception ex){
				TempData["MESSAGE"]=ex.Message ;
				return RedirectToAction("Index", "Home");
			}
		}
    }
}
