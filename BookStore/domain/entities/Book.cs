namespace Arquitectura_BACKEND.BookStore.domain.entities
{
    public class Book
    {
        public int BookId { get; private set; }

        public string Title { get; private set; }

        public string Author { get; private set; }

        public string ISBN { get; private set; }

        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public Book(
            string title,
            string author,
            string isbn,
            decimal price,
            int stock
        )
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Price = price;
            Stock = stock;
        }

        public void Update(
            string title,
            string author,
            string isbn,
            decimal price,
            int stock
        )
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Price = price;
            Stock = stock;
        }

        public void SetId(int bookId)
        {
            BookId = bookId;
        }
    }
}
