using System.ComponentModel.DataAnnotations;

namespace TLN_JoelMovies.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
