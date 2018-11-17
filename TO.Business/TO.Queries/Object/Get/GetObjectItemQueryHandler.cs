using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TO.Domain.Entities;
using TO.Persistence;
using TO.Queries.Object.Exceptions;

namespace TO.Queries.Object.Get
{
    public class GetObjectItemQueryHandler : MediatR.IRequestHandler<GetObjectItemQuery, ObjectItemViewModel>
    {
        private readonly TODBContext _context;

        public GetObjectItemQueryHandler(TODBContext context)
        {
            _context = context;
        }

        public async Task<ObjectItemViewModel> Handle(GetObjectItemQuery request, CancellationToken cancellationToken)
        {
            var objectItem = await _context.ObjectItems
                .Where(p => p.ObjectItemId == request.Id)
                .Select(ObjectItemViewModel.Projection)
                .SingleOrDefaultAsync(cancellationToken);

            if (objectItem == null)
            {
                throw new NotFoundException(nameof(ObjectItem), request.Id);
            }

            objectItem.EditEnabled = true;

            return objectItem;
        }
    }
}
