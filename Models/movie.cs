using System.ComponentModel.DataAnnotations;

namespace TLN_JoelMovies.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int movieID { get; set; }

        [Required]
        public string category { get; set; }
        public string? subcategory { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public int year { get; set; }

        [Required]
        public string director { get; set; }

        [Required]
        public string rating { get; set; }

        [Required]
        public bool edited { get; set; }

        public string? lent { get; set; }  // Not marked as required
        public string? notes { get; set; } // Not marked as required
    }

}
