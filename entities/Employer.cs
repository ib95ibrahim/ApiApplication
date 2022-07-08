namespace API.entities
{
    public class Employer : Person
    {
        public string EmployerType { get; set; }
        public string TypeEquipe { get; set; }
        
        public List<Activity> Activities { get; set; }
       
    }
}
