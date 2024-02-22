using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TLN_JoelMovies.Models
{
    public class Movie
    {
        [Key]
        public int movieID { get; set; }

        [ForeignKey("CategoryID")]
        public int? CategoryID { get; set; }
        public Category? Category{ get; set; }
        [Required(ErrorMessage = "Sorry, you have to enter a title")]
        public string Title { get; set; }

        [Range(1888, 2100, ErrorMessage = "Sorry, you have to enter a year later than 1888")]
        public int Year { get; set; } = 1888;

        public string? Director { get; set; }

        public string? Rating { get; set; }

        public bool Edited { get; set; }

        public string? LentTo { get; set; }  // Not marked as required
        
        public bool CopiedToPlex { get; set; }
        public string? Notes { get; set; } // Not marked as required
    }

}
