using MediatR;
using MiniOrderManagement.Application.Interfaces;

namespace MiniOrderManagement.Application.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler
        : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomerByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerDto> Handle(
            GetCustomerByIdQuery request,
            CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers
                .GetCustomerWithProfileAndOrdersAsync(request.CustomerId);

            if (customer == null)
                throw new Exception("Customer not found");

            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Profile = new CustomerProfileDto
                {
                    Address = customer.Profile.Address,
                    PhoneNumber = customer.Profile.PhoneNumber
                },
                Orders = customer.Orders.Select(o => new OrderDto
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount
                }).ToList()
            };
        }
    }
}
