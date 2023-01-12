using Microsoft.EntityFrameworkCore;
using BookProject.Models;

namespace BookProject.Context
{
    public class ApplicationDbContext: DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<BookModel> Books { get; set; }
    }
}
