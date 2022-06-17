namespace API.entities
{
    public class Service
    {
        public int Id { get; set; }
        public string NameService { get; set; }
        public List<Rapport> rapports { get; set; }
        public List<Employer> Employers { get; set; }
        public List<Immigrant> Immigrants { get; set; }
    }
}
