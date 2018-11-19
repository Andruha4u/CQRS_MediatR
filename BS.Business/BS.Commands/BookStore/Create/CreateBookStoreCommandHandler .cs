using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BS.Domain.Entities;
using BS.Persistence;

namespace BS.Commands.Store.Create
{
    public class CreateInterfaceCommandHandler : IRequestHandler<CreateBookStoreCommand, int>
    {
        private readonly BSDBContext _context;

        public CreateInterfaceCommandHandler(BSDBContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBookStoreCommand request, CancellationToken cancellationToken)
        {
            var bookStore = new BookStore
            {
                BookStoreName = request.BookStoreName
            };

            _context.Add(bookStore);

            await _context.SaveChangesAsync(cancellationToken);

            return bookStore.BookStoreId;
        }
    }
}
