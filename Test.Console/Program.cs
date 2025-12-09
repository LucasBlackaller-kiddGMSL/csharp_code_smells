using MovieRentals;

namespace Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string imdbID = args[0];
            string member = args[1];
            Rental rental = new Rental(imdbID, member);
            System.Console.WriteLine("imdb ID: " + rental.ImdbID + ", member: " + rental.Member + ", title: " 
                                     + rental.Title + ", price: " + rental.Price);
        }
    }
}