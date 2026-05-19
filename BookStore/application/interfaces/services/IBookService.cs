using Arquitectura_BACKEND.BookStore.application.dtos.requests;
using Arquitectura_BACKEND.BookStore.application.dtos.responses;

namespace Arquitectura_BACKEND.BookStore.application.interfaces.services
{
    public interface IBookService
    {
        Task<List<BookResponse>> GetAllAsync();

        Task<BookResponse?> GetByIdAsync(Guid id);

        Task CreateAsync(CreateBookRequest request);

        Task UpdateAsync(
            Guid id,
            UpdateBookRequest request
        );

        Task DeleteAsync(Guid id);
    }
}
