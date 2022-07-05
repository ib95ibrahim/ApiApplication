using API.entities;

namespace API.DTOs;

public class RegisterEmployerDto: Person
{
    public string EmployerType { get; set; }
    public string TypeEquipe { get; set; }
    
    public string Password { get; set; }
    
}