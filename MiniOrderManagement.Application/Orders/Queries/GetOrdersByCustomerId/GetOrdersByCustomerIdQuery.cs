using MediatR;

namespace MiniOrderManagement.Application.Orders.Queries.GetOrdersByCustomerId
{
    public record GetOrdersByCustomerIdQuery(int CustomerId)
        : IRequest<List<OrderDto>>;
}
