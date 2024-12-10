using MediatR;

namespace CThub.Application.Common.CQRS;

public interface IQueryHandler<TQuery, TResponse>: IRequestHandler<TQuery, TResponse>
where TQuery: IQuery<TResponse>
where TResponse: notnull
{
    
}