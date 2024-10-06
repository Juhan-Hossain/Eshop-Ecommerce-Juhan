﻿using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace BuildingBlocks.Behaviors
{
    public class ValidationBehaviors<TRequest, TResponse>
        (IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = 
                await Task.WhenAll(validators.Select(x => x.ValidateAsync(context, cancellationToken)));
            var failurs = validationResults
                                .Where(x=>x.Errors.Any())
                                .SelectMany(x=>x.Errors)
                                .ToList();
            if (failurs.Any())
                throw new ValidationException(failurs);
            return await next();
        }
    }
}
