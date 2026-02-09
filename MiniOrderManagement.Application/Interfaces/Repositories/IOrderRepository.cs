using MiniOrderManagement.Domain.Entities;

namespace MiniOrderManagement.Application.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<IReadOnlyList<Order>> GetByCustomerIdAsync(int customerId);
        Task AddAsync(Order order);
    }
}
