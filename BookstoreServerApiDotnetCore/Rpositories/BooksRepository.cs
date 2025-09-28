using BookstoreServerApiDotnetCore.Data;
using BookstoreServerApiDotnetCore.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace BookstoreServerApiDotnetCore.Rpositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookstoreContext _context;
        public BooksRepository(BookstoreContext context)
        {
            _context = context;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var books = await _context.Books.Include(b => b.Author).ToListAsync();
            return books;
        }

        // video 4 - minute 1:21:59 - exercise 01
        // write n apply function which returns one record by its unique identifier (Id)
        public async Task<BookModel?> GetBookByIdAsync(int bookId)
        {
            var book = await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b=> b.Id == bookId);
            return book;
        }

        public async Task<int> AddBookAsync(NewBookModel newBookModel)
        {
            var author = await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == newBookModel.AuthorId);
            if ( author == null )
            {
                return -1;
            }
            BookModel bookModel = new()
            {
                Title = newBookModel.Title,
                Details = newBookModel.Details,
                Price = newBookModel.Price,
                Author = author,
                ImageUrl = ""
            };
            author.Books.Add(bookModel);
            _context.Add(bookModel);
            await _context.SaveChangesAsync();
            return bookModel.Id;
        }

        /// <summary>
        /// Adds a batch of new books. Returns a list of created book IDs.
        /// If an author is not found for a book, that book is skipped.
        /// </summary>
        public async Task<List<int>> AddBooksBatchAsync(List<NewBookModel> newBooks)
        {
            var createdIds = new List<int>();
            var addedBooks = new List<BookModel>();
            foreach (var newBook in newBooks)
            {
                var author = await _context.Authors.Include(a => a.Books)
                    .FirstOrDefaultAsync(a => a.Id == newBook.AuthorId);

                if (author == null)
                    continue;

                var bookModel = new BookModel
                {
                    Title = newBook.Title,
                    Details = newBook.Details,
                    Price = newBook.Price,
                    Author = author,
                    ImageUrl = ""
                };
                author.Books.Add(bookModel);
                _context.Books.Add(bookModel);
                addedBooks.Add(bookModel);

            }
            await _context.SaveChangesAsync();
            createdIds.AddRange(addedBooks.Select(b => b.Id));
            return createdIds;
        }



        /*
                public async Task<BookModel> UpdateBookAsync(int bookId, BookModel updatedModel)
                {
                    updatedModel.Id = bookId;
                    _context.Books.Update(updatedModel);
                    await _context.SaveChangesAsync();
                    return updatedModel;
                }
        */

        public async Task<BookModel?> UpdateBookAsync(int bookId, NewBookModel updatedModel)
        {
            var book = await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == bookId); ;
            var author = await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == updatedModel.AuthorId);
            if (book != null && author != null)
            {
                int index = author.Books.IndexOf(book);
                book.Details = updatedModel.Details;
                book.Title = updatedModel.Title;
                if (index == -1)
                {
                    author.Books.Add(book);
                    book.Author = author;
                }
                await _context.SaveChangesAsync();
            }
            return book;
        }

        public async Task<BookModel?> UpdatedByPatch( int bookId, JsonPatchDocument updatedBook)
        {
            var book = await _context.Books.FindAsync(bookId);
            if ( book != null )
            {
                updatedBook.ApplyTo( book );
                await _context.SaveChangesAsync();
            }
            return book;
        }

        public async Task<int> DeleteById(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            if ( book != null )
            {
                _context.Books.Remove(book);
                return await _context.SaveChangesAsync();
            }
            return -1;
        }

    }
}
