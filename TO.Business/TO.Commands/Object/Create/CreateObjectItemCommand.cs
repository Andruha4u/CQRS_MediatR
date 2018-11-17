using MediatR;

namespace TO.Commands.Object.Create
{
    public class CreateObjectItemCommand : IRequest<int>
    {
        public string ObjectItemName { get; set; }

        public int? InterfaceId { get; set; }
}
}
