using Arquitectura_BACKEND.BookStore.application.dtos.requests;
using Arquitectura_BACKEND.BookStore.application.dtos.responses;
using Arquitectura_BACKEND.BookStore.application.interfaces.services;
using Arquitectura_BACKEND.BookStore.domain.contracts;
using Arquitectura_BACKEND.BookStore.domain.entities;

namespace Arquitectura_BACKEND.BookStore.application.services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(
            IBookRepository bookRepository
        )
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<BookResponse>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();

            return books.Select(MapToResponse).ToList();
        }

        public async Task<BookResponse?> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
                return null;

            return MapToResponse(book);
        }

        public async Task CreateAsync(CreateBookRequest request)
        {
            var book = new Book(
                request.Title,
                request.Author,
                request.ISBN,
                request.Price,
                request.Stock
            );

            await _bookRepository.CreateAsync(book);
        }

        public async Task UpdateAsync(int id, UpdateBookRequest request)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
                throw new Exception("Book not found");

            book.Update(
                request.Title,
                request.Author,
                request.ISBN,
                request.Price,
                request.Stock
            );

            await _bookRepository.UpdateAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
                throw new Exception("Book not found");

            await _bookRepository.DeleteAsync(id);
        }

        public async Task<List<BookResponse>> GetTop3CheapestBooksAsync()
        {
            var books = await _bookRepository.GetTop3CheapestBooksAsync();

            return books.Select(MapToResponse).ToList();
        }

        private static BookResponse MapToResponse(Book book) => new BookResponse
        {
            BookId = book.BookId,
            Title = book.Title,
            Author = book.Author,
            ISBN = book.ISBN,
            Price = book.Price,
            Stock = book.Stock
        };
    }
}
