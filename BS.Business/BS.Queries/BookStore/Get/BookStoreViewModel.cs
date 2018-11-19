using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BS.Domain.Entities;

namespace BS.Queries.Store.Get
{
    public class BookStoreViewModel
    {
        public int BookStoreId { get; set; }

        public string BookStoreName { get; set; }

        public static Expression<Func<BookStore, BookStoreViewModel>> Projection
        {
            get
            {
                return p => new BookStoreViewModel
                {
                    BookStoreId = p.BookStoreId,
                    BookStoreName = p.BookStoreName
                };
            }
        }

        public static BookStoreViewModel Create(BookStore product)
        {
            return Projection.Compile().Invoke(product);
        }
    }
}
