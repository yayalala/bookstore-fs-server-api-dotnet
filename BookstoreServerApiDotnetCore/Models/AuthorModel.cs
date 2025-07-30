namespace BookstoreServerApiDotnetCore.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public IList<BookModel>? Books { get; set; }
    }
}
