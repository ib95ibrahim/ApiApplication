namespace API.entities
{
    public class ChefEquipe : Employer
    {
        public new int Id { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Assistant> Assistants { get; set; }
    }
}
