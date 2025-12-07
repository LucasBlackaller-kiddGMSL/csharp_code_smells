namespace MessageChains
{
    public class Customer
    {
        private readonly Address _address;

        public Customer(Address address)
        {
            _address = address;
        }

        public Address Address => _address;
    }
}