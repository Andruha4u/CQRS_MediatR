using MediatR;

namespace TO.Queries.Object.Get
{
    public class GetObjectItemQuery : IRequest<ObjectItemViewModel>
    {
        public int Id { get; set; }
    }
}
