namespace Arquitectura_BACKEND.BookStore.application.dtos.requests
{
    public class CreateBookRequest
    {
        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
