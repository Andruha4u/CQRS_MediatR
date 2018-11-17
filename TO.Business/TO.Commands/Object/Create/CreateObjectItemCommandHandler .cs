using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TO.Domain.Entities;
using TO.Persistence;

namespace TO.Commands.Object.Create
{
    public class CreateObjectItemCommandHandler: IRequestHandler<CreateObjectItemCommand, int>
    {
        private readonly TODBContext _context;

        public CreateObjectItemCommandHandler(TODBContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateObjectItemCommand request, CancellationToken cancellationToken)
        {
            var objectItem = new ObjectItem
            {
                InterfaceId = request.InterfaceId.Value,
                ObjectItemName = request.ObjectItemName
            };

            _context.Add(objectItem);

            await _context.SaveChangesAsync(cancellationToken);

            return objectItem.ObjectItemId;
        }
    }
}
