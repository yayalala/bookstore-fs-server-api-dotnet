using BookstoreServerApiDotnetCore.Models;
using BookstoreServerApiDotnetCore.Rpositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreServerApiDotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet("")]
        //[Authorize]
        public async Task<IActionResult> GetAllBooks() 
        { 
            var res = await _booksRepository.GetAllBooksAsync();
            if (res?.Count > 0 )
            {
                return Ok(res);
            }
            return NotFound(); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var res = await _booksRepository.GetBookByIdAsync(id);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound($"No book with id {id} could be found ...");
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody] NewBookModel newBookModel)
        {
            var id = await _booksRepository.AddBookAsync(newBookModel);
            if (id == -1)
            {
                return BadRequest();
            }
            //return CreatedAtAction(nameof(GetBookById), new { id, controller = "books"}, newBookModel);
            return CreatedAtAction(nameof(GetBookById), new { id, controller = "books" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook( [FromRoute] int id, [FromBody] NewBookModel newBookModel )
        {
            var book = await _booksRepository.UpdateBookAsync(id, newBookModel);
            if ( book == null )
            {
                return BadRequest();
            }
            return Ok(book);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateByPatch([FromRoute] int id, [FromBody] JsonPatchDocument updatedBook)
        {
            var book = await _booksRepository.UpdatedByPatch(id, updatedBook);
            if ( book == null)
            {
                return BadRequest();
            }
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            var changes = await _booksRepository.DeleteById(id);
            if ( changes == -1 )
            {
                return BadRequest();
            }
            return Ok();
        }


    }
}
