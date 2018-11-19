using MediatR;

namespace BS.Queries.Book.Get
{
    public class GetBookQuery : IRequest<BookViewModel>
    {
        public int Id { get; set; }
    }
}
