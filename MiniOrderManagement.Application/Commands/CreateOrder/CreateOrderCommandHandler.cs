using MediatR;
using MiniOrderManagement.Application.Interfaces;
using MiniOrderManagement.Domain.Entities;

namespace MiniOrderManagement.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler
        : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(
            CreateOrderCommand request,
            CancellationToken cancellationToken)
        {
            // ✅ Business rule: Customer must exist
            var customer = await _unitOfWork.Customers
                .GetByIdAsync(request.CustomerId);
            


            if (customer == null)
                throw new Exception("Customer not found");

            var order = new Order(
            request.OrderDate,
            request.TotalAmount,
            request.CustomerId
);


            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            return order.Id;
        }
    }
}
