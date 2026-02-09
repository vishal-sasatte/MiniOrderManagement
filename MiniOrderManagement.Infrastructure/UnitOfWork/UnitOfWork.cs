using MiniOrderManagement.Application.Interfaces;
using MiniOrderManagement.Application.Interfaces.Repositories;
using MiniOrderManagement.Infrastructure.Data;
using MiniOrderManagement.Infrastructure.Repositories;

namespace MiniOrderManagement.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Customers = new CustomerRepository(_context);
            Orders = new OrderRepository(_context);
        }

        public ICustomerRepository Customers { get; }
        public IOrderRepository Orders { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
