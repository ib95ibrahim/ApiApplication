using API.DTOs;
using API.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

    public class UsersController : BaseApiController
    {
        private readonly UserManager<Person> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UsersController(UserManager<Person> userManager , RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager; 
        }

        [Authorize(Roles = "Assistant")]
        [HttpGet]
        public async Task<List<Person>> GetUsers()
        {
            return await _userManager.Users.ToListAsync();
        }
        
        
        [HttpPost("add_user")]
        public async Task<ActionResult<IEnumerable<Person>>> AddUser(RegisterDto registerDto)
        {
          
            var user = new Person
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Gender = registerDto.Gender,
                UserName = registerDto.UserName,
                SecurityStamp = Guid.NewGuid().ToString()
            };
          //  await _userManager.AddToRoleAsync(user, "ChefEquipe");
            await _userManager.CreateAsync(user , registerDto.Password);
            return Ok("done");
        }
        
    }