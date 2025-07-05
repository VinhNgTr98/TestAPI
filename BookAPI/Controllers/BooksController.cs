using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookAPI.Data;
using BookAPI.Model;
using BookAPI.Services.Interfaces;
using BookAPI.DTOs;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize] // Yêu cầu có token hợp lệ
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/Books
        [HttpGet]
        [EnableQuery]
        public IQueryable<BookReadDTO> GetBooksAsync()
        {
           return _bookService.GetAllBooksAsync();
                     
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(Guid id, BookUpdateDTO book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            var success = await _bookService.UpdateBookAsync(book);
            if (!success) return NotFound();
            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookCreateDTO book)
        {
            var newBook = await _bookService.CreateBookAsync(book);

            return CreatedAtAction("GetBook", new { id = newBook.Id }, newBook);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
;
            await _bookService.DeleteBookAsync(id);

            return NoContent();
        }

    }
}
