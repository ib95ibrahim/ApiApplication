namespace API.entities
{
    public class Rapport
    {
        public int Id { get; set; }
        public string DateRapport { get; set; }
        public int AdministratorId { get; set; }
        public Administrator Administrator { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
