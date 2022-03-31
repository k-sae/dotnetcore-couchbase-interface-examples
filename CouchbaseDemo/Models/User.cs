using System.Collections.Generic;

namespace CouchbaseDemo.Models
{

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Address
    {
        public string type { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }

    public class CreditCard
    {
        public string type { get; set; }
        public string number { get; set; }
        public string expiration { get; set; }
    }

    public class User : IUser, IModel
    {
        public string driving_licence { get; set; }
        public string passport { get; set; }
        public string preferred_email { get; set; }
        public string preferred_phone { get; set; }
        public string preferred_airline { get; set; }
        public string preferred_airport { get; set; }
        public List<CreditCard> credit_cards { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public string name { get; set; }
        public List<Address> addresses { get; set; }
        public int id { get; set; }
    }

    interface IUser
    {
        public string name { get; set; }
        public List<Address> addresses { get; set; }
    }
}