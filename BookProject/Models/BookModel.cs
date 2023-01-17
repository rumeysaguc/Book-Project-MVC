using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookProject.Models
{
    public class BookModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
		public string Publisher { get; set; } = string.Empty;
        [Precision(16, 1)]
		public decimal? Price { get; set; }
		public DateTime PublishTime { get; set; }

    }
}
