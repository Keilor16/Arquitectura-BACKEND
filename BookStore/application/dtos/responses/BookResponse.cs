namespace Arquitectura_BACKEND.BookStore.application.dtos.responses
{
    public class BookResponse
    {
        public int BookId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
