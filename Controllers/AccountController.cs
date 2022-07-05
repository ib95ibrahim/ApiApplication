using API.DTOs;
using API.entities;
using API.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController : BaseApiController
{
    private readonly UserManager<Person> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly SignInManager<Person> _signInManager;
    private readonly ITokenService _tokenService;

    public AccountController(UserManager<Person> userManager, RoleManager<AppRole> roleManager,
        SignInManager<Person> signInManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    
    [HttpPost("register")]
    public async Task<ActionResult<PersonDto>> Register(RegisterDto registerDto)
    {
        if (await CheckUsername(registerDto.UserName))
        {
            return BadRequest("Username already exists");
        }
        
        var person = new Person
        {
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            Gender = registerDto.Gender,
            UserName = registerDto.UserName,
        };
        /*
         
           {"userName": "emm1",
            "firstName": "string",
            "lastName": "string",
            "gender": "string" }
            
        */
        await _userManager.CreateAsync(person, "App123@");
        
        await _userManager.AddToRoleAsync(person, "ChefEquipe");
        

       // return Ok("Registration Successful !");
        return new PersonDto
        {
            UserName = person.UserName,
            Token = await _tokenService.CreateToken(person)
        };

    }

    [HttpPost("login")]
    public async Task<ActionResult<PersonDto>> Login(LoginDto loginDto)
    {
        var person = await _userManager.Users.SingleOrDefaultAsync(person => person.UserName == loginDto.Username);

        if (person == null) return Unauthorized("Invalid username ! ");

        var result = await _signInManager.CheckPasswordSignInAsync(person, loginDto.Password, false);

        if (!result.Succeeded) return Unauthorized("Invalid password !");

        return new PersonDto
        {
            UserName = person.UserName,
            Token = await _tokenService.CreateToken(person)
        };

    }

    private async Task<bool> CheckUsername(string username)
    {
        return await _userManager.Users.AnyAsync(p => p.UserName == username.ToLower());
    }
}