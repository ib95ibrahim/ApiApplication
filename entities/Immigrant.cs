namespace API.entities
{
    public class Immigrant : Person
    {
        public new int Id { get; set; }
        public string Nationality { get; set; }
        public string BirthDate { get; set; }
        public string Vulnerability { get; set; }
        public List<Service> Services { get; set; }
        public Location Location { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
