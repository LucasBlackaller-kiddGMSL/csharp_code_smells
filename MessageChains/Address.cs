namespace MessageChains
{
    public class Address
    {
        private readonly Country _country;

        public Address(Country country)
        {
            _country = country;
        }

        public Country Country
        {
            get { return _country; }
        }
    }
}