using MediatR;

namespace TO.Commands.Interface.Create
{
    public class CreateInterfaceCommand : IRequest<int>
    {
        public string InterfaceName { get; set; }
    }
}
