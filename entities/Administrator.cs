namespace API.entities
{
    public class Administrator : Person
    {
       
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<Rapport> rapports { get; set; }
    }
}
