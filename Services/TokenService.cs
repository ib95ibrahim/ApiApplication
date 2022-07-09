using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.entities;
using API.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace API.Services;

public class TokenService : ITokenService
{
    private readonly UserManager<Person> _userManager;
    private readonly SymmetricSecurityKey _key;
    public TokenService(IConfiguration config ,UserManager<Person> userManager)
    {
        _userManager = userManager;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
    }
   public async Task<string> CreateToken(Person person)
   {
       var claims = new List<Claim>
       {
           new Claim(JwtRegisteredClaimNames.NameId, person.Id.ToString()),
           new Claim(JwtRegisteredClaimNames.UniqueName, person.UserName),
           //new Claim(JwtRegisteredClaimNames.Name, (person.FirstName +' '+ person.LastName).ToString()),  
           
       };
       var roles = await _userManager.GetRolesAsync(person);
       
       claims.AddRange(roles.Select(role=>new Claim(ClaimTypes.Role,role)));
       
      var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
          Subject = new ClaimsIdentity(claims),
          Expires = DateTime.Now.AddDays(5),
          SigningCredentials = cred

      };
      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
   }
   
}
