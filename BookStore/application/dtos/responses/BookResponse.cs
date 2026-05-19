namespace Arquitectura_BACKEND.BookStore.application.dtos.responses
{
    public class BookResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}
