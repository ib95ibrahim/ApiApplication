namespace API.entities
{
    public class Activity
    {
        public int Id { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDate { get; set; }
        public string ActivityType { get; set; }
        public string ActivityPlace { get; set; }
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
        
        public List<Immigrant> Immigrants { get; set; }

    }
}
