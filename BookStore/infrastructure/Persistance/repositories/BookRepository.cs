using System.Data;
using Arquitectura_BACKEND.BookStore.domain.contracts;
using Arquitectura_BACKEND.BookStore.domain.entities;
using Arquitectura_BACKEND.BookStore.infrastructure.Persistance.connection;
using Microsoft.Data.SqlClient;

namespace Arquitectura_BACKEND.BookStore.infrastructure.Persistance.repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly SqlServerConnection _connection;

        public BookRepository(SqlServerConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            var books = new List<Book>();

            using var connection = _connection.CreateConnection();
            using var command = new SqlCommand("SP_GetAllBooks", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                books.Add(MapReader(reader));
            }

            return books;
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            using var connection = _connection.CreateConnection();
            using var command = new SqlCommand("SP_GetBookById", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@BookId", id);

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return MapReader(reader);

            return null;
        }

        public async Task CreateAsync(Book book)
        {
            using var connection = _connection.CreateConnection();
            using var command = new SqlCommand("SP_CreateBook", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@Title", book.Title);
            command.Parameters.AddWithValue("@Author", book.Author);
            command.Parameters.AddWithValue("@ISBN", book.ISBN);
            command.Parameters.AddWithValue("@Price", book.Price);
            command.Parameters.AddWithValue("@Stock", book.Stock);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            using var connection = _connection.CreateConnection();
            using var command = new SqlCommand("SP_UpdateBook", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@BookId", book.BookId);
            command.Parameters.AddWithValue("@Title", book.Title);
            command.Parameters.AddWithValue("@Author", book.Author);
            command.Parameters.AddWithValue("@ISBN", book.ISBN);
            command.Parameters.AddWithValue("@Price", book.Price);
            command.Parameters.AddWithValue("@Stock", book.Stock);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _connection.CreateConnection();
            using var command = new SqlCommand("SP_DeleteBook", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@BookId", id);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<Book>> GetTop3CheapestBooksAsync()
        {
            var books = new List<Book>();

            using var connection = _connection.CreateConnection();
            using var command = new SqlCommand("SP_GetTop3CheapestBooks", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                books.Add(MapReader(reader));
            }

            return books;
        }

        private static Book MapReader(SqlDataReader reader)
        {
            var book = new Book(
                reader["Title"].ToString()!,
                reader["Author"].ToString()!,
                reader["ISBN"].ToString()!,
                Convert.ToDecimal(reader["Price"]),
                Convert.ToInt32(reader["Stock"])
            );

            book.SetId(Convert.ToInt32(reader["BookId"]));

            return book;
        }
    }
}
