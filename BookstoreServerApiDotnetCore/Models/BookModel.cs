namespace BookstoreServerApiDotnetCore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required AuthorModel Author { get; set; }
        public string Details { get; set; }
        public required decimal Price { get; set; }
        public decimal DiscountPercentage { get; set; }
        public string ImageUrl { get; set; }
    }
}
