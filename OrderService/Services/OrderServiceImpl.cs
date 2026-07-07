using Grpc.Core;

namespace OrderService.Services;

public class OrderServiceImpl : Order.OrderBase
{
    public override Task<PlaceOrderReply> PlaceOrder(PlaceOrderRequest request, ServerCallContext context)
    {
        return Task.FromResult(new PlaceOrderReply
        {
            Success = true,
            Message = $"Order placed for item {request.ItemId} with quantity {request.Quantity}"
        });
    }
}
