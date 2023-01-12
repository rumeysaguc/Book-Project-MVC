using System.ComponentModel.DataAnnotations;

namespace BookProject.Models
{
    public class BookModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

    }
}
