using Arquitectura_BACKEND.BookStore.domain.contracts;
using Arquitectura_BACKEND.BookStore.domain.entities;
using Arquitectura_BACKEND.BookStore.infrastructure.Persistance.connection;
using Microsoft.Data.SqlClient;


namespace Arquitectura_BACKEND.BookStore.infrastructure.Persistance.repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly SqlServerConnection _connection;

        public BookRepository(
            SqlServerConnection connection
        )
        {
            _connection = connection;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            var books = new List<Book>();

            using var connection = _connection.CreateConnection();

            string query = @"
            SELECT
                Id,
                Title,
                Author,
                Price
            FROM Books";

            using var command = new SqlCommand(
                query,
                connection
            );

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var book = new Book(
                    reader["Title"].ToString()!,
                    reader["Author"].ToString()!,
                    Convert.ToDecimal(reader["Price"])
                );

                book.SetId(
                    Guid.Parse(reader["Id"].ToString()!)
                );

                books.Add(book);
            }

            return books;
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            using var connection = _connection.CreateConnection();

            string query = @"
            SELECT
                Id,
                Title,
                Author,
                Price
            FROM Books
            WHERE Id = @Id";

            using var command = new SqlCommand(
                query,
                connection
            );

            command.Parameters.AddWithValue("@Id", id);

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                var book = new Book(
                    reader["Title"].ToString()!,
                    reader["Author"].ToString()!,
                    Convert.ToDecimal(reader["Price"])
                );

                book.SetId(
                    Guid.Parse(reader["Id"].ToString()!)
                );

                return book;
            }

            return null;
        }

        public async Task CreateAsync(Book book)
        {
            using var connection = _connection.CreateConnection();

            string query = @"
            INSERT INTO Books
            (
                Id,
                Title,
                Author,
                Price
            )
            VALUES
            (
                @Id,
                @Title,
                @Author,
                @Price
            )";

            using var command = new SqlCommand(
                query,
                connection
            );

            command.Parameters.AddWithValue("@Id", book.Id);

            command.Parameters.AddWithValue(
                "@Title",
                book.Title
            );

            command.Parameters.AddWithValue(
                "@Author",
                book.Author
            );

            command.Parameters.AddWithValue(
                "@Price",
                book.Price
            );

            await connection.OpenAsync();

            await command.ExecuteNonQueryAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            using var connection = _connection.CreateConnection();

            string query = @"
            UPDATE Books
            SET
                Title = @Title,
                Author = @Author,
                Price = @Price
            WHERE Id = @Id";

            using var command = new SqlCommand(
                query,
                connection
            );

            command.Parameters.AddWithValue("@Id", book.Id);

            command.Parameters.AddWithValue(
                "@Title",
                book.Title
            );

            command.Parameters.AddWithValue(
                "@Author",
                book.Author
            );

            command.Parameters.AddWithValue(
                "@Price",
                book.Price
            );

            await connection.OpenAsync();

            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            using var connection = _connection.CreateConnection();

            string query = @"
            DELETE FROM Books
            WHERE Id = @Id";

            using var command = new SqlCommand(
                query,
                connection
            );

            command.Parameters.AddWithValue(
                "@Id",
                book.Id
            );

            await connection.OpenAsync();

            await command.ExecuteNonQueryAsync();
        }
    }
}
