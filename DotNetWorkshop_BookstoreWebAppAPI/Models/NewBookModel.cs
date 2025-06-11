using System.ComponentModel.DataAnnotations;

namespace DotNetWorkshop_BookstoreWebAppAPI.Models
{
    public class NewBookModel
    {
        [Required(ErrorMessage = "Please add a title")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Please add author id")]
        public int AuthorId { get; set; }
    }
}
