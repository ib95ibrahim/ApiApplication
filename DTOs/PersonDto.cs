using API.entities;

namespace API.DTOs;

public class PersonDto : Person
{
    public string Token { get; set; }
    public string Password { get; set; }
}