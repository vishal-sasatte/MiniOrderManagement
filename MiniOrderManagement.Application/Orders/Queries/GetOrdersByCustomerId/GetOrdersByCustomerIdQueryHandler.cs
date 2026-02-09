using MediatR;
using MiniOrderManagement.Application.Interfaces;

namespace MiniOrderManagement.Application.Orders.Queries.GetOrdersByCustomerId
{
    public class GetOrdersByCustomerIdQueryHandler
        : IRequestHandler<GetOrdersByCustomerIdQuery, List<OrderDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOrdersByCustomerIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<OrderDto>> Handle(
            GetOrdersByCustomerIdQuery request,
            CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.Orders
                .GetByCustomerIdAsync(request.CustomerId);

            return orders.Select(o => new OrderDto
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount
            }).ToList();
        }
    }
}
