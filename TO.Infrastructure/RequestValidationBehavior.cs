using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TO.Queries.Object.Get;

namespace TO.Infrastructure
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
    {
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is GetObjectItemQuery && (request as GetObjectItemQuery).Id < 0)
            {
                throw new Exception("Id could not be less then 0.");
            }

            return next();
        }
    }
}
