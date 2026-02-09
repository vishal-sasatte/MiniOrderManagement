namespace MiniOrderManagement.Domain.Entities
{
    public class CustomerProfile
    {
        protected CustomerProfile() { }

        public CustomerProfile(string address, string phoneNumber)
        {
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public int Id { get; private set; }

        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }

        
        public int CustomerId { get; private set; }
        public Customer Customer { get; private set; }
    }
}
