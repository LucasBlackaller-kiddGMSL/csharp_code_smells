namespace MessageChains
{
    public class Country
    {
        private readonly bool _inEurope = false;

        public Country(bool inEurope)
        {
            _inEurope = inEurope;
        }

        public bool IsInEurope
        {
            get { return _inEurope; }
        }
    }
}