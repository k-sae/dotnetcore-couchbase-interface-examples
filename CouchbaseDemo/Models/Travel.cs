namespace CouchbaseDemo.Models
{

    public class Travel : ITravel
    {
        public string callsign { get; set; }
        public string country { get; set; }
        public string iata { get; set; }
        public string icao { get; set; }
        public string address { get; set; }
        public string type { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }

    interface ITravel : IModel
    {
        public string name { get; set; }
    }
}