using API.entities;

namespace API.Interfaces;

    public interface ITokenService
    {
        String CreateToken(AppUser user);
    }