﻿namespace Proto.Domain.QueryHandlers
{
    public interface IQueryHandler<TQuery, TResult> 
        where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}

