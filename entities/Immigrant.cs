namespace API.entities
{
    public class Immigrant : Person
    {
        
        public string Nationality { get; set; }
        public string BirthDate { get; set; }
        public string Vulnerability { get; set; }
        public List<Service> Services { get; set; }

        public int locationId { get; set; }
        public Location Location { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
