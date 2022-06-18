using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class EmployerController : BaseApiController
{
    private readonly DataContext _context;
    public EmployerController(DataContext context)
    {
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
    public async Task<ActionResult<Employer>> AddEmployer(RegisterEmployerDto registerEmployerDto)
    {
        using var hmac = new HMACSHA512();
        var employe = new Employer
        {
           EmployerType = registerEmployerDto.EmployerType,
           FirstName = registerEmployerDto.FirstName,
           LastName = registerEmployerDto.LastName,
           Email = registerEmployerDto.Email,
           Gender = registerEmployerDto.Gender,
           TypeEquipe = registerEmployerDto.TypeEquipe,
           PhoneNumber = registerEmployerDto.PhoneNumber,
           UserName = registerEmployerDto.UserName,
           PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerEmployerDto.Password)),
           PasswordSalt = hmac.Key

        };
          _context.Employers.Add(employe);
          await _context.SaveChangesAsync();
          return Ok("Done, employer added ! ");
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<IEnumerable<Employer>>> GetOneEmployer(int id,RegisterEmployerDto employer)
    {  
        var OldEmployer = await _context.Employers.FindAsync(id);
        
        OldEmployer.EmployerType = employer.EmployerType!;
        OldEmployer.TypeEquipe = employer.TypeEquipe;
        OldEmployer.FirstName = employer.FirstName;
        OldEmployer.LastName = employer.LastName;
        OldEmployer.Email = employer.Email;
        OldEmployer.Gender = employer.Gender;
        OldEmployer.PhoneNumber = employer.PhoneNumber;
        OldEmployer.UserName = employer.UserName;
        //pass?
        
        await _context.SaveChangesAsync();
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
}