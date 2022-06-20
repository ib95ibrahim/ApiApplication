using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class ChefEquipeController : BaseApiController
{
    private readonly DataContext _context;
    public ChefEquipeController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet("all_chefs")]
    public async Task<ActionResult<IEnumerable<ChefEquipe>>> GetChefsEquipe()
    {
        return await _context.ChefEquipes.ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ChefEquipe>> GetOneChefEquipe(int id)
    {
        return await _context.ChefEquipes.FindAsync(id);;
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<IEnumerable<ChefEquipe>>> RemoveChefEquip(int id)
    {
        var chef = await _context.ChefEquipes.FindAsync(id);
          _context.ChefEquipes.Remove(chef);
        await  _context.SaveChangesAsync();
        return await GetChefsEquipe();

    }

    [HttpPost("add_chef")]
    public async Task<ActionResult<IEnumerable<ChefEquipe>>> AddChefEquipe(ChefEquipeDto chefEquipeDto)
    {
        using var hmac = new HMACSHA512();
        var chef = new ChefEquipe
        {
            EmployerType = chefEquipeDto.TypeEquipe,
            FirstName = chefEquipeDto.FirstName,
            LastName = chefEquipeDto.LastName,
            Email = chefEquipeDto.Email,
            Gender = chefEquipeDto.Gender,
            PhoneNumber = chefEquipeDto.PhoneNumber,
            UserName = chefEquipeDto.UserName,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(chefEquipeDto.Password)),
            PasswordSalt = hmac.Key
        };
        _context.ChefEquipes.Add(chef);
        await _context.SaveChangesAsync();
        return await GetChefsEquipe();
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<IEnumerable<ChefEquipe>>> UpdateChefEquipe(int id,ChefEquipeDto chefEquipeDto)
    {  
        var OldchefEquipe = await _context.ChefEquipes.FindAsync(id);
        
        OldchefEquipe!.TypeEquipe = chefEquipeDto.TypeEquipe;
        OldchefEquipe.FirstName = chefEquipeDto.FirstName;
        OldchefEquipe.LastName = chefEquipeDto.LastName;
        OldchefEquipe.Email = chefEquipeDto.Email;
        OldchefEquipe.Gender = chefEquipeDto.Gender;
        OldchefEquipe.PhoneNumber = chefEquipeDto.PhoneNumber;
        OldchefEquipe.UserName = chefEquipeDto.UserName;
        //pass?
        await _context.SaveChangesAsync();
        return await GetChefsEquipe();
    }
    
}