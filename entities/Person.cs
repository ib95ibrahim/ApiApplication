using Microsoft.AspNetCore.Identity;

namespace API.entities
{
    public class Person : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
