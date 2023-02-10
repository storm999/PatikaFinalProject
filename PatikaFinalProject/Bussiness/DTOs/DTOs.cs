using System.Data.SqlTypes;

namespace PatikaFinalProject.DataAccess
{
    public class DirectorDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class DirectorCreateDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class ActorDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }    
    public class ActorCreateDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class MovieDTO
    {
        public int ID { get; set; }
        public string MovieName { get; set; }
        public string MovieType { get; set; }
        public DateTime MovieYear { get; set; }
        public int DirectorID { get; set; }
        public int Price { get; set; }
    }
    public class MovieCreateDTO
    {
        public int ID { get; set; }
        public string MovieName { get; set; }
        public string MovieType { get; set; }
        public DateTime MovieYear { get; set; }
        public int DirectorID { get; set; }
        public int Price { get; set; }
    }

    public class MovieTypeDTO
    {
        //enum MovieTypes { Comedy = 1, Horror, Action};
        public int ID { get; set; }
        public string Type { get; set; }
    }


    public class CustomerCreateDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class OrderDTO
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public int MovieID { get; set; }
        public int DirectorID { get; set; }
        public int Price { get; set; }
    }

    public class ActorMovieDTO
    {
        public int ActorID { get; set; }
        public int MovieID { get; set; }
    }

    public class CustomerFavTypeDTO
    {
        public int CustomerID { get; set; }
        public int FavMovieTypeID { get; set; }
    }
}
