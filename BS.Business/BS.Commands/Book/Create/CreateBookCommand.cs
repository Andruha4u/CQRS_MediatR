using MediatR;
using System.Collections.Generic;

namespace BS.Commands.Book.Create
{
    public class CreateBookCommand : IRequest<int>
    {
        public string BookName { get; set; }

        public int BookStoreId { get; set; }
    }
}
