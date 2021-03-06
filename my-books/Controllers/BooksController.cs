using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        public BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }



        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookService.GetAllBooks();
            return Ok(allBooks);    
        }


        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            return Ok(book);
        }


        [HttpPost("add-book-with-authros")]
        public IActionResult AddBook([FromBody]BookVM book )
        {
            _bookService.AddBookWithAuthors(book);
            return Ok();
        }


        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody]BookVM book)
        {
            var updateBook = _bookService.UpdateBookById(id, book);

            return Ok(updateBook);
        }


        [HttpPut("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
           _bookService.DeleteBookById(id);

            return Ok();
        }



    }

}
