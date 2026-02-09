namespace MiniOrderManagement.Application.Orders.Queries.GetOrdersByCustomerId
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
