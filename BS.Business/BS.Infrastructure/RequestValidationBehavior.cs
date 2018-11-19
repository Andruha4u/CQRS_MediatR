using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using BS.Queries.Book.Get;

namespace BS.Infrastructure
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
    {
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is GetBookQuery && (request as GetBookQuery).Id < 0)
            {
                throw new Exception("Id could not be less then 0.");
            }

            return next();
        }
    }
}
