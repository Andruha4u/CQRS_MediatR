using MediatR;

namespace BS.Queries.Store.Get
{
    public class GetBookStoreQuery : IRequest<BookStoreViewModel>
    {
        public int Id { get; set; }
    }
}
