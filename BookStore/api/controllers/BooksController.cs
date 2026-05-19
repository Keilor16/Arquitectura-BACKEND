using Arquitectura_BACKEND.BookStore.application.dtos.requests;
using Arquitectura_BACKEND.BookStore.application.interfaces.services;
using Microsoft.AspNetCore.Mvc;

namespace Arquitectura_BACKEND.BookStore.api.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllAsync();

            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookRequest request)
        {
            await _bookService.CreateAsync(request);

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateBookRequest request)
        {
            await _bookService.UpdateAsync(id, request);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("cheapest")]
        public async Task<IActionResult> GetTop3Cheapest()
        {
            var books = await _bookService.GetTop3CheapestBooksAsync();

            return Ok(books);
        }
    }
}
