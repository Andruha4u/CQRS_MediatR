using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BS.Persistence;

using BookItem = BS.Domain.Entities.Book;

namespace BS.Commands.Book.Create
{
    public class CreateObjectItemCommandHandler: IRequestHandler<CreateBookCommand, int>
    {
        private readonly BSDBContext _context;

        public CreateObjectItemCommandHandler(BSDBContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var objectItem = new BookItem
            {
                BookStoreId = request.BookStoreId,
                BookName = request.BookName
            };

            _context.Add(objectItem);

            await _context.SaveChangesAsync(cancellationToken);

            return objectItem.BookId;
        }
    }
}
