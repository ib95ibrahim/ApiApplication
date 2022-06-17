namespace API.entities
{
    public class Assistant : Employer
    {
        public new int Id { get; set; }
        public ChefEquipe ChefEquipe { get; set; }
        
    }
}
