﻿namespace DotNetWorkshop_BookstoreWebAppAPI.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AuthorModel Author { get; set; }
    }
}
