using Arquitectura_BACKEND.BookStore.application.dtos.requests;
using Arquitectura_BACKEND.BookStore.application.dtos.responses;

namespace Arquitectura_BACKEND.BookStore.application.interfaces.services
{
    public interface IBookService
    {
        Task<List<BookResponse>> GetAllAsync();

        Task<BookResponse?> GetByIdAsync(int id);

        Task CreateAsync(CreateBookRequest request);

        Task UpdateAsync(
            int id,
            UpdateBookRequest request
        );

        Task DeleteAsync(int id);

        Task<List<BookResponse>> GetTop3CheapestBooksAsync();
    }
}
