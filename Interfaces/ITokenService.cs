using API.entities;

namespace API.Interfaces;

    public interface ITokenService
    {
        Task<string> CreateToken(Person person);
    }