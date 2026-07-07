using Grpc.Core;

namespace CatalogService.Services;

public class CatalogServiceImpl : Catalog.CatalogBase
{
    public override Task<GetItemReply> GetItem(GetItemRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GetItemReply
        {
            Id = request.Id,
            Name = "Sample Item",
            Price = 9.99
        });
    }
}
