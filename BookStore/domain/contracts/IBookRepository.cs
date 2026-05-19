using Arquitectura_BACKEND.BookStore.domain.entities;

namespace Arquitectura_BACKEND.BookStore.domain.contracts
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();

        Task<Book?> GetByIdAsync(Guid id);

        Task CreateAsync(Book book);

        Task UpdateAsync(Book book);

        Task DeleteAsync(Book book);
    }
}
