using System.ComponentModel.DataAnnotations;

namespace BookstoreServerApiDotnetCore.Models
{
    public class NewBookModel
    {
        [Required(ErrorMessage = "Please add a title")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Please add book details")]
        public required string Details { get; set; }

        [Required(ErrorMessage = "Please add author id")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Please add a price")]
        [Range(0, double.MaxValue, ErrorMessage = "Price can't be negative")]
        public required decimal Price { get; set; }
    }
}
