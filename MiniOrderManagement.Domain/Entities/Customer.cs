namespace MiniOrderManagement.Domain.Entities
{
    public class Customer
    {
        
        protected Customer() { }

        public Customer(string name)
        {
            Name = name;
            Orders = new List<Order>();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }

        
        public CustomerProfile Profile { get; private set; }

        
        public ICollection<Order> Orders { get; private set; }

        public void AddProfile(CustomerProfile profile)
        {
            Profile = profile;
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }
    }
}
