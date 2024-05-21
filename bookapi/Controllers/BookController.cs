using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using bookapi.Data;
using bookapi.Models.Domain;
using bookapi.Models.DTO;
using bookapi.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace bookapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IBookRepository _bookRepository;
        public BooksController(AppDbContext dbContext, IBookRepository bookRepository)
        {
            _dbContext = dbContext;
            _bookRepository = bookRepository;
        }
        [HttpGet("get-all-books")]
        public IActionResult GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
 [FromQuery] string? sortBy, [FromQuery] bool isAscending,
 [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100)
        {
            // su dung reposity pattern 
            var allBooks = _bookRepository.GetAllBooks(filterOn, filterQuery, sortBy,
           isAscending, pageNumber, pageSize);
            return Ok(allBooks);
        }
        [HttpGet]
        [Route("get-book-by-id/{id}")]
        public IActionResult GetBookById([FromRoute] int id)
        {
            var bookWithIdDTO = _bookRepository.GetBookById(id);
            return Ok(bookWithIdDTO);
        }
        [HttpPost("add - book")]
        public IActionResult AddBook([FromBody] AddBookRequestDTO addBookRequestDTO)
        {

            if (ModelState.IsValid)
            {
                var bookAdd = _bookRepository.AddBook(addBookRequestDTO);
                return Ok(bookAdd);
            }
            else return BadRequest(ModelState);
        }
        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] AddBookRequestDTO bookDTO)
        {
            var updateBook = _bookRepository.UpdateBookById(id, bookDTO);
            return Ok(updateBook);
        }
        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            var deleteBook = _bookRepository.DeleteBookById(id);
            return Ok(deleteBook);
        }
    }
}