using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BS.Domain.Entities;
using BS.Persistence;
using BS.Queries.Object.Exceptions;

namespace BS.Queries.Store.Get
{
    public class GetBookQueryHandler : MediatR.IRequestHandler<GetBookStoreQuery, BookStoreViewModel>
    {
        private readonly BSDBContext _context;

        public GetBookQueryHandler(BSDBContext context)
        {
            _context = context;
        }

        public async Task<BookStoreViewModel> Handle(GetBookStoreQuery request, CancellationToken cancellationToken)
        {
            var bookStore = await _context.BookStores
                .Where(p => p.BookStoreId == request.Id)
                .Select(BookStoreViewModel.Projection)
                .SingleOrDefaultAsync(cancellationToken);

            if (bookStore == null)
            {
                throw new NotFoundException(nameof(BookStore), request.Id);
            }

            return bookStore;
        }
    }
}
