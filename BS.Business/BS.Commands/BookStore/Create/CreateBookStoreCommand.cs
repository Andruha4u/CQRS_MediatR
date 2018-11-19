using MediatR;

namespace BS.Commands.Store.Create
{
    public class CreateBookStoreCommand : IRequest<int>
    {
        public string BookStoreName { get; set; }
    }
}
