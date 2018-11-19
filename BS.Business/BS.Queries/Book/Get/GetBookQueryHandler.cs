using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BS.Persistence;
using BS.Queries.Object.Exceptions;

namespace BS.Queries.Book.Get
{
    public class GetBookQueryHandler : MediatR.IRequestHandler<GetBookQuery, BookViewModel>
    {
        private readonly BSDBContext _context;

        public GetBookQueryHandler(BSDBContext context)
        {
            _context = context;
        }

        public async Task<BookViewModel> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books
                .Where(p => p.BookId == request.Id)
                .Select(BookViewModel.Projection)
                .SingleOrDefaultAsync(cancellationToken);

            if (book == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            book.EditEnabled = true;

            return book;
        }
    }
}
