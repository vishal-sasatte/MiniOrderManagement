using MediatR;

namespace MiniOrderManagement.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
