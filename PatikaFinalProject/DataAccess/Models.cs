using System.Data.SqlTypes;

namespace PatikaFinalProject.DataAccess
{
    public class Director
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class Actor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class Movie
    {
        public int ID { get; set; }
        public string MovieName { get; set; }
        public string MovieType { get; set; }
        public DateTime MovieYear { get; set; }
        public int DirectorID { get; set; }
        public int Price { get; set; }
    }

    public class MovieType
    {
        //enum MovieTypes { Comedy = 1, Horror, Action};
        public int ID { get; set; }
        public string Type { get; set; }
    }


    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public int MovieID { get; set; }
        public int DirectorID { get; set; }
        public int Price { get; set; }
    }

    public class ActorMovie
    {
        public int ActorID { get; set; }
        public int MovieID { get; set; }
    }

    public class CustomerFavType
    {
        public int CustomerID { get; set; }
        public int FavMovieTypeID { get; set; }
    }
}
