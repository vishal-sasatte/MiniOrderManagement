using FluentAssertions;
using MiniOrderManagement.Application.Commands.CreateCustomer;
using MiniOrderManagement.Application.Commands.CreateCustomer;
using MiniOrderManagement.Application.Interfaces;
using MiniOrderManagement.Domain.Entities;
using Moq;
using Xunit;

public class CreateCustomerCommandTests
{
    [Fact]
    public async Task Handle_ValidCommand_ShouldCreateCustomer()
    {
        // Arrange
        var customerRepo = new Mock<ICustomerRepository>();
        var uow = new Mock<IUnitOfWork>();

        uow.Setup(x => x.Customers).Returns(customerRepo.Object);
        uow.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

        var handler = new CreateCustomerCommandHandler(uow.Object);

        var command = new CreateCustomerCommand
        {
            Name = "Ravi",
            Address = "Pune",
            PhoneNumber = "9876543210"
        };



        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.Should().BeGreaterThan(0);
        customerRepo.Verify(x => x.AddAsync(It.IsAny<Customer>()), Times.Once);
        uow.Verify(x => x.SaveChangesAsync(), Times.Once);
    }
}
