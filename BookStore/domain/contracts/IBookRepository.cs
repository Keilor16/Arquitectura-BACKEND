using Arquitectura_BACKEND.BookStore.domain.entities;

namespace Arquitectura_BACKEND.BookStore.domain.contracts
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();

        Task<Book?> GetByIdAsync(int id);

        Task CreateAsync(Book book);

        Task UpdateAsync(Book book);

        Task DeleteAsync(int id);

        Task<List<Book>> GetTop3CheapestBooksAsync();
    }
}
