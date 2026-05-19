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

            return books.Select(book => new BookResponse
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price
            }).ToList();
        }

        public async Task<BookResponse?> GetByIdAsync(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
                return null;

            return new BookResponse
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price
            };
        }

        public async Task CreateAsync(
            CreateBookRequest request
        )
        {
            var book = new Book(
                request.Title,
                request.Author,
                request.Price
            );

            await _bookRepository.CreateAsync(book);
        }

        public async Task UpdateAsync(
            Guid id,
            UpdateBookRequest request
        )
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
                throw new Exception("Book not found");

            book.Update(
                request.Title,
                request.Author,
                request.Price
            );

            await _bookRepository.UpdateAsync(book);
        }

        public async Task DeleteAsync(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
                throw new Exception("Book not found");

            await _bookRepository.DeleteAsync(book);
        }
    }
}
