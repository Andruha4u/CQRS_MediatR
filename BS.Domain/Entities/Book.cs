using System.Collections.Generic;

namespace BS.Domain.Entities
{
    public sealed class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
        }

        public int BookId { get; set; }

        public string BookName { get; set; }

        public int BookStoreId { get; set; }

        public ICollection<Author> Authors { get; private set; }

        public BookStore BookStore { get; set; }
    }
}
