namespace MiniOrderManagement.Application.Customers.Queries.GetCustomerById
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public CustomerProfileDto Profile { get; set; } = null!;
        public List<OrderDto> Orders { get; set; } = new();
    }

    public class CustomerProfileDto
    {
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }

    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
