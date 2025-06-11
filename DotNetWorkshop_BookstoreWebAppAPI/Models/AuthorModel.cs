namespace DotNetWorkshop_BookstoreWebAppAPI.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<BookModel>? Books { get; set; }
    }
}
