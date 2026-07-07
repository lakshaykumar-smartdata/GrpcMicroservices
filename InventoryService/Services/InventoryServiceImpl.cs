using Grpc.Core;

namespace InventoryService.Services;

public class InventoryServiceImpl : Inventory.InventoryBase
{
    public override Task<CheckStockReply> CheckStock(CheckStockRequest request, ServerCallContext context)
    {
        return Task.FromResult(new CheckStockReply
        {
            InStock = 100
        });
    }
}
