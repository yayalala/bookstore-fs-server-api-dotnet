using DotNetWorkshop_BookstoreWebAppAPI.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace DotNetWorkshop_BookstoreWebAppAPI.Rpositories
{
    public interface IBooksRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByIdAsync(int bookId);
        Task<int> AddBookAsync(NewBookModel newBookModel);
        Task<BookModel> UpdateBookAsync(int bookId, NewBookModel updatedModel);
        Task<BookModel> UpdatedByPatch(int bookId, JsonPatchDocument updatedBook);
        Task<int> DeleteById(int bookId);
    }
}