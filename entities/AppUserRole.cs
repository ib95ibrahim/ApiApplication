using Microsoft.AspNetCore.Identity;

namespace API.entities;
public class AppUserRole : IdentityUserRole<int>
{
    public virtual int Id { get; set; }
    public Person Person { get; set; }
    public AppRole Role { get; set; }

}