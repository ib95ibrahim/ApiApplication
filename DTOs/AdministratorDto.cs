using API.entities;

namespace API.DTOs
{
    public class AdministratorDto : Person
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
