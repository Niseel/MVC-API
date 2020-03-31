using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please enter title"),MaxLength(30)]
        public string Title { get; set; }   
        public int Price { get; set; }
    }
}