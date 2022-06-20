using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AdministratorController : BaseApiController
    {
        private readonly DataContext _context;
        

        public AdministratorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("All_Administrator")]
        public async Task<ActionResult<IEnumerable<Administrator>>> GetAllAdministrators()
        {
            return await _context.Administrators.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Administrator>> GetAdministratorById(int id)
        {
            return await _context.Administrators.FindAsync(id);
        }

        [HttpPost("Add_Administrator")]
        public async Task<ActionResult<AdministratorDto>> AddAdministrator(AdministratorDto administratorDto)
        {
            using var hmac = new HMACSHA512();
            var administrator = new Administrator
            {
                FirstName= administratorDto.FirstName,
                LastName= administratorDto.LastName,
                Email= administratorDto.Email,
                Gender= administratorDto.Gender,
                PhoneNumber= administratorDto.PhoneNumber,
                UserName=administratorDto.Username,
                PasswordHash= hmac.ComputeHash(Encoding.UTF8.GetBytes(administratorDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Administrators.Add(administrator);
            await _context.SaveChangesAsync();

            return new AdministratorDto
            {
                Username = administrator.UserName
            };
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Administrator>> UpdateAdministrator(int id,AdministratorDto administratorDto)
        {
            var admin = await _context.Administrators.FindAsync(id);   

            admin.FirstName = administratorDto.FirstName;
            admin.LastName = administratorDto.LastName;
            admin.UserName = administratorDto.Username;
            admin.Gender = administratorDto.Gender;
            admin.PhoneNumber = administratorDto.PhoneNumber;

            await _context.SaveChangesAsync();
            return await GetAdministratorById(id);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<IEnumerable<Administrator>>> DeleteAdministrator(int id)
        {
            var admin = await _context.Administrators.FindAsync(id);

            _context.Administrators.Remove(admin);

            return await GetAllAdministrators();
        }

    }
}
