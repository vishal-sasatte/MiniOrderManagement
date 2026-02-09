namespace MiniOrderManagement.Domain.Entities
{
    public class Order
    {
        protected Order() { }

        
        public Order(DateTime orderDate, decimal totalAmount, int customerId)
        {
            if (totalAmount <= 0)
                throw new ArgumentException("Order total must be greater than zero");

            OrderDate = orderDate;
            TotalAmount = totalAmount;
            CustomerId = customerId;
        }

        public int Id { get; private set; }

        public DateTime OrderDate { get; private set; }
        public decimal TotalAmount { get; private set; }

        
        public int CustomerId { get; private set; }
        public Customer Customer { get; private set; }
    }
}
