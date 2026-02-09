using MediatR;
using MiniOrderManagement.Application.Interfaces;
using MiniOrderManagement.Domain.Entities;

namespace MiniOrderManagement.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler
        : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(
            CreateCustomerCommand request,
            CancellationToken cancellationToken)
        {
            var customer = new Customer(request.Name);

            var profile = new CustomerProfile(
                request.Address,
                request.PhoneNumber
            );

            customer.AddProfile(profile);

            await _unitOfWork.Customers.AddAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            return customer.Id;
        }
    }
}
