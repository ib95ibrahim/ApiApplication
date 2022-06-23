namespace API.entities
{
    public class ChefEquipe : Employer
    {
        public List<Activity> Activities { get; set; }
        public List<Assistant> Assistants { get; set; }
    }
}
