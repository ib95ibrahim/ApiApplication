using API.Data;
using API.DTOs;
using API.entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class EmployerController : BaseApiController
{
    private readonly UserManager<Person> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly DataContext _context;
    public EmployerController(DataContext context, UserManager<Person> userManager,RoleManager<AppRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }

    [HttpGet("all_employers")]
    public async Task<ActionResult<IEnumerable<Employer>>> GetEmployers()
    {
        return await _context.Employers.ToListAsync();
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Employer>> GetOneEmployer(int id)
    {
        return await _context.Employers.FindAsync(id);
    }
    
    
    [HttpPost("add_employer")]
    public async Task<ActionResult<IEnumerable<Employer>>> AddEmployer(RegisterEmployerDto registerEmployerDto)
    {
        if (await CheckUsername(registerEmployerDto.UserName))
        {
            return BadRequest("Username already exists");
        }

        var employee = new Employer
        {
           EmployerType = registerEmployerDto.EmployerType,
           FirstName = registerEmployerDto.FirstName,
           LastName = registerEmployerDto.LastName,
           Email = registerEmployerDto.Email,
           Gender = registerEmployerDto.Gender,
           TypeEquipe = registerEmployerDto.TypeEquipe,
           PhoneNumber = registerEmployerDto.PhoneNumber,
           UserName = registerEmployerDto.UserName,
           SecurityStamp = Guid.NewGuid().ToString()
        };
        
      //  await _context.Employers.AddAsync(employee);
        await _userManager.CreateAsync(employee, registerEmployerDto.Password);
        await _userManager.AddToRoleAsync(employee, employee.EmployerType);
        
        return Ok("Registration Successful !");
    }
    
    
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<IEnumerable<Employer>>> UpdateEmployer(int id,RegisterEmployerDto employer)
    {  
        var OldEmployer = await _context.Employers.FindAsync(id);

        var result = await _userManager.RemoveFromRoleAsync(OldEmployer, OldEmployer.EmployerType);
        
        if (!result.Succeeded) Console.WriteLine("makhdamaax");

        OldEmployer!.EmployerType = employer.EmployerType!;
        OldEmployer.TypeEquipe = employer.TypeEquipe;
        OldEmployer.FirstName = employer.FirstName;
        OldEmployer.LastName = employer.LastName;
        OldEmployer.Email = employer.Email;
        OldEmployer.Gender = employer.Gender;
        OldEmployer.PhoneNumber = employer.PhoneNumber;
        OldEmployer.UserName = employer.UserName;
        
        await _userManager.AddToRoleAsync(OldEmployer, employer.EmployerType);
        return await GetEmployers();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<IEnumerable<Employer>>> RemoveEmployer(int id)
    {
        var employe = await _context.Employers.FindAsync(id);
        
        _context.Employers.Remove(employe!);
        await _context.SaveChangesAsync();
        
        return await GetEmployers();
    }
    private async Task<bool> CheckUsername(string username)
    {
        return await _userManager.Users.AnyAsync(p => p.UserName == username.ToLower());
    }
}