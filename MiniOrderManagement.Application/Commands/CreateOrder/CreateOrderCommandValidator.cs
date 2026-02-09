using FluentValidation;

namespace MiniOrderManagement.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator
        : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThan(0);

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0)
                .WithMessage("Total amount must be greater than zero");

            RuleFor(x => x.OrderDate)
                .NotEmpty();
        }
    }
}
