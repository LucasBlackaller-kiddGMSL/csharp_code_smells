namespace MovieRentals
{
    public class Rental
    {
        private readonly Movie _movie;

        public Rental(string imdbId, string member)
        {
            ImdbID = imdbId;
            Member = member;
            _movie = Pricer.Price(imdbId);
        }

        public string ImdbID { get; }
        public string Member { get; }
        public string Title => _movie.Title;
        public double Price => _movie.Price;
    }
}