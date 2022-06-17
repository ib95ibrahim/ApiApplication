namespace API.entities
{
    public class Location
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string LocationCity { get; set; }
        public List<Immigrant> Immigrants { get; set; }
    }
}
