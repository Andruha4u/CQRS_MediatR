using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BS.Domain.Entities;

using BookItem = BS.Domain.Entities.Book;

namespace BS.Queries.Book.Get
{
    public class BookViewModel
    {
        public int BookId { get; set; }

        public string BookName { get; set; }

        public int BookStoreId { get; set; }

        public bool EditEnabled { get; set; }

        public ICollection<Author> Authors { get; private set; }

        public static Expression<Func<BookItem, BookViewModel>> Projection
        {
            get
            {
                return p => new BookViewModel
                {
                    Authors = p.Authors,
                    BookId = p.BookId,
                    BookName = p.BookName,
                    BookStoreId = p.BookStoreId
                };
            }
        }

        public static BookViewModel Create(BookItem product)
        {
            return Projection.Compile().Invoke(product);
        }
    }
}
