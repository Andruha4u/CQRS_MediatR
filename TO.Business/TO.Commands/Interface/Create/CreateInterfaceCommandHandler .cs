using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TO.Persistence;

using InterfaceItem = TO.Domain.Entities.Interface;

namespace TO.Commands.Interface.Create
{
    public class CreateInterfaceCommandHandler : IRequestHandler<CreateInterfaceCommand, int>
    {
        private readonly TODBContext _context;

        public CreateInterfaceCommandHandler(TODBContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateInterfaceCommand request, CancellationToken cancellationToken)
        {
            var interfaceItem = new InterfaceItem
            {
                InterfaceName = request.InterfaceName
            };

            _context.Add(interfaceItem);

            await _context.SaveChangesAsync(cancellationToken);

            return interfaceItem.InterfaceId;
        }
    }
}
