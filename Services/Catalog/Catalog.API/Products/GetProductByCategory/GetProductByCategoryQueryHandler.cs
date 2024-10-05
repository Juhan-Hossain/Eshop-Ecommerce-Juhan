using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string catogory) : IQuery<GetProductByCategoryResult>;
public record GetProductByCategoryResult(IEnumerable<Product> products);
internal class GetProductByCategoryQueryHandler
    (IDocumentSession session, ILogger<GetProductByCategoryQueryHandler> logger)
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation($"GetProductByCategoryQueryHandler is called by {query}");
        var products = await session.Query<Product>()
            .Where(p => p.Category.Contains(query.catogory))
            .ToListAsync(cancellationToken);
        return new GetProductByCategoryResult(products);
    }
}

