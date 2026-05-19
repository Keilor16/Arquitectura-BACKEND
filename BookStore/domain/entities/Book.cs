namespace Arquitectura_BACKEND.BookStore.domain.entities
{
    public class Book
    {
        public Guid Id { get; private set; }

        public string Title { get; private set; }

        public string Author { get; private set; }

        public decimal Price { get; private set; }

        public Book(
            string title,
            string author,
            decimal price
        )
        {
            Id = Guid.NewGuid();

            Title = title;

            Author = author;

            Price = price;
        }

        public void Update(
            string title,
            string author,
            decimal price
        )
        {
            Title = title;

            Author = author;

            Price = price;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
