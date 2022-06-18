using System.Data;
using System.Reflection.Metadata;

namespace API.entities;

public class AppUser {
    public int Id { get; set; }
    public string UserName { get; set; } 
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}