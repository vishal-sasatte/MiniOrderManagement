using FluentAssertions;
using MiniOrderManagement.Application.Commands;
using MiniOrderManagement.Application.Interfaces;
using MiniOrderManagement.Application.Interfaces.Repositories;
using MiniOrderManagement.Application.Orders.Commands.CreateOrder;
using MiniOrderManagement.Domain.Entities;
using Moq;
using Xunit;

namespace MiniOrderManagement.Tests.Orders;

public class CreateOrderCommandTests
{
    [Fact]
    public async Task Handle_ValidCommand_ShouldCreateOrder()
    {
        // Arrange
        var orderRepo = new Mock<IOrderRepository>();
        var customerRepo = new Mock<ICustomerRepository>();
        var uow = new Mock<IUnitOfWork>();

        customerRepo
            .Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync(new Customer("Ravi"));

        uow.Setup(x => x.Orders).Returns(orderRepo.Object);
        uow.Setup(x => x.Customers).Returns(customerRepo.Object);
        uow.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

        var handler = new CreateOrderCommandHandler(uow.Object);

        var command = new CreateOrderCommand
        {
            CustomerId = 1,
            OrderDate = DateTime.Today,
            TotalAmount = 1500
        };

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.Should().BeGreaterThan(0);
        orderRepo.Verify(x => x.AddAsync(It.IsAny<Order>()), Times.Once);
        uow.Verify(x => x.SaveChangesAsync(), Times.Once);
    }
}

